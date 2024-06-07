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
    }
}
