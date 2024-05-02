using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class TiepNhanHocSinh : Form
    {
        public TrangChu formTNHocSinh { get; set; }

        public TiepNhanHocSinh(TrangChu mainform)
        {
            this.formTNHocSinh = mainform;
            InitializeComponent();
            this.uC_ThemHocSinhMoi1.Visible = true;
            this.uC_XemThongTinHocSinh1.Visible = false;
        }

        private void btnHomeScreen_Click(object sender, EventArgs e)
        {
            (this.formTNHocSinh as TrangChu).Show();
            this.Close();
        }

        private void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            if(this.uC_ThemHocSinhMoi1.Visible == false)
            {
                this.uC_ThemHocSinhMoi1.Visible = true;
                this.uC_XemThongTinHocSinh1.Visible = false;
            }
        }

        private void btnInteractStudentInfo_Click(object sender, EventArgs e)
        {
            if(this.uC_XemThongTinHocSinh1.Visible == false)
            {
                this.uC_XemThongTinHocSinh1.Visible = true;
                this.uC_ThemHocSinhMoi1.Visible = false;
            }
        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void mainLabelStdInfo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
