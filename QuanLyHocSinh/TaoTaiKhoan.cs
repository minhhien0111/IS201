using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;

namespace QuanLyHocSinh
{
    public partial class TaoTaiKhoan : Form
    {
        public TaoTaiKhoan()
        {
            InitializeComponent();
            var dtb = new dataEntities();
            var comboBoxSource = dtb.PHANQUYENs.Where(x => x.MaPhanQuyen != "QL").Select(x => x);
            guna2ComboBox1.DataSource = comboBoxSource.ToList();
            guna2ComboBox1.ValueMember = "MaPhanQuyen";
            guna2ComboBox1.DisplayMember = "VaiTro";
        }

        private void guna2ButtonAccount_Click(object sender, EventArgs e)
        {
            label6.Hide();
            label7.Hide();
            if (txbMaPQ.Text == "" || guna2TextBox3.Text == "" || guna2TextBox4.Text == "")
            {
                label6.Show();
                txbMaPQ.Text = "";
                guna2TextBox3.Text = "";
                guna2TextBox4.Text = "";
            }
            else
            {
                var dtb = new dataEntities();
                var check_source = dtb.TAIKHOANs.Select(r => r.TenDangNhap).ToList();
                bool check = true;
                var check_gv = dtb.GIAOVIENs.Where(x => x.MaGiaoVien == txbMaPQ.Text).Select(r => r).ToList();
                var check_hs = dtb.HOCSINHs.Where(x => x.MaHocSinh == txbMaPQ.Text).Select(r => r).ToList();
                string HoTen = "";
                DateTime NgaySinh = DateTime.Now;
                string temp_matk = "";
                if (guna2ComboBox1.SelectedValue.ToString() == "GV")
                {
                    if (check_gv.Count == 0)
                    {
                        check = false;
                        MessageBox.Show("Giáo viên không tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        temp_matk = "GV";
                        HoTen = check_gv.First().HoTen;
                        NgaySinh = check_gv.First().NgaySinh ?? DateTime.Now;
                    }
                }
                else
                {
                    HoTen = check_hs.First().HoTen;
                    NgaySinh = check_hs.First().NgaySinh ?? DateTime.Now;
                    if (check_hs.First().HoTen == null)
                    {
                        check = false;
                        MessageBox.Show("Học sinh không tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }    
                    if (check_hs.Count == 0)
                    {
                        check = false;
                        MessageBox.Show("Học sinh không tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        temp_matk = "HS";
                        HoTen = check_hs.First().HoTen;
                        NgaySinh = check_hs.First().NgaySinh ?? DateTime.Now;
                    }
                }    
                foreach (var item in check_source)
                {
                    if (guna2TextBox3.Text == item.ToString())
                    {
                        label7.Show();
                        guna2TextBox3.Text = "";
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    try
                    {
                        var account = new TAIKHOAN();
                        account.HoTen = HoTen;
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        if (guna2TextBox3.Text.ToString().Length >= 60 || guna2TextBox4.Text.Length >= 60)
                        {
                            MessageBox.Show("Tên đăng nhập và mật khẩu phải dưới 60 kí tự", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }    
                        /*account.NgaySinh = DateTime.ParseExact(guna2TextBox2.Text, "dd/MM/yyyy", provider);*/
                        account.NgaySinh = NgaySinh;
                        account.MaPhanQuyen = guna2ComboBox1.SelectedValue.ToString();
                        account.TenDangNhap = guna2TextBox3.Text;
                        account.MatKhau = guna2TextBox4.Text;
                        /*var MaTK = dtb.TAIKHOANs.Where(r => r.MaPhanQuyen == account.MaPhanQuyen).OrderByDescending(r => r.MaTaiKhoan).Select(r => r.MaTaiKhoan).FirstOrDefault();
                        
                        int num = Convert.ToInt32(MaTK.Substring(2));
                        num += 1;*/
                        string MaTK = temp_matk + txbMaPQ.Text;
                        account.MaTaiKhoan = MaTK;
                        dtb.TAIKHOANs.Add(account);
                        dtb.SaveChanges();
                        MessageBox.Show("Tạo tài khoản thành công!");
                    }
                    catch
                    {
                        MessageBox.Show("Học sinh/Giáo viên này đã có tài khoản");
                    }
                }
            }
        }

        private void guna2ImageButtonMinimize1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButtonClose1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
