using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class QuanLyQuyDinh : Form
    {
        public QuanLyQuyDinh()
        {
            InitializeComponent();
            PanelDsQuydinh.Hide();
            dataEntities dtb = new dataEntities();
            //Danh sách lớp
            var dsLop = from obj in dtb.LOPs
                        where obj.TenLop != null && obj.MaNamHoc == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                        select new {TenLop = obj.TenLop };
            dgvDSLOP.DataSource = dsLop.ToList();
            dgvDSLOP.Show();
            //Danh sách khối
            var dsKhoi = from obj in dtb.KHOIs
                         where obj.TenKhoi != null && obj.MaNamHoc == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                         select new {TenKhoi = obj.TenKhoi };
            dgvDSKHOI.DataSource = dsKhoi.ToList();
            dgvDSKHOI.Show();
            //Danh sách môn học
            var dsMonhoc = from obj in dtb.MONHOCs
                           where obj.TenMonHoc != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                           select new {TenMonHoc = obj.TenMonHoc };
            dgvDSMONHOC.DataSource = dsMonhoc.ToList();
            dgvDSMONHOC.Show();
            //Danh sách điểm thành phần
            var dsDiemTP = from obj in dtb.THANHPHANs
                           where obj.TenThanhPhan != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                           select new {TenThanhPhan = obj.TenThanhPhan, TrongSo = obj.TrongSo };
            dgvDiemthanhphan.DataSource = dsDiemTP.ToList();
            dgvDiemthanhphan.Show();
            //Danh sách xếp loại
            var dsXeploai = from obj in dtb.XEPLOAIs
                            where obj.TenXepLoai != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                            && obj.TenXepLoai != "Không"
                            select new { TenXepLoai = obj.TenXepLoai, DiemToiThieu = obj.DiemToiThieu, DiemToiDa = obj.DiemToiDa, DiemKhongChe = obj.DiemKhongChe };
            dgvXepLoai.DataSource = dsXeploai.ToList();
            dgvXepLoai.Show();
            //Danh sách điểm học kỳ
            var dsDiemHK = from obj in dtb.HOCKies
                           where obj.HocKy1 != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                           select new { HocKy1 = obj.HocKy1, TrongSo = obj.TrongSo };
            dgvDiemHK.DataSource = dsDiemHK.ToList();
            dgvDiemHK.Show();
            //Load quy định tuổi tiếp nhận học sinh
            var min_Tuoi = from obj in dtb.THAMSOes
                           select obj.TuoiToiThieu;
            TuoiToiThieutxtbox.Text = min_Tuoi.First().ToString();
            var max_Tuoi = from obj in dtb.THAMSOes
                           select obj.TuoiToiDa;
            TuoiToiDatxtbox.Text = max_Tuoi.First().ToString();
            //Load sĩ số tối đa của lớp
            var max_Siso = from obj in dtb.THAMSOes
                           select obj.SiSoToiDa;
            Sisotextbox.Text = max_Siso.First().ToString();
        }

        private void dgvDSLOP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TenLoptextbox.Text = dgvDSLOP.CurrentRow.Cells[0].Value.ToString();
        }

        private void dgvDSKHOI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TenKhoitextbox.Text = dgvDSKHOI.CurrentRow.Cells[0].Value.ToString();
        }

        private void dgvDSMONHOC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Tenmhtextbox.Text = dgvDSMONHOC.CurrentRow.Cells[0].Value.ToString();
        }
        private void dgvDiemthanhphan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TenTPtextbox.Text = dgvDiemthanhphan.CurrentRow.Cells[0].Value.ToString();
            TrongsoTPtextbox.Text = dgvDiemthanhphan.CurrentRow.Cells[1].Value.ToString();
        }
        private void dgvXepLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Tenxeploaitextbox.Text = dgvXepLoai.CurrentRow.Cells[0].Value.ToString();
            minDiemtextbox.Text = dgvXepLoai.CurrentRow.Cells[1].Value.ToString();
            maxDiemtextbox.Text = dgvXepLoai.CurrentRow.Cells[2].Value.ToString();
            DiemKCtextbox.Text = dgvXepLoai.CurrentRow.Cells[3].Value.ToString();
        }
        private void dgvDiemHK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HocKytextbox.Text = dgvDiemHK.CurrentRow.Cells[0].Value.ToString();
            TrongSoHKtextbox.Text = dgvDiemHK.CurrentRow.Cells[1].Value.ToString();
        }
        //Thêm năm học mới
        //Lưu mã năm học mới
        string MaNamHoc_moi;
        private void AddNamhoc_button_Click(object sender, EventArgs e)
        {
            string namhoc = Namhoctextbox.Text;
            string pattern = @"^20\d{2}-20\d{2}$";
            bool isMatch = Regex.IsMatch(namhoc, pattern);
            string manamhoc = "";
            if (namhoc.Length == 9 && isMatch)
            {
                manamhoc = "NH" + namhoc[2] + namhoc[3] + namhoc[7] + namhoc[8];
                MaNamHoc_moi = manamhoc;
                using (var dtb = new dataEntities())
                {
                    bool check_namhoc = true;
                    var ds_namhoc = dtb.NAMHOCs.Select(r => r.NamHoc1).ToList();
                    for (int i = 0; i < ds_namhoc.Count; i++)
                    {
                        if (ds_namhoc[i] == namhoc) { check_namhoc = false; break; }
                    }
                    if (check_namhoc)
                    {
                        NAMHOC new_item = new NAMHOC();
                        new_item.MaNamHoc = manamhoc;
                        new_item.NamHoc1 = namhoc;
                        dtb.NAMHOCs.Add(new_item);
                        //dtb.SaveChanges();
                        MessageBox.Show("Thêm năm học thành công!");
                        // Xuất danh sách môn học áp dụng cho năm học
                        var dsMonhoc = from obj in dtb.MonHoc_NamApDung(MaNamHoc_moi)
                                       select new {TenMonHoc = obj.TenMonHoc };
                        dgvDSMONHOC.DataSource = dsMonhoc.ToList();
                        dgvDSMONHOC.Show();
                        //Thêm các lớp của năm học mới.
                        string MaNamHoc_Truoc = dtb.NAMHOCs.AsEnumerable().LastOrDefault().MaNamHoc.ToString();
                        foreach (var i in dtb.KHOIs)
                        {
                            if (i.MaNamHoc == MaNamHoc_Truoc)
                            {
                                KHOI new_khoi = new KHOI();
                                new_khoi.MaKhoi = manamhoc.Substring(2, 2) + i.MaKhoi.Substring(2);
                                new_khoi.TenKhoi = i.TenKhoi;
                                new_khoi.MaNamHoc = manamhoc;
                                dtb.KHOIs.Add(new_khoi);
                            }
                        }
                        foreach (var i in dtb.LOPs)
                        {
                            if (i.MaNamHoc == MaNamHoc_Truoc)
                            {
                                var check_khoi = dtb.KhoiLop_NamApDung(manamhoc).Where(p => p.TenKhoi == i.MaKhoi.Substring(2, 2));
                                int count = check_khoi.Count();
                                if (count > 0)
                                {
                                    LOP new_class = new LOP();
                                    new_class.MaLop = manamhoc.Substring(2,2) + i.MaLop.Substring(2);
                                    new_class.TenLop = i.TenLop;                     
                                    new_class.MaKhoi = manamhoc.Substring(2,2)+i.MaKhoi.Substring(2,2);
                                    new_class.SiSo = 0;
                                    new_class.MaNamHoc = manamhoc;
                                    dtb.LOPs.Add(new_class);
                                }
                            }
                        }
                        dtb.SaveChanges();
                        var dsKHOI = from obj in dtb.KHOIs
                                     where obj.TenKhoi != null && obj.MaNamHoc == MaNamHoc_moi
                                     select new { TenKhoi = obj.TenKhoi };
                        dgvDSKHOI.DataSource = dsKHOI.ToList();
                        dgvDSKHOI.Show();
                        var dsLop = from obj in dtb.LOPs
                                    where obj.TenLop != null && obj.MaNamHoc == MaNamHoc_moi
                                    select new { TenLop = obj.TenLop };
                        dgvDSLOP.DataSource = dsLop.ToList();
                        dgvDSLOP.Show();
                        PanelDsQuydinh.Show();
                    }
                    else MessageBox.Show("Năm học đã tồn tại!");
                };
            }
            else MessageBox.Show("Năm học không hợp lệ!");
        }
        //Thay đổi quy định tiếp nhận học sinh
        private void updateTuoi_button_Click(object sender, EventArgs e)
        {
            using(var context = new dataEntities())
            {
                var std = context.THAMSOes.First();
                Byte toithieu = Convert.ToByte(TuoiToiThieutxtbox.Text);
                Byte toida = Convert.ToByte(TuoiToiDatxtbox.Text);
                if (toithieu > 0 && toida >0 && toithieu <= toida)
                {
                    std.TuoiToiThieu = Convert.ToByte(TuoiToiThieutxtbox.Text);
                    std.TuoiToiDa = Convert.ToByte(TuoiToiDatxtbox.Text);
                    context.SaveChanges();
                    MessageBox.Show("Cập nhật quy định thành công!");
                }
                else
                {
                    MessageBox.Show("Tuổi phải lớn hơn 0 và tuổi tối thiểu phải bé hơn hoặc bằng tuổi tối đa!");
                }    
            }
        }
        //Thay đổi quy định lập danh sách lớp
        private void updateSiso_button_Click(object sender, EventArgs e)
        {
            using(var context = new dataEntities())
            {
                var std = context.THAMSOes.First();
                byte a;
                if (Byte.TryParse(Sisotextbox.Text, out a) && Convert.ToByte(Sisotextbox.Text) > 0)
                {
                    std.SiSoToiDa = Convert.ToByte(Sisotextbox.Text);
                    context.SaveChanges();
                    MessageBox.Show("Cập nhật quy định thành công!");
                }    
                else MessageBox.Show("Sĩ số tối đa của lớp phải là số nguyên dương!");
            }
        }

        //Thay đổi danh sách lớp
        private void AddLop_button_Click(object sender, EventArgs e)
        {
            string year = Namhoctextbox.Text;
            string tenlop = TenLoptextbox.Text;
            string malop = MaNamHoc_moi.Substring(2, 2) + TenLoptextbox.Text;
            if(tenlop.Length != 4)
            {
                MessageBox.Show("Tên lớp không hợp lệ!");
                return;
            }
            using (var dtb = new dataEntities())
            {
                var ds_tenlop = dtb.LOPs.Select(r => r.TenLop).ToList();
                bool check_tenlop = true;
                for(int i = 0;i < ds_tenlop.Count;i++)
                {
                    if (ds_tenlop[i] == tenlop) { check_tenlop = false;}
                }
                if (check_tenlop)
                {
                    var makhoi = dtb.KhoiLop_NamApDung(MaNamHoc_moi).Where(r => r.TenKhoi == tenlop.Substring(0, 2)).FirstOrDefault();
                    if(makhoi == null)
                    {
                        MessageBox.Show("Không tồn tại khối " + tenlop.Substring(0, 2));
                        return;
                    }
                    var namhoc = dtb.NAMHOCs.Where(r => r.NamHoc1 == year).First();
                    LOP new_item = new LOP();
                    new_item.MaLop = malop;
                    new_item.TenLop = tenlop;
                    new_item.MaKhoi = makhoi.MaKhoi;
                    new_item.MaNamHoc = MaNamHoc_moi;
                    dtb.LOPs.Add(new_item);
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách lớp thành công!");
                }
                else if (!check_tenlop) MessageBox.Show("Tên lớp đã tồn tại!");
                var dsLop = from obj in dtb.LOPs
                            where obj.TenLop != null && obj.MaNamHoc == MaNamHoc_moi
                            select new { TenLop = obj.TenLop };
                dgvDSLOP.DataSource = dsLop.ToList();
                dgvDSLOP.Show();
            }
        }
        private void DeleteLop_button_Click(object sender, EventArgs e)
        {
            string ten_lop = dgvDSLOP.CurrentRow.Cells[0].Value.ToString();
            using (var dtb = new dataEntities())
            {
                LOP std = dtb.LOPs.Where(r => r.TenLop == ten_lop && r.MaNamHoc == MaNamHoc_moi).First();
                dtb.LOPs.Remove(std);
                dtb.SaveChanges();
                MessageBox.Show("Cập nhật danh sách lớp thành công!");
                TenLoptextbox.Text = null;
                var dsLop = from obj in dtb.LOPs
                            where obj.TenLop != null && obj.MaNamHoc == MaNamHoc_moi
                            select new {TenLop = obj.TenLop };
                dgvDSLOP.DataSource = dsLop.ToList();
                dgvDSLOP.Show();
            }
        }
        private void EditLop_button_Click(object sender, EventArgs e)
        {
            string ten_lop = dgvDSLOP.CurrentRow.Cells[0].Value.ToString();
            string tenlop = TenLoptextbox.Text;
            if (tenlop.Length != 4)
            {
                MessageBox.Show("Tên lớp không hợp lệ!");
                return;
            }
            using (var dtb = new dataEntities())
            {
                bool check_tenlop = true;
                var ds_tenlop = dtb.LOPs.Select(r => r.TenLop).ToList();
                for (int i = 0; i < ds_tenlop.Count;i++)
                {
                    if (ds_tenlop[i] == tenlop) { check_tenlop = false; break;}
                }
                if (check_tenlop)
                {
                    var std = dtb.LOPs.Where(r => r.TenLop == ten_lop && r.MaNamHoc==MaNamHoc_moi).First();
                    std.TenLop = TenLoptextbox.Text;
                    dtb.SaveChanges();
                    MessageBox.Show("Cập nhật danh sách lớp thành công!");
                }
                else MessageBox.Show("Tên lớp đã tồn tại!");
                var dsLop = from obj in dtb.LOPs
                            where obj.TenLop != null && obj.MaNamHoc == MaNamHoc_moi
                            select new {TenLop = obj.TenLop };
                dgvDSLOP.DataSource = dsLop.ToList();
                dgvDSLOP.Show();
            }
        }

        //Thay đổi danh sách khối
        private void AddKhoi_button_Click(object sender, EventArgs e)
        {
            string tenkhoi = TenKhoitextbox.Text;
            if (tenkhoi.Length == 0)
            {
                MessageBox.Show("Tên khối không hợp lệ!");
                return;
            }
            using (var dtb = new dataEntities())
            {
                string subMaNamHoc = MaNamHoc_moi.Substring(2, 2);
                var ds_tenkhoi = dtb.KHOIs.Where(p=>p.MaNamHoc==MaNamHoc_moi).Select(r => r.TenKhoi).ToList();
                bool check_tenkhoi = true;
                string makhoi = subMaNamHoc + tenkhoi;
                for (int i = 0; i < ds_tenkhoi.Count; i++)
                {
                    if (ds_tenkhoi[i] == tenkhoi) { check_tenkhoi = false; }
                }
                if (check_tenkhoi)
                {
                    KHOI new_item = new KHOI();
                    new_item.TenKhoi = tenkhoi;
                    new_item.MaKhoi = makhoi;
                    new_item.MaNamHoc = MaNamHoc_moi;
                    dtb.KHOIs.Add(new_item);
                    MessageBox.Show("Cập nhật danh sách khối thành công!");

                }
                else if (!check_tenkhoi) MessageBox.Show("Tên khối đã tồn tại!");

                dtb.SaveChanges();
                var dsKhoi = from obj in dtb.KHOIs
                             where obj.TenKhoi != null && obj.MaNamHoc == MaNamHoc_moi
                             select new {TenKhoi = obj.TenKhoi };
                dgvDSKHOI.DataSource = dsKhoi.ToList();
                dgvDSKHOI.Show();
            }
        }
        private void EditKhoi_button_Click(object sender, EventArgs e)
        {
            var dtb = new dataEntities();

            string subMaNamHoc = MaNamHoc_moi.Substring(2, 2);
            string ten_khoi = dgvDSKHOI.CurrentRow.Cells[0].Value.ToString();
            string tenkhoi = TenKhoitextbox.Text;
            if (tenkhoi.Length == 0)
            {
                MessageBox.Show("Tên khối không hợp lệ!");
                return;
            }
            var ds_tenkhoi = dtb.KHOIs.Where(p=>p.MaNamHoc == MaNamHoc_moi).Select(r => r.TenKhoi).ToList();
            bool check_tenkhoi = true;
            for (int i = 0; i < ds_tenkhoi.Count; i++)
            {
                if (ds_tenkhoi[i] == tenkhoi) { check_tenkhoi = false; break; }
            }
            if (check_tenkhoi)
            {

                var std = dtb.KHOIs.Where(r => r.TenKhoi == ten_khoi && r.MaNamHoc == MaNamHoc_moi).First();
                std.TenKhoi = TenKhoitextbox.Text;
                dtb.SaveChanges();

                MessageBox.Show("Cập nhật danh sách khối lớp thành công!");
            }
            else MessageBox.Show("Tên khối đã tồn tại!");
            var dsKhoi = from obj in dtb.KHOIs
                         where obj.TenKhoi != null && obj.MaNamHoc == MaNamHoc_moi
                         select new { TenKhoi = obj.TenKhoi };
            dgvDSKHOI.DataSource = dsKhoi.ToList();
            dgvDSKHOI.Show();
        }

        private void DeleteKhoi_button_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            string tenkhoi = dgvDSKHOI.CurrentRow.Cells[0].Value.ToString();
            string makhoi = MaNamHoc_moi.Substring(2,2)+tenkhoi;
            var std = dtb.KHOIs.Where(r => r.MaKhoi == makhoi).First();
            dtb.KHOIs.Remove(std);
            foreach (var item in dtb.LOPs.Where(r=>r.MaKhoi == makhoi))
            {
                dtb.LOPs.Remove(item);
            }
            dtb.SaveChanges();
            var dsKhoi = from obj in dtb.KHOIs
                         where obj.TenKhoi != null && obj.MaNamHoc == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                         select new {TenKhoi = obj.TenKhoi};
            dgvDSKHOI.DataSource = dsKhoi.ToList();
            dgvDSKHOI.Show();
            var dsLop = from obj in dtb.LOPs
                        where obj.TenLop != null && obj.MaNamHoc == MaNamHoc_moi
                        select new { TenLop = obj.TenLop };
            dgvDSLOP.DataSource = dsLop.ToList();
            dgvDSLOP.Show();
            MessageBox.Show("Cập nhật danh sách khối lớp thành công! Đã xóa các lớp của khối "+tenkhoi);
        }

        //Thay đổi danh sách môn học
        List<MONHOC> Copy_Monhoc()
        {
            dataEntities dtb = new dataEntities();
            var getMaNamHoc = from scr in dtb.NAMHOCs
                    where scr.NamHoc1 == Namhoctextbox.Text
                    select scr;
            string MaNamHoc = getMaNamHoc.SingleOrDefault().MaNamHoc.ToString();
            string subMaNamHoc = MaNamHoc.Substring(2,2);
            List<MONHOC> list = new List<MONHOC>();
            foreach (var i in dtb.MonHoc_NamApDung(MaNamHoc))
            {
                MONHOC mh = new MONHOC();
                mh.MaMonHoc = subMaNamHoc + i.MaMonHoc;
                mh.TenMonHoc = i.TenMonHoc;
                mh.NamApDung = MaNamHoc;
                list.Add(mh);
            }
            return list;
        }
        private void AddMonhoc_button_Click(object sender, EventArgs e)
        {
            if (Tenmhtextbox.Text == string.Empty)
                return;
            var dtb = new dataEntities();
            string tenmh = Tenmhtextbox.Text;
            var getMaNamHoc = dtb.NAMHOCs.Where(p => p.NamHoc1 == Namhoctextbox.Text).Select(p => p.MaNamHoc).SingleOrDefault();
            string MaNamHoc = getMaNamHoc.ToString();
            string subMaNamHoc = MaNamHoc.Substring(2, 2);
            List<MONHOC> list_mh = new List<MONHOC>();
            if (tenmh.Length == 0)
            {
                MessageBox.Show("Tên môn học không hợp lệ!");
                return;
            }
            string[] words = tenmh.Split(' ');
            string mamh = "";
            if (words.Length > 2) 
            { 
                for (int i = 0; i < words.Length - 1; i++ )
                    mamh = mamh + words[i].Substring(0, 1).ToUpper();
                mamh = subMaNamHoc + mamh + words[words.Length - 1];
            }
            else if (words.Length == 2) mamh = subMaNamHoc + words[0].Substring(0, 2) + words[words.Length - 1];
            var check_ = dtb.MONHOCs.Where(p => p.NamApDung == MaNamHoc);
            if (check_.Count() == 0)
            {
                    list_mh = Copy_Monhoc();
            }
            var ds_mamh = dtb.MonHoc_NamApDung(MaNamHoc).Select(r => r.MaMonHoc).ToList();
            var ds_tenmh = dtb.MonHoc_NamApDung(MaNamHoc).Select(r => r.TenMonHoc).ToList();
            bool check_tenmh = true;
            for (int i = 0; i < ds_mamh.Count; i++)
            {
                    if (ds_tenmh[i] == tenmh) { check_tenmh = false; }
            }
            if (check_tenmh)
            {
                    MONHOC new_item = new MONHOC();
                    new_item.TenMonHoc = tenmh;
                    new_item.MaMonHoc =  mamh;
                    new_item.NamApDung = MaNamHoc;
                    list_mh.Add(new_item);
                    MessageBox.Show("Cập nhật danh sách môn học thành công!");
            }
            else if (!check_tenmh) MessageBox.Show("Tên môn học đã tồn tại!");
            foreach (var i in list_mh)
                    dtb.MONHOCs.Add(i);
            dtb.SaveChanges();
            var dsMonhoc = from obj in dtb.MONHOCs
                               where obj.TenMonHoc != null && obj.NamApDung == MaNamHoc
                               select new {TenMonHoc = obj.TenMonHoc };
            dgvDSMONHOC.DataSource = dsMonhoc.ToList();
            dgvDSMONHOC.Show();
        }
        private void EditMonhoc_button_Click(object sender, EventArgs e)
        {
            var dtb = new dataEntities();
            var getMaNamHoc = dtb.NAMHOCs.Where(p => p.NamHoc1 == Namhoctextbox.Text).Select(p => p.MaNamHoc).SingleOrDefault();
            string MaNamHoc = getMaNamHoc.ToString();
            string subMaNamHoc = MaNamHoc.Substring(2, 2);
            string ten_mh = dgvDSMONHOC.CurrentRow.Cells[0].Value.ToString();
            string tenmh = Tenmhtextbox.Text;
            List<MONHOC> list_mh = new List<MONHOC>();
            if (tenmh.Length == 0)
            {
                MessageBox.Show("Tên môn học không hợp lệ!");
                return;
            }
            var check_ = dtb.MONHOCs.Where(p => p.NamApDung == MaNamHoc);
            if (check_.Count() == 0)
            {
                list_mh = Copy_Monhoc();
            }
            var ds_tenmh = dtb.MonHoc_NamApDung(MaNamHoc).Select(r => r.TenMonHoc).ToList();
            bool check_tenmh = true;
            for (int i = 0; i < ds_tenmh.Count; i++)
            {
                if (ds_tenmh[i] == tenmh) { check_tenmh = false; break; }
            }
            if (check_tenmh)
            {
                if (list_mh.Count() > 0)
                {
                    foreach (var i in list_mh)
                    {
                        if (i.TenMonHoc == ten_mh)
                        {
                            i.TenMonHoc = tenmh; break;
                        }
                    }
                    foreach (var i in list_mh)
                        dtb.MONHOCs.Add(i);
                }
                else
                {
                    var std = dtb.MONHOCs.Where(r => r.TenMonHoc == ten_mh && r.NamApDung == MaNamHoc_moi).First();
                    std.TenMonHoc = Tenmhtextbox.Text;
                }
                dtb.SaveChanges();
                MessageBox.Show("Cập nhật danh sách môn học thành công!");
            }
            else MessageBox.Show("Môn học đã tồn tại!");
            var dsMonhoc = from obj in dtb.MonHoc_NamApDung(MaNamHoc)
                           where obj.TenMonHoc != null
                           select new {TenMonHoc = obj.TenMonHoc };
            dgvDSMONHOC.DataSource = dsMonhoc.ToList();
            dgvDSMONHOC.Show();
        }
        private void DeleteMonhoc_button_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var getMaNamHoc = dtb.NAMHOCs.Where(p => p.NamHoc1 == Namhoctextbox.Text).Select(p => p.MaNamHoc).SingleOrDefault();
            string MaNamHoc = getMaNamHoc.ToString();
            string subMaNamHoc = MaNamHoc.Substring(2, 2);
            var check_ = dtb.MONHOCs.Where(p => p.NamApDung == MaNamHoc);
            List<MONHOC> list_mh = new List<MONHOC>();
            if (check_.Count() == 0)
            {
                list_mh = Copy_Monhoc();
            }
            string tenmh = dgvDSMONHOC.CurrentRow.Cells[0].Value.ToString();
            if (list_mh.Count > 0)
            {
                foreach (var i in list_mh)
                {
                    if (i.TenMonHoc != tenmh)
                        dtb.MONHOCs.Add(i);
                }

            }
            else
            {
                var std = dtb.MONHOCs.Where(r => r.TenMonHoc == tenmh && r.NamApDung == MaNamHoc_moi).First();
                dtb.MONHOCs.Remove(std);
            }
            dtb.SaveChanges();
            var dsMonhoc = from obj in dtb.MONHOCs
                           where obj.TenMonHoc != null && obj.NamApDung == MaNamHoc_moi
                           select new {TenKhoi = obj.TenMonHoc };
            dgvDSMONHOC.DataSource = dsMonhoc.ToList();
            dgvDSMONHOC.Show();
            MessageBox.Show("Cập nhật danh sách môn học thành công!");
        }
        //Thay đổi danh sách điểm thành phần
        List<THANHPHAN> Copy_ThanhPhan()
        {
            dataEntities dtb = new dataEntities();
            string subMaNamHoc = MaNamHoc_moi.Substring(2, 2);
            List<THANHPHAN> list = new List<THANHPHAN>();
            foreach (var i in dtb.ThanhPhan_NamApDung(MaNamHoc_moi))
            {
                THANHPHAN mh = new THANHPHAN();
                mh.MaThanhPhan = subMaNamHoc + i.MaThanhPhan;
                mh.TenThanhPhan = i.TenThanhPhan;
                mh.TrongSo = i.TrongSo;
                mh.NamApDung = MaNamHoc_moi;
                list.Add(mh);
            }
            return list;
        }
        private void AddDiemTP_button_Click(object sender, EventArgs e)
        {
            string tentp = TenTPtextbox.Text;
            string[] words = tentp.Split(' ');
            string matp = "";
            string string_trongso = TrongsoTPtextbox.Text;
            if (string_trongso == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập trọng số!");
                return;
            }    
            double trongso = Convert.ToDouble(TrongsoTPtextbox.Text);
            if(trongso < 0.1 || trongso > 1)
            {
                MessageBox.Show("Trọng số không hợp lệ!");
                return;
            }
            if (words.Length > 1)
            {
                for (int i = 0; i < words.Length; i++)
                    matp += words[i].Substring(0, 1).ToUpper();
                matp = MaNamHoc_moi.Substring(2, 2) + matp;
            }
            else if (words.Length == 1) matp = MaNamHoc_moi.Substring(2, 2) + words[0];
            else
            {
                MessageBox.Show("Tên thành phần không hợp lệ!");
                return;
            }
            using (var dtb = new dataEntities())
            {
                var ds_matp = dtb.THANHPHANs.Select(r => r.MaThanhPhan).ToList();
                var ds_tentp = dtb.ThanhPhan_NamApDung(MaNamHoc_moi).Select(r => r.TenThanhPhan).ToList();
                bool check_tentp = true;
                List<THANHPHAN> list_khoi = new List<THANHPHAN>();
                var check_ = dtb.THANHPHANs.Where(p => p.NamApDung == MaNamHoc_moi);
                if (check_.Count() == 0)
                    list_khoi = Copy_ThanhPhan();
                for (int i = 0; i < ds_tentp.Count; i++)
                {
                    if (ds_tentp[i] == tentp) { check_tentp = false; }
                }
                if (check_tentp)
                {
                    THANHPHAN new_item = new THANHPHAN();
                    new_item.TenThanhPhan = tentp;
                    new_item.MaThanhPhan = matp;
                    new_item.TrongSo = trongso;
                    new_item.NamApDung = MaNamHoc_moi;
                    dtb.THANHPHANs.Add(new_item);
                    MessageBox.Show("Cập nhật danh sách điểm thành phần thành công!");
                }
                else if (!check_tentp) MessageBox.Show("Tên thành phần đã tồn tại!");
                foreach (var i in list_khoi)
                    dtb.THANHPHANs.Add(i);
                dtb.SaveChanges();
                var dsDiemTP = from obj in dtb.THANHPHANs
                               where obj.TenThanhPhan != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                               select new {TenThanhPhan = obj.TenThanhPhan, TrongSo = obj.TrongSo };
                dgvDiemthanhphan.DataSource = dsDiemTP.ToList();
                dgvDiemthanhphan.Show();
            }
        }
        private void EditDiemTP_button_Click(object sender, EventArgs e)
        {
            var dtb = new dataEntities();
            string tentp = TenTPtextbox.Text;
            string ten_tp = dgvDiemthanhphan.CurrentRow.Cells[0].Value.ToString();
            List<THANHPHAN> list_tp = new List<THANHPHAN>();
            string string_trongso = TrongsoTPtextbox.Text;
            if (string_trongso == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập trọng số!");
                return;
            }
            double trongso = Convert.ToDouble(TrongsoTPtextbox.Text);
            if (trongso < 0.1 || trongso > 1)
            {
                MessageBox.Show("Trọng số không hợp lệ!");
                return;
            }
            if(tentp == "")
            {
                MessageBox.Show("Tên thành phần không hợp lệ!");
                return;
            }
            var check_ = dtb.THANHPHANs.Where(p => p.NamApDung == MaNamHoc_moi);
            if (check_.Count() == 0)
            {
                list_tp = Copy_ThanhPhan();
            }
            var ds_tentp = dtb.ThanhPhan_NamApDung(MaNamHoc_moi).ToList();
            bool check_tentp = true;
            for (int i = 0; i < ds_tentp.Count; i++)
            {
                if (ds_tentp[i].TenThanhPhan == tentp) 
                {  
                    if (ds_tentp[i].TrongSo == trongso || tentp != ten_tp)
                    {
                        check_tentp = false; break;
                    }    
                }
            }
            if (check_tentp)
            {
                if (list_tp.Count() > 0)
                {
                    foreach (var i in list_tp)
                    {
                        if (i.TenThanhPhan == ten_tp)
                        {
                            //i.MaThanhPhan = tentp;
                            i.TenThanhPhan = tentp;
                            i.TrongSo = trongso;
                        }
                    }
                }
                else
                {
                    var std = dtb.THANHPHANs.Where(r => r.TenThanhPhan == ten_tp && r.NamApDung == MaNamHoc_moi).First();
                    std.TenThanhPhan = tentp;
                    std.TrongSo = trongso;
                }
                MessageBox.Show("Cập nhật danh sách điểm thành phần thành công!");
            }
            else MessageBox.Show("Tên thành phần đã tồn tại!");
            foreach (var i in list_tp)
                dtb.THANHPHANs.Add(i);
            dtb.SaveChanges();
            var dsDiemTP = from obj in dtb.THANHPHANs
                           where obj.TenThanhPhan != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                           select new {TenThanhPhan = obj.TenThanhPhan, TrongSo = obj.TrongSo };
            dgvDiemthanhphan.DataSource = dsDiemTP.ToList();
            dgvDiemthanhphan.Show();
        }
        private void DeleteDiemTP_button_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var check_ = dtb.THANHPHANs.Where(p => p.NamApDung == MaNamHoc_moi);
            List<THANHPHAN> list_tp = new List<THANHPHAN>();
            if (check_.Count() == 0)
            {
                list_tp = Copy_ThanhPhan();
            }
            string tentp = dgvDiemthanhphan.CurrentRow.Cells[0].Value.ToString();

            if (list_tp.Count > 0)
            {
                foreach (var i in list_tp)
                {
                    if (i.TenThanhPhan != tentp)
                        dtb.THANHPHANs.Add(i);
                }

            }
            else
            {
                var std = dtb.THANHPHANs.Where(r => r.TenThanhPhan == tentp && r.NamApDung == MaNamHoc_moi).First();
                dtb.THANHPHANs.Remove(std);
            }
            dtb.SaveChanges();
            var dsDiemTP = from obj in dtb.THANHPHANs
                           where obj.TenThanhPhan != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                           select new {TenThanhPhan = obj.TenThanhPhan, TrongSo = obj.TrongSo };
            dgvDiemthanhphan.DataSource = dsDiemTP.ToList();
            dgvDiemthanhphan.Show();
            MessageBox.Show("Cập nhật danh sách môn học thành công!");
        }
        //Thay đổi danh sách xếp loại
        List<XEPLOAI> Copy_Xeploai()
        {
            dataEntities dtb = new dataEntities();
            var getMaNamHoc = from scr in dtb.NAMHOCs
                              where scr.NamHoc1 == Namhoctextbox.Text
                              select scr;
            string MaNamHoc = getMaNamHoc.SingleOrDefault().MaNamHoc.ToString();
            string subMaNamHoc = MaNamHoc.Substring(2, 2).ToUpper();
            List<XEPLOAI> list = new List<XEPLOAI>();
            foreach (var i in dtb.XepLoai_NamApDung(MaNamHoc))
            {
                XEPLOAI xl = new XEPLOAI();
                xl.MaXepLoai = subMaNamHoc + i.MaXepLoai;
                xl.TenXepLoai = i.TenXepLoai;
                xl.DiemToiThieu = i.DiemToiThieu;
                xl.DiemToiDa = i.DiemToiDa;
                xl.DiemKhongChe = i.DiemKhongChe;
                xl.NamApDung = MaNamHoc;
                list.Add(xl);
            }
            return list;
        }
        private void AddXeploai_button_Click(object sender, EventArgs e)
        {
            if (Tenxeploaitextbox.Text == string.Empty || DiemKCtextbox.Text == string.Empty || minDiemtextbox.Text == string.Empty || maxDiemtextbox.Text == string.Empty)  
                return;
            double diem_kc = Convert.ToDouble(DiemKCtextbox.Text);
            double diem_min = Convert.ToDouble(minDiemtextbox.Text);
            double diem_max = Convert.ToDouble(maxDiemtextbox.Text);
            if(diem_kc > 10 || diem_kc < 0 || diem_min > 10 || diem_min < 0 || diem_max > 10 || diem_max < 0)
            {
                MessageBox.Show("Gía trị điểm không hợp lệ!", "Error");
                return;
            }
            var dtb = new dataEntities();
            string tenxl = Tenxeploaitextbox.Text;
            var getMaNamHoc = dtb.NAMHOCs.Where(p => p.NamHoc1 == Namhoctextbox.Text).Select(p => p.MaNamHoc).SingleOrDefault();
            string MaNamHoc = getMaNamHoc.ToString();
            string subMaNamHoc = MaNamHoc.Substring(2, 2);
            List<XEPLOAI> list_xl = new List<XEPLOAI>();
            string[] words = tenxl.Split(' ');
            string maxl = "";
            if (words.Length >= 2)
            {
                for (int i = 0; i < words.Length; i++)
                    maxl += words[i].Substring(0, 1).ToUpper();
                maxl = subMaNamHoc + maxl;
            }
            else if (words.Length == 1) maxl = subMaNamHoc + words[0].Substring(0, 2).ToUpper();
            var check_ = dtb.XEPLOAIs.Where(p => p.NamApDung == MaNamHoc);
            if (check_.Count() == 0)
            {
                list_xl = Copy_Xeploai();
            }
            var ds_maxl = dtb.XepLoai_NamApDung(MaNamHoc).Select(r => r.MaXepLoai).ToList();
            var ds_tenxl = dtb.XepLoai_NamApDung(MaNamHoc).Select(r => r.TenXepLoai).ToList();
            bool check_tenxl = true;
            for (int i = 0; i < ds_maxl.Count; i++)
            {
                if (ds_tenxl[i] == tenxl) { check_tenxl = false; }
            }
            if (check_tenxl)
            {
                XEPLOAI new_item = new XEPLOAI();
                new_item.TenXepLoai = tenxl;
                new_item.MaXepLoai = maxl;
                new_item.DiemKhongChe = Convert.ToDouble(DiemKCtextbox.Text);
                new_item.DiemToiThieu = Convert.ToDouble(minDiemtextbox.Text);
                new_item.DiemToiDa = Convert.ToDouble(maxDiemtextbox.Text);
                new_item.NamApDung = MaNamHoc;
                list_xl.Add(new_item);
                MessageBox.Show("Cập nhật danh sách học lực thành công!");
            }
            else if (!check_tenxl) MessageBox.Show("Tên học lực đã tồn tại!");
            foreach (var i in list_xl)
                dtb.XEPLOAIs.Add(i);
            dtb.SaveChanges();
            var dsXeploai = from obj in dtb.XEPLOAIs
                            where obj.TenXepLoai != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                            && obj.TenXepLoai != "Không"
                            orderby obj.DiemToiThieu descending
                            select new {TenXepLoai = obj.TenXepLoai, DiemToiThieu = obj.DiemToiThieu, DiemToiDa = obj.DiemToiDa, DiemKhongChe = obj.DiemKhongChe };
            dgvXepLoai.DataSource = dsXeploai.ToList();
            dgvXepLoai.Show();
        }
        private void EditXeploai_button_Click(object sender, EventArgs e)
        {
            if (Tenxeploaitextbox.Text == string.Empty || DiemKCtextbox.Text == string.Empty || minDiemtextbox.Text == string.Empty || maxDiemtextbox.Text == string.Empty)
                return;
            double diem_kc = Convert.ToDouble(DiemKCtextbox.Text);
            double diem_min = Convert.ToDouble(minDiemtextbox.Text);
            double diem_max = Convert.ToDouble(maxDiemtextbox.Text);
            if (diem_kc > 10 || diem_kc < 0 || diem_min > 10 || diem_min < 0 || diem_max > 10 || diem_max < 0)
            {
                MessageBox.Show("Gía trị điểm không hợp lệ!", "Error");
                return;
            }
            var dtb = new dataEntities();
            string ten_xl = dgvXepLoai.CurrentRow.Cells[0].Value.ToString();
            string tenxl = Tenxeploaitextbox.Text;
            List<XEPLOAI> list_xl = new List<XEPLOAI>();
            var check_ = dtb.XEPLOAIs.Where(p => p.NamApDung == MaNamHoc_moi);
            if (check_.Count() == 0)
            {
                list_xl = Copy_Xeploai();
            }
            var ds_tenxl = dtb.XepLoai_NamApDung(MaNamHoc_moi).Select(r => r.TenXepLoai).ToList();
            bool check_tenxl = true;
            for (int i = 0; i < ds_tenxl.Count; i++)
            {
                if (ds_tenxl[i] == tenxl && ds_tenxl[i] != Tenxeploaitextbox.Text) { check_tenxl = false; break; }
            }
            if (check_tenxl)
            {
                if (list_xl.Count() > 0)
                {
                    foreach (var i in list_xl)
                    {
                        if (i.TenXepLoai == ten_xl)
                        {
                            i.TenXepLoai = tenxl; break;
                        }
                    }
                    foreach (var i in list_xl)
                        dtb.XEPLOAIs.Add(i);
                }
                else
                {
                    var std = dtb.XEPLOAIs.Where(r => r.TenXepLoai == ten_xl && r.NamApDung == MaNamHoc_moi).First();
                    std.TenXepLoai = Tenxeploaitextbox.Text;
                    std.DiemKhongChe = Convert.ToDouble(DiemKCtextbox.Text);
                    std.DiemToiThieu = Convert.ToDouble(minDiemtextbox.Text);
                    std.DiemToiDa = Convert.ToDouble(maxDiemtextbox.Text);
                }
                dtb.SaveChanges();
                MessageBox.Show("Cập nhật danh sách học lực thành công!");
            }
            var dsXeploai = from obj in dtb.XEPLOAIs
                            where obj.TenXepLoai != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                            && obj.TenXepLoai != "Không"
                            orderby obj.DiemToiThieu descending
                            select new {TenXepLoai = obj.TenXepLoai, DiemToiThieu = obj.DiemToiThieu, DiemToiDa = obj.DiemToiDa, DiemKhongChe = obj.DiemKhongChe };
            dgvXepLoai.DataSource = dsXeploai.ToList();
            dgvXepLoai.Show();
        }
        private void DeleteXeploai_button_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var getMaNamHoc = dtb.NAMHOCs.Where(p => p.NamHoc1 == Namhoctextbox.Text).Select(p => p.MaNamHoc).SingleOrDefault();
            string MaNamHoc = getMaNamHoc.ToString();
            string subMaNamHoc = MaNamHoc.Substring(2, 2);
            var check_ = dtb.XEPLOAIs.Where(p => p.NamApDung == MaNamHoc);
            List<XEPLOAI> list_xl = new List<XEPLOAI>();
            if (check_.Count() == 0)
            {
                list_xl = Copy_Xeploai();
            }
            string tenxl = dgvXepLoai.CurrentRow.Cells[0].Value.ToString();
            if (list_xl.Count > 0)
            {
                foreach (var i in list_xl)
                {
                    if (i.TenXepLoai != tenxl)
                        dtb.XEPLOAIs.Add(i);
                }
            }
            else
            {
                var std = dtb.XEPLOAIs.Where(r => r.TenXepLoai == tenxl && r.NamApDung == MaNamHoc_moi).First();
                dtb.XEPLOAIs.Remove(std);
            }
            dtb.SaveChanges();
            var dsXeploai = from obj in dtb.XEPLOAIs
                            where obj.TenXepLoai != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                            && obj.TenXepLoai != "Không"
                            orderby obj.DiemToiThieu descending
                            select new {TenXepLoai = obj.TenXepLoai, DiemToiThieu = obj.DiemToiThieu, DiemToiDa = obj.DiemToiDa, DiemKhongChe = obj.DiemKhongChe };
            dgvXepLoai.DataSource = dsXeploai.ToList();
            dgvXepLoai.Show();
            MessageBox.Show("Cập nhật danh sách học lực thành công!");
        }
        //Thay đổi danh sách học kỳ
        List<HOCKY> Copy_HocKy()
        {
            dataEntities dtb = new dataEntities();
            string subMaNamHoc = MaNamHoc_moi.Substring(2, 2);
            int mahk = dtb.HOCKies.Select(r => r).ToList().Count() + 1;
            List<HOCKY> list = new List<HOCKY>();
            foreach (var i in dtb.HocKy_NamApDung(MaNamHoc_moi))
            {
                HOCKY mh = new HOCKY();
                mh.MaHocKy = mahk.ToString();
                mh.HocKy1 = i.HocKy;
                mh.TrongSo = i.TrongSo;
                mh.NamApDung = MaNamHoc_moi;
                mahk++;
                list.Add(mh);
            }
            return list;
        }
        private void AddHocky_button_Click(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            string tenhk = HocKytextbox.Text;
            string string_trongso = TrongSoHKtextbox.Text;
            if (string_trongso == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập trọng số!");
                return;
            }
            double trongso = Convert.ToDouble(TrongSoHKtextbox.Text);
            if (trongso < 1)
            {
                MessageBox.Show("Trọng số không hợp lệ!");
                return;
            }
            else if (tenhk == "")
            {
                MessageBox.Show("Tên thành phần không hợp lệ!");
                return;
            }
            var ds_tenhk = dtb.HocKy_NamApDung(MaNamHoc_moi).Select(r => r.HocKy).ToList();
            bool check_tentp = true;
            var check_ = dtb.HOCKies.Where(p => p.NamApDung == MaNamHoc_moi);
            List<HOCKY> list_hk = new List<HOCKY>();
            if (check_.Count() == 0)
            {
                list_hk = Copy_HocKy();
            }
            var mahk = list_hk.Select(r => r).ToList().Count() + dtb.HOCKies.Select(r => r).ToList().Count() + 1;
            for (int i = 0; i < ds_tenhk.Count; i++)
            {
                if (ds_tenhk[i] == tenhk) { check_tentp = false; }
            }
            if (check_tentp)
            {
                HOCKY new_item = new HOCKY();
                new_item.HocKy1 = tenhk;
                new_item.MaHocKy =  mahk.ToString();
                new_item.TrongSo = trongso;
                new_item.NamApDung = MaNamHoc_moi;
                dtb.HOCKies.Add(new_item);
                MessageBox.Show("Cập nhật danh sách học kỳ thành công!");
            }
            else if (!check_tentp) MessageBox.Show("Tên học kỳ đã tồn tại!");
            foreach (var i in list_hk)
                dtb.HOCKies.Add(i);
            dtb.SaveChanges();
            var dsDiemHK = from obj in dtb.HOCKies
                           where obj.HocKy1 != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                           select new {HocKy1 = obj.HocKy1, TrongSo = obj.TrongSo };
            dgvDiemHK.DataSource = dsDiemHK.ToList();
            dgvDiemHK.Show();
        }
        private void EditHocky_button_Click(object sender, EventArgs e)
        {
            var dtb = new dataEntities();
            string tenhk = HocKytextbox.Text;
            string ten_hk = dgvDiemHK.CurrentRow.Cells[0].Value.ToString();
            var ds_tenhk = dtb.HocKy_NamApDung(MaNamHoc_moi).ToList();
            string string_trongso = TrongSoHKtextbox.Text;
            if (string_trongso == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập trọng số!");
                return;
            }
            double trongso = Convert.ToDouble(TrongSoHKtextbox.Text);
            if (trongso < 1)
            {
                MessageBox.Show("Trọng số không hợp lệ!");
                return;
            }
            if (tenhk == "")
            {
                MessageBox.Show("Tên học kỳ không hợp lệ!");
                return;
            }
            var check_ = dtb.HOCKies.Where(p => p.NamApDung == MaNamHoc_moi);
            List<HOCKY> list_hk = new List<HOCKY>();
            if (check_.Count() == 0)
            {
                list_hk = Copy_HocKy();
            }
            bool check_tenhk = true;
            for (int i = 0; i < ds_tenhk.Count; i++)
            {
                if (ds_tenhk[i].HocKy == tenhk) 
                {
                    if (ds_tenhk[i].TrongSo == trongso || tenhk!=ten_hk)
                    {
                        check_tenhk = false; break;
                    }   
                }
            }
            if (check_tenhk)
            {
                if (list_hk.Count() > 0)
                {
                    foreach (var i in list_hk)
                    {
                        if (i.HocKy1 == ten_hk)
                        {
                            i.HocKy1 = tenhk;
                            i.TrongSo = trongso;
                            break;
                        }
                    }
                }
                else
                {
                    var std = dtb.HOCKies.Where(r => r.HocKy1 == tenhk && r.NamApDung == MaNamHoc_moi).First();
                    std.HocKy1 = HocKytextbox.Text;
                    std.TrongSo = trongso;
                }
                MessageBox.Show("Cập nhật danh sách học kỳ thành công!");
            }
            else MessageBox.Show("Học kỳ này đã tồn tại!");
            foreach (var i in list_hk)
                dtb.HOCKies.Add(i);
            dtb.SaveChanges();
            var dsDiemHK = from obj in dtb.HOCKies
                           where obj.HocKy1 != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                           select new {HocKy1 = obj.HocKy1, TrongSo = obj.TrongSo };
            dgvDiemHK.DataSource = dsDiemHK.ToList();
            dgvDiemHK.Show();
        }
        private void DeleteHocky_button_Click(object sender, EventArgs e)
        {
            var dtb = new dataEntities();
            string tenhk = dgvDiemHK.CurrentRow.Cells[0].Value.ToString();
            var check_ = dtb.HOCKies.Where(p => p.NamApDung == MaNamHoc_moi);
            List<HOCKY> list_hk = new List<HOCKY>();
            if (check_.Count() == 0)
            {
                list_hk = Copy_HocKy();
            }
            if (list_hk.Count > 0)
            {
                foreach (var i in list_hk)
                {
                    if (i.HocKy1 != tenhk)
                        dtb.HOCKies.Add(i);
                }

            }
            else
            {
                var std = dtb.HOCKies.Where(r => r.HocKy1 == tenhk && r.NamApDung == MaNamHoc_moi).First();
                dtb.HOCKies.Remove(std);
            }
            dtb.SaveChanges();
            MessageBox.Show("Cập nhật danh sách học kỳ thành công!");
            var dsDiemHK = from obj in dtb.HOCKies
                           where obj.HocKy1 != null && obj.NamApDung == dtb.NAMHOCs.OrderByDescending(r => r.MaNamHoc).Select(r => r.MaNamHoc).FirstOrDefault()
                           select new {HocKy1 = obj.HocKy1, TrongSo = obj.TrongSo };
            dgvDiemHK.DataSource = dsDiemHK.ToList();
            dgvDiemHK.Show();
        }
        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
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
        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            this.Close();
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

    }
}
