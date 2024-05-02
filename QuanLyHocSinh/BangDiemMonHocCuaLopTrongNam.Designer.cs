namespace QuanLyHocSinh
{
    partial class BangDiemMonHocCuaLopTrongNam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BangDiemMonHocCuaLopTrongNam));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.LabelYear = new System.Windows.Forms.Label();
            this.LabelSubject = new System.Windows.Forms.Label();
            this.PanelPrint = new System.Windows.Forms.Panel();
            this.ButtonExportExcelFile = new Guna.UI2.WinForms.Guna2ImageButton();
            this.DataGridViewScore = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ChartRatio = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LabelNameOfDGV = new System.Windows.Forms.Label();
            this.PanelSummary = new System.Windows.Forms.Panel();
            this.ComboBoxYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ComboBoxClass = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ComboBoxSubject = new Guna.UI2.WinForms.Guna2ComboBox();
            this.LabelClass = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ImageButtonClose1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButtonMinimize1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ButtonHome = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ButtonShowScore = new Guna.UI2.WinForms.Guna2ImageButton();
            this.ButtonAccount = new Guna.UI2.WinForms.Guna2ImageButton();
            this.LabelSplit = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.LabelAttention = new System.Windows.Forms.Label();
            this.PanelPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartRatio)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelYear
            // 
            this.LabelYear.AutoSize = true;
            this.LabelYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LabelYear.Location = new System.Drawing.Point(176, 92);
            this.LabelYear.Name = "LabelYear";
            this.LabelYear.Size = new System.Drawing.Size(80, 23);
            this.LabelYear.TabIndex = 4;
            this.LabelYear.Text = "Năm học";
            // 
            // LabelSubject
            // 
            this.LabelSubject.AutoSize = true;
            this.LabelSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LabelSubject.Location = new System.Drawing.Point(565, 141);
            this.LabelSubject.Name = "LabelSubject";
            this.LabelSubject.Size = new System.Drawing.Size(78, 23);
            this.LabelSubject.TabIndex = 12;
            this.LabelSubject.Text = "Môn học";
            // 
            // PanelPrint
            // 
            this.PanelPrint.Controls.Add(this.ButtonExportExcelFile);
            this.PanelPrint.Controls.Add(this.DataGridViewScore);
            this.PanelPrint.Controls.Add(this.ChartRatio);
            this.PanelPrint.Controls.Add(this.LabelNameOfDGV);
            this.PanelPrint.Controls.Add(this.PanelSummary);
            this.PanelPrint.Location = new System.Drawing.Point(35, 235);
            this.PanelPrint.Name = "PanelPrint";
            this.PanelPrint.Size = new System.Drawing.Size(1373, 614);
            this.PanelPrint.TabIndex = 50;
            // 
            // ButtonExportExcelFile
            // 
            this.ButtonExportExcelFile.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonExportExcelFile.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonExportExcelFile.Image = ((System.Drawing.Image)(resources.GetObject("ButtonExportExcelFile.Image")));
            this.ButtonExportExcelFile.ImageOffset = new System.Drawing.Point(0, 0);
            this.ButtonExportExcelFile.ImageRotate = 0F;
            this.ButtonExportExcelFile.ImageSize = new System.Drawing.Size(40, 40);
            this.ButtonExportExcelFile.Location = new System.Drawing.Point(937, 491);
            this.ButtonExportExcelFile.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonExportExcelFile.Name = "ButtonExportExcelFile";
            this.ButtonExportExcelFile.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonExportExcelFile.Size = new System.Drawing.Size(87, 88);
            this.ButtonExportExcelFile.TabIndex = 139;
            this.ButtonExportExcelFile.Click += new System.EventHandler(this.ButtonExportExcel_Click);
            // 
            // DataGridViewScore
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataGridViewScore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewScore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewScore.ColumnHeadersHeight = 40;
            this.DataGridViewScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewScore.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewScore.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridViewScore.Location = new System.Drawing.Point(3, 244);
            this.DataGridViewScore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataGridViewScore.Name = "DataGridViewScore";
            this.DataGridViewScore.ReadOnly = true;
            this.DataGridViewScore.RowHeadersVisible = false;
            this.DataGridViewScore.RowHeadersWidth = 51;
            this.DataGridViewScore.RowTemplate.Height = 24;
            this.DataGridViewScore.Size = new System.Drawing.Size(987, 224);
            this.DataGridViewScore.TabIndex = 138;
            this.DataGridViewScore.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewScore.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataGridViewScore.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataGridViewScore.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataGridViewScore.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataGridViewScore.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewScore.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridViewScore.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DataGridViewScore.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataGridViewScore.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridViewScore.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataGridViewScore.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataGridViewScore.ThemeStyle.HeaderStyle.Height = 40;
            this.DataGridViewScore.ThemeStyle.ReadOnly = true;
            this.DataGridViewScore.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DataGridViewScore.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataGridViewScore.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridViewScore.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridViewScore.ThemeStyle.RowsStyle.Height = 24;
            this.DataGridViewScore.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DataGridViewScore.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DataGridViewScore.Visible = false;
            // 
            // ChartRatio
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartRatio.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartRatio.Legends.Add(legend1);
            this.ChartRatio.Location = new System.Drawing.Point(1011, 244);
            this.ChartRatio.Name = "ChartRatio";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ChartRatio.Series.Add(series1);
            this.ChartRatio.Size = new System.Drawing.Size(350, 314);
            this.ChartRatio.TabIndex = 137;
            this.ChartRatio.Text = "chart1";
            // 
            // LabelNameOfDGV
            // 
            this.LabelNameOfDGV.AutoSize = true;
            this.LabelNameOfDGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNameOfDGV.Location = new System.Drawing.Point(532, 541);
            this.LabelNameOfDGV.Name = "LabelNameOfDGV";
            this.LabelNameOfDGV.Size = new System.Drawing.Size(85, 29);
            this.LabelNameOfDGV.TabIndex = 136;
            this.LabelNameOfDGV.Text = "label1";
            // 
            // PanelSummary
            // 
            this.PanelSummary.Location = new System.Drawing.Point(65, 3);
            this.PanelSummary.Name = "PanelSummary";
            this.PanelSummary.Size = new System.Drawing.Size(925, 236);
            this.PanelSummary.TabIndex = 112;
            // 
            // ComboBoxYear
            // 
            this.ComboBoxYear.BackColor = System.Drawing.Color.Transparent;
            this.ComboBoxYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboBoxYear.ForeColor = System.Drawing.Color.Black;
            this.ComboBoxYear.ItemHeight = 25;
            this.ComboBoxYear.Location = new System.Drawing.Point(262, 92);
            this.ComboBoxYear.Name = "ComboBoxYear";
            this.ComboBoxYear.Size = new System.Drawing.Size(231, 31);
            this.ComboBoxYear.TabIndex = 55;
            this.ComboBoxYear.SelectedValueChanged += new System.EventHandler(this.comboBoxYear_SelectedValueChanged);
            // 
            // ComboBoxClass
            // 
            this.ComboBoxClass.BackColor = System.Drawing.Color.Transparent;
            this.ComboBoxClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxClass.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxClass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboBoxClass.ForeColor = System.Drawing.Color.Black;
            this.ComboBoxClass.ItemHeight = 25;
            this.ComboBoxClass.Location = new System.Drawing.Point(262, 141);
            this.ComboBoxClass.Name = "ComboBoxClass";
            this.ComboBoxClass.Size = new System.Drawing.Size(231, 31);
            this.ComboBoxClass.TabIndex = 57;
            this.ComboBoxClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxClass_SelectedIndexChanged);
            this.ComboBoxClass.Click += new System.EventHandler(this.comboBoxClass_Click);
            // 
            // ComboBoxSubject
            // 
            this.ComboBoxSubject.BackColor = System.Drawing.Color.Transparent;
            this.ComboBoxSubject.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboBoxSubject.DropDownHeight = 200;
            this.ComboBoxSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxSubject.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxSubject.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboBoxSubject.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ComboBoxSubject.ForeColor = System.Drawing.Color.Black;
            this.ComboBoxSubject.FormattingEnabled = true;
            this.ComboBoxSubject.IntegralHeight = false;
            this.ComboBoxSubject.ItemHeight = 25;
            this.ComboBoxSubject.Location = new System.Drawing.Point(649, 141);
            this.ComboBoxSubject.Name = "ComboBoxSubject";
            this.ComboBoxSubject.Size = new System.Drawing.Size(231, 31);
            this.ComboBoxSubject.TabIndex = 58;
            // 
            // LabelClass
            // 
            this.LabelClass.AutoSize = false;
            this.LabelClass.BackColor = System.Drawing.Color.Transparent;
            this.LabelClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LabelClass.Location = new System.Drawing.Point(209, 141);
            this.LabelClass.Name = "LabelClass";
            this.LabelClass.Size = new System.Drawing.Size(46, 31);
            this.LabelClass.TabIndex = 59;
            this.LabelClass.Text = "Lớp";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.guna2ImageButtonClose1);
            this.guna2Panel1.Controls.Add(this.guna2ImageButtonMinimize1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1444, 52);
            this.guna2Panel1.TabIndex = 62;
            this.guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(587, 41);
            this.label1.TabIndex = 2;
            this.label1.Text = "Xuất bảng điểm môn học của lớp trong năm học";
            // 
            // guna2ImageButtonClose1
            // 
            this.guna2ImageButtonClose1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonClose1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonClose1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButtonClose1.Image")));
            this.guna2ImageButtonClose1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButtonClose1.ImageRotate = 0F;
            this.guna2ImageButtonClose1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageButtonClose1.Location = new System.Drawing.Point(1361, 5);
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
            this.guna2ImageButtonMinimize1.Location = new System.Drawing.Point(1306, 5);
            this.guna2ImageButtonMinimize1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ImageButtonMinimize1.Name = "guna2ImageButtonMinimize1";
            this.guna2ImageButtonMinimize1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonMinimize1.Size = new System.Drawing.Size(47, 43);
            this.guna2ImageButtonMinimize1.TabIndex = 0;
            this.guna2ImageButtonMinimize1.Click += new System.EventHandler(this.guna2ImageButtonMinimize1_Click);
            // 
            // ButtonHome
            // 
            this.ButtonHome.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonHome.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonHome.Image = ((System.Drawing.Image)(resources.GetObject("ButtonHome.Image")));
            this.ButtonHome.ImageOffset = new System.Drawing.Point(0, 0);
            this.ButtonHome.ImageRotate = 0F;
            this.ButtonHome.ImageSize = new System.Drawing.Size(40, 40);
            this.ButtonHome.Location = new System.Drawing.Point(35, 70);
            this.ButtonHome.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonHome.Name = "ButtonHome";
            this.ButtonHome.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonHome.Size = new System.Drawing.Size(67, 62);
            this.ButtonHome.TabIndex = 63;
            this.ButtonHome.Click += new System.EventHandler(this.guna2ImageButtonHome_Click);
            // 
            // ButtonShowScore
            // 
            this.ButtonShowScore.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonShowScore.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonShowScore.Image = ((System.Drawing.Image)(resources.GetObject("ButtonShowScore.Image")));
            this.ButtonShowScore.ImageOffset = new System.Drawing.Point(0, 0);
            this.ButtonShowScore.ImageRotate = 0F;
            this.ButtonShowScore.ImageSize = new System.Drawing.Size(60, 60);
            this.ButtonShowScore.Location = new System.Drawing.Point(1073, 120);
            this.ButtonShowScore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonShowScore.Name = "ButtonShowScore";
            this.ButtonShowScore.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonShowScore.Size = new System.Drawing.Size(75, 82);
            this.ButtonShowScore.TabIndex = 64;
            this.ButtonShowScore.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // ButtonAccount
            // 
            this.ButtonAccount.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonAccount.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonAccount.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAccount.Image")));
            this.ButtonAccount.ImageOffset = new System.Drawing.Point(0, 0);
            this.ButtonAccount.ImageRotate = 0F;
            this.ButtonAccount.ImageSize = new System.Drawing.Size(40, 40);
            this.ButtonAccount.Location = new System.Drawing.Point(1335, 70);
            this.ButtonAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonAccount.Name = "ButtonAccount";
            this.ButtonAccount.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.ButtonAccount.Size = new System.Drawing.Size(73, 68);
            this.ButtonAccount.TabIndex = 65;
            this.ButtonAccount.Click += new System.EventHandler(this.guna2ImageButton2_Click);
            // 
            // LabelSplit
            // 
            this.LabelSplit.BackColor = System.Drawing.Color.Transparent;
            this.LabelSplit.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSplit.Location = new System.Drawing.Point(528, 210);
            this.LabelSplit.Name = "LabelSplit";
            this.LabelSplit.Size = new System.Drawing.Size(388, 19);
            this.LabelSplit.TabIndex = 71;
            this.LabelSplit.Text = "-----------------------------------------------------------------------------";
            // 
            // LabelAttention
            // 
            this.LabelAttention.AutoSize = true;
            this.LabelAttention.BackColor = System.Drawing.Color.White;
            this.LabelAttention.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAttention.ForeColor = System.Drawing.Color.Black;
            this.LabelAttention.Location = new System.Drawing.Point(273, 191);
            this.LabelAttention.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelAttention.Name = "LabelAttention";
            this.LabelAttention.Size = new System.Drawing.Size(207, 20);
            this.LabelAttention.TabIndex = 98;
            this.LabelAttention.Text = "*Lưu ý: Vui lòng chọn lớp trước";
            // 
            // BangDiemMonHocCuaLopTrongNam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1444, 900);
            this.Controls.Add(this.LabelAttention);
            this.Controls.Add(this.LabelSplit);
            this.Controls.Add(this.ButtonAccount);
            this.Controls.Add(this.ButtonShowScore);
            this.Controls.Add(this.ButtonHome);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.LabelClass);
            this.Controls.Add(this.ComboBoxSubject);
            this.Controls.Add(this.ComboBoxClass);
            this.Controls.Add(this.ComboBoxYear);
            this.Controls.Add(this.PanelPrint);
            this.Controls.Add(this.LabelSubject);
            this.Controls.Add(this.LabelYear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BangDiemMonHocCuaLopTrongNam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XuatBangDiemMonHocCuaLopTrongNamHoc";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseDown);
            this.PanelPrint.ResumeLayout(false);
            this.PanelPrint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartRatio)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Label LabelYear;
        private System.Windows.Forms.Label LabelSubject;
        private System.Windows.Forms.Panel PanelPrint;
        private System.Windows.Forms.Panel PanelSummary;
        private System.Windows.Forms.Label LabelNameOfDGV;
        #endregion

        private Guna.UI2.WinForms.Guna2ComboBox ComboBoxYear;
        private Guna.UI2.WinForms.Guna2ComboBox ComboBoxClass;
        private Guna.UI2.WinForms.Guna2ComboBox ComboBoxSubject;
        private Guna.UI2.WinForms.Guna2HtmlLabel LabelClass;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartRatio;
        private Guna.UI2.WinForms.Guna2DataGridView DataGridViewScore;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButtonClose1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButtonMinimize1;
        private Guna.UI2.WinForms.Guna2ImageButton ButtonHome;
        private Guna.UI2.WinForms.Guna2ImageButton ButtonExportExcelFile;
        private Guna.UI2.WinForms.Guna2ImageButton ButtonShowScore;
        private Guna.UI2.WinForms.Guna2ImageButton ButtonAccount;
        private Guna.UI2.WinForms.Guna2HtmlLabel LabelSplit;
        private System.Windows.Forms.Label LabelAttention;
    }
}