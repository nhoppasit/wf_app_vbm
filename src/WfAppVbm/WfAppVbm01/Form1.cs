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
            string installerPath = Path.Combine(Application.StartupPath, "Resources\\SQL2019-SSEI-Expr.exe");

            if (!File.Exists(installerPath))
            {
                MessageBox.Show("Installer file not found!");
                return;
            }

            // Start the installer process
            Process installer = new Process();
            installer.StartInfo.FileName = installerPath;
            installer.StartInfo.Arguments = "/Q"; // Quiet mode (no user interaction)
            installer.StartInfo.UseShellExecute = false;
            installer.StartInfo.RedirectStandardOutput = true;
            installer.StartInfo.RedirectStandardError = true;

            installer.OutputDataReceived += (s, ea) => AppendOutput(ea.Data);
            installer.ErrorDataReceived += (s, ea) => AppendOutput(ea.Data);

            installer.Start();
            installer.BeginOutputReadLine();
            installer.BeginErrorReadLine();

            installer.WaitForExit();

            MessageBox.Show("Installation process completed.");
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
