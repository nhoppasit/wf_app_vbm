using System.Windows.Forms;

namespace WfAppVbm01.Pages.Main {
    public partial class MeasurementForm : Form {

        public ToolStrip ToolStrip {
            get {
                return toolStrip1 as ToolStrip;
            }
        }

        public MeasurementForm() {
            InitializeComponent();

            toolStrip1.Dock = DockStyle.None;
        }
    }
}
