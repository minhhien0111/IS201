using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class XepLoaiHanhKiem : Form
    {
        public XepLoaiHanhKiem()
        {
            InitializeComponent();
            dgvHocKy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHocKy.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataEntities data = new dataEntities();
            var ComboBoxYearSource = from obj in data.NAMHOCs orderby obj.NamHoc1 descending select obj;
            NamHocCbb_nh.DataSource = ComboBoxYearSource.ToList();
            NamHocCbb_nh.DisplayMember = "NamHoc1";
            NamHocCbb_nh.ValueMember = "MaNamHoc";
            NamHocCbb_hk.DataSource = ComboBoxYearSource.ToList();
            NamHocCbb_hk.DisplayMember = "NamHoc1";
            NamHocCbb_hk.ValueMember = "MaNamHoc";
            PanelInputSemester.Hide();
        }

        private void NamHocCbb_hk_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities data = new dataEntities();
            var ComboBoxSemesterSource = data.HocKy_NamApDung(NamHocCbb_hk.SelectedValue.ToString());
            var SemesterSource_temp = ComboBoxSemesterSource.ToList();
            HocKyCbb.DataSource = SemesterSource_temp;
            HocKyCbb.DisplayMember = "HocKy";
            HocKyCbb.ValueMember = "MaHocKy";
            var t = Account.MaTK.Substring(2);
            var ComboBoxClassSource = from obj in data.LOPs
                                      join cls in data.NAMHOCs on obj.MaNamHoc equals cls.MaNamHoc
                                      join cls2 in data.CTLOPGVs on obj.MaLop equals cls2.MaLop
                                      where cls.NamHoc1 == NamHocCbb_hk.Text && cls2.MaGVCN == t
                                      select obj;
            if (ComboBoxClassSource.Count() == 0 || SemesterSource_temp.Count() == 0)
            {
                TraCuuButton_hk.Visible = false;
            }
            else
            {
                TraCuuButton_hk.Visible = true;
            }
            LopCbb_hk.DataSource = ComboBoxClassSource.ToList();
            LopCbb_hk.DisplayMember = "TenLop";
            LopCbb_hk.ValueMember = "MaLop";
            PanelInputSemester.Hide();
        }
        public string get_NamApDung(string Nam)
        {
            dataEntities dtb = new dataEntities();
            var temp = from t in dtb.HANHKIEMs
                       where Nam.CompareTo(t.NamApDung) >= 0
                       select t.NamApDung;
            var NamApDung = temp.Distinct().OrderByDescending(r => r).First().ToString();
            /*MessageBox.Show(NamApDung, "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            return NamApDung;
        }
        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void NamHocCbb_nh_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities data = new dataEntities();
            var t = Account.MaTK.Substring(2);
            var ComboBoxClassSource = from obj in data.LOPs
                                      join cls in data.NAMHOCs on obj.MaNamHoc equals cls.MaNamHoc
                                      join cls2 in data.CTLOPGVs on obj.MaLop equals cls2.MaLop
                                      where cls.NamHoc1 == NamHocCbb_nh.Text && cls2.MaGVCN == t
                                      select obj;
            if (ComboBoxClassSource.Count() == 0)
            {
                TraCuuButton_nh.Visible = false;
            }
            else
            {
                TraCuuButton_nh.Visible = true;
            }
            LopCbb_nh.DataSource = ComboBoxClassSource.ToList();
            LopCbb_nh.DisplayMember = "TenLop";
            LopCbb_nh.ValueMember = "MaLop";
        }

        private void guna2ImageButtonMinimize1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButtonClose1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void TongKetNamHoc()
        {
            dataEntities dtb = new dataEntities();
            var MaNamHoc = from obj in dtb.NAMHOCs
                           where obj.NamHoc1 == NamHocCbb_hk.Text
                           select obj.MaNamHoc;

            var HoTen = from ctl in dtb.CTLOPs
                        join l in dtb.LOPs on ctl.MaLop equals l.MaLop
                        join hs in dtb.HOCSINHs on ctl.MaHocSinh equals hs.MaHocSinh
                        where l.MaLop == LopCbb_nh.SelectedValue && l.MaNamHoc == NamHocCbb_nh.SelectedValue
                        select new { HoTen = hs.HoTen, MaHS = hs.MaHocSinh };
            var hocki_ = from t in  dtb.HocKy_NamApDung(NamHocCbb_nh.SelectedValue.ToString()) select new {Mahk = t.MaHocKy};
            string namapdung = get_NamApDung(NamHocCbb_nh.SelectedValue.ToString());
            var TenHanhKiem = dtb.HANHKIEMs.Where(x => x.NamApDung == namapdung).Select(x => x);
            int[] hanhkiem = new int[TenHanhKiem.Count() - 1];
            hocki_ = hocki_.ToList();
            dgvNamHoc.Columns.Clear();
            dgvNamHoc.Rows.Clear();
            dgvNamHoc.Columns.Add("STT", "STT");
            dgvNamHoc.Columns.Add("Hoten", "Họ và tên");
            dgvNamHoc.Columns.Add("HanhKiem", "Hạnh kiểm");
            dgvNamHoc.Columns[dgvNamHoc.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (HoTen.Count() == 0)
            {
                labelName_nh.Text = $"Không tìm thấy dữ liệu";
                labelName_nh.Show();
                dgvNamHoc.Visible = false;
                dgvRatio_nh.Visible = false;
                chartRatio_nh.Visible = false;
                label2.Visible = false;
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Không tìm thấy dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = 0; i < HoTen.Count(); i++)
            {
                DataGridViewRow newrow = new DataGridViewRow();
                newrow.CreateCells(dgvNamHoc);
                newrow.Cells[0].Value = i + 1;
                newrow.Cells[1].Value = HoTen.ToList()[i].HoTen.ToString();
                string mhs = HoTen.ToList()[i].MaHS.ToString();
                var tempHK = from cthk in dtb.CTHKs
                             join hk in dtb.HANHKIEMs on cthk.MaHanhKiem equals hk.MaHanhKiem
                             where cthk.MaNamHoc == NamHocCbb_nh.SelectedValue.ToString() && cthk.MaHocSinh == mhs
                             select new {MaCT = cthk.MaCTHK, MaHocSinh = cthk.MaHocSinh, MaNamHoc = cthk.MaNamHoc, MaHanhKiem = cthk.MaHanhKiem, Diem = hk.Diem, HanhKiem = hk.TenHanhKiem };
/*                MessageBox.Show(tempHK.Count().ToString(), "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                if (tempHK.Count() == 0)
                    newrow.Cells[2].Value = "";
                else if(tempHK.Count() != hocki_.Count())
                {
                    newrow.Cells[2].Value = "Chưa đánh giá";
                }    
                else 
                {
                    var check_Null = tempHK.Where(x => x.HanhKiem == "Chưa đánh giá").Select(x => x);
                    if (check_Null.Count() != 0)
                    {
                        newrow.Cells[2].Value = "Chưa đánh giá";
                    }
                    else
                    {
                        var grpCTHK = tempHK.GroupBy(x => new { x.MaHocSinh, x.MaNamHoc }).Select(g => new
                        {
                            MaHS = g.Key.MaHocSinh,
                            MaNamHoc = g.Key.MaNamHoc,
                            TongDiem = (int)(g.Average(x => x.Diem)),
                        });
                        var grpCTHK_2 = from gCT in grpCTHK
                                        join hk in dtb.HANHKIEMs on gCT.TongDiem equals hk.Diem
                                        where hk.NamApDung == namapdung
                                        select new { MaHS = gCT.MaHS, HanhKiem = hk.TenHanhKiem, Diem = hk.Diem };
                        newrow.Cells[2].Value = grpCTHK_2.First().HanhKiem.ToString();
                        int temp_index_hanhkiem = (int)(grpCTHK_2.First().Diem) - 1;
                        hanhkiem[temp_index_hanhkiem] += 1;
                    }
/*                    MessageBox.Show(grpCTHK.First().TongDiem.ToString(), "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                }
                dgvNamHoc.Rows.Add(newrow);
            }
            dgvNamHoc.Show();
            var NamHoc = from obj in dtb.NAMHOCs
                         where obj.MaNamHoc == NamHocCbb_nh.SelectedValue.ToString()
                         select obj.NamHoc1;
            labelName_nh.Text = $"BẢNG THỐNG KÊ LỚP {LopCbb_nh.Text}";
            labelName_nh.Show();

            DataTable ratio_Source = new DataTable();
            ratio_Source.Columns.Add("Hạnh kiểm", typeof(string));
            ratio_Source.Columns.Add("Số lượng", typeof(int));
            ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
            foreach (var item in dtb.HANHKIEMs.Where(x => x.NamApDung == namapdung && x.TenHanhKiem != "Chưa đánh giá").Select(x => x).OrderByDescending(r => r.Diem))
            {
                DataRow row_ratio = ratio_Source.NewRow();
                row_ratio["Hạnh kiểm"] = item.TenHanhKiem;

                row_ratio["Số lượng"] = hanhkiem[(int)item.Diem - 1];
                double rat = 0;
                if (hanhkiem.Sum() == 0) rat = 0;
                else rat = Math.Round((float)(100 * hanhkiem[(int)item.Diem - 1] / hanhkiem.Sum()), 2);
                row_ratio["Tỉ lệ (%)"] = rat;
                if (rat > 0)
                    ratio_Source.Rows.Add(row_ratio);
            }

            dgvRatio_nh.DataSource = ratio_Source;
            dgvRatio_nh.Show();

            chartRatio_nh.DataSource = ratio_Source;
            chartRatio_nh.Series[0].XValueMember = "Hạnh kiểm";
            chartRatio_nh.Series[0].YValueMembers = "Tỉ lệ (%)";
            chartRatio_nh.Series[0].IsValueShownAsLabel = true;
            label2.Visible = true;
            chartRatio_nh.Show();
        }
        private void TraCuuButton_nh_Click(object sender, EventArgs e)
        {
            TongKetNamHoc();
        }
        private void comboBoxID_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities data = new dataEntities();
            var a = from obj in data.HOCSINHs where obj.MaHocSinh == ComboBoxID.Text select obj.HoTen;
            TextBoxName.Text = a.ToList().SingleOrDefault();
            var reSource1 = from scr in data.CTHKs
                            join cls1 in data.HANHKIEMs on scr.MaHanhKiem equals cls1.MaHanhKiem
                            join cls2 in data.HOCSINHs on scr.MaHocSinh equals cls2.MaHocSinh
                            where ComboBoxID.Text == scr.MaHocSinh && NamHocCbb_hk.SelectedValue == scr.MaNamHoc && HocKyCbb.SelectedValue == scr.MaHocKy
                            select new {HoTen = cls2.HoTen, HanhKiem = cls1.TenHanhKiem };
            if (reSource1.Count() != 0)
            {
                string maKQ = reSource1.ToList().SingleOrDefault().HanhKiem;
                ComboBoxClassify.Text = reSource1.ToList().SingleOrDefault().HanhKiem.ToString();
            }
            else
            {
                var namapdung = get_NamApDung(NamHocCbb_hk.SelectedValue.ToString());
                var ChuaDG = data.HANHKIEMs.Where(x => x.NamApDung == namapdung && x.TenHanhKiem == "Chưa đánh giá").Select(x => x.MaHanhKiem).First().ToString();
                ComboBoxClassify.SelectedValue = ChuaDG;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name;
            if (e.RowIndex > -1 && dgvHocKy.Rows[e.RowIndex].Cells[1].Value != null)
            {
                name = dgvHocKy.Rows[e.RowIndex].Cells[1].Value.ToString();
                ComboBoxID.Text = name;
            }

        }
        void TongKetHocKy()
        {
            dataEntities dtb = new dataEntities();
            string namapdung = get_NamApDung(NamHocCbb_hk.SelectedValue.ToString());
            var comboClassify = from obj in dtb.HANHKIEMs
                                where obj.NamApDung == namapdung
                                select new { TenHanhKiem = obj.TenHanhKiem, MaHanhKiem = obj.MaHanhKiem };
            ComboBoxClassify.DataSource = comboClassify.ToList();
            ComboBoxClassify.DisplayMember = "TenHanhKiem";
            ComboBoxClassify.ValueMember = "MaHanhKiem";
            TextBoxName.Text = string.Empty;
            var comboxID = from obj in dtb.CTLOPs
                           join obj1 in dtb.LOPs on obj.MaLop equals obj1.MaLop
                           where obj.MaLop == LopCbb_hk.SelectedValue.ToString() && obj1.MaNamHoc == NamHocCbb_hk.SelectedValue.ToString()
                           select obj.MaHocSinh;
            ComboBoxID.DataSource = comboxID.ToList();

            var HoTen = from ctl in dtb.CTLOPs
                        join l in dtb.LOPs on ctl.MaLop equals l.MaLop
                        join nh in dtb.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                        join hs in dtb.HOCSINHs on ctl.MaHocSinh equals hs.MaHocSinh
                        where l.TenLop == LopCbb_hk.Text && nh.NamHoc1 == NamHocCbb_hk.Text
                        select new { HoTen = hs.HoTen, MaHS = hs.MaHocSinh };
            dgvHocKy.Columns.Clear();
            dgvHocKy.Rows.Clear();
            dgvHocKy.Columns.Add("STT", "STT");
            dgvHocKy.Columns.Add("MaHS", "Mã học sinh");
            dgvHocKy.Columns.Add("Hoten", "Họ và tên");
            dgvHocKy.Columns.Add("HanhKiem", "Hạnh kiểm");
            dgvHocKy.Columns[dgvHocKy.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            if (HoTen.Count() == 0) 
            {
                labelName.Text = $"Không tìm thấy dữ liệu";
                labelName.Show();
                dgvHocKy.Visible = false;
                PanelInfo.Visible = false;
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp", "Không tìm thấy dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                dgvHocKy.Visible = true;
                PanelInfo.Visible = true;
            }
            for (int i = 0; i < HoTen.Count(); i++)
            {
                DataGridViewRow newrow = new DataGridViewRow();
                newrow.CreateCells(dgvHocKy);
                newrow.Cells[0].Value = i + 1;
                newrow.Cells[1].Value = HoTen.ToList()[i].MaHS.ToString();
                newrow.Cells[2].Value = HoTen.ToList()[i].HoTen.ToString();
                string mhs = HoTen.ToList()[i].MaHS.ToString();
                var tempHK = from cthk in dtb.CTHKs
                             join hk in dtb.HANHKIEMs on cthk.MaHanhKiem equals hk.MaHanhKiem
                             where cthk.MaHocKy == HocKyCbb.SelectedValue.ToString() && cthk.MaNamHoc == NamHocCbb_hk.SelectedValue.ToString() && cthk.MaHocSinh == mhs
                             select new {HanhKiem = hk.TenHanhKiem};
                if (tempHK.Count() == 0 )
                    newrow.Cells[3].Value = "Chưa đánh giá";
                else newrow.Cells[3].Value = tempHK.First().HanhKiem.ToString();
                dgvHocKy.Rows.Add(newrow);
            }
            dgvHocKy.Show();
            var NamHoc = from obj in dtb.NAMHOCs
                         where obj.MaNamHoc == NamHocCbb_hk.Text
                         select obj.NamHoc1;
            labelName.Text = $"BẢNG THỐNG KÊ LỚP {LopCbb_hk.Text}";
            labelName.Show();
            PanelInputSemester.Show();
        }

        private void TraCuuButton_hk_Click(object sender, EventArgs e)
        {
            TongKetHocKy();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void PictureBoxSave_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            if ((ComboBoxID.Text.ToString() == string.Empty) || (ComboBoxClassify.Text.ToString() == string.Empty) || (TextBoxName.Text.ToString() == string.Empty))
            {
                MessageBox.Show("Thông tin không đầy đủ", "Chỉnh sửa điểm hạnh kiểm không thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var cthk = from obj in dtb.CTHKs
                           where obj.MaHocSinh == ComboBoxID.Text && obj.MaHocKy == HocKyCbb.SelectedValue.ToString() && obj.MaNamHoc == NamHocCbb_hk.SelectedValue.ToString()
                           select obj;
            if (cthk.Count() != 0)
            {
                var newCTHK_2 = dtb.CTHKs.First(m => m.MaHocSinh == ComboBoxID.Text && m.MaHocKy == HocKyCbb.SelectedValue.ToString() && m.MaNamHoc == NamHocCbb_hk.SelectedValue.ToString());
                newCTHK_2.MaHanhKiem = ComboBoxClassify.SelectedValue.ToString();
                dtb.CTHKs.AddOrUpdate(newCTHK_2);
                dtb.SaveChanges();
                MessageBox.Show("Lưu thay đổi thành công",
                "Lưu thành công",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                TongKetHocKy();
            }
            else
            {
                CTHK newCTHK = new CTHK();
                string newMaCTHK = RandomString(9);
                while(dtb.CTHKs.Where(x => x.MaCTHK == newMaCTHK).Select(x => x).Count() != 0) 
                {
                    newMaCTHK = RandomString(9);
                }
                newCTHK.MaCTHK = newMaCTHK;
                newCTHK.MaHocSinh = ComboBoxID.Text;
                newCTHK.MaNamHoc = NamHocCbb_hk.SelectedValue.ToString();
                newCTHK.MaHocKy = HocKyCbb.SelectedValue.ToString();
                newCTHK.MaHanhKiem = ComboBoxClassify.SelectedValue.ToString();
                dtb.CTHKs.Add(newCTHK);
                dtb.SaveChanges();
                MessageBox.Show("Lưu thay đổi thành công",
                                "Lưu thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                TongKetHocKy();
            }
        }

        private void HocKyCbb_SelectedValueChanged(object sender, EventArgs e)
        {
            PanelInputSemester.Hide();
        }

        private void LopCbb_hk_SelectedValueChanged(object sender, EventArgs e)
        {
            PanelInputSemester.Hide();
        }
    }
}
