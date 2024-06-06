﻿using Syncfusion.WinForms.Core.Utils;
using System;
using System.Data;
using System.Data.Sql;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfAppVbm01.Pages.Setup {
    public partial class DialogCheckSqlServerInstances : Form {
        readonly BusyIndicator busyIndicator;

        public DialogCheckSqlServerInstances() {
            InitializeComponent();

            ListViewDatabaseInstances.FullRowSelect = true;
            ListViewDatabaseInstances.GridLines = true;
            ListViewDatabaseInstances.MultiSelect = false;

            ListViewDatabaseInstances.ItemSelectionChanged += DatabaseInstancesListView_ItemSelectionChanged;

            busyIndicator = new BusyIndicator();
        }

        protected override async void OnLoad(EventArgs e) {
            base.OnLoad(e);
            await Task.Run(() => {
                ListViewItem item = new ListViewItem("1");
                item.SubItems.Add(Properties.Settings.Default.SelectedServerName);
                item.SubItems.Add(Properties.Settings.Default.SelectedInstanceName);
                item.SubItems.Add(Properties.Settings.Default.SelectedInstanceVersion);
                item.SubItems.Add("Yes");
                item.Selected = true;
                this.Invoke((MethodInvoker)delegate {
                    ListViewDatabaseInstances.Items.Clear();
                    ListViewDatabaseInstances.Items.Add(item);
                });
            });
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            bool anyItemSelected = ListViewDatabaseInstances.SelectedItems.Count > 0;
            bool anySelectedHasDefault = ListViewDatabaseInstances.SelectedItems.Cast<ListViewItem>().Any(item => item.SubItems[4].Text == "Yes");
            if (!anyItemSelected || !anySelectedHasDefault) {
                var result = MessageBox.Show("You are about to quit without selecting a default SQL Server instance. Are you sure you want to quit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) {
                    e.Cancel = true;
                }
            }
        }

        readonly int defaultColumnIndex = 4;
        private void DatabaseInstancesListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (e.IsSelected) {
                foreach (ListViewItem item in ListViewDatabaseInstances.Items) {
                    item.SubItems[defaultColumnIndex].Text = "";
                }
                e.Item.SubItems[defaultColumnIndex].Text = "Yes";
                Trace.WriteLine($"Selected SQL Server instance: {e.Item.Text}");
                Properties.Settings.Default.SelectedServerName = e.Item.SubItems[1].Text;
                Properties.Settings.Default.SelectedInstanceName = e.Item.SubItems[2].Text;
                Properties.Settings.Default.SelectedInstanceVersion = e.Item.SubItems[3].Text;
                Properties.Settings.Default.Save();
            }
        }

        private async void DiscoveringDatabaseInstancesButton_Click(object sender, EventArgs e) {
            DiscoveringDatabaseInstancesButton.Enabled = false;
            this.busyIndicator.Show(DiscoveringDatabaseInstancesButton);
            await Task.Run(() => DiscoveringDatabaseInstances());
            this.busyIndicator.Hide();
            DiscoveringDatabaseInstancesButton.Enabled = true;
        }

        void DiscoveringDatabaseInstances() {
            try {
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                DataTable dataTable = instance.GetDataSources();
                if (dataTable.Rows.Count == 0) {
                    var message = "No SQL Server instances found.";
                    Trace.WriteLine(message);
                    MessageBox.Show(message, "Discovering SQL Server Instances", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.Invoke((MethodInvoker)delegate {
                    int rowNo = 1;
                    this.ListViewDatabaseInstances.Items.Clear();
                    foreach (DataRow row in dataTable.Rows) {
                        string serverName = row["ServerName"].ToString();
                        string instanceName = row["InstanceName"].ToString();
                        string version = row["Version"].ToString();

                        Trace.WriteLine($"SQL Server instance found: {serverName}\\{instanceName} (Version: {version})");

                        // Add the instance information to the ListView
                        ListViewItem item = new ListViewItem(rowNo.ToString());
                        item.SubItems.Add(serverName);
                        item.SubItems.Add(instanceName);
                        item.SubItems.Add(version);
                        item.SubItems.Add(""); // Initialize Default column as empty
                        if (serverName == Properties.Settings.Default.SelectedServerName &&
                            instanceName == Properties.Settings.Default.SelectedInstanceName &&
                            version == Properties.Settings.Default.SelectedInstanceVersion) {
                            item.SubItems[defaultColumnIndex].Text = "Yes"; // Mark as default
                        }
                        ListViewDatabaseInstances.Items.Add(item);
                        rowNo++;
                    }
                });
            } catch (Exception ex) {
                Trace.WriteLine($"An error occurred: {ex.Message}");
                this.Invoke((MethodInvoker)delegate {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
        }
    }
}