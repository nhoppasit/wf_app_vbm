namespace WfAppVbm01.Pages.Setup
{
    partial class SetupDialog
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
            this.btnInstallSqlExpress = new System.Windows.Forms.Button();
            this.btnCreateNewDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInstallSqlExpress
            // 
            this.btnInstallSqlExpress.Location = new System.Drawing.Point(12, 12);
            this.btnInstallSqlExpress.Name = "btnInstallSqlExpress";
            this.btnInstallSqlExpress.Size = new System.Drawing.Size(114, 86);
            this.btnInstallSqlExpress.TabIndex = 0;
            this.btnInstallSqlExpress.Text = "Install SQL Express 2019";
            this.btnInstallSqlExpress.UseVisualStyleBackColor = true;
            this.btnInstallSqlExpress.Click += new System.EventHandler(this.btnInstallSqlExpress_Click);
            // 
            // btnCreateNewDatabase
            // 
            this.btnCreateNewDatabase.Location = new System.Drawing.Point(132, 12);
            this.btnCreateNewDatabase.Name = "btnCreateNewDatabase";
            this.btnCreateNewDatabase.Size = new System.Drawing.Size(114, 86);
            this.btnCreateNewDatabase.TabIndex = 1;
            this.btnCreateNewDatabase.Text = "Create new database";
            this.btnCreateNewDatabase.UseVisualStyleBackColor = true;
            this.btnCreateNewDatabase.Click += new System.EventHandler(this.btnCreateNewDatabase_Click);
            // 
            // SetupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 227);
            this.Controls.Add(this.btnCreateNewDatabase);
            this.Controls.Add(this.btnInstallSqlExpress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SetupDialog";
            this.Text = "Application Setup";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInstallSqlExpress;
        private System.Windows.Forms.Button btnCreateNewDatabase;
    }
}

