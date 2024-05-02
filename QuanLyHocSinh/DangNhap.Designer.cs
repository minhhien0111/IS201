
namespace QuanLyHocSinh
{
    partial class DangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DangNhap));
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelWrong = new System.Windows.Forms.Label();
            this.textBoxUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.textBoxPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ImageButtonClose1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2ImageButtonMinimize1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.buttonLogin = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.guna2Panel1.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // labelWrong
            // 
            resources.ApplyResources(this.labelWrong, "labelWrong");
            this.labelWrong.ForeColor = System.Drawing.Color.Red;
            this.labelWrong.Name = "labelWrong";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BorderRadius = 18;
            this.textBoxUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxUsername.DefaultText = "";
            this.textBoxUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.textBoxUsername, "textBoxUsername");
            this.textBoxUsername.ForeColor = System.Drawing.Color.Black;
            this.textBoxUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxUsername.IconLeft = ((System.Drawing.Image)(resources.GetObject("textBoxUsername.IconLeft")));
            this.textBoxUsername.IconLeftSize = new System.Drawing.Size(30, 30);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.PasswordChar = '\0';
            this.textBoxUsername.PlaceholderText = "Tên đăng nhập";
            this.textBoxUsername.SelectedText = "";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderRadius = 18;
            this.textBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPassword.DefaultText = "";
            this.textBoxPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBoxPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBoxPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBoxPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.textBoxPassword, "textBoxPassword");
            this.textBoxPassword.ForeColor = System.Drawing.Color.Black;
            this.textBoxPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBoxPassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("textBoxPassword.IconLeft")));
            this.textBoxPassword.IconLeftSize = new System.Drawing.Size(30, 30);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '●';
            this.textBoxPassword.PlaceholderText = "Mật khẩu";
            this.textBoxPassword.SelectedText = "";
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.guna2Panel1.Controls.Add(this.guna2ImageButtonClose1);
            this.guna2Panel1.Controls.Add(this.guna2ImageButtonMinimize1);
            resources.ApplyResources(this.guna2Panel1, "guna2Panel1");
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseDown);
            // 
            // guna2ImageButtonClose1
            // 
            this.guna2ImageButtonClose1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            resources.ApplyResources(this.guna2ImageButtonClose1, "guna2ImageButtonClose1");
            this.guna2ImageButtonClose1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonClose1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButtonClose1.Image")));
            this.guna2ImageButtonClose1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButtonClose1.ImageRotate = 0F;
            this.guna2ImageButtonClose1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageButtonClose1.Name = "guna2ImageButtonClose1";
            this.guna2ImageButtonClose1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonClose1.Click += new System.EventHandler(this.guna2ImageButton2_Click);
            // 
            // guna2ImageButtonMinimize1
            // 
            this.guna2ImageButtonMinimize1.BackColor = System.Drawing.SystemColors.Highlight;
            this.guna2ImageButtonMinimize1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            resources.ApplyResources(this.guna2ImageButtonMinimize1, "guna2ImageButtonMinimize1");
            this.guna2ImageButtonMinimize1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonMinimize1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButtonMinimize1.Image")));
            this.guna2ImageButtonMinimize1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButtonMinimize1.ImageRotate = 0F;
            this.guna2ImageButtonMinimize1.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2ImageButtonMinimize1.Name = "guna2ImageButtonMinimize1";
            this.guna2ImageButtonMinimize1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButtonMinimize1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.AutoRoundedCorners = true;
            this.buttonLogin.BorderRadius = 31;
            this.buttonLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.buttonLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.buttonLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.buttonLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.buttonLogin.FillColor = System.Drawing.SystemColors.MenuHighlight;
            resources.ApplyResources(this.buttonLogin, "buttonLogin");
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(201)))));
            this.guna2CustomGradientPanel1.Controls.Add(this.textBoxUsername);
            this.guna2CustomGradientPanel1.Controls.Add(this.buttonLogin);
            this.guna2CustomGradientPanel1.Controls.Add(this.panel4);
            this.guna2CustomGradientPanel1.Controls.Add(this.textBoxPassword);
            this.guna2CustomGradientPanel1.Controls.Add(this.panel3);
            this.guna2CustomGradientPanel1.Controls.Add(this.labelWrong);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(201)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(201)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(201)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(201)))));
            resources.ApplyResources(this.guna2CustomGradientPanel1, "guna2CustomGradientPanel1");
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // DangNhap
            // 
            this.AcceptButton = this.buttonLogin;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.guna2Panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DangNhap";
            this.TopMost = true;
            this.guna2Panel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelWrong;
        private Guna.UI2.WinForms.Guna2TextBox textBoxUsername;
        private Guna.UI2.WinForms.Guna2TextBox textBoxPassword;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButtonMinimize1;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButtonClose1;
        private Guna.UI2.WinForms.Guna2Button buttonLogin;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.Panel panel4;
    }
}