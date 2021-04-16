namespace Server
{
    partial class UFrmClient
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.pbClient = new System.Windows.Forms.PictureBox();
            this.txtPCName = new System.Windows.Forms.TextBox();
            this.txtClientIP = new System.Windows.Forms.TextBox();
            this.tltInfo = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbClient)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStudentId
            // 
            this.txtStudentId.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentId.Location = new System.Drawing.Point(19, 90);
            this.txtStudentId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(84, 27);
            this.txtStudentId.TabIndex = 0;
            this.txtStudentId.Text = "1812756";
            this.txtStudentId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbClient
            // 
            this.pbClient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbClient.Location = new System.Drawing.Point(0, 4);
            this.pbClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbClient.Name = "pbClient";
            this.pbClient.Size = new System.Drawing.Size(128, 79);
            this.pbClient.TabIndex = 1;
            this.pbClient.TabStop = false;
            // 
            // txtPCName
            // 
            this.txtPCName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPCName.Location = new System.Drawing.Point(36, 26);
            this.txtPCName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPCName.Name = "txtPCName";
            this.txtPCName.Size = new System.Drawing.Size(57, 27);
            this.txtPCName.TabIndex = 2;
            this.txtPCName.Text = "PC301";
            this.txtPCName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtClientIP
            // 
            this.txtClientIP.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientIP.Location = new System.Drawing.Point(0, 126);
            this.txtClientIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtClientIP.Name = "txtClientIP";
            this.txtClientIP.Size = new System.Drawing.Size(127, 26);
            this.txtClientIP.TabIndex = 3;
            this.txtClientIP.Text = "1812756";
            this.txtClientIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tltInfo
            // 
            this.tltInfo.AutomaticDelay = 100;
            this.tltInfo.AutoPopDelay = 7000;
            this.tltInfo.InitialDelay = 100;
            this.tltInfo.ReshowDelay = 100;
            this.tltInfo.ShowAlways = true;
            // 
            // UFrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.txtClientIP);
            this.Controls.Add(this.txtPCName);
            this.Controls.Add(this.pbClient);
            this.Controls.Add(this.txtStudentId);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UFrmClient";
            this.Size = new System.Drawing.Size(128, 159);
            this.Load += new System.EventHandler(this.UFrmClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.PictureBox pbClient;
        private System.Windows.Forms.TextBox txtPCName;
        private System.Windows.Forms.TextBox txtClientIP;
		private System.Windows.Forms.ToolTip tltInfo;
	}
}
