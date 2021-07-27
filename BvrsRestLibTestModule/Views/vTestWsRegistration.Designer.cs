namespace BvrsRestLibTestModule
{
    partial class vTestWsRegistration
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
            this.bRegister = new System.Windows.Forms.Button();
            this.bsyncworkstation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bRegister
            // 
            this.bRegister.Location = new System.Drawing.Point(377, 471);
            this.bRegister.Name = "bRegister";
            this.bRegister.Size = new System.Drawing.Size(124, 51);
            this.bRegister.TabIndex = 0;
            this.bRegister.Text = "Register";
            this.bRegister.UseVisualStyleBackColor = true;
            this.bRegister.Click += new System.EventHandler(this.bRegister_Click);
            // 
            // bsyncworkstation
            // 
            this.bsyncworkstation.Location = new System.Drawing.Point(653, 383);
            this.bsyncworkstation.Name = "bsyncworkstation";
            this.bsyncworkstation.Size = new System.Drawing.Size(124, 51);
            this.bsyncworkstation.TabIndex = 1;
            this.bsyncworkstation.Text = "Sync Workstation";
            this.bsyncworkstation.UseVisualStyleBackColor = true;
            this.bsyncworkstation.Click += new System.EventHandler(this.button1_Click);
            // 
            // vTestWsRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 576);
            this.Controls.Add(this.bsyncworkstation);
            this.Controls.Add(this.bRegister);
            this.Name = "vTestWsRegistration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.vTestWsRegistration_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bRegister;
        private System.Windows.Forms.Button bsyncworkstation;
    }
}

