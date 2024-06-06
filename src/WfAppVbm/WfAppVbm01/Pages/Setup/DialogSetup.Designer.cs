namespace WfAppVbm01.Pages.Setup
{
    partial class DialogSetup
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
            this.ButtonInstallSqlExpress = new System.Windows.Forms.Button();
            this.ButtonCreateNewDatabase = new System.Windows.Forms.Button();
            this.ButtonCheckAndChooseDbInstance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonInstallSqlExpress
            // 
            this.ButtonInstallSqlExpress.Location = new System.Drawing.Point(12, 12);
            this.ButtonInstallSqlExpress.Name = "ButtonInstallSqlExpress";
            this.ButtonInstallSqlExpress.Size = new System.Drawing.Size(114, 86);
            this.ButtonInstallSqlExpress.TabIndex = 0;
            this.ButtonInstallSqlExpress.Text = "Install SQL Express 2019";
            this.ButtonInstallSqlExpress.UseVisualStyleBackColor = true;
            this.ButtonInstallSqlExpress.Click += new System.EventHandler(this.ButtonInstallSqlExpress_Click);
            // 
            // ButtonCreateNewDatabase
            // 
            this.ButtonCreateNewDatabase.Location = new System.Drawing.Point(252, 12);
            this.ButtonCreateNewDatabase.Name = "ButtonCreateNewDatabase";
            this.ButtonCreateNewDatabase.Size = new System.Drawing.Size(114, 86);
            this.ButtonCreateNewDatabase.TabIndex = 1;
            this.ButtonCreateNewDatabase.Text = "Create new database";
            this.ButtonCreateNewDatabase.UseVisualStyleBackColor = true;
            this.ButtonCreateNewDatabase.Click += new System.EventHandler(this.ButtonCreateNewDatabase_Click);
            // 
            // ButtonCheckAndChooseDbInstance
            // 
            this.ButtonCheckAndChooseDbInstance.Location = new System.Drawing.Point(132, 12);
            this.ButtonCheckAndChooseDbInstance.Name = "ButtonCheckAndChooseDbInstance";
            this.ButtonCheckAndChooseDbInstance.Size = new System.Drawing.Size(114, 86);
            this.ButtonCheckAndChooseDbInstance.TabIndex = 2;
            this.ButtonCheckAndChooseDbInstance.Text = "Check and choose database instance";
            this.ButtonCheckAndChooseDbInstance.UseVisualStyleBackColor = true;
            this.ButtonCheckAndChooseDbInstance.Click += new System.EventHandler(this.ButtonCheckAndChooseDbInstance_Click);
            // 
            // DialogSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 117);
            this.Controls.Add(this.ButtonCheckAndChooseDbInstance);
            this.Controls.Add(this.ButtonCreateNewDatabase);
            this.Controls.Add(this.ButtonInstallSqlExpress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DialogSetup";
            this.Text = "Application Setup";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonInstallSqlExpress;
        private System.Windows.Forms.Button ButtonCreateNewDatabase;
        private System.Windows.Forms.Button ButtonCheckAndChooseDbInstance;
    }
}

