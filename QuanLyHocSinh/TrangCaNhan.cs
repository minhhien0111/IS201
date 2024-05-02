using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QuanLyHocSinh
{
    public partial class TrangCaNhan : Form
    {
        public TrangCaNhan()
        {
            InitializeComponent();
            this.guna2TextBox1.Text = Account.HoTen;
            this.guna2TextBox2.Text = Account.NgaySinh.ToString();
            this.guna2TextBox3.Text = Account.TenDangNhap;
            this.guna2TextBox4.Text = Account.VaiTro;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void guna2Panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void guna2ImageButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageButtonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            TrangChu newform = new TrangChu();
            this.Hide();
            newform.ShowDialog();
            this.Close();
        }

        private void guna2ButtonLogout_Click(object sender, EventArgs e)
        {
            DangNhap newform = new DangNhap();
            this.Hide();
            newform.ShowDialog();
            this.Close();
        }

        private void guna2ButtonChangePass_Click(object sender, EventArgs e)
        {
            DoiMatKhau newform = new DoiMatKhau();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
    }
}
