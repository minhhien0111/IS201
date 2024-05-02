
namespace QuanLyHocSinh
{
    partial class TrangChu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrangChu));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuItemAddStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemListCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFindStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemScoreBoard = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubjectScore = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubjectScore1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSubjectScoreYear = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFinalReport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemClassReport = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFinalReport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuQuanLyQuyDinh = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ImageButtonClose1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButtonMinimize1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.guna2DataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ComboBoxYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2ButtonSubject = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ButtonClass = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ImageButtonUser = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2TextBoxUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.Background = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemAddStudent,
            this.MenuItemListCreate,
            this.MenuItemSearch,
            this.MenuItemSubjectScore,
            this.MenuItemFinalReport,
            this.MenuQuanLyQuyDinh,
            this.ToolStripMenuItemAccount});
            this.menuStrip1.Location = new System.Drawing.Point(0, 208);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1312, 50);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemAddStudent
            // 
            this.MenuItemAddStudent.AutoSize = false;
            this.MenuItemAddStudent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemAddStudent.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemAddStudent.Name = "MenuItemAddStudent";
            this.MenuItemAddStudent.Size = new System.Drawing.Size(200, 50);
            this.MenuItemAddStudent.Text = "Tiếp nhận học sinh";
            this.MenuItemAddStudent.Visible = false;
            this.MenuItemAddStudent.Click += new System.EventHandler(this.MenuItemAddStudent_Click);
            // 
            // MenuItemListCreate
            // 
            this.MenuItemListCreate.AutoSize = false;
            this.MenuItemListCreate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemListCreate.ForeColor = System.Drawing.Color.White;
            this.MenuItemListCreate.Name = "MenuItemListCreate";
            this.MenuItemListCreate.Size = new System.Drawing.Size(200, 50);
            this.MenuItemListCreate.Text = "Lập danh sách lớp";
            this.MenuItemListCreate.Visible = false;
            this.MenuItemListCreate.Click += new System.EventHandler(this.MenuItemListCreate_Click);
            // 
            // MenuItemSearch
            // 
            this.MenuItemSearch.AutoSize = false;
            this.MenuItemSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemFindStudent,
            this.MenuItemScoreBoard});
            this.MenuItemSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemSearch.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemSearch.Name = "MenuItemSearch";
            this.MenuItemSearch.Size = new System.Drawing.Size(180, 50);
            this.MenuItemSearch.Text = "Tra cứu học sinh";
            this.MenuItemSearch.Visible = false;
            // 
            // MenuItemFindStudent
            // 
            this.MenuItemFindStudent.Name = "MenuItemFindStudent";
            this.MenuItemFindStudent.Size = new System.Drawing.Size(275, 32);
            this.MenuItemFindStudent.Text = "Tra cứu thông tin";
            this.MenuItemFindStudent.Click += new System.EventHandler(this.MenuItemFindStudent_Click);
            // 
            // MenuItemScoreBoard
            // 
            this.MenuItemScoreBoard.Name = "MenuItemScoreBoard";
            this.MenuItemScoreBoard.Size = new System.Drawing.Size(275, 32);
            this.MenuItemScoreBoard.Text = "Tra cứu bảng điểm";
            this.MenuItemScoreBoard.Click += new System.EventHandler(this.MenuItemScoreBoard_Click);
            // 
            // MenuItemSubjectScore
            // 
            this.MenuItemSubjectScore.AutoSize = false;
            this.MenuItemSubjectScore.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemSubjectScore1,
            this.MenuItemSubjectScoreYear});
            this.MenuItemSubjectScore.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemSubjectScore.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemSubjectScore.Name = "MenuItemSubjectScore";
            this.MenuItemSubjectScore.Size = new System.Drawing.Size(200, 50);
            this.MenuItemSubjectScore.Text = "Bảng điểm môn học";
            this.MenuItemSubjectScore.Visible = false;
            // 
            // MenuItemSubjectScore1
            // 
            this.MenuItemSubjectScore1.Name = "MenuItemSubjectScore1";
            this.MenuItemSubjectScore1.Size = new System.Drawing.Size(344, 32);
            this.MenuItemSubjectScore1.Text = "Nhập bảng điểm môn học";
            this.MenuItemSubjectScore1.Click += new System.EventHandler(this.MenuItemSubjectScore_Click);
            // 
            // MenuItemSubjectScoreYear
            // 
            this.MenuItemSubjectScoreYear.Name = "MenuItemSubjectScoreYear";
            this.MenuItemSubjectScoreYear.Size = new System.Drawing.Size(344, 32);
            this.MenuItemSubjectScoreYear.Text = "Xuất bảng điểm môn học";
            this.MenuItemSubjectScoreYear.Click += new System.EventHandler(this.MenuItemSubjectScoreYear_Click);
            // 
            // MenuItemFinalReport
            // 
            this.MenuItemFinalReport.AutoSize = false;
            this.MenuItemFinalReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemClassReport,
            this.ToolStripMenuItemFinalReport});
            this.MenuItemFinalReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuItemFinalReport.ForeColor = System.Drawing.SystemColors.Window;
            this.MenuItemFinalReport.Name = "MenuItemFinalReport";
            this.MenuItemFinalReport.Size = new System.Drawing.Size(200, 50);
            this.MenuItemFinalReport.Text = "Báo cáo tổng kết";
            this.MenuItemFinalReport.Visible = false;
            // 
            // ToolStripMenuItemClassReport
            // 
            this.ToolStripMenuItemClassReport.Name = "ToolStripMenuItemClassReport";
            this.ToolStripMenuItemClassReport.Size = new System.Drawing.Size(254, 32);
            this.ToolStripMenuItemClassReport.Text = "Tổng kết lớp";
            this.ToolStripMenuItemClassReport.Click += new System.EventHandler(this.MenuItemClassScore_Click);
            // 
            // ToolStripMenuItemFinalReport
            // 
            this.ToolStripMenuItemFinalReport.Name = "ToolStripMenuItemFinalReport";
            this.ToolStripMenuItemFinalReport.Size = new System.Drawing.Size(254, 32);
            this.ToolStripMenuItemFinalReport.Text = "Tổng kết trường";
            this.ToolStripMenuItemFinalReport.Click += new System.EventHandler(this.MenuItemFinalReport_Click);
            // 
            // MenuQuanLyQuyDinh
            // 
            this.MenuQuanLyQuyDinh.AutoSize = false;
            this.MenuQuanLyQuyDinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuQuanLyQuyDinh.ForeColor = System.Drawing.Color.White;
            this.MenuQuanLyQuyDinh.Name = "MenuQuanLyQuyDinh";
            this.MenuQuanLyQuyDinh.Size = new System.Drawing.Size(200, 50);
            this.MenuQuanLyQuyDinh.Text = "Quản lý quy định";
            this.MenuQuanLyQuyDinh.Visible = false;
            this.MenuQuanLyQuyDinh.Click += new System.EventHandler(this.MenuQuanLyQuyDinh_Click);
            // 
            // ToolStripMenuItemAccount
            // 
            this.ToolStripMenuItemAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStripMenuItemAccount.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItemAccount.Name = "ToolStripMenuItemAccount";
            this.ToolStripMenuItemAccount.Size = new System.Drawing.Size(156, 46);
            this.ToolStripMenuItemAccount.Text = "Tạo tài khoản";
            this.ToolStripMenuItemAccount.Visible = false;
            this.ToolStripMenuItemAccount.Click += new System.EventHandler(this.taojToolStripMenuItem_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.guna2Panel1.Controls.Add(this.guna2ImageButtonClose1);
            this.guna2Panel1.Controls.Add(this.guna2ImageButtonMinimize1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1312, 53);
            this.guna2Panel1.TabIndex = 17;
            this.guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseDown);
            // 
            // guna2ImageButtonClose1
            // 
            this.guna2ImageButtonClose1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonClose1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonClose1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButtonClose1.Image")));
            this.guna2ImageButtonClose1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButtonClose1.ImageRotate = 0F;
            this.guna2ImageButtonClose1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageButtonClose1.Location = new System.Drawing.Point(1261, 6);
            this.guna2ImageButtonClose1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ImageButtonClose1.Name = "guna2ImageButtonClose1";
            this.guna2ImageButtonClose1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonClose1.Size = new System.Drawing.Size(47, 43);
            this.guna2ImageButtonClose1.TabIndex = 1;
            this.guna2ImageButtonClose1.Click += new System.EventHandler(this.guna2ImageButtonClose1_Click);
            // 
            // guna2ImageButtonMinimize1
            // 
            this.guna2ImageButtonMinimize1.BackColor = System.Drawing.SystemColors.Highlight;
            this.guna2ImageButtonMinimize1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonMinimize1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonMinimize1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButtonMinimize1.Image")));
            this.guna2ImageButtonMinimize1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButtonMinimize1.ImageRotate = 0F;
            this.guna2ImageButtonMinimize1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageButtonMinimize1.Location = new System.Drawing.Point(1219, 6);
            this.guna2ImageButtonMinimize1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ImageButtonMinimize1.Name = "guna2ImageButtonMinimize1";
            this.guna2ImageButtonMinimize1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonMinimize1.Size = new System.Drawing.Size(47, 43);
            this.guna2ImageButtonMinimize1.TabIndex = 0;
            this.guna2ImageButtonMinimize1.Click += new System.EventHandler(this.guna2ImageButtonMinimize1_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(32, 35);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 18;
            // 
            // guna2DataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView.ColumnHeadersHeight = 40;
            this.guna2DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.guna2DataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView.Location = new System.Drawing.Point(243, 23);
            this.guna2DataGridView.Name = "guna2DataGridView";
            this.guna2DataGridView.RowHeadersVisible = false;
            this.guna2DataGridView.RowHeadersWidth = 51;
            this.guna2DataGridView.RowTemplate.Height = 24;
            this.guna2DataGridView.Size = new System.Drawing.Size(576, 341);
            this.guna2DataGridView.TabIndex = 19;
            this.guna2DataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView.ThemeStyle.HeaderStyle.Height = 40;
            this.guna2DataGridView.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.monthCalendar1);
            this.guna2Panel2.CustomBorderColor = System.Drawing.SystemColors.HotTrack;
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.guna2Panel2.Location = new System.Drawing.Point(26, 348);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(370, 289);
            this.guna2Panel2.TabIndex = 20;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.Controls.Add(this.label1);
            this.guna2Panel3.Controls.Add(this.guna2ComboBoxYear);
            this.guna2Panel3.Controls.Add(this.guna2ButtonSubject);
            this.guna2Panel3.Controls.Add(this.guna2ButtonClass);
            this.guna2Panel3.Controls.Add(this.guna2DataGridView);
            this.guna2Panel3.CustomBorderColor = System.Drawing.SystemColors.HotTrack;
            this.guna2Panel3.CustomBorderThickness = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.guna2Panel3.Location = new System.Drawing.Point(433, 348);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(847, 405);
            this.guna2Panel3.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 28);
            this.label1.TabIndex = 23;
            this.label1.Text = "Năm học";
            // 
            // guna2ComboBoxYear
            // 
            this.guna2ComboBoxYear.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBoxYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBoxYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBoxYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2ComboBoxYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBoxYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBoxYear.ItemHeight = 30;
            this.guna2ComboBoxYear.Location = new System.Drawing.Point(35, 70);
            this.guna2ComboBoxYear.Name = "guna2ComboBoxYear";
            this.guna2ComboBoxYear.Size = new System.Drawing.Size(166, 36);
            this.guna2ComboBoxYear.TabIndex = 22;
            // 
            // guna2ButtonSubject
            // 
            this.guna2ButtonSubject.AutoRoundedCorners = true;
            this.guna2ButtonSubject.BorderRadius = 22;
            this.guna2ButtonSubject.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2ButtonSubject.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2ButtonSubject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2ButtonSubject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2ButtonSubject.FillColor = System.Drawing.SystemColors.HotTrack;
            this.guna2ButtonSubject.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2ButtonSubject.ForeColor = System.Drawing.Color.White;
            this.guna2ButtonSubject.Location = new System.Drawing.Point(35, 225);
            this.guna2ButtonSubject.Name = "guna2ButtonSubject";
            this.guna2ButtonSubject.Size = new System.Drawing.Size(153, 47);
            this.guna2ButtonSubject.TabIndex = 21;
            this.guna2ButtonSubject.Text = "Danh sách môn";
            this.guna2ButtonSubject.Click += new System.EventHandler(this.guna2ButtonSubject_Click);
            // 
            // guna2ButtonClass
            // 
            this.guna2ButtonClass.AutoRoundedCorners = true;
            this.guna2ButtonClass.BorderRadius = 22;
            this.guna2ButtonClass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2ButtonClass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2ButtonClass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2ButtonClass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2ButtonClass.FillColor = System.Drawing.SystemColors.HotTrack;
            this.guna2ButtonClass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2ButtonClass.ForeColor = System.Drawing.Color.White;
            this.guna2ButtonClass.Location = new System.Drawing.Point(35, 145);
            this.guna2ButtonClass.Name = "guna2ButtonClass";
            this.guna2ButtonClass.Size = new System.Drawing.Size(153, 47);
            this.guna2ButtonClass.TabIndex = 20;
            this.guna2ButtonClass.Text = "Danh sách lớp";
            this.guna2ButtonClass.Click += new System.EventHandler(this.guna2ButtonClass_Click);
            // 
            // guna2ImageButtonUser
            // 
            this.guna2ImageButtonUser.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonUser.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonUser.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButtonUser.Image")));
            this.guna2ImageButtonUser.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButtonUser.ImageRotate = 0F;
            this.guna2ImageButtonUser.ImageSize = new System.Drawing.Size(60, 60);
            this.guna2ImageButtonUser.Location = new System.Drawing.Point(1207, 264);
            this.guna2ImageButtonUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2ImageButtonUser.Name = "guna2ImageButtonUser";
            this.guna2ImageButtonUser.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonUser.Size = new System.Drawing.Size(73, 68);
            this.guna2ImageButtonUser.TabIndex = 22;
            this.guna2ImageButtonUser.Click += new System.EventHandler(this.guna2ImageButtonUser_Click);
            // 
            // guna2TextBoxUser
            // 
            this.guna2TextBoxUser.AutoRoundedCorners = true;
            this.guna2TextBoxUser.BorderRadius = 27;
            this.guna2TextBoxUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBoxUser.DefaultText = "";
            this.guna2TextBoxUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBoxUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBoxUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBoxUser.ForeColor = System.Drawing.Color.Black;
            this.guna2TextBoxUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxUser.Location = new System.Drawing.Point(926, 275);
            this.guna2TextBoxUser.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.guna2TextBoxUser.Name = "guna2TextBoxUser";
            this.guna2TextBoxUser.PasswordChar = '\0';
            this.guna2TextBoxUser.PlaceholderForeColor = System.Drawing.Color.Black;
            this.guna2TextBoxUser.PlaceholderText = "";
            this.guna2TextBoxUser.ReadOnly = true;
            this.guna2TextBoxUser.SelectedText = "";
            this.guna2TextBoxUser.Size = new System.Drawing.Size(274, 57);
            this.guna2TextBoxUser.TabIndex = 23;
            this.guna2TextBoxUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Background
            // 
            this.Background.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Background.BackgroundImage")));
            this.Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Background.Location = new System.Drawing.Point(0, 56);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(1312, 149);
            this.Background.TabIndex = 24;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1312, 783);
            this.Controls.Add(this.Background);
            this.Controls.Add(this.guna2TextBoxUser);
            this.Controls.Add(this.guna2ImageButtonUser);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFinalReport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAddStudent;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSearch;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFindStudent;
        private System.Windows.Forms.ToolStripMenuItem MenuItemScoreBoard;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScore;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScore1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSubjectScoreYear;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButtonClose1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButtonMinimize1;
        private System.Windows.Forms.ToolStripMenuItem MenuQuanLyQuyDinh;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemClassReport;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFinalReport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemListCreate;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Button guna2ButtonSubject;
        private Guna.UI2.WinForms.Guna2Button guna2ButtonClass;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBoxYear;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButtonUser;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBoxUser;
        private System.Windows.Forms.Panel Background;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemAccount;
    }
}