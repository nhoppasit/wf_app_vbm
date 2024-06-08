namespace ZedGraph_Real_time_Simulation
{
    partial class Store
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
            this.panelControl = new System.Windows.Forms.Panel();
            this.panelZedPlot = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelZedPlot.SuspendLayout();
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
            this.zedGraphTest.Size = new System.Drawing.Size(800, 294);
            this.zedGraphTest.TabIndex = 0;
            this.zedGraphTest.UseExtendedPrintDialog = true;
            // 
            // panelControl
            // 
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(800, 294);
            this.panelControl.TabIndex = 1;
            // 
            // panelZedPlot
            // 
            this.panelZedPlot.Controls.Add(this.zedGraphTest);
            this.panelZedPlot.Controls.Add(this.panelControl);
            this.panelZedPlot.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelZedPlot.Location = new System.Drawing.Point(0, 0);
            this.panelZedPlot.Name = "panelZedPlot";
            this.panelZedPlot.Size = new System.Drawing.Size(800, 294);
            this.panelZedPlot.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(29, 384);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(198, 42);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(311, 384);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(198, 42);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(590, 384);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(198, 42);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Store
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panelZedPlot);
            this.Name = "Store";
            this.Text = "Store";
            this.panelZedPlot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphTest;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Panel panelZedPlot;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClear;
    }
}