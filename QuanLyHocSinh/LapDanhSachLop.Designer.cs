namespace QuanLyHocSinh
{
    partial class LapDanhSachLop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LapDanhSachLop));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbClass = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbGrade = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbSchoolYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.tbStdNum = new System.Windows.Forms.TextBox();
            this.lbStdNum = new System.Windows.Forms.Label();
            this.lbClass = new System.Windows.Forms.Label();
            this.lbGrade = new System.Windows.Forms.Label();
            this.lbSchoolYear = new System.Windows.Forms.Label();
            this.duLieu = new QuanLyHocSinh.DuLieu();
            this.duLieuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lOPTableAdapter = new QuanLyHocSinh.DuLieuTableAdapters.LOPTableAdapter();
            this.duLieuBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainLabelStdInfo = new System.Windows.Forms.Label();
            this.Btn_Minimize = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Btn_Close = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnHomeScreen = new Guna.UI2.WinForms.Guna2Button();
            this.dgvClassDetail = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddStdToClass = new Guna.UI2.WinForms.Guna2Button();
            this.tbStdIdAdd = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbInputStdID = new System.Windows.Forms.Label();
            this.lbAddStdToClass = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDelStdOutClass = new Guna.UI2.WinForms.Guna2Button();
            this.tbStdIDDel = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duLieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duLieuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duLieuBindingSource1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassDetail)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.cbClass);
            this.panel1.Controls.Add(this.cbGrade);
            this.panel1.Controls.Add(this.cbSchoolYear);
            this.panel1.Controls.Add(this.tbStdNum);
            this.panel1.Controls.Add(this.lbStdNum);
            this.panel1.Controls.Add(this.lbClass);
            this.panel1.Controls.Add(this.lbGrade);
            this.panel1.Controls.Add(this.lbSchoolYear);
            this.panel1.Location = new System.Drawing.Point(177, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1390, 123);
            this.panel1.TabIndex = 0;
            // 
            // cbClass
            // 
            this.cbClass.BackColor = System.Drawing.Color.Transparent;
            this.cbClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClass.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbClass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbClass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbClass.ItemHeight = 30;
            this.cbClass.Location = new System.Drawing.Point(907, 29);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(185, 36);
            this.cbClass.TabIndex = 10;
            // 
            // cbGrade
            // 
            this.cbGrade.BackColor = System.Drawing.Color.Transparent;
            this.cbGrade.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrade.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGrade.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGrade.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbGrade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbGrade.ItemHeight = 30;
            this.cbGrade.Location = new System.Drawing.Point(529, 29);
            this.cbGrade.Name = "cbGrade";
            this.cbGrade.Size = new System.Drawing.Size(209, 36);
            this.cbGrade.TabIndex = 9;
            // 
            // cbSchoolYear
            // 
            this.cbSchoolYear.BackColor = System.Drawing.Color.Transparent;
            this.cbSchoolYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSchoolYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSchoolYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSchoolYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbSchoolYear.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbSchoolYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSchoolYear.ItemHeight = 30;
            this.cbSchoolYear.Location = new System.Drawing.Point(157, 28);
            this.cbSchoolYear.Name = "cbSchoolYear";
            this.cbSchoolYear.Size = new System.Drawing.Size(209, 36);
            this.cbSchoolYear.TabIndex = 8;
            // 
            // tbStdNum
            // 
            this.tbStdNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStdNum.Location = new System.Drawing.Point(1222, 40);
            this.tbStdNum.Name = "tbStdNum";
            this.tbStdNum.ReadOnly = true;
            this.tbStdNum.Size = new System.Drawing.Size(88, 39);
            this.tbStdNum.TabIndex = 7;
            // 
            // lbStdNum
            // 
            this.lbStdNum.AutoSize = true;
            this.lbStdNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStdNum.Location = new System.Drawing.Point(1149, 43);
            this.lbStdNum.Name = "lbStdNum";
            this.lbStdNum.Size = new System.Drawing.Size(67, 32);
            this.lbStdNum.TabIndex = 3;
            this.lbStdNum.Text = "Sĩ số";
            // 
            // lbClass
            // 
            this.lbClass.AutoSize = true;
            this.lbClass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbClass.Location = new System.Drawing.Point(831, 43);
            this.lbClass.Name = "lbClass";
            this.lbClass.Size = new System.Drawing.Size(56, 32);
            this.lbClass.TabIndex = 2;
            this.lbClass.Text = "Lớp";
            // 
            // lbGrade
            // 
            this.lbGrade.AutoSize = true;
            this.lbGrade.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGrade.Location = new System.Drawing.Point(441, 43);
            this.lbGrade.Name = "lbGrade";
            this.lbGrade.Size = new System.Drawing.Size(66, 32);
            this.lbGrade.TabIndex = 1;
            this.lbGrade.Text = "Khối";
            // 
            // lbSchoolYear
            // 
            this.lbSchoolYear.AutoSize = true;
            this.lbSchoolYear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSchoolYear.Location = new System.Drawing.Point(21, 43);
            this.lbSchoolYear.Name = "lbSchoolYear";
            this.lbSchoolYear.Size = new System.Drawing.Size(116, 32);
            this.lbSchoolYear.TabIndex = 0;
            this.lbSchoolYear.Text = "Năm học";
            // 
            // duLieu
            // 
            this.duLieu.DataSetName = "DuLieu";
            this.duLieu.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // duLieuBindingSource
            // 
            this.duLieuBindingSource.DataSource = this.duLieu;
            this.duLieuBindingSource.Position = 0;
            // 
            // lOPBindingSource
            // 
            this.lOPBindingSource.DataMember = "LOP";
            this.lOPBindingSource.DataSource = this.duLieuBindingSource;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // duLieuBindingSource1
            // 
            this.duLieuBindingSource1.DataSource = this.duLieu;
            this.duLieuBindingSource1.Position = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.mainLabelStdInfo);
            this.panel2.Controls.Add(this.Btn_Minimize);
            this.panel2.Controls.Add(this.Btn_Close);
            this.panel2.Location = new System.Drawing.Point(-4, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1605, 76);
            this.panel2.TabIndex = 7;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // mainLabelStdInfo
            // 
            this.mainLabelStdInfo.AutoSize = true;
            this.mainLabelStdInfo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabelStdInfo.ForeColor = System.Drawing.Color.White;
            this.mainLabelStdInfo.Location = new System.Drawing.Point(18, 17);
            this.mainLabelStdInfo.Name = "mainLabelStdInfo";
            this.mainLabelStdInfo.Size = new System.Drawing.Size(231, 45);
            this.mainLabelStdInfo.TabIndex = 6;
            this.mainLabelStdInfo.Text = "Danh sách lớp";
            this.mainLabelStdInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainLabelStdInfo_MouseDown);
            // 
            // Btn_Minimize
            // 
            this.Btn_Minimize.BackColor = System.Drawing.SystemColors.Highlight;
            this.Btn_Minimize.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Minimize.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Minimize.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Minimize.Image")));
            this.Btn_Minimize.ImageOffset = new System.Drawing.Point(0, 0);
            this.Btn_Minimize.ImageRotate = 0F;
            this.Btn_Minimize.ImageSize = new System.Drawing.Size(30, 30);
            this.Btn_Minimize.Location = new System.Drawing.Point(1473, 14);
            this.Btn_Minimize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Minimize.Name = "Btn_Minimize";
            this.Btn_Minimize.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Minimize.Size = new System.Drawing.Size(53, 54);
            this.Btn_Minimize.TabIndex = 4;
            this.Btn_Minimize.Click += new System.EventHandler(this.Btn_Minimize_Click);
            // 
            // Btn_Close
            // 
            this.Btn_Close.BackColor = System.Drawing.SystemColors.Highlight;
            this.Btn_Close.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Close.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Close.Image")));
            this.Btn_Close.ImageOffset = new System.Drawing.Point(0, 0);
            this.Btn_Close.ImageRotate = 0F;
            this.Btn_Close.ImageSize = new System.Drawing.Size(30, 30);
            this.Btn_Close.Location = new System.Drawing.Point(1534, 14);
            this.Btn_Close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Close.Size = new System.Drawing.Size(53, 54);
            this.Btn_Close.TabIndex = 5;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // btnHomeScreen
            // 
            this.btnHomeScreen.BorderColor = System.Drawing.Color.White;
            this.btnHomeScreen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHomeScreen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHomeScreen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHomeScreen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHomeScreen.FillColor = System.Drawing.Color.White;
            this.btnHomeScreen.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnHomeScreen.ForeColor = System.Drawing.Color.White;
            this.btnHomeScreen.Image = ((System.Drawing.Image)(resources.GetObject("btnHomeScreen.Image")));
            this.btnHomeScreen.ImageSize = new System.Drawing.Size(30, 30);
            this.btnHomeScreen.Location = new System.Drawing.Point(60, 136);
            this.btnHomeScreen.Name = "btnHomeScreen";
            this.btnHomeScreen.Size = new System.Drawing.Size(60, 60);
            this.btnHomeScreen.TabIndex = 8;
            this.btnHomeScreen.Click += new System.EventHandler(this.btnHomeScreen_Click);
            // 
            // dgvClassDetail
            // 
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            this.dgvClassDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClassDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvClassDetail.ColumnHeadersHeight = 40;
            this.dgvClassDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvClassDetail.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgvClassDetail.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvClassDetail.Location = new System.Drawing.Point(22, 366);
            this.dgvClassDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvClassDetail.Name = "dgvClassDetail";
            this.dgvClassDetail.ReadOnly = true;
            this.dgvClassDetail.RowHeadersVisible = false;
            this.dgvClassDetail.RowHeadersWidth = 62;
            this.dgvClassDetail.RowTemplate.Height = 24;
            this.dgvClassDetail.Size = new System.Drawing.Size(1545, 300);
            this.dgvClassDetail.TabIndex = 9;
            this.dgvClassDetail.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvClassDetail.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvClassDetail.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvClassDetail.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvClassDetail.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvClassDetail.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvClassDetail.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvClassDetail.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvClassDetail.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvClassDetail.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvClassDetail.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvClassDetail.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvClassDetail.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvClassDetail.ThemeStyle.ReadOnly = true;
            this.dgvClassDetail.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvClassDetail.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvClassDetail.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvClassDetail.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvClassDetail.ThemeStyle.RowsStyle.Height = 24;
            this.dgvClassDetail.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvClassDetail.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddStdToClass);
            this.panel3.Controls.Add(this.tbStdIdAdd);
            this.panel3.Controls.Add(this.lbInputStdID);
            this.panel3.Controls.Add(this.lbAddStdToClass);
            this.panel3.Location = new System.Drawing.Point(22, 219);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1042, 141);
            this.panel3.TabIndex = 10;
            // 
            // btnAddStdToClass
            // 
            this.btnAddStdToClass.AutoRoundedCorners = true;
            this.btnAddStdToClass.BackColor = System.Drawing.Color.White;
            this.btnAddStdToClass.BorderRadius = 21;
            this.btnAddStdToClass.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.btnAddStdToClass.DefaultAutoSize = true;
            this.btnAddStdToClass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddStdToClass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddStdToClass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddStdToClass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddStdToClass.FillColor = System.Drawing.Color.LightCyan;
            this.btnAddStdToClass.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAddStdToClass.ForeColor = System.Drawing.Color.Black;
            this.btnAddStdToClass.Image = ((System.Drawing.Image)(resources.GetObject("btnAddStdToClass.Image")));
            this.btnAddStdToClass.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddStdToClass.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAddStdToClass.Location = new System.Drawing.Point(811, 65);
            this.btnAddStdToClass.Name = "btnAddStdToClass";
            this.btnAddStdToClass.Size = new System.Drawing.Size(125, 44);
            this.btnAddStdToClass.TabIndex = 3;
            this.btnAddStdToClass.Text = "Thêm";
            this.btnAddStdToClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAddStdToClass.Click += new System.EventHandler(this.btnAddStdToClass_Click);
            // 
            // tbStdIdAdd
            // 
            this.tbStdIdAdd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbStdIdAdd.DefaultText = "";
            this.tbStdIdAdd.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbStdIdAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbStdIdAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbStdIdAdd.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbStdIdAdd.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStdIdAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbStdIdAdd.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStdIdAdd.Location = new System.Drawing.Point(192, 62);
            this.tbStdIdAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbStdIdAdd.Name = "tbStdIdAdd";
            this.tbStdIdAdd.PasswordChar = '\0';
            this.tbStdIdAdd.PlaceholderText = "";
            this.tbStdIdAdd.SelectedText = "";
            this.tbStdIdAdd.Size = new System.Drawing.Size(592, 60);
            this.tbStdIdAdd.TabIndex = 2;
            // 
            // lbInputStdID
            // 
            this.lbInputStdID.AutoSize = true;
            this.lbInputStdID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInputStdID.Location = new System.Drawing.Point(21, 78);
            this.lbInputStdID.Name = "lbInputStdID";
            this.lbInputStdID.Size = new System.Drawing.Size(144, 32);
            this.lbInputStdID.TabIndex = 1;
            this.lbInputStdID.Text = "Nhập MSHS";
            // 
            // lbAddStdToClass
            // 
            this.lbAddStdToClass.AutoSize = true;
            this.lbAddStdToClass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddStdToClass.Location = new System.Drawing.Point(21, 18);
            this.lbAddStdToClass.Name = "lbAddStdToClass";
            this.lbAddStdToClass.Size = new System.Drawing.Size(271, 32);
            this.lbAddStdToClass.TabIndex = 0;
            this.lbAddStdToClass.Text = "Thêm học sinh vào lớp";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnDelStdOutClass);
            this.panel4.Controls.Add(this.tbStdIDDel);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(1091, 219);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(476, 141);
            this.panel4.TabIndex = 11;
            // 
            // btnDelStdOutClass
            // 
            this.btnDelStdOutClass.AutoRoundedCorners = true;
            this.btnDelStdOutClass.BorderRadius = 21;
            this.btnDelStdOutClass.DefaultAutoSize = true;
            this.btnDelStdOutClass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelStdOutClass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelStdOutClass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelStdOutClass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelStdOutClass.FillColor = System.Drawing.Color.LightCyan;
            this.btnDelStdOutClass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelStdOutClass.ForeColor = System.Drawing.Color.Black;
            this.btnDelStdOutClass.Image = ((System.Drawing.Image)(resources.GetObject("btnDelStdOutClass.Image")));
            this.btnDelStdOutClass.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDelStdOutClass.ImageSize = new System.Drawing.Size(30, 30);
            this.btnDelStdOutClass.Location = new System.Drawing.Point(329, 65);
            this.btnDelStdOutClass.Name = "btnDelStdOutClass";
            this.btnDelStdOutClass.Size = new System.Drawing.Size(105, 44);
            this.btnDelStdOutClass.TabIndex = 4;
            this.btnDelStdOutClass.Text = "Xoá";
            this.btnDelStdOutClass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnDelStdOutClass.Click += new System.EventHandler(this.btnDelStdOutClass_Click);
            // 
            // tbStdIDDel
            // 
            this.tbStdIDDel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbStdIDDel.DefaultText = "";
            this.tbStdIDDel.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbStdIDDel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbStdIDDel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbStdIDDel.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbStdIDDel.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStdIDDel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbStdIDDel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbStdIDDel.Location = new System.Drawing.Point(185, 61);
            this.tbStdIDDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbStdIDDel.Name = "tbStdIDDel";
            this.tbStdIDDel.PasswordChar = '\0';
            this.tbStdIDDel.PlaceholderText = "";
            this.tbStdIDDel.SelectedText = "";
            this.tbStdIDDel.Size = new System.Drawing.Size(118, 60);
            this.tbStdIDDel.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 32);
            this.label8.TabIndex = 2;
            this.label8.Text = "Nhập STT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(260, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "Xoá học sinh khỏi lớp";
            // 
            // LapDanhSachLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1900, 850);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvClassDetail);
            this.Controls.Add(this.btnHomeScreen);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LapDanhSachLop";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LapDanhSachLop";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duLieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duLieuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duLieuBindingSource1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassDetail)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbStdNum;
        private System.Windows.Forms.Label lbStdNum;
        private System.Windows.Forms.Label lbClass;
        private System.Windows.Forms.Label lbGrade;
        private System.Windows.Forms.Label lbSchoolYear;
        private System.Windows.Forms.BindingSource duLieuBindingSource;
        private DuLieu duLieu;
        private System.Windows.Forms.BindingSource lOPBindingSource;
        private DuLieuTableAdapters.LOPTableAdapter lOPTableAdapter;
        private System.Windows.Forms.BindingSource duLieuBindingSource1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label mainLabelStdInfo;
        private Guna.UI2.WinForms.Guna2ImageButton Btn_Minimize;
        private Guna.UI2.WinForms.Guna2ImageButton Btn_Close;
        private Guna.UI2.WinForms.Guna2Button btnHomeScreen;
        private Guna.UI2.WinForms.Guna2ComboBox cbClass;
        private Guna.UI2.WinForms.Guna2ComboBox cbGrade;
        private Guna.UI2.WinForms.Guna2ComboBox cbSchoolYear;
        private Guna.UI2.WinForms.Guna2DataGridView dgvClassDetail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbAddStdToClass;
        private Guna.UI2.WinForms.Guna2Button btnAddStdToClass;
        private Guna.UI2.WinForms.Guna2TextBox tbStdIdAdd;
        private System.Windows.Forms.Label lbInputStdID;
        private Guna.UI2.WinForms.Guna2TextBox tbStdIDDel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button btnDelStdOutClass;
    }
}