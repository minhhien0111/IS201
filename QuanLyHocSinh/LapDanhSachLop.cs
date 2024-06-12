using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class LapDanhSachLop : Form
    {
        private TrangChu mainform { get; set; }
        private short sStdNum;
        private System.Data.DataTable dt;
        private int iNamHoc;
        private int iKhoi;
        private int iLop;

        public LapDanhSachLop(TrangChu mainform)
        {
            InitializeComponent();
            this.mainform = mainform;

            this.dgvClassDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClassDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dt = new System.Data.DataTable();
            dt.Columns.Add("STT", typeof(byte)).ReadOnly = true;
            dt.Columns.Add("MSHS", typeof(String)).ReadOnly = true;
            dt.Columns.Add("Họ tên", typeof(String)).ReadOnly = true;
            dt.Columns.Add("Giới tính", typeof(String)).ReadOnly = true;
            dt.Columns.Add("Ngày sinh", typeof(DateTime)).ReadOnly = true;
            dt.Columns.Add("Địa chỉ", typeof(String)).ReadOnly = true;
            dt.Columns.Add("SĐT", typeof(String)).ReadOnly = true;

            dataEntities db = new dataEntities();
            CapNhatDanhSachNamHoc(db);
            CapNhatDanhSachKhoi(db);
            CapNhatDanhSachLop(db);
            CapNhatMaGV();
            HienThiDanhSachHocSinh(db);

            this.cbSchoolYear.SelectedIndexChanged += new System.EventHandler(this.cbSchoolYear_SelectedIndexChanged);
            this.cbGrade.SelectedIndexChanged += new System.EventHandler(this.cbGrade_SelectedIndexChanged);
            this.cbClass.SelectedIndexChanged += new System.EventHandler(this.cbClass_SelectedIndexChanged);
        }

        //private void LapDanhSachLop_Load(object sender, EventArgs e)
        //{
        //    // TODO: This line of code loads data into the 'duLieu.LOP' table. You can move, or remove it, as needed.
        //    this.lOPTableAdapter.Fill(this.duLieu.LOP);

        //}

        private void CapNhatDanhSachNamHoc(dataEntities db)
        {
            List<NAMHOC> list = (from obj in db.NAMHOCs.AsEnumerable()
                                 orderby obj.MaNamHoc descending
                                 select obj).ToList();
            iNamHoc = list.Count();
            cbSchoolYear.DataSource = list;
            cbSchoolYear.DisplayMember = "NamHoc1";
            cbSchoolYear.ValueMember = "MaNamHoc"; 
            cbSchoolYear.SelectedValue = list[0].MaNamHoc;
            cbSchoolYear.Enabled = false;
        }

        private void CapNhatDanhSachKhoi(dataEntities db)
        {
            try
            {
                List<KHOI> list = (from obj in db.KHOIs.AsEnumerable()
                                   where obj.MaNamHoc == this.cbSchoolYear.SelectedValue.ToString()
                                   select obj).ToList();
                iKhoi = list.Count();
                cbGrade.DataSource = list;
                cbGrade.DisplayMember = "TenKhoi";
                cbGrade.ValueMember = "MaKhoi";

                if (iKhoi == 0)
                {
                    List<LOP> lop = new List<LOP>();
                    cbClass.DataSource = lop;
                    tbStdNum.Text = "";
                    dgvClassDetail.Hide();
                }
            }
            catch(InvalidOperationException)
            {
                List<KHOI> khoi = new List<KHOI>();
                cbGrade.DataSource = khoi;
                List<LOP> lop = new List<LOP>();
                cbClass.DataSource = lop;
                tbStdNum.Text = "";
                dgvClassDetail.Hide();
            }
        }

        private void CapNhatDanhSachLop(dataEntities db)
        {
            try
            {
                List<LOP> list = (from l in db.LOPs.AsEnumerable()
                                  where l.MaNamHoc == this.cbSchoolYear.SelectedValue.ToString()
                                  && l.MaKhoi == this.cbGrade.SelectedValue.ToString()
                                  orderby l.MaLop ascending
                                  select l).ToList();
                iLop = list.Count();
                this.cbClass.DataSource = list;
                this.cbClass.DisplayMember = "TenLop";
                this.cbClass.ValueMember = "MaLop";

                if (iLop == 0)
                {
                    tbStdNum.Text = "";
                    dgvClassDetail.Hide();
                }
            }
            catch(InvalidOperationException) 
            {
                List<LOP> lop = new List<LOP>();
                cbClass.DataSource = lop;
                tbStdNum.Text = "";
                dgvClassDetail.Hide();
            }           
        }
        private void CapNhatMaGV()
        {
            dataEntities db = new dataEntities();
            var stdIdNowDb = from ctgv in db.CTLOPGVs
                             join l in db.LOPs on ctgv.MaLop equals l.MaLop
                             join nh in db.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                             where nh.MaNamHoc == this.cbSchoolYear.SelectedValue.ToString()
                             where l.MaLop == this.cbClass.SelectedValue.ToString()
                             select new {MaGV =  ctgv.MaGVCN, MaLop = l.MaLop};
            //tbInputTeacherID.Text = stdIdNowDb.First().MaGV;
            if(stdIdNowDb.Count() != 0)
            {
                tbInputTeacherID.Text = stdIdNowDb.First().MaGV;
            }
            else
            {
                tbInputTeacherID.Text = "";
            }
             
        }

        private void ThemHocSinhVaoLop()
        {
            if(this.tbStdIdAdd.Text == "")
            {
                MessageBox.Show("Hãy nhập mã số học sinh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataEntities db = new dataEntities();
                var stdIdDb = from hs in db.HOCSINHs
                              where hs.MaHocSinh == this.tbStdIdAdd.Text
                              select hs;
                if (stdIdDb.Count() > 0)
                {
                    bool isAvailable = true;
                    foreach (var std in stdIdDb)
                    {
                        if (std.HoTen == null)
                        {
                            isAvailable = false;
                            MessageBox.Show("Thông tin của học sinh này không còn tồn tại trong hệ thống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                    if(isAvailable)
                    {
                        var stdIdNowDb = from hs in stdIdDb
                                         join ctl in db.CTLOPs on hs.MaHocSinh equals ctl.MaHocSinh
                                         join l in db.LOPs on ctl.MaLop equals l.MaLop
                                         join nh in db.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                                         where nh.MaNamHoc == this.cbSchoolYear.SelectedValue.ToString()
                                         select hs;
                        if (stdIdNowDb.Count() == 0)
                        {
                            short SiSoToiDa = (short)(from obj in db.THAMSOes
                                                      select obj.SiSoToiDa).ToList().First();
                            if (sStdNum < SiSoToiDa)
                            {
                                // Thêm học sinh vào lớp
                                CTLOP cTLOP = new CTLOP();
                                cTLOP.MaHocSinh = this.tbStdIdAdd.Text;
                                cTLOP.MaLop = this.cbClass.SelectedValue.ToString();
                                cTLOP.MaCTL = this.cbClass.SelectedValue.ToString() + "_" + this.tbStdIdAdd.Text;
                                db.CTLOPs.Add(cTLOP);
                                db.SaveChanges();
                                // Thêm học sinh vào lớp

                                HienThiDanhSachHocSinh(db);
                                this.tbStdIdAdd.Text = "";
                                var lop = db.LOPs.First(x => x.MaLop == this.cbClass.SelectedValue.ToString());
                                lop.SiSo += 1;
                                db.LOPs.AddOrUpdate(lop);
                                db.SaveChanges();
                                MessageBox.Show("Thêm học sinh vào lớp thành công", "Thêm thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Lớp đã đạt sĩ số tối đa, không thể thêm học sinh",
                                                "Lỗi",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Học sinh này đã được xếp lớp ở năm học này, không thể thêm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }    
                } 
                else
                {
                    MessageBox.Show("Mã số học sinh không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }            
        }

        private void XoaHocSinhKhoiLop()
        {
            try
            {
                if (short.Parse(this.tbStdIDDel.Text) < 1)
                {
                    MessageBox.Show("Giá trị nhập vào không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (short.Parse(this.tbStdIDDel.Text) > sStdNum)
                {
                    MessageBox.Show("Số thứ tự lớn hơn sĩ số lớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Xoá học sinh khỏi lớp
                    DialogResult choose = MessageBox.Show(
                        "Xoá học sinh này khỏi lớp? Tác vụ này không thể hoàn tác",
                        "Xoá học sinh khỏi lớp",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning
                    );

                    if(choose == DialogResult.OK)
                    {
                        dataEntities db = new dataEntities();

                        String str1 = dt.Rows[short.Parse(this.tbStdIDDel.Text) - 1]["MSHS"].ToString();
                        String str2 = this.cbClass.SelectedValue.ToString();

                        db.CTLOPs.Remove(
                            db.CTLOPs.Where(p => p.MaHocSinh == str1)
                                .Intersect(
                                    db.CTLOPs.Where(p => p.MaLop == str2)
                                )
                                .FirstOrDefault()
                        ) ;

                        var lop = db.LOPs.First(x => x.MaLop == this.cbClass.SelectedValue.ToString());
                        lop.SiSo -= 1;
                        db.LOPs.AddOrUpdate(lop);

                        db.SaveChanges();
                                             
                        // Xoá học sinh khỏi lớp

                        HienThiDanhSachHocSinh(db);
                        this.tbStdIDDel.Text = string.Empty;
                        MessageBox.Show(
                            "Xoá học sinh khỏi lớp thành công",
                            "Xoá thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Hãy nhập STT", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Giá trị nhập vào vượt quá giới hạn cho phép", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDanhSachHocSinh(dataEntities db)
        {
            try
            {
                var dataSource = from ctl in db.CTLOPs.AsEnumerable()
                                 join hs in db.HOCSINHs.AsEnumerable() on ctl.MaHocSinh equals hs.MaHocSinh
                                 where ctl.MaLop == this.cbClass.SelectedValue.ToString()
                                 group new { hs }
                                 by new { hs.MaHocSinh, hs.HoTen, hs.GioiTinh, hs.NgaySinh, hs.DiaChi, hs.SDT }
                             into g
                                 select new
                                 {
                                     MaHocSinh = g.Key.MaHocSinh,
                                     HoTen = g.Key.HoTen,
                                     GioiTinh = g.Key.GioiTinh,
                                     NgaySinh = g.Key.NgaySinh,
                                     DiaChi = g.Key.DiaChi,
                                     SDT = g.Key.SDT
                                 };

                dt.Clear();
                sStdNum = 0;
                foreach (var std in dataSource)
                {
                    DataRow row = dt.NewRow();
                    row["STT"] = ++sStdNum;
                    row["MSHS"] = std.MaHocSinh;
                    row["Họ tên"] = std.HoTen;
                    row["Giới tính"] = std.GioiTinh;
                    row["Ngày sinh"] = std.NgaySinh;
                    row["Địa chỉ"] = std.DiaChi;
                    row["SĐT"] = std.SDT;

                    dt.Rows.Add(row);
                }

                this.tbStdNum.Text = sStdNum.ToString();
                this.dgvClassDetail.DataSource = dt;
                this.dgvClassDetail.AutoResizeColumns();
                this.dgvClassDetail.Show();
            }
            catch(InvalidOperationException)
            {
                tbStdNum.Text = "";
                dgvClassDetail.Hide();
            }
            
        }

        private void cbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();
            CapNhatDanhSachKhoi(db);
        }

        private void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();
            CapNhatDanhSachLop(db);
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataEntities db = new dataEntities();            
            HienThiDanhSachHocSinh(db);
            CapNhatMaGV();
        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnHomeScreen_Click(object sender, EventArgs e)
        {
            (this.mainform as TrangChu).Show();
            this.Hide();
        }

        private void btnAddStdToClass_Click(object sender, EventArgs e)
        {
            if (cbSchoolYear.Text == string.Empty || cbGrade.Text == string.Empty || cbClass.Text == string.Empty)
            {
                MessageBox.Show("Thông tin không đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            else
                ThemHocSinhVaoLop();
        }

        private void btnDelStdOutClass_Click(object sender, EventArgs e)
        {
            if (cbSchoolYear.Text == string.Empty || cbGrade.Text == string.Empty || cbClass.Text == string.Empty)
            {
                MessageBox.Show("Thông tin không đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                XoaHocSinhKhoiLop();
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
        private string getPreviousMaGVCN()
        {
            dataEntities db = new dataEntities();
            var stdIdNowDb = from ctgv in db.CTLOPGVs
                             join l in db.LOPs on ctgv.MaLop equals l.MaLop
                             join nh in db.NAMHOCs on l.MaNamHoc equals nh.MaNamHoc
                             where nh.MaNamHoc == this.cbSchoolYear.SelectedValue.ToString()
                             where l.MaLop == this.cbClass.SelectedValue.ToString()
                             select new { MaGV = ctgv.MaGVCN, MaLop = l.MaLop };
            if (stdIdNowDb.Count() != 0)
                return stdIdNowDb.First().MaGV.ToString();
            else return "";
        }
        private void saveMaGV(object sender, EventArgs e)
        {
            if (cbSchoolYear.Text == string.Empty || cbGrade.Text == string.Empty || cbClass.Text == string.Empty)
            {
                MessageBox.Show("Thông tin không đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string MaGVCNmoi = tbInputTeacherID.Text;
            if (MaGVCNmoi.Length > 0)
            {
                dataEntities db = new dataEntities();
                var stdIdNowDb = from ctgv in db.CTLOPGVs
                                 join l in db.LOPs on ctgv.MaLop equals l.MaLop
                                 where l.MaNamHoc == this.cbSchoolYear.SelectedValue.ToString() && ctgv.MaGVCN == MaGVCNmoi
                                 select new { MaGV = ctgv.MaGVCN, MaLop = l.MaLop };
                //tbInputTeacherID.Text = stdIdNowDb.First().MaGV;
                if (stdIdNowDb.Count() != 0)
                {
                    MessageBox.Show("Giáo viên này đã có lớp chủ nhiệm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbInputTeacherID.Text = getPreviousMaGVCN();
                }
                else
                {
                    var ctlop = from ctgv in db.CTLOPGVs
                                where ctgv.MaLop == cbClass.SelectedValue.ToString()
                                select new { MaCTLOPGV = ctgv.MaCTLGV, MaLop = ctgv.MaLop };
                    if(ctlop.Count() > 0 )
                    {
                        CTLOPGV newCTLOP = new CTLOPGV();
                        newCTLOP.MaCTLGV = ctlop.First().MaCTLOPGV;
                        newCTLOP.MaGVCN = MaGVCNmoi;
                        newCTLOP.MaLop = ctlop.First().MaLop;
                        db.CTLOPGVs.AddOrUpdate(newCTLOP);
                        db.SaveChanges();
                        MessageBox.Show("Lưu thay đổi thành công",
                                        "Lưu thành công",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        CTLOPGV newCTLOP = new CTLOPGV();
                        var temp_ctlop = from ctgv in db.CTLOPGVs
                                          select new { MaCTLOPGV = ctgv.MaCTLGV};
                        String newMaCTLGV = db.CTLOPGVs.OrderByDescending(row => row.MaCTLGV).Select(row => row.MaCTLGV).FirstOrDefault();
                        string temp2_kq = newMaCTLGV.ToString();
                        int index_kq = Convert.ToInt32(temp2_kq);
                        newCTLOP.MaCTLGV = (index_kq + 1).ToString();
                        newCTLOP.MaGVCN = MaGVCNmoi;
                        newCTLOP.MaLop = cbClass.SelectedValue.ToString();
                        db.CTLOPGVs.Add(newCTLOP);
                        db.SaveChanges();
                        MessageBox.Show("Lưu thay đổi thành công",
                                        "Lưu thành công",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã giáo viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbInputTeacherID.Text = getPreviousMaGVCN();
            }
        }

        private void btnDeleteGVCN_Click(object sender, EventArgs e)
        {
            if (cbSchoolYear.Text == string.Empty || cbGrade.Text == string.Empty || cbClass.Text == string.Empty)
            {
                MessageBox.Show("Thông tin không đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tbInputTeacherID.Text = getPreviousMaGVCN();
            if (tbInputTeacherID.Text.Length > 0)
            {
                dataEntities db = new dataEntities();
                var stdIdNowDb = from ctgv in db.CTLOPGVs
                                 join l in db.LOPs on ctgv.MaLop equals l.MaLop
                                 where l.MaNamHoc == this.cbSchoolYear.SelectedValue.ToString() && l.MaLop == this.cbClass.SelectedValue.ToString()
                                 select new {MaCTLGV = ctgv.MaCTLGV, MaGV = ctgv.MaGVCN, MaLop = l.MaLop };
                //tbInputTeacherID.Text = stdIdNowDb.First().MaGV;
                if (stdIdNowDb.Count() != 0)
                {
                    CTLOPGV temp = new CTLOPGV {MaCTLGV = stdIdNowDb.First().MaCTLGV, MaGVCN = stdIdNowDb.First().MaGV, MaLop = this.cbClass.SelectedValue.ToString() };
                    db.CTLOPGVs.Attach(temp);
                    db.CTLOPGVs.Remove(temp);
                    db.SaveChanges();
                    tbInputTeacherID.Text = "";
                    MessageBox.Show("Xóa thành công",
                                        "Xóa thành công",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lớp hiện tại không có GVCN", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
