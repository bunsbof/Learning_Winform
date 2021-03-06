namespace Server
{
    partial class Server
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnThuBai = new System.Windows.Forms.Button();
            this.cmdNhapVungIP = new System.Windows.Forms.Button();
            this.cmdKichHoatAllClient = new System.Windows.Forms.Button();
            this.btn_SendMessage = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.btnFile = new System.Windows.Forms.Button();
            this.btnDisconnectAll = new System.Windows.Forms.Button();
            this.cmdBatDauLamBai = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnChonClientPath = new System.Windows.Forms.Button();
            this.btnChonServerPath = new System.Windows.Forms.Button();
            this.txtClientPath = new System.Windows.Forms.TextBox();
            this.txtServerPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXoaDe = new System.Windows.Forms.Button();
            this.lsvDeThi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPhatDe = new System.Windows.Forms.Button();
            this.btnThemDe = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSetTime = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.btnLock);
            this.groupBox4.Controls.Add(this.btnThuBai);
            this.groupBox4.Controls.Add(this.cmdNhapVungIP);
            this.groupBox4.Controls.Add(this.cmdKichHoatAllClient);
            this.groupBox4.Controls.Add(this.btn_SendMessage);
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.btnFile);
            this.groupBox4.Controls.Add(this.btnDisconnectAll);
            this.groupBox4.Location = new System.Drawing.Point(14, 11);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1309, 134);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chức Năng";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblTimeLeft);
            this.groupBox5.Location = new System.Drawing.Point(1174, 19);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(126, 79);
            this.groupBox5.TabIndex = 38;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Time Left:";
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeLeft.Location = new System.Drawing.Point(29, 36);
            this.lblTimeLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(67, 25);
            this.lblTimeLeft.TabIndex = 11;
            this.lblTimeLeft.Text = "00:00";
            // 
            // btnLock
            // 
            this.btnLock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLock.Location = new System.Drawing.Point(1044, 19);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(110, 41);
            this.btnLock.TabIndex = 47;
            this.btnLock.Text = "Chặn chương trình";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnThuBai
            // 
            this.btnThuBai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThuBai.Location = new System.Drawing.Point(913, 19);
            this.btnThuBai.Name = "btnThuBai";
            this.btnThuBai.Size = new System.Drawing.Size(110, 41);
            this.btnThuBai.TabIndex = 47;
            this.btnThuBai.Text = "Thu Bài";
            this.btnThuBai.UseVisualStyleBackColor = true;
            this.btnThuBai.Click += new System.EventHandler(this.btnThuBai_Click);
            // 
            // cmdNhapVungIP
            // 
            this.cmdNhapVungIP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdNhapVungIP.Location = new System.Drawing.Point(82, 19);
            this.cmdNhapVungIP.Name = "cmdNhapVungIP";
            this.cmdNhapVungIP.Size = new System.Drawing.Size(110, 41);
            this.cmdNhapVungIP.TabIndex = 46;
            this.cmdNhapVungIP.Text = "Nhập Vùng IP";
            this.cmdNhapVungIP.UseVisualStyleBackColor = true;
            this.cmdNhapVungIP.Click += new System.EventHandler(this.cmdNhapVungIP_Click);
            // 
            // cmdKichHoatAllClient
            // 
            this.cmdKichHoatAllClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdKichHoatAllClient.Location = new System.Drawing.Point(774, 19);
            this.cmdKichHoatAllClient.Name = "cmdKichHoatAllClient";
            this.cmdKichHoatAllClient.Size = new System.Drawing.Size(110, 41);
            this.cmdKichHoatAllClient.TabIndex = 45;
            this.cmdKichHoatAllClient.Text = "Active All";
            this.cmdKichHoatAllClient.UseVisualStyleBackColor = true;
            this.cmdKichHoatAllClient.Click += new System.EventHandler(this.cmdKichHoatAllClient_Click);
            // 
            // btn_SendMessage
            // 
            this.btn_SendMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_SendMessage.Location = new System.Drawing.Point(359, 19);
            this.btn_SendMessage.Name = "btn_SendMessage";
            this.btn_SendMessage.Size = new System.Drawing.Size(110, 41);
            this.btn_SendMessage.TabIndex = 40;
            this.btn_SendMessage.Text = "Message";
            this.btn_SendMessage.UseVisualStyleBackColor = true;
            this.btn_SendMessage.Click += new System.EventHandler(this.btn_SendMessage_Click);
            // 
            // button11
            // 
            this.button11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button11.Location = new System.Drawing.Point(626, 19);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(132, 41);
            this.button11.TabIndex = 40;
            this.button11.Text = "Disable empty PC";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // btnFile
            // 
            this.btnFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFile.Location = new System.Drawing.Point(498, 19);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(110, 41);
            this.btnFile.TabIndex = 40;
            this.btnFile.Text = "File";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnDisconnectAll
            // 
            this.btnDisconnectAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDisconnectAll.Location = new System.Drawing.Point(221, 19);
            this.btnDisconnectAll.Name = "btnDisconnectAll";
            this.btnDisconnectAll.Size = new System.Drawing.Size(110, 41);
            this.btnDisconnectAll.TabIndex = 40;
            this.btnDisconnectAll.Text = "Disconnect All";
            this.btnDisconnectAll.UseVisualStyleBackColor = true;
            this.btnDisconnectAll.Click += new System.EventHandler(this.btnDisconnectAll_Click);
            // 
            // cmdBatDauLamBai
            // 
            this.cmdBatDauLamBai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmdBatDauLamBai.Location = new System.Drawing.Point(1226, 340);
            this.cmdBatDauLamBai.Name = "cmdBatDauLamBai";
            this.cmdBatDauLamBai.Size = new System.Drawing.Size(88, 41);
            this.cmdBatDauLamBai.TabIndex = 44;
            this.cmdBatDauLamBai.Text = "Begin";
            this.cmdBatDauLamBai.UseVisualStyleBackColor = true;
            this.cmdBatDauLamBai.Click += new System.EventHandler(this.cmdBatDauLamBai_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btnChonClientPath);
            this.groupBox3.Controls.Add(this.btnChonServerPath);
            this.groupBox3.Controls.Add(this.txtClientPath);
            this.groupBox3.Controls.Add(this.txtServerPath);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(14, 422);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(808, 140);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Đường Dẫn";
            // 
            // btnChonClientPath
            // 
            this.btnChonClientPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChonClientPath.Location = new System.Drawing.Point(724, 104);
            this.btnChonClientPath.Name = "btnChonClientPath";
            this.btnChonClientPath.Size = new System.Drawing.Size(69, 30);
            this.btnChonClientPath.TabIndex = 36;
            this.btnChonClientPath.Text = "Chọn";
            this.btnChonClientPath.UseVisualStyleBackColor = true;
            this.btnChonClientPath.Click += new System.EventHandler(this.btnChonClientPath_Click);
            // 
            // btnChonServerPath
            // 
            this.btnChonServerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChonServerPath.Location = new System.Drawing.Point(724, 48);
            this.btnChonServerPath.Name = "btnChonServerPath";
            this.btnChonServerPath.Size = new System.Drawing.Size(69, 24);
            this.btnChonServerPath.TabIndex = 35;
            this.btnChonServerPath.Text = "Chọn";
            this.btnChonServerPath.UseVisualStyleBackColor = true;
            this.btnChonServerPath.Click += new System.EventHandler(this.btnChonServerPath_Click);
            // 
            // txtClientPath
            // 
            this.txtClientPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClientPath.Location = new System.Drawing.Point(243, 104);
            this.txtClientPath.Name = "txtClientPath";
            this.txtClientPath.Size = new System.Drawing.Size(421, 26);
            this.txtClientPath.TabIndex = 34;
            this.txtClientPath.Text = "D:\\StudentFolder";
            // 
            // txtServerPath
            // 
            this.txtServerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerPath.Location = new System.Drawing.Point(243, 45);
            this.txtServerPath.Name = "txtServerPath";
            this.txtServerPath.Size = new System.Drawing.Size(421, 26);
            this.txtServerPath.TabIndex = 34;
            this.txtServerPath.Text = "D:\\ServerFolder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Gửi đề thi đến (Máy con):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Lưu bài thi (Máy chủ):";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnXoaDe);
            this.groupBox1.Controls.Add(this.lsvDeThi);
            this.groupBox1.Controls.Add(this.btnPhatDe);
            this.groupBox1.Controls.Add(this.btnThemDe);
            this.groupBox1.Location = new System.Drawing.Point(821, 419);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 143);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Đề Thi";
            // 
            // btnXoaDe
            // 
            this.btnXoaDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaDe.Location = new System.Drawing.Point(405, 63);
            this.btnXoaDe.Name = "btnXoaDe";
            this.btnXoaDe.Size = new System.Drawing.Size(88, 32);
            this.btnXoaDe.TabIndex = 34;
            this.btnXoaDe.Text = "Xóa";
            this.btnXoaDe.UseVisualStyleBackColor = true;
            this.btnXoaDe.Click += new System.EventHandler(this.btnXoaDe_Click);
            // 
            // lsvDeThi
            // 
            this.lsvDeThi.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lsvDeThi.AllowDrop = true;
            this.lsvDeThi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvDeThi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvDeThi.FullRowSelect = true;
            this.lsvDeThi.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvDeThi.HideSelection = false;
            this.lsvDeThi.Location = new System.Drawing.Point(7, 25);
            this.lsvDeThi.MultiSelect = false;
            this.lsvDeThi.Name = "lsvDeThi";
            this.lsvDeThi.Size = new System.Drawing.Size(352, 112);
            this.lsvDeThi.TabIndex = 33;
            this.lsvDeThi.UseCompatibleStateImageBehavior = false;
            this.lsvDeThi.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Danh sách đề thi";
            this.columnHeader1.Width = 600;
            // 
            // btnPhatDe
            // 
            this.btnPhatDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhatDe.Location = new System.Drawing.Point(405, 106);
            this.btnPhatDe.Name = "btnPhatDe";
            this.btnPhatDe.Size = new System.Drawing.Size(88, 31);
            this.btnPhatDe.TabIndex = 32;
            this.btnPhatDe.Text = "Phát Đề";
            this.btnPhatDe.UseVisualStyleBackColor = true;
            this.btnPhatDe.Click += new System.EventHandler(this.btnPhatDe_Click);
            // 
            // btnThemDe
            // 
            this.btnThemDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemDe.Location = new System.Drawing.Point(405, 27);
            this.btnThemDe.Name = "btnThemDe";
            this.btnThemDe.Size = new System.Drawing.Size(88, 36);
            this.btnThemDe.TabIndex = 31;
            this.btnThemDe.Text = "Thêm";
            this.btnThemDe.UseVisualStyleBackColor = true;
            this.btnThemDe.Click += new System.EventHandler(this.btnThemDe_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.flpMain);
            this.groupBox6.Location = new System.Drawing.Point(14, 147);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1167, 269);
            this.groupBox6.TabIndex = 53;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Danh sách các máy con trong phòng";
            // 
            // flpMain
            // 
            this.flpMain.AutoScroll = true;
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.Location = new System.Drawing.Point(3, 22);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(1161, 244);
            this.flpMain.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSetTime);
            this.groupBox2.Location = new System.Drawing.Point(1188, 182);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(126, 73);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Time:";
            // 
            // txtSetTime
            // 
            this.txtSetTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSetTime.Location = new System.Drawing.Point(9, 23);
            this.txtSetTime.Margin = new System.Windows.Forms.Padding(4);
            this.txtSetTime.Name = "txtSetTime";
            this.txtSetTime.Size = new System.Drawing.Size(106, 37);
            this.txtSetTime.TabIndex = 13;
            this.txtSetTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 574);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdBatDauLamBai);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Server";
            this.Text = "Server";
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cmdNhapVungIP;
        private System.Windows.Forms.Button cmdKichHoatAllClient;
        private System.Windows.Forms.Button cmdBatDauLamBai;
        private System.Windows.Forms.Button btn_SendMessage;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.Button btnDisconnectAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnChonClientPath;
        private System.Windows.Forms.Button btnChonServerPath;
        private System.Windows.Forms.TextBox txtClientPath;
        private System.Windows.Forms.TextBox txtServerPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThemDe;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
		private System.Windows.Forms.Button btnPhatDe;
		private System.Windows.Forms.Button btnThuBai;
		private System.Windows.Forms.ListView lsvDeThi;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button btnXoaDe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSetTime;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Button btnLock;
    }
}

