namespace BvrsRestLibTestModule.Views
{
    partial class vMain
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
            this.bRegisterWs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bRegisterWs
            // 
            this.bRegisterWs.Location = new System.Drawing.Point(33, 38);
            this.bRegisterWs.Name = "bRegisterWs";
            this.bRegisterWs.Size = new System.Drawing.Size(105, 23);
            this.bRegisterWs.TabIndex = 1;
            this.bRegisterWs.Text = "Resgister WS";
            this.bRegisterWs.UseVisualStyleBackColor = true;
            this.bRegisterWs.Click += new System.EventHandler(this.bRegisterWs_Click);
            // 
            // vMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 576);
            this.Controls.Add(this.bRegisterWs);
            this.Name = "vMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "vMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bRegisterWs;
    }
}