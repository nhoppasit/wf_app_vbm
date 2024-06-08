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
            this.panelControl = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelZedPlot.SuspendLayout();
            this.panelControl.SuspendLayout();
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
            this.zedGraphTest.Size = new System.Drawing.Size(1138, 430);
            this.zedGraphTest.TabIndex = 0;
            this.zedGraphTest.UseExtendedPrintDialog = true;
            // 
            // panelZedPlot
            // 
            this.panelZedPlot.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelZedPlot.Controls.Add(this.zedGraphTest);
            this.panelZedPlot.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelZedPlot.Location = new System.Drawing.Point(0, 0);
            this.panelZedPlot.Name = "panelZedPlot";
            this.panelZedPlot.Size = new System.Drawing.Size(1138, 430);
            this.panelZedPlot.TabIndex = 1;
            // 
            // panelControl
            // 
            this.panelControl.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelControl.Controls.Add(this.btnClear);
            this.panelControl.Controls.Add(this.btnStop);
            this.panelControl.Controls.Add(this.btnStart);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 430);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1138, 252);
            this.panelControl.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(728, 113);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(144, 47);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(963, 147);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(144, 47);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(963, 71);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(144, 47);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // TestZed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 682);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.panelZedPlot);
            this.Name = "TestZed";
            this.Text = "Form1";
            this.panelZedPlot.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelZedPlot;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        public ZedGraph.ZedGraphControl zedGraphTest;
    }
}

