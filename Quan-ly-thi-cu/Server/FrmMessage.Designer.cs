
namespace Server
{
    partial class FrmMessage
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
            this.txtMess = new System.Windows.Forms.TextBox();
            this.btnMess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMess
            // 
            this.txtMess.Location = new System.Drawing.Point(185, 118);
            this.txtMess.Multiline = true;
            this.txtMess.Name = "txtMess";
            this.txtMess.Size = new System.Drawing.Size(417, 83);
            this.txtMess.TabIndex = 0;
            // 
            // btnMess
            // 
            this.btnMess.Location = new System.Drawing.Point(275, 293);
            this.btnMess.Name = "btnMess";
            this.btnMess.Size = new System.Drawing.Size(226, 55);
            this.btnMess.TabIndex = 1;
            this.btnMess.Text = "Gửi tin nhắn";
            this.btnMess.UseVisualStyleBackColor = true;
            this.btnMess.Click += new System.EventHandler(this.btnMess_Click);
            // 
            // FrmMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMess);
            this.Controls.Add(this.txtMess);
            this.Name = "FrmMessage";
            this.Text = "FrmMessage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMess;
        private System.Windows.Forms.Button btnMess;
    }
}