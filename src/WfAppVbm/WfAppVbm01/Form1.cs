using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WfAppVbm01
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnInstallSqlExpress_Click(object sender, EventArgs e)
        {
            if (!IsAdministrator())
            {
                // Restart program and run as admin
                var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName)
                {
                    UseShellExecute = true,
                    Verb = "runas"
                };
                try
                {
                    Process.Start(startInfo);
                } catch (Exception)
                {
                    MessageBox.Show("The operation requires elevated permissions.");
                }
                Application.Exit(); // Close the current instance
            } else
            {
                // Extract and run the installer
                string installerPath = Path.Combine(Application.StartupPath, "Resources\\SQL2019-SSEI-Expr.exe");
                // Assuming the file has been copied or downloaded to installerPath

                Process installer = new Process();
                installer.StartInfo.FileName = installerPath;
                // Remove or leave Arguments empty to run in interactive mode
                installer.StartInfo.Arguments = ""; // No quiet mode
                installer.StartInfo.UseShellExecute = true; // Use shell execute for interactive mode

                try
                {
                    installer.Start();
                    installer.WaitForExit();
                    MessageBox.Show("Installation process completed.");
                } catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private bool IsAdministrator()
        {
            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var principal = new System.Security.Principal.WindowsPrincipal(identity);
            return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        private void AppendOutput(string data)
        {
            if (!string.IsNullOrEmpty(data))
            {
                this.Invoke((MethodInvoker)delegate
                {
                    System.Diagnostics.Trace.WriteLine(data);
                    //txtOutput.AppendText(data + Environment.NewLine);
                });
            }
        }
    }
}
