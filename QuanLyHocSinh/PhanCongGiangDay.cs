using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyHocSinh
{
    public partial class PhanCongGiangDay : Form
    {
        public PhanCongGiangDay()
        {
            InitializeComponent();
            dgvPhanCong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhanCong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataEntities data = new dataEntities();
            var ComboBoxYearSource = from obj in data.NAMHOCs orderby obj.NamHoc1 descending select obj;
            NamHocCbb.DataSource = ComboBoxYearSource.ToList();
            NamHocCbb.DisplayMember = "NamHoc1";
            NamHocCbb.ValueMember = "MaNamHoc";
        }

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gunaButtonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void gunaButtonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaButtonUser_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
        void PhanCong()
        {
            dataEntities dtb = new dataEntities();
            ComboBoxSubject.DataSource = null;
            var ComboBoxTeacherSource = from obj in dtb.GIAOVIENs select obj;
            ComboBoxName.DataSource = ComboBoxTeacherSource.ToList();
            ComboBoxName.DisplayMember = "HoTen";
            ComboBoxName.ValueMember = "MaGiaoVien";
            var ComboBoxClassSource = from obj in dtb.LOPs where obj.MaNamHoc == NamHocCbb.SelectedValue.ToString() select obj;
            ComboBoxClass.DataSource = ComboBoxClassSource.ToList();
            ComboBoxClass.DisplayMember = "TenLop";
            ComboBoxClass.ValueMember = "MaLop";
            LoadGrid();
            PanelInfo.Show();
        }

        void LoadGrid()
        {
            dataEntities dtb = new dataEntities();
            dgvPhanCong.Columns.Clear();
            dgvPhanCong.Rows.Clear();
            dgvPhanCong.Columns.Add("STT", "STT");
            dgvPhanCong.Columns.Add("MaGV", "Mã giáo viên");
            dgvPhanCong.Columns.Add("Hoten", "Tên giáo viên");
            dgvPhanCong.Columns.Add("MonHoc", "Môn học");
            dgvPhanCong.Columns.Add("Lop", "Lớp");
            var data = from obj in dtb.CTGIANGDAYs
                       join obj2 in dtb.MONHOCs on obj.MaMonHoc equals obj2.MaMonHoc
                       join obj3 in dtb.LOPs on obj.MaLop equals obj3.MaLop
                       join obj4 in dtb.GIAOVIENs on obj.MaGiaoVien equals obj4.MaGiaoVien
                       where obj3.MaNamHoc == NamHocCbb.SelectedValue.ToString()
                       select new { MaGiaoVien = obj4.MaGiaoVien, TenGiaoVien = obj4.HoTen, MonHoc = obj2.TenMonHoc, Lop = obj3.TenLop };
            for (int i = 0; i < data.Count(); i++)
            {
                DataGridViewRow newrow = new DataGridViewRow();
                newrow.CreateCells(dgvPhanCong);
                newrow.Cells[0].Value = i + 1;
                newrow.Cells[1].Value = data.ToList()[i].MaGiaoVien.ToString();
                newrow.Cells[2].Value = data.ToList()[i].TenGiaoVien.ToString();
                newrow.Cells[3].Value = data.ToList()[i].MonHoc.ToString();
                newrow.Cells[4].Value = data.ToList()[i].Lop.ToString();
                dgvPhanCong.Rows.Add(newrow);
            }
            dgvPhanCong.Show();
        }
        private void ComboBoxClass_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            if (ComboBoxClass.Text != string.Empty || ComboBoxClass.Text != "")
            {
                var ComboBoxSubjectsSource = from obj in dtb.MonHoc_NamApDung(NamHocCbb.SelectedValue.ToString())
                                             where obj.TenMonHoc.Substring(obj.TenMonHoc.Length - 2) == ComboBoxClass.Text.Substring(0, 2)
                                             select obj;
                ComboBoxSubject.DataSource = ComboBoxSubjectsSource.ToList();
                ComboBoxSubject.DisplayMember = "TenMonHoc";
                ComboBoxSubject.ValueMember = "MaMonHoc";
            }
            else
            {
                ComboBoxSubject.DataSource = null;
                ComboBoxSubject.Items.Clear();
            }
        }
        private void ComboBoxName_SelectedValueChanged(object sender, EventArgs e)
        {
            gunaTxbID.Text = ComboBoxName.SelectedValue.ToString();
        }
        private void TraCuuButton_hk_Click(object sender, EventArgs e)
        {
            PhanCong();
        }

        private void PictureBoxSave_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            if ((ComboBoxName.Text.ToString() == string.Empty) || (ComboBoxClass.Text.ToString() == string.Empty) || (ComboBoxName.Text.ToString() == string.Empty))
            {
                MessageBox.Show("Thông tin không đầy đủ", "Đã được phân công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            var check_1 = from obj in dtb.CTGIANGDAYs
                     where obj.MaGiaoVien == ComboBoxName.SelectedValue.ToString() && obj.MaLop == ComboBoxClass.SelectedValue.ToString()
                     select obj;
            var check_2 = from obj in dtb.CTGIANGDAYs
                          where obj.MaMonHoc == ComboBoxSubject.SelectedValue.ToString() && obj.MaLop == ComboBoxClass.SelectedValue.ToString()
                          select obj;
            if (check_1.Count() != 0 ) 
            {
                MessageBox.Show("Giáo viên đã được phân công cho lớp "+ ComboBoxClass.Text, "Đã được phân công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (check_2.Count()!=0)
            {
                MessageBox.Show("Môn học đã được phân công cho lớp giáo viên giảng dạy" + ComboBoxClass.Text, "Đã được phân công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            else
            {
                CTGIANGDAY new_pc = new CTGIANGDAY();
                string newMaGD = RandomString(9);
                while (dtb.CTGIANGDAYs.Where(x => x.MaCTGD == newMaGD).Select(x => x).Count() != 0)
                {
                    newMaGD = RandomString(9);
                }
                new_pc.MaCTGD = newMaGD;
                new_pc.MaGiaoVien = ComboBoxName.SelectedValue.ToString();
                new_pc.MaMonHoc = ComboBoxSubject.SelectedValue.ToString();
                new_pc.MaLop = ComboBoxClass.SelectedValue.ToString();
                dtb.CTGIANGDAYs.Add(new_pc);
                dtb.SaveChanges();
                MessageBox.Show("Lưu thay đổi thành công",
                                "Lưu thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                LoadGrid();
            }
        }

        private void NamHocCbb_SelectedValueChanged(object sender, EventArgs e)
        {
            dgvPhanCong.Hide();
            PanelInfo.Hide();
        }

        private void pictureBoxDelete_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            if ((ComboBoxName.Text.ToString() == string.Empty) || (ComboBoxClass.Text.ToString() == string.Empty) || (ComboBoxName.Text.ToString() == string.Empty))
            {
                MessageBox.Show("Thông tin không đầy đủ", "Đã được phân công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var check_1 = from obj in dtb.CTGIANGDAYs
                          where obj.MaGiaoVien == ComboBoxName.SelectedValue.ToString() && obj.MaLop == ComboBoxClass.SelectedValue.ToString() && obj.MaMonHoc == ComboBoxSubject.SelectedValue.ToString()
                          select obj;
            if (check_1.Count() == 0)
            {
                MessageBox.Show("Giáo viên chưa được phân vào lớp " + ComboBoxClass.Text, "Xóa thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CTGIANGDAY new_pc = new CTGIANGDAY();
                new_pc = check_1.First();
                dtb.CTGIANGDAYs.Remove(new_pc);
                dtb.SaveChanges();
                MessageBox.Show("Lưu thay đổi thành công",
                                "Lưu thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                LoadGrid();
            }
        }

        private void dgvPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name;
            if (e.RowIndex > -1 && dgvPhanCong.Rows[e.RowIndex].Cells[1].Value != null)
            {
                name = dgvPhanCong.Rows[e.RowIndex].Cells[1].Value.ToString();
                ComboBoxName.SelectedValue = name;
            }
            if (e.RowIndex > -1 && dgvPhanCong.Rows[e.RowIndex].Cells[4].Value != null)
            {
                name = dgvPhanCong.Rows[e.RowIndex].Cells[4].Value.ToString();
                ComboBoxClass.Text = name;
            }
            if (e.RowIndex > -1 && dgvPhanCong.Rows[e.RowIndex].Cells[3].Value != null)
            {
                name = dgvPhanCong.Rows[e.RowIndex].Cells[3].Value.ToString();
                ComboBoxSubject.Text = name;
            }
        }
    }
}
