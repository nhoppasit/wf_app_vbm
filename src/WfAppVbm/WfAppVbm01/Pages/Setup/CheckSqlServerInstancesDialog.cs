using Syncfusion.WinForms.Core.Utils;
using System;
using System.Data;
using System.Data.Sql;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfAppVbm01.Pages.Setup {
    public partial class CheckSqlServerInstancesDialog : Form {
        BusyIndicator busyIndicator;

        public CheckSqlServerInstancesDialog() {
            InitializeComponent();

            ListViewDatabaseInstances.FullRowSelect = true;
            ListViewDatabaseInstances.GridLines = true;

            ListViewDatabaseInstances.ItemSelectionChanged += ListViewDatabaseInstances_ItemSelectionChanged;

            busyIndicator = new BusyIndicator();
        }

        private void ListViewDatabaseInstances_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (e.IsSelected) {
                var defaultColumnIndex = 4;
                foreach (ListViewItem item in ListViewDatabaseInstances.Items) {
                    item.SubItems[defaultColumnIndex].Text = "";
                }
                e.Item.SubItems[defaultColumnIndex].Text = "Yes";
                Trace.WriteLine($"Selected SQL Server instance: {e.Item.Text}");
            }
        }

        private async void DiscoveringDatabaseInstancesButton_Click(object sender, EventArgs e) {
            this.busyIndicator.Show(DiscoveringDatabaseInstancesButton);
            await Task.Run(() => DiscoveringDatabaseInstances());
            this.busyIndicator.Hide();
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
                    this.listView.Items.Clear();
                    foreach (DataRow row in dataTable.Rows) {
                        string serverName = row["ServerName"].ToString();
                        string instanceName = row["InstanceName"].ToString();
                        string version = row["Version"].ToString();

                        Trace.WriteLine($"SQL Server instance found: {serverName}\\{instanceName} (Version: {version})");

                        // Add the instance information to the ListView
                        ListViewItem item = new ListViewItem(serverName);
                        item.SubItems.Add(instanceName);
                        item.SubItems.Add(version);
                        item.SubItems.Add(""); // Initialize Default column as empty
                        ListViewDatabaseInstances.Items.Add(item);
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
}
