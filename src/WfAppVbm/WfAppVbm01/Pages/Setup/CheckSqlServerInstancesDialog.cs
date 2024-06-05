using Syncfusion.WinForms.Core.Utils;
using System;
using System.Data;
using System.Data.Sql;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfAppVbm01.Pages.Setup {
    public partial class CheckSqlServerInstancesDialog : Form {
        BusyIndicator busyIndicator;

        public CheckSqlServerInstancesDialog() {
            InitializeComponent();

            ListViewDatabaseInstances.FullRowSelect = true;
            ListViewDatabaseInstances.GridLines = true;
            ListViewDatabaseInstances.MultiSelect = false;

            ListViewDatabaseInstances.ItemSelectionChanged += ListViewDatabaseInstances_ItemSelectionChanged;

            busyIndicator = new BusyIndicator();
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
        private void ListViewDatabaseInstances_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (e.IsSelected) {
                foreach (ListViewItem item in ListViewDatabaseInstances.Items) {
                    item.SubItems[defaultColumnIndex].Text = "";
                }
                e.Item.SubItems[defaultColumnIndex].Text = "Yes";
                Trace.WriteLine($"Selected SQL Server instance: {e.Item.Text}");
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
