namespace QuanLyHocSinh
{
    partial class TiepNhanHocSinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TiepNhanHocSinh));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInteractStudentInfo = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddNewStudent = new Guna.UI2.WinForms.Guna2Button();
            this.btnHomeScreen = new Guna.UI2.WinForms.Guna2Button();
            this.Btn_Minimize = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Btn_Close = new Guna.UI2.WinForms.Guna2ImageButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainLabelStdInfo = new System.Windows.Forms.Label();
            this.uC_XemThongTinHocSinh1 = new QuanLyHocSinh.UC_XemThongTinHocSinh();
            this.uC_ThemHocSinhMoi1 = new QuanLyHocSinh.UC_ThemHocSinhMoi();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.btnInteractStudentInfo);
            this.panel1.Controls.Add(this.btnAddNewStudent);
            this.panel1.Location = new System.Drawing.Point(209, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 98);
            this.panel1.TabIndex = 0;
            // 
            // btnInteractStudentInfo
            // 
            this.btnInteractStudentInfo.AutoRoundedCorners = true;
            this.btnInteractStudentInfo.BorderRadius = 24;
            this.btnInteractStudentInfo.DefaultAutoSize = true;
            this.btnInteractStudentInfo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInteractStudentInfo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInteractStudentInfo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInteractStudentInfo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInteractStudentInfo.FillColor = System.Drawing.SystemColors.Highlight;
            this.btnInteractStudentInfo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInteractStudentInfo.ForeColor = System.Drawing.Color.White;
            this.btnInteractStudentInfo.Location = new System.Drawing.Point(681, 19);
            this.btnInteractStudentInfo.Name = "btnInteractStudentInfo";
            this.btnInteractStudentInfo.Size = new System.Drawing.Size(350, 50);
            this.btnInteractStudentInfo.TabIndex = 1;
            this.btnInteractStudentInfo.Text = "Xem thông tin học sinh";
            this.btnInteractStudentInfo.Click += new System.EventHandler(this.btnInteractStudentInfo_Click);
            // 
            // btnAddNewStudent
            // 
            this.btnAddNewStudent.AutoRoundedCorners = true;
            this.btnAddNewStudent.BorderRadius = 24;
            this.btnAddNewStudent.DefaultAutoSize = true;
            this.btnAddNewStudent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewStudent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewStudent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewStudent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewStudent.FillColor = System.Drawing.SystemColors.Highlight;
            this.btnAddNewStudent.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewStudent.ForeColor = System.Drawing.Color.White;
            this.btnAddNewStudent.Location = new System.Drawing.Point(167, 19);
            this.btnAddNewStudent.Name = "btnAddNewStudent";
            this.btnAddNewStudent.Size = new System.Drawing.Size(292, 50);
            this.btnAddNewStudent.TabIndex = 0;
            this.btnAddNewStudent.Text = "Thêm học sinh mới";
            this.btnAddNewStudent.Click += new System.EventHandler(this.btnAddNewStudent_Click);
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
            this.btnHomeScreen.Location = new System.Drawing.Point(64, 110);
            this.btnHomeScreen.Name = "btnHomeScreen";
            this.btnHomeScreen.Size = new System.Drawing.Size(49, 45);
            this.btnHomeScreen.TabIndex = 1;
            this.btnHomeScreen.Click += new System.EventHandler(this.btnHomeScreen_Click);
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
            this.Btn_Minimize.Location = new System.Drawing.Point(1309, 14);
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
            this.Btn_Close.Location = new System.Drawing.Point(1370, 14);
            this.Btn_Close.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Btn_Close.Size = new System.Drawing.Size(53, 54);
            this.Btn_Close.TabIndex = 5;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.mainLabelStdInfo);
            this.panel2.Controls.Add(this.Btn_Minimize);
            this.panel2.Controls.Add(this.Btn_Close);
            this.panel2.Location = new System.Drawing.Point(-2, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1481, 76);
            this.panel2.TabIndex = 6;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // mainLabelStdInfo
            // 
            this.mainLabelStdInfo.AutoSize = true;
            this.mainLabelStdInfo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabelStdInfo.ForeColor = System.Drawing.Color.White;
            this.mainLabelStdInfo.Location = new System.Drawing.Point(59, 17);
            this.mainLabelStdInfo.Name = "mainLabelStdInfo";
            this.mainLabelStdInfo.Size = new System.Drawing.Size(241, 45);
            this.mainLabelStdInfo.TabIndex = 6;
            this.mainLabelStdInfo.Text = "Hồ sơ học sinh";
            this.mainLabelStdInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainLabelStdInfo_MouseDown);
            // 
            // uC_XemThongTinHocSinh1
            // 
            this.uC_XemThongTinHocSinh1.Location = new System.Drawing.Point(80, 188);
            this.uC_XemThongTinHocSinh1.Name = "uC_XemThongTinHocSinh1";
            this.uC_XemThongTinHocSinh1.Size = new System.Drawing.Size(1257, 811);
            this.uC_XemThongTinHocSinh1.TabIndex = 3;
            // 
            // uC_ThemHocSinhMoi1
            // 
            this.uC_ThemHocSinhMoi1.Location = new System.Drawing.Point(76, 194);
            this.uC_ThemHocSinhMoi1.Name = "uC_ThemHocSinhMoi1";
            this.uC_ThemHocSinhMoi1.Size = new System.Drawing.Size(1257, 811);
            this.uC_ThemHocSinhMoi1.TabIndex = 2;
            // 
            // TiepNhanHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1556, 970);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.uC_XemThongTinHocSinh1);
            this.Controls.Add(this.uC_ThemHocSinhMoi1);
            this.Controls.Add(this.btnHomeScreen);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TiepNhanHocSinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TiepNhanHocSinh";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnInteractStudentInfo;
        private Guna.UI2.WinForms.Guna2Button btnAddNewStudent;
        private Guna.UI2.WinForms.Guna2Button btnHomeScreen;
        private UC_ThemHocSinhMoi uC_ThemHocSinhMoi1;
        private UC_XemThongTinHocSinh uC_XemThongTinHocSinh1;
        private Guna.UI2.WinForms.Guna2ImageButton Btn_Minimize;
        private Guna.UI2.WinForms.Guna2ImageButton Btn_Close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label mainLabelStdInfo;
    }
}