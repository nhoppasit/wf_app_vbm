using System;
using System.Data;
using System.Data.Sql;
using System.Diagnostics;
using System.Windows.Forms;

namespace WfAppVbm01.Pages.Setup
{
    public partial class CheckSqlServerInstancesDialog : Form
    {
        public CheckSqlServerInstancesDialog()
        {
            InitializeComponent();
        }

        private void DiscoveringDatabaseInstancesButton_Click(object sender, EventArgs e)
        {
            DiscoveringDatabaseInstances();
        }

        void DiscoveringDatabaseInstances()
        {
            try
            {
                SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
                DataTable dataTable = instance.GetDataSources();
                if (dataTable.Rows.Count == 0)
                {
                    var message = "No SQL Server instances found.";
                    Trace.WriteLine(message);
                    MessageBox.Show(message, "Discovering SQL Server Instances", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (DataRow row in dataTable.Rows)
                {
                    string serverName = row["ServerName"].ToString();
                    string instanceName = row["InstanceName"].ToString();
                    string version = row["Version"].ToString();

                    Trace.WriteLine($"SQL Server instance found: {serverName}\\{instanceName} (Version: {version})");
                }
            } catch (Exception ex)
            {
                Trace.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
