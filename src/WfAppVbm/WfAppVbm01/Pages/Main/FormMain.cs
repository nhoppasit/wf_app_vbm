using System.Reflection;
using System.Windows.Forms;

namespace WfAppVbm01.Pages.Main {
    public partial class FormMain : Form {
        public FormMain() {
            InitializeComponent();
            this.Text = GetTitle();
        }

        string GetTitle() {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionText = $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            return $"Vibrograph Version {versionText}";
        }

        private void ShowWorkspace() {
            // Create an instance of FormWorkspace
            FormWorkspace formWorkspace = new FormWorkspace();
            formWorkspace.TopLevel = false;  // Make it a child form
            formWorkspace.FormBorderStyle = FormBorderStyle.None;  // Remove borders
            formWorkspace.Dock = DockStyle.Fill;  // Dock it to fill the parent

            // Add the FormWorkspace to the ToolStripContainer content panel
            ToolStripContainer container = toolStripContainer1;
            container.ContentPanel.Controls.Clear();  // Clear any previous content
            container.ContentPanel.Controls.Add(formWorkspace);
            formWorkspace.Show();
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e) {
            ShowWorkspace();
        }
    }
}
