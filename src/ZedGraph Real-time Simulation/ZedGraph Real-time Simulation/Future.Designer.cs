namespace ZedGraph_Real_time_Simulation
{
    partial class Future
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
            this.panelContol = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelZedPlot = new System.Windows.Forms.Panel();
            this.zedGraphPlot = new ZedGraph.ZedGraphControl();
            this.panelContol.SuspendLayout();
            this.panelZedPlot.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContol
            // 
            this.panelContol.Controls.Add(this.btnSubmit);
            this.panelContol.Controls.Add(this.btnClear);
            this.panelContol.Controls.Add(this.btnStop);
            this.panelContol.Controls.Add(this.btnStart);
            this.panelContol.Controls.Add(this.textBox1);
            this.panelContol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContol.Location = new System.Drawing.Point(0, 0);
            this.panelContol.Name = "panelContol";
            this.panelContol.Size = new System.Drawing.Size(965, 566);
            this.panelContol.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(256, 288);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(179, 42);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(751, 438);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(179, 42);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(291, 438);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(179, 42);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(49, 438);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(179, 42);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 298);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 22);
            this.textBox1.TabIndex = 0;
            // 
            // panelZedPlot
            // 
            this.panelZedPlot.Controls.Add(this.zedGraphPlot);
            this.panelZedPlot.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelZedPlot.Location = new System.Drawing.Point(0, 0);
            this.panelZedPlot.Name = "panelZedPlot";
            this.panelZedPlot.Size = new System.Drawing.Size(965, 384);
            this.panelZedPlot.TabIndex = 1;
            // 
            // zedGraphPlot
            // 
            this.zedGraphPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphPlot.Location = new System.Drawing.Point(0, 0);
            this.zedGraphPlot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphPlot.Name = "zedGraphPlot";
            this.zedGraphPlot.ScrollGrace = 0D;
            this.zedGraphPlot.ScrollMaxX = 0D;
            this.zedGraphPlot.ScrollMaxY = 0D;
            this.zedGraphPlot.ScrollMaxY2 = 0D;
            this.zedGraphPlot.ScrollMinX = 0D;
            this.zedGraphPlot.ScrollMinY = 0D;
            this.zedGraphPlot.ScrollMinY2 = 0D;
            this.zedGraphPlot.Size = new System.Drawing.Size(965, 384);
            this.zedGraphPlot.TabIndex = 0;
            this.zedGraphPlot.UseExtendedPrintDialog = true;
            // 
            // Future
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 566);
            this.Controls.Add(this.panelZedPlot);
            this.Controls.Add(this.panelContol);
            this.Name = "Future";
            this.Text = "Future";
            this.panelContol.ResumeLayout(false);
            this.panelContol.PerformLayout();
            this.panelZedPlot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContol;
        private System.Windows.Forms.Panel panelZedPlot;
        private ZedGraph.ZedGraphControl zedGraphPlot;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSubmit;
    }
}