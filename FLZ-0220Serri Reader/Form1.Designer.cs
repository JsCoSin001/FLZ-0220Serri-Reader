namespace FLZ_0220Serri_Reader
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pbTrangThai = new System.Windows.Forms.ProgressBar();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChonNoiLuu = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXoaDS = new System.Windows.Forms.Button();
            this.btnLuuDS = new System.Windows.Forms.Button();
            this.grvDSDki = new System.Windows.Forms.DataGridView();
            this.TenMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDkiMay = new System.Windows.Forms.Button();
            this.cbxPortMay = new System.Windows.Forms.ComboBox();
            this.tbMayDo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.linklbAboutMe = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.llableZaloMe = new System.Windows.Forms.LinkLabel();
            this.grvDSMayDangHoatDong = new System.Windows.Forms.DataGridView();
            this.tenMay_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenPort_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QrInput_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kq_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangThai_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.lbThongBaoLoi = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnMoThuMucLuuKQ = new System.Windows.Forms.Button();
            this.lbThuMucLuuKQ = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbQrCodeInput = new System.Windows.Forms.TextBox();
            this.cbxChonMayDo = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDSDki)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDSMayDangHoatDong)).BeginInit();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(234, 457);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cài Đặt";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pbTrangThai);
            this.panel4.Controls.Add(this.btnBatDau);
            this.panel4.Controls.Add(this.btnKetThuc);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(2, 380);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(230, 75);
            this.panel4.TabIndex = 8;
            // 
            // pbTrangThai
            // 
            this.pbTrangThai.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbTrangThai.Location = new System.Drawing.Point(5, 52);
            this.pbTrangThai.Name = "pbTrangThai";
            this.pbTrangThai.Size = new System.Drawing.Size(220, 18);
            this.pbTrangThai.TabIndex = 2;
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(120, 8);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(108, 38);
            this.btnBatDau.TabIndex = 1;
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Location = new System.Drawing.Point(1, 8);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(111, 38);
            this.btnKetThuc.TabIndex = 0;
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.UseVisualStyleBackColor = true;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.btnChonNoiLuu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(2, 324);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 44);
            this.panel3.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Lưu kết quả";
            // 
            // btnChonNoiLuu
            // 
            this.btnChonNoiLuu.Location = new System.Drawing.Point(126, 8);
            this.btnChonNoiLuu.Name = "btnChonNoiLuu";
            this.btnChonNoiLuu.Size = new System.Drawing.Size(102, 27);
            this.btnChonNoiLuu.TabIndex = 0;
            this.btnChonNoiLuu.Text = "Chọn thư mục";
            this.btnChonNoiLuu.UseVisualStyleBackColor = true;
            this.btnChonNoiLuu.Click += new System.EventHandler(this.btnChonNoiLuu_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXoaDS);
            this.panel2.Controls.Add(this.btnLuuDS);
            this.panel2.Controls.Add(this.grvDSDki);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 127);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(230, 197);
            this.panel2.TabIndex = 6;
            // 
            // btnXoaDS
            // 
            this.btnXoaDS.Location = new System.Drawing.Point(3, 162);
            this.btnXoaDS.Name = "btnXoaDS";
            this.btnXoaDS.Size = new System.Drawing.Size(102, 29);
            this.btnXoaDS.TabIndex = 3;
            this.btnXoaDS.Text = "Xoá danh sách";
            this.btnXoaDS.UseVisualStyleBackColor = true;
            this.btnXoaDS.Click += new System.EventHandler(this.btnXoaDS_Click);
            // 
            // btnLuuDS
            // 
            this.btnLuuDS.Location = new System.Drawing.Point(126, 162);
            this.btnLuuDS.Name = "btnLuuDS";
            this.btnLuuDS.Size = new System.Drawing.Size(102, 29);
            this.btnLuuDS.TabIndex = 2;
            this.btnLuuDS.Text = "Lưu danh sách";
            this.btnLuuDS.UseVisualStyleBackColor = true;
            this.btnLuuDS.Click += new System.EventHandler(this.btnLuuDS_Click);
            // 
            // grvDSDki
            // 
            this.grvDSDki.AllowUserToAddRows = false;
            this.grvDSDki.AllowUserToDeleteRows = false;
            this.grvDSDki.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDSDki.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TenMay,
            this.TenPort});
            this.grvDSDki.Dock = System.Windows.Forms.DockStyle.Top;
            this.grvDSDki.Location = new System.Drawing.Point(3, 28);
            this.grvDSDki.Margin = new System.Windows.Forms.Padding(2);
            this.grvDSDki.Name = "grvDSDki";
            this.grvDSDki.ReadOnly = true;
            this.grvDSDki.RowHeadersVisible = false;
            this.grvDSDki.RowHeadersWidth = 62;
            this.grvDSDki.RowTemplate.Height = 28;
            this.grvDSDki.Size = new System.Drawing.Size(224, 129);
            this.grvDSDki.TabIndex = 1;
            // 
            // TenMay
            // 
            this.TenMay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenMay.HeaderText = "Tên máy";
            this.TenMay.MinimumWidth = 8;
            this.TenMay.Name = "TenMay";
            this.TenMay.ReadOnly = true;
            // 
            // TenPort
            // 
            this.TenPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TenPort.HeaderText = "Tên Port";
            this.TenPort.MinimumWidth = 8;
            this.TenPort.Name = "TenPort";
            this.TenPort.ReadOnly = true;
            this.TenPort.Width = 80;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "DS ĐĂNG KÍ MÁY ĐO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDkiMay);
            this.panel1.Controls.Add(this.cbxPortMay);
            this.panel1.Controls.Add(this.tbMayDo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 110);
            this.panel1.TabIndex = 5;
            // 
            // btnDkiMay
            // 
            this.btnDkiMay.Location = new System.Drawing.Point(154, 73);
            this.btnDkiMay.Margin = new System.Windows.Forms.Padding(2);
            this.btnDkiMay.Name = "btnDkiMay";
            this.btnDkiMay.Size = new System.Drawing.Size(70, 27);
            this.btnDkiMay.TabIndex = 3;
            this.btnDkiMay.Text = "Đăng kí";
            this.btnDkiMay.UseVisualStyleBackColor = true;
            this.btnDkiMay.Click += new System.EventHandler(this.btnDkiMay_Click);
            // 
            // cbxPortMay
            // 
            this.cbxPortMay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPortMay.FormattingEnabled = true;
            this.cbxPortMay.Items.AddRange(new object[] {
            "COM1"});
            this.cbxPortMay.Location = new System.Drawing.Point(75, 44);
            this.cbxPortMay.Margin = new System.Windows.Forms.Padding(2);
            this.cbxPortMay.Name = "cbxPortMay";
            this.cbxPortMay.Size = new System.Drawing.Size(150, 22);
            this.cbxPortMay.TabIndex = 2;
            // 
            // tbMayDo
            // 
            this.tbMayDo.Location = new System.Drawing.Point(75, 11);
            this.tbMayDo.Margin = new System.Windows.Forms.Padding(2);
            this.tbMayDo.Name = "tbMayDo";
            this.tbMayDo.Size = new System.Drawing.Size(150, 22);
            this.tbMayDo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port Máy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Máy";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(7, 2);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(3);
            this.panel5.Size = new System.Drawing.Size(240, 463);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(247, 2);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(3);
            this.panel6.Size = new System.Drawing.Size(736, 463);
            this.panel6.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel8);
            this.groupBox2.Controls.Add(this.lbThongBaoLoi);
            this.groupBox2.Controls.Add(this.panel7);
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(730, 457);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đo Hàng";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tableLayoutPanel2);
            this.panel8.Controls.Add(this.grvDSMayDangHoatDong);
            this.panel8.Controls.Add(this.label10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 170);
            this.panel8.Margin = new System.Windows.Forms.Padding(2);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(3);
            this.panel8.Size = new System.Drawing.Size(724, 284);
            this.panel8.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.linklbAboutMe, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.llableZaloMe, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 258);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(718, 23);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Created by";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linklbAboutMe
            // 
            this.linklbAboutMe.AutoSize = true;
            this.linklbAboutMe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linklbAboutMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklbAboutMe.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linklbAboutMe.LinkVisited = true;
            this.linklbAboutMe.Location = new System.Drawing.Point(67, 0);
            this.linklbAboutMe.Name = "linklbAboutMe";
            this.linklbAboutMe.Size = new System.Drawing.Size(269, 23);
            this.linklbAboutMe.TabIndex = 1;
            this.linklbAboutMe.TabStop = true;
            this.linklbAboutMe.Text = "Mr. Linh - HQP";
            this.linklbAboutMe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linklbAboutMe.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.linklbAboutMe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbAboutMe_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(555, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "Contact to";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // llableZaloMe
            // 
            this.llableZaloMe.AutoSize = true;
            this.llableZaloMe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llableZaloMe.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.llableZaloMe.Location = new System.Drawing.Point(617, 0);
            this.llableZaloMe.Name = "llableZaloMe";
            this.llableZaloMe.Size = new System.Drawing.Size(98, 23);
            this.llableZaloMe.TabIndex = 3;
            this.llableZaloMe.TabStop = true;
            this.llableZaloMe.Text = "(+84)5.89.98.89.98";
            this.llableZaloMe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.llableZaloMe.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.llableZaloMe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llableZaloMe_LinkClicked);
            // 
            // grvDSMayDangHoatDong
            // 
            this.grvDSMayDangHoatDong.AllowUserToAddRows = false;
            this.grvDSMayDangHoatDong.AllowUserToDeleteRows = false;
            this.grvDSMayDangHoatDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDSMayDangHoatDong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tenMay_TT,
            this.tenPort_TT,
            this.QrInput_TT,
            this.kq_TT,
            this.trangThai_TT});
            this.grvDSMayDangHoatDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvDSMayDangHoatDong.Location = new System.Drawing.Point(3, 28);
            this.grvDSMayDangHoatDong.Margin = new System.Windows.Forms.Padding(2);
            this.grvDSMayDangHoatDong.Name = "grvDSMayDangHoatDong";
            this.grvDSMayDangHoatDong.ReadOnly = true;
            this.grvDSMayDangHoatDong.RowHeadersVisible = false;
            this.grvDSMayDangHoatDong.RowHeadersWidth = 62;
            this.grvDSMayDangHoatDong.RowTemplate.Height = 28;
            this.grvDSMayDangHoatDong.Size = new System.Drawing.Size(718, 253);
            this.grvDSMayDangHoatDong.TabIndex = 1;
            // 
            // tenMay_TT
            // 
            this.tenMay_TT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tenMay_TT.HeaderText = "Tên máy";
            this.tenMay_TT.MinimumWidth = 8;
            this.tenMay_TT.Name = "tenMay_TT";
            this.tenMay_TT.ReadOnly = true;
            // 
            // tenPort_TT
            // 
            this.tenPort_TT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.tenPort_TT.HeaderText = "Tên Port";
            this.tenPort_TT.Name = "tenPort_TT";
            this.tenPort_TT.ReadOnly = true;
            // 
            // QrInput_TT
            // 
            this.QrInput_TT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QrInput_TT.HeaderText = "Qr code";
            this.QrInput_TT.MinimumWidth = 8;
            this.QrInput_TT.Name = "QrInput_TT";
            this.QrInput_TT.ReadOnly = true;
            // 
            // kq_TT
            // 
            this.kq_TT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.kq_TT.DefaultCellStyle = dataGridViewCellStyle3;
            this.kq_TT.HeaderText = "Kết quả";
            this.kq_TT.MinimumWidth = 8;
            this.kq_TT.Name = "kq_TT";
            this.kq_TT.ReadOnly = true;
            // 
            // trangThai_TT
            // 
            this.trangThai_TT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.trangThai_TT.DefaultCellStyle = dataGridViewCellStyle4;
            this.trangThai_TT.HeaderText = "Trạng thái";
            this.trangThai_TT.MinimumWidth = 8;
            this.trangThai_TT.Name = "trangThai_TT";
            this.trangThai_TT.ReadOnly = true;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 3);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(718, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "TRẠNG THÁI MÁY ĐO";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbThongBaoLoi
            // 
            this.lbThongBaoLoi.AutoSize = true;
            this.lbThongBaoLoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbThongBaoLoi.ForeColor = System.Drawing.Color.Firebrick;
            this.lbThongBaoLoi.Location = new System.Drawing.Point(3, 144);
            this.lbThongBaoLoi.Name = "lbThongBaoLoi";
            this.lbThongBaoLoi.Padding = new System.Windows.Forms.Padding(5);
            this.lbThongBaoLoi.Size = new System.Drawing.Size(10, 26);
            this.lbThongBaoLoi.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnMoThuMucLuuKQ);
            this.panel7.Controls.Add(this.lbThuMucLuuKQ);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 46);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.panel7.Size = new System.Drawing.Size(724, 98);
            this.panel7.TabIndex = 1;
            // 
            // btnMoThuMucLuuKQ
            // 
            this.btnMoThuMucLuuKQ.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnMoThuMucLuuKQ.Location = new System.Drawing.Point(0, 67);
            this.btnMoThuMucLuuKQ.Name = "btnMoThuMucLuuKQ";
            this.btnMoThuMucLuuKQ.Size = new System.Drawing.Size(724, 31);
            this.btnMoThuMucLuuKQ.TabIndex = 1;
            this.btnMoThuMucLuuKQ.Text = "Mở thư mục lưu kết quả";
            this.btnMoThuMucLuuKQ.UseVisualStyleBackColor = true;
            this.btnMoThuMucLuuKQ.Click += new System.EventHandler(this.btnMoThuMucLuuKQ_Click);
            // 
            // lbThuMucLuuKQ
            // 
            this.lbThuMucLuuKQ.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbThuMucLuuKQ.Location = new System.Drawing.Point(0, 28);
            this.lbThuMucLuuKQ.Name = "lbThuMucLuuKQ";
            this.lbThuMucLuuKQ.Padding = new System.Windows.Forms.Padding(5);
            this.lbThuMucLuuKQ.Size = new System.Drawing.Size(724, 34);
            this.lbThuMucLuuKQ.TabIndex = 0;
            this.lbThuMucLuuKQ.Text = "Không có dữ liệu...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 6);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label7.Size = new System.Drawing.Size(125, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Kết quả được lưu tại:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbQrCodeInput, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbxChonMayDo, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 28);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Chọn máy đo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(266, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "Qr code";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbQrCodeInput
            // 
            this.tbQrCodeInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbQrCodeInput.Enabled = false;
            this.tbQrCodeInput.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQrCodeInput.Location = new System.Drawing.Point(346, 3);
            this.tbQrCodeInput.Name = "tbQrCodeInput";
            this.tbQrCodeInput.Size = new System.Drawing.Size(375, 23);
            this.tbQrCodeInput.TabIndex = 3;
            this.tbQrCodeInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbQrCodeInput_KeyPress);
            // 
            // cbxChonMayDo
            // 
            this.cbxChonMayDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxChonMayDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChonMayDo.FormattingEnabled = true;
            this.cbxChonMayDo.Location = new System.Drawing.Point(103, 3);
            this.cbxChonMayDo.Name = "cbxChonMayDo";
            this.cbxChonMayDo.Size = new System.Drawing.Size(157, 24);
            this.cbxChonMayDo.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 471);
            this.ControlBox = false;
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(7, 2, 2, 6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FLZ-0220 Serri Reader";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDSDki)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDSMayDangHoatDong)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMayDo;
        private System.Windows.Forms.ComboBox cbxPortMay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDkiMay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView grvDSDki;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLuuDS;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnChonNoiLuu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.ProgressBar pbTrangThai;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbQrCodeInput;
        private System.Windows.Forms.ComboBox cbxChonMayDo;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbThongBaoLoi;
        private System.Windows.Forms.Button btnMoThuMucLuuKQ;
        private System.Windows.Forms.Label lbThuMucLuuKQ;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView grvDSMayDangHoatDong;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnXoaDS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linklbAboutMe;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel llableZaloMe;
        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenMay_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenPort_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn QrInput_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn kq_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangThai_TT;
    }
}

