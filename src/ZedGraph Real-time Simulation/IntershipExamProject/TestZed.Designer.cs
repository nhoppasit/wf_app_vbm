namespace IntershipExamProject
{
    partial class TestZed
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphTest = new ZedGraph.ZedGraphControl();
            this.panelZedPlot = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // zedGraphTest
            // 
            this.zedGraphTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphTest.Location = new System.Drawing.Point(0, 0);
            this.zedGraphTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphTest.Name = "zedGraphTest";
            this.zedGraphTest.ScrollGrace = 0D;
            this.zedGraphTest.ScrollMaxX = 0D;
            this.zedGraphTest.ScrollMaxY = 0D;
            this.zedGraphTest.ScrollMaxY2 = 0D;
            this.zedGraphTest.ScrollMinX = 0D;
            this.zedGraphTest.ScrollMinY = 0D;
            this.zedGraphTest.ScrollMinY2 = 0D;
            this.zedGraphTest.Size = new System.Drawing.Size(1138, 682);
            this.zedGraphTest.TabIndex = 0;
            this.zedGraphTest.UseExtendedPrintDialog = true;
            // 
            // panelZedPlot
            // 
            this.panelZedPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelZedPlot.Location = new System.Drawing.Point(0, 0);
            this.panelZedPlot.Name = "panelZedPlot";
            this.panelZedPlot.Size = new System.Drawing.Size(1138, 682);
            this.panelZedPlot.TabIndex = 1;
            // 
            // TestZed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 682);
            this.Controls.Add(this.zedGraphTest);
            this.Controls.Add(this.panelZedPlot);
            this.Name = "TestZed";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphTest;
        private System.Windows.Forms.Panel panelZedPlot;
    }
}

