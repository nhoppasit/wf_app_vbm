using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WfAppVbm01.Pages.Setup {
    public partial class DialogSetup : Form {
        public DialogSetup() {
            InitializeComponent();
        }

        private void btnInstallSqlExpress_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show(
                "Do you want to install SQL Server Express?",
                "Confirm Installation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result != DialogResult.Yes) {
                return;
            }
            result = MessageBox.Show(
               "The installation of SQL Server Express might take some time. " +
               "Please ensure you have sufficient time and do not interrupt the installation process. " +
               "Are you sure you want to proceed with the installation of SQL Server Express?",
               "Confirm Installation Again",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) {
                return;
            }
            if (!IsAdministrator()) {
                // Restart program and run as admin
                var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName) {
                    UseShellExecute = true,
                    Verb = "runas"
                };
                try {
                    Process.Start(startInfo);
                } catch (Exception) {
                    MessageBox.Show("The operation requires elevated permissions.");
                }
            } else {
                // Extract and run the installer
                string installerPath = Path.Combine(Application.StartupPath, "Resources\\SQL2019-SSEI-Expr.exe");
                // Assuming the file has been copied or downloaded to installerPath

                Process installer = new Process();
                installer.StartInfo.FileName = installerPath;
                // Remove or leave Arguments empty to run in interactive mode
                installer.StartInfo.Arguments = ""; // No quiet mode
                installer.StartInfo.UseShellExecute = true; // Use shell execute for interactive mode

                try {
                    installer.Start();
                    installer.WaitForExit();
                    MessageBox.Show("Installation process completed.");
                } catch (Exception ex) {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private bool IsAdministrator() {
            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        private void AppendOutput(string data) {
            if (!string.IsNullOrEmpty(data)) {
                this.Invoke((MethodInvoker)delegate {
                    System.Diagnostics.Trace.WriteLine(data);
                    //txtOutput.AppendText(data + Environment.NewLine);
                });
            }
        }

        private void btnCreateNewDatabase_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show(
                "Do you want to create a new database?",
                "Confirm Database Creation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result != DialogResult.Yes) {
                return;
            }

            // Second confirmation message box with additional warning
            result = MessageBox.Show(
                "Creating a new database will result in the loss of all existing data in the current database. " +
                "Are you sure you want to proceed with creating a new database?",
                "Confirm Database Creation Again",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) {
                return;
            }

            string scriptContent = Properties.Resources.db;
            string serverName = "localhost\\SQLEXPRESS02";
            string connectionString = $"Server={serverName};Integrated Security=true;";
            try {
                ExecuteSqlScript(connectionString, scriptContent);
                MessageBox.Show("Database created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteSqlScript(string connectionString, string scriptContent) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                string[] commandTexts = scriptContent.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string commandText in commandTexts) {
                    using (SqlCommand command = new SqlCommand(commandText, connection)) {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}
