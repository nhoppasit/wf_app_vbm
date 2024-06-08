using System.Windows.Forms;

namespace WfAppVbm01.Pages.Main {
    public partial class FormWorkspace : Form {

        public ToolStrip ToolStrip {
            get {
                return toolStrip1 as ToolStrip;
            }
        }

        public FormWorkspace() {
            InitializeComponent();

            toolStrip1.Dock = DockStyle.None;
        }
    }
}
