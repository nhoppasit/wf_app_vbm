namespace WfAppVbm01.Pages.Setup
{
    partial class DialogCheckSqlServerInstances
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
            this.DiscoveringDatabaseInstancesButton = new System.Windows.Forms.Button();
            this.ListViewDatabaseInstances = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // DiscoveringDatabaseInstancesButton
            // 
            this.DiscoveringDatabaseInstancesButton.Location = new System.Drawing.Point(12, 12);
            this.DiscoveringDatabaseInstancesButton.Name = "DiscoveringDatabaseInstancesButton";
            this.DiscoveringDatabaseInstancesButton.Size = new System.Drawing.Size(202, 67);
            this.DiscoveringDatabaseInstancesButton.TabIndex = 0;
            this.DiscoveringDatabaseInstancesButton.Text = "Discover database instances";
            this.DiscoveringDatabaseInstancesButton.UseVisualStyleBackColor = true;
            this.DiscoveringDatabaseInstancesButton.Click += new System.EventHandler(this.DiscoveringDatabaseInstancesButton_Click);
            // 
            // ListViewDatabaseInstances
            // 
            this.ListViewDatabaseInstances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListViewDatabaseInstances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.ListViewDatabaseInstances.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListViewDatabaseInstances.HideSelection = false;
            this.ListViewDatabaseInstances.Location = new System.Drawing.Point(12, 85);
            this.ListViewDatabaseInstances.Name = "ListViewDatabaseInstances";
            this.ListViewDatabaseInstances.Size = new System.Drawing.Size(532, 151);
            this.ListViewDatabaseInstances.TabIndex = 3;
            this.ListViewDatabaseInstances.UseCompatibleStateImageBehavior = false;
            this.ListViewDatabaseInstances.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            this.columnHeader1.Width = 38;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Server Name";
            this.columnHeader2.Width = 122;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Instance Name";
            this.columnHeader3.Width = 139;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Version";
            this.columnHeader4.Width = 111;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Default";
            // 
            // DialogCheckSqlServerInstances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 248);
            this.Controls.Add(this.ListViewDatabaseInstances);
            this.Controls.Add(this.DiscoveringDatabaseInstancesButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DialogCheckSqlServerInstances";
            this.Text = "Check SQL Server Instances Dialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DiscoveringDatabaseInstancesButton;
        private System.Windows.Forms.ListView ListViewDatabaseInstances;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}