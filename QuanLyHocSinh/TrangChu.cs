
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
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            initialize();
        }

        void initialize()
        {
            guna2TextBoxUser.Text = Account.HoTen.ToString();
            if (Account.VaiTro == "Giáo viên")
            {
                this.MenuItemSubjectScore.Visible = true;
                this.MenuItemFinalReport.Visible = true;
            }
            else if (Account.VaiTro == "Người quản lý")
            {
                this.MenuItemListCreate.Visible = true;
                this.MenuItemAddStudent.Visible = true;
                this.MenuQuanLyQuyDinh.Visible = true;
                this.ToolStripMenuItemAccount.Visible = true;
            }
            this.MenuItemSearch.Visible = true;
            dataEntities dtb = new dataEntities();
            var ComboBoxYearsSource = from obj in dtb.NAMHOCs
                                      orderby obj.MaNamHoc descending
                                      select obj;
            guna2ComboBoxYear.DataSource = ComboBoxYearsSource.ToList();
            guna2ComboBoxYear.DisplayMember = "NamHoc1";
            guna2ComboBoxYear.ValueMember = "MaNamHoc";
        }

        private void MenuItemFinalReport_Click(object sender, EventArgs e)
        {
            BaoCaoTongKet newform = new BaoCaoTongKet();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }


        private void MenuItemAddStudent_Click(object sender, EventArgs e)
        {
            TiepNhanHocSinh newform = new TiepNhanHocSinh(this);
            this.Hide();
            newform.ShowDialog();
            initialize();
            this.Show();
        }


        private void MenuItemClassScore_Click(object sender, EventArgs e)
        {
            BangDiemTongKetLop newform = new BangDiemTongKetLop();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void MenuItemFindStudent_Click(object sender, EventArgs e)
        {
            TraCuuHocSinh newform = new TraCuuHocSinh(this);
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void MenuItemScoreBoard_Click(object sender, EventArgs e)
        {
            BangDiemHocSinh newform = new BangDiemHocSinh();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void MenuItemSubjectScore_Click(object sender, EventArgs e)
        {
            LapBangDiemMonHoc newform = new LapBangDiemMonHoc(this);
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void MenuItemSubjectScoreYear_Click(object sender, EventArgs e)
        {
            BangDiemMonHocCuaLopTrongNam newform = new BangDiemMonHocCuaLopTrongNam(this);
            this.Hide();
            newform.ShowDialog();
            this.Show();
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

        private void MenuQuanLyQuyDinh_Click(object sender, EventArgs e)
        {
            QuanLyQuyDinh newform = new QuanLyQuyDinh();
            this.Hide();
            newform.ShowDialog();
            initialize();
            this.Show();
        }

        private void MenuItemListCreate_Click(object sender, EventArgs e)
        {
            LapDanhSachLop newform = new LapDanhSachLop(this);
            this.Hide();
            newform.ShowDialog();
            initialize();
            this.Show();
        }

        private void guna2ButtonClass_Click(object sender, EventArgs e)
        {
            try
            {
                dataEntities dtb = new dataEntities();
                var Source = from cls in dtb.LOPs
                             where cls.MaNamHoc == guna2ComboBoxYear.SelectedValue.ToString()
                             select new { cls.MaLop, cls.TenLop, SoLuong = cls.SiSo };
                DataTable tbl = new DataTable();
                tbl.Columns.Add("STT", typeof(int));
                tbl.Columns.Add("Mã lớp", typeof(string));
                tbl.Columns.Add("Tên lớp", typeof(string));
                tbl.Columns.Add("Sĩ số", typeof(int));

                int index = 0;
                foreach (var item in Source)
                {
                    DataRow row = tbl.NewRow();
                    index += 1;
                    row["STT"] = index;
                    row["Mã lớp"] = item.MaLop.ToString();
                    row["Tên lớp"] = item.TenLop.ToString();
                    row["Sĩ số"] = (int)item.SoLuong;
                    tbl.Rows.Add(row);
                }

                guna2DataGridView.DataSource = tbl;
                guna2DataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

                guna2DataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
            catch
            {
                MessageBox.Show("Thao tác xảy ra lỗi, mời thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ButtonSubject_Click(object sender, EventArgs e)
        {
            try
            {
                dataEntities dtb = new dataEntities();
                var Source = dtb.MonHoc_NamApDung(guna2ComboBoxYear.SelectedValue.ToString()).Select(r => new { r.TenMonHoc, r.NamApDung });
                    
                DataTable tbl = new DataTable();
                tbl.Columns.Add("STT", typeof(int));
                tbl.Columns.Add("Tên môn học", typeof(string));
                tbl.Columns.Add("Năm áp dụng", typeof(string));

                int index = 0;
                foreach (var item in Source)
                {
                    DataRow row = tbl.NewRow();
                    index += 1;
                    row["STT"] = index;
                    row["Tên môn học"] = item.TenMonHoc.ToString();
                    row["Năm áp dụng"] = item.NamApDung.ToString();
                    tbl.Rows.Add(row);
                }

                guna2DataGridView.DataSource = tbl;
                guna2DataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
            catch
            {
                MessageBox.Show("Thao tác xảy ra lỗi, mời thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ImageButtonUser_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void taojToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaoTaiKhoan newform = new TaoTaiKhoan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
    }
}
