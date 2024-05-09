using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Runtime.InteropServices;
using System.Data.Entity.Migrations;
using System.Net;
using Microsoft.Office.Interop.Excel;

namespace QuanLyHocSinh
{
    public partial class TraCuuHocSinh : Form
    {
        public TrangChu formTraCuu { get; set; }

        public TraCuuHocSinh(TrangChu mainform)
        {
            InitializeComponent();
            this.formTraCuu = mainform;
            tbFindName.Text = "";
            tbStudentID.Text = "";
            tbFindEmail.Text = "";
            tbFindPhoneNum.Text = "";
            pnStudent_info.Hide();
            pnParentInfo.Hide();

            dataEntities data = new dataEntities();
            var CBNamHoc = from obj in data.NAMHOCs
                           select obj;
            cbSchoolYear.DataSource = CBNamHoc.ToList();
            cbSchoolYear.ValueMember = "NamHoc1";

            cbGrade.ResetText();
            cbClass.ResetText();
            cbSchoolYear.SelectedIndex = -1;
            cbGrade.SelectedIndex = -1;
            cbClass.SelectedIndex = -1;
            cbFindStudenID_2.Hide();
            cbFindStudenID_2.SelectedIndex = -1;
            if (Account.VaiTro == "Học sinh")
            {
                tbStudentID.Text = Account.MaTK;
                tbStudentID.Enabled = false;
                tbStudentID.Show();
            }
            pnHuongDanTraCuu.Hide();
        }
        void ThongTinHS_byID (string id = "")
        {
            dataEntities db = new dataEntities();
            // Sau khi kiểm tra đúng thì lấy thông tin của học sinh được tìm thấy
            tbFindName.ReadOnly = true;
            tbStudentID.ReadOnly = true;
            cbGrade.Enabled = false;
            cbClass.Enabled = false;
            tbFindEmail.ReadOnly = true;
            tbFindPhoneNum.ReadOnly = true;
            cbFindStudenID_2.Enabled = false;
            var result1 = from iter1 in db.HOCSINHs
                          join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                          join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                          where iter1.MaHocSinh == id
                          select new
                          {
                              name = iter1.HoTen,
                              idStudent = iter1.MaHocSinh,
                              class_name = iter3.TenLop,
                              sex = iter1.GioiTinh,
                              dob = iter1.NgaySinh,
                              ethnic = iter1.DanToc,
                              religion = iter1.TonGiao,
                              hometown = iter1.QueQuan,
                              address = iter1.DiaChi,
                              phone_num = iter1.SDT,
                              email = iter1.Email,

                              name_dad = iter1.HoTenCha,
                              phonenum_dad = iter1.SDT_Cha,
                              yearbirth_dad = iter1.NamSinh_Cha,
                              job_dad = iter1.NgheNghiep_Cha,
                              id_dad = iter1.CCCD_Cha,

                              name_mom = iter1.HoTenMe,
                              phonenum_mom = iter1.SDT_Me,
                              yearbirth_mom = iter1.NamSinh_Me,
                              job_mom = iter1.NgheNghiep_Me,
                              id_mom = iter1.CCCD_Me,
                          };

            foreach (var item in result1)
            {
                //Thông tin cá nhân của học sinh
                tbMaSoHS.Text = item.idStudent;
                tbHoTen.Text = item.name;
                tbLop.Text = item.class_name;
                tbGioiTinh.Text = item.sex;
                tbDiaChi.Text = item.address;
                tbSDT.Text = item.phone_num;

                //Xử lý ngày tháng năm trong chuỗi có kiểu dữ liệu Datetime
                string temp = item.dob.ToString();
                Regex re = new Regex(@"[^ ]*");
                Match m = re.Match(temp);
                tbNgaySinh.Text = m.Groups[0].Value;

                if (item.ethnic != null) tbDanToc.Text = item.ethnic;
                else tbDanToc.Text = "Không có thông tin";

                if (item.religion != null) tbTonGiao.Text = item.religion;
                else tbTonGiao.Text = "Không có thông tin";

                if (item.hometown != null) tbQueQuan.Text = item.hometown;
                else tbQueQuan.Text = "Không có thông tin";

                if (item.email != null) tbEmail.Text = item.email;
                else tbEmail.Text = "Không có thông tin";

                //Thông tin của cha của học sinh
                if (item.name_dad != null) tbHoTenCha.Text = item.name_dad;
                else tbHoTenCha.Text = "Không có thông tin";

                if (item.id_dad != null) tbCCCD_Cha.Text = item.id_dad;
                else tbCCCD_Cha.Text = "Không có thông tin";

                if (item.phonenum_dad != null) tbSDT_Cha.Text = item.phonenum_dad;
                else tbSDT_Cha.Text = "Không có thông tin";

                if (item.job_dad != null) tbNgheNghiep_Cha.Text = item.job_dad;
                else tbNgheNghiep_Cha.Text = "Không có thông tin";

                if (item.yearbirth_dad != null) tbNamSinh_Cha.Text = item.yearbirth_dad.ToString();
                else tbNamSinh_Cha.Text = "Không có thông tin";

                //Thông tin của mẹ của học sinh
                if (item.name_mom != null) tbHoTenMe.Text = item.name_mom;
                else tbHoTenMe.Text = "Không có thông tin";

                if (item.id_mom != null) tbCCCD_Me.Text = item.id_mom;
                else tbCCCD_Me.Text = "Không có thông tin";

                if (item.phonenum_mom != null) tbSDT_Me.Text = item.phonenum_mom;
                else tbSDT_Me.Text = "Không có thông tin";

                if (item.job_mom != null) tbNgheNghiepMe.Text = item.job_mom;
                else tbNgheNghiepMe.Text = "Không có thông tin";

                if (item.yearbirth_mom != null) tbNamSinhMe.Text = item.yearbirth_mom.ToString();
                else tbNamSinhMe.Text = "Không có thông tin";
            }
            pnStudent_info.Show();
            lbThongTinHocSinh.Show();
            pnDadofStudent_Info.Show();
            pnMomOfStudent_Info.Show();
            pnParentInfo.Show();
        }

        void ThongTinHS_byName (string name = "")
        {
            dataEntities db = new dataEntities();
            // Sau khi kiểm tra đúng thì lấy thông tin của học sinh được tìm thấy
            tbFindName.ReadOnly = true;
            tbStudentID.ReadOnly = true;
            cbGrade.Enabled = false;
            cbClass.Enabled = false;
            tbFindEmail.ReadOnly = true;
            tbFindPhoneNum.ReadOnly = true;
            cbFindStudenID_2.Enabled = false;
            var result1 = from iter1 in db.HOCSINHs
                          join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                          join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                          where iter1.HoTen == name
                          select new
                          {
                              name = iter1.HoTen,
                              idStudent = iter1.MaHocSinh,
                              class_name = iter3.TenLop,
                              sex = iter1.GioiTinh,
                              dob = iter1.NgaySinh,
                              ethnic = iter1.DanToc,
                              religion = iter1.TonGiao,
                              hometown = iter1.QueQuan,
                              address = iter1.DiaChi,
                              phone_num = iter1.SDT,
                              email = iter1.Email,

                              name_dad = iter1.HoTenCha,
                              phonenum_dad = iter1.SDT_Cha,
                              yearbirth_dad = iter1.NamSinh_Cha,
                              job_dad = iter1.NgheNghiep_Cha,
                              id_dad = iter1.CCCD_Cha,

                              name_mom = iter1.HoTenMe,
                              phonenum_mom = iter1.SDT_Me,
                              yearbirth_mom = iter1.NamSinh_Me,
                              job_mom = iter1.NgheNghiep_Me,
                              id_mom = iter1.CCCD_Me,
                          };

            foreach (var item in result1)
            {
                //Thông tin cá nhân của học sinh
                tbMaSoHS.Text = item.idStudent;
                tbHoTen.Text = item.name;
                tbLop.Text = item.class_name;
                tbGioiTinh.Text = item.sex;
                tbDiaChi.Text = item.address;
                //tbSDT.Text = item.phone_num;
                tbEmail.Text = item.email;

                //Xử lý ngày tháng năm trong chuỗi có kiểu dữ liệu Datetime
                string temp = item.dob.ToString();
                Regex re = new Regex(@"[^ ]*");
                Match m = re.Match(temp);
                tbNgaySinh.Text = m.Groups[0].Value;

                if (item.ethnic != null) tbDanToc.Text = item.ethnic;
                else tbDanToc.Text = "Không có thông tin";

                if (item.religion != null) tbTonGiao.Text = item.religion;
                else tbTonGiao.Text = "Không có thông tin";

                if (item.hometown != null) tbQueQuan.Text = item.hometown;
                else tbQueQuan.Text = "Không có thông tin";

                if (item.phone_num != null) tbSDT.Text = item.phone_num;
                else tbSDT.Text = "Không có thông tin";

                //Thông tin của cha của học sinh
                if (item.name_dad != null) tbHoTenCha.Text = item.name_dad;
                else tbHoTenCha.Text = "Không có thông tin";

                if (item.id_dad != null) tbCCCD_Cha.Text = item.id_dad;
                else tbCCCD_Cha.Text = "Không có thông tin";

                if (item.phonenum_dad != null) tbSDT_Cha.Text = item.phonenum_dad;
                else tbSDT_Cha.Text = "Không có thông tin";

                if (item.job_dad != null) tbNgheNghiep_Cha.Text = item.job_dad;
                else tbNgheNghiep_Cha.Text = "Không có thông tin";

                if (item.yearbirth_dad != null) tbNamSinh_Cha.Text = item.yearbirth_dad.ToString();
                else tbNamSinh_Cha.Text = "Không có thông tin";

                //Thông tin của mẹ của học sinh
                if (item.name_mom != null) tbHoTenMe.Text = item.name_mom;
                else tbHoTenMe.Text = "Không có thông tin";

                if (item.id_mom != null) tbCCCD_Me.Text = item.id_mom;
                else tbCCCD_Me.Text = "Không có thông tin";

                if (item.phonenum_mom != null) tbSDT_Me.Text = item.phonenum_mom;
                else tbSDT_Me.Text = "Không có thông tin";

                if (item.job_mom != null) tbNgheNghiepMe.Text = item.job_mom;
                else tbNgheNghiepMe.Text = "Không có thông tin";

                if (item.yearbirth_mom != null) tbNamSinhMe.Text = item.yearbirth_mom.ToString();
                else tbNamSinhMe.Text = "Không có thông tin";
            }
            pnStudent_info.Show();
            lbThongTinHocSinh.Show();
            pnDadofStudent_Info.Show();
            pnMomOfStudent_Info.Show();
            pnParentInfo.Show();
        }
        void TraCuuHS()
        {
            dataEntities db = new dataEntities();
            //Tra cứu theo mã số học sinh
            if (tbStudentID.Text != "")
            {
                if (tbFindName.Text != "" && cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1 && tbFindEmail.Text != "" && tbFindPhoneNum.Text != "")
                {
                    var case1 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text && iter3.TenLop == cbClass.SelectedValue.ToString() && iter1.Email == tbFindEmail.Text && iter1.SDT == tbFindPhoneNum.Text
                                select iter1.MaHocSinh;
                    if (case1.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        ThongTinHS_byID(tbStudentID.Text);
                    }
                }
                else if (tbFindName.Text != "" && cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1 && tbFindEmail.Text != "")
                {
                    var case2 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text && iter3.TenLop == cbClass.SelectedValue.ToString() && iter1.Email == tbFindEmail.Text
                                select iter1.MaHocSinh;
                    if (case2.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }

                }
                else if (tbFindName.Text != "" && cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1 && tbFindPhoneNum.Text != "")
                {
                    var case3 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text && iter3.TenLop == cbClass.SelectedValue.ToString() && iter1.SDT == tbFindPhoneNum.Text
                                select iter1.MaHocSinh;
                    if (case3.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else if (tbFindName.Text != "" && tbFindEmail.Text != "" && tbFindPhoneNum.Text != "")
                {
                    var case4 = from iter in db.HOCSINHs
                                where iter.MaHocSinh == tbStudentID.Text && iter.HoTen == tbFindName.Text && iter.SDT == tbFindPhoneNum.Text && iter.Email == tbFindEmail.Text
                                select iter.MaHocSinh;
                    if (case4.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else if (tbFindName.Text != "" && cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1)
                {
                    var case5 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == tbStudentID.Text && iter1.HoTen == tbFindName.Text && iter3.TenLop == cbClass.SelectedValue.ToString()
                                select iter1.MaHocSinh;
                    if (case5.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else if (tbFindName.Text != "" && tbFindPhoneNum.Text != "")
                {
                    var case6 = from iter in db.HOCSINHs
                                where iter.MaHocSinh == tbStudentID.Text && iter.HoTen == tbFindName.Text && iter.SDT == tbFindPhoneNum.Text
                                select iter.MaHocSinh;
                    if (case6.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else if (tbFindName.Text != "" && tbFindEmail.Text != "")
                {
                    var case7 = from iter in db.HOCSINHs
                                where iter.MaHocSinh == tbStudentID.Text && iter.HoTen == tbFindName.Text && iter.Email == tbFindEmail.Text
                                select iter.MaHocSinh;
                    if (case7.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else if (cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1 && tbFindEmail.Text != "" && tbFindPhoneNum.Text != "")
                {
                    var case8 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == tbStudentID.Text && iter3.TenLop == cbClass.SelectedValue.ToString() && iter1.Email == tbFindEmail.Text && iter1.SDT == tbFindPhoneNum.Text
                                select iter1.MaHocSinh;
                    if (case8.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else if (cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1 && tbFindEmail.Text != "")
                {
                    var case9 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.MaHocSinh == tbStudentID.Text && iter3.TenLop == cbClass.SelectedValue.ToString() && iter1.Email == tbFindEmail.Text
                                select iter1.MaHocSinh;
                    if (case9.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else if (cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1 && tbFindPhoneNum.Text != "")
                {
                    var case10 = from iter1 in db.HOCSINHs
                                 join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                 join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                 where iter1.MaHocSinh == tbStudentID.Text && iter3.TenLop == cbClass.SelectedValue.ToString() && iter1.SDT == tbFindPhoneNum.Text
                                 select iter1.MaHocSinh;
                    if (case10.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else if (tbFindEmail.Text != "" && tbFindPhoneNum.Text != "")
                {
                    var case11 = from iter in db.HOCSINHs
                                 where iter.MaHocSinh == tbStudentID.Text && iter.SDT == tbFindPhoneNum.Text && iter.Email == tbFindEmail.Text
                                 select iter.MaHocSinh;
                    if (case11.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else if (tbFindEmail.Text != "")
                {
                    var case12 = from iter in db.HOCSINHs
                                 where iter.MaHocSinh == tbStudentID.Text && iter.Email == tbFindEmail.Text
                                 select iter.MaHocSinh;
                    if (case12.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else if (tbFindPhoneNum.Text != "")
                {
                    var case13 = from iter in db.HOCSINHs
                                 where iter.MaHocSinh == tbStudentID.Text && iter.SDT == tbFindPhoneNum.Text
                                 select iter.MaHocSinh;
                    if (case13.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else if (cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1)
                {
                    var case14 = from iter1 in db.HOCSINHs
                                 join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                 join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                 where iter1.MaHocSinh == tbStudentID.Text && iter3.TenLop == cbClass.SelectedValue.ToString()
                                 select iter1.MaHocSinh;
                    if (case14.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else if (tbFindName.Text != "")
                {
                    var case15 = from iter in db.HOCSINHs
                                 where iter.MaHocSinh == tbStudentID.Text && iter.HoTen == tbFindName.Text
                                 select iter.MaHocSinh;
                    if (case15.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
                else
                {
                    var case16 = from iter in db.HOCSINHs
                                 where iter.MaHocSinh == tbStudentID.Text
                                 select iter.MaHocSinh;
                    if (case16.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else { ThongTinHS_byID(tbStudentID.Text); }
                }
            }
            //Tra cứu theo Họ tên + Lớp + SĐT/Email
            else if (cbFindStudenID_2.SelectedIndex == -1 && tbFindName.Text != "" && cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1)
            {
                if (tbFindEmail.Text != "" && tbFindPhoneNum.Text != "")
                {
                    var case1 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.HoTen == tbFindName.Text && iter3.TenLop == cbClass.SelectedValue.ToString() && iter1.Email == tbFindEmail.Text && iter1.SDT == tbFindPhoneNum.Text
                                select iter1.MaHocSinh;
                    if (case1.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (case1.Count() > 1)
                    {
                        MessageBox.Show("Có nhiều hơn 1 học sinh trùng với thông tin đã nhập. Hãy chọn mã số học sinh muốn tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbStudentID.Hide();
                        cbFindStudenID_2.Show();
                        cbFindStudenID_2.DataSource = case1.ToList();
                        cbFindStudenID_2.DisplayMember = "MaHocSinh";
                        cbFindStudenID_2.SelectedIndex = -1;
                    }
                    else
                    {
                        ThongTinHS_byName(tbFindName.Text);
                    }

                }
                else if (tbFindEmail.Text != "")
                {
                    var case2 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.HoTen == tbFindName.Text && iter3.TenLop == cbClass.SelectedValue.ToString() && iter1.Email == tbFindEmail.Text
                                select iter1.MaHocSinh;
                    if (case2.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (case2.Count() > 1)
                    {
                        MessageBox.Show("Có nhiều hơn 1 học sinh trùng với thông tin đã nhập. Hãy chọn mã số học sinh muốn tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbStudentID.Hide();
                        cbFindStudenID_2.Show();
                        cbFindStudenID_2.DataSource = case2.ToList();
                        cbFindStudenID_2.DisplayMember = "MaHocSinh"; 
                        cbFindStudenID_2.SelectedIndex = -1;
                    }
                    else
                    {
                        ThongTinHS_byName(tbFindName.Text);
                    }
                }
                else if (tbFindPhoneNum.Text != "")
                {
                    var case3 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.HoTen == tbFindName.Text && iter3.TenLop == cbClass.SelectedValue.ToString() && iter1.SDT == tbFindPhoneNum.Text
                                select iter1.MaHocSinh;
                    if (case3.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (case3.Count() > 1)
                    {
                        MessageBox.Show("Có nhiều hơn 1 học sinh trùng với thông tin đã nhập. Hãy chọn mã số học sinh muốn tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbStudentID.Hide();
                        cbFindStudenID_2.Show();
                        cbFindStudenID_2.DataSource = case3.ToList();
                        cbFindStudenID_2.DisplayMember = "MaHocSinh";
                        cbFindStudenID_2.SelectedIndex = -1;    
                    }
                    else
                    {
                        ThongTinHS_byName(tbFindName.Text);
                    }
                }
                else
                {
                    var case4 = from iter1 in db.HOCSINHs
                                join iter2 in db.CTLOPs on iter1.MaHocSinh equals iter2.MaHocSinh
                                join iter3 in db.LOPs on iter2.MaLop equals iter3.MaLop
                                where iter1.HoTen == tbFindName.Text && iter3.TenLop == cbClass.SelectedValue.ToString()
                                select iter1.MaHocSinh;
                    if (case4.Count() == 0)
                    {
                        MessageBox.Show("Không tìm thấy học sinh phù hợp với thông tin đã nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (case4.Count() > 1)
                    {
                        MessageBox.Show("Có nhiều hơn 1 học sinh trùng với thông tin đã nhập. Hãy chọn mã số học sinh muốn tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbStudentID.Hide();
                        cbFindStudenID_2.Show();
                        cbFindStudenID_2.DataSource = case4.ToList();
                        cbFindStudenID_2.DisplayMember = "MaHocSinh";
                        cbFindStudenID_2.SelectedIndex = -1;
                    }
                    else
                    {
                        ThongTinHS_byName(tbFindName.Text);
                    }
                } 
                    
                return;   
            }
            else if (cbFindStudenID_2.SelectedIndex != -1 && tbFindName.Text != "" && cbGrade.SelectedIndex != -1 && cbClass.SelectedIndex != -1)
            {
                ThongTinHS_byID(cbFindStudenID_2.SelectedValue.ToString());
            }    
            else if (tbFindName.Text == "" || cbClass.SelectedIndex == -1)
            {
                MessageBox.Show("Cần nhập thêm thông tin để tra cứu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (tbStudentID.Text == "" && tbFindEmail.Text == "" && tbFindName.Text == "" && tbFindPhoneNum.Text == "" && cbClass.SelectedIndex == -1)
                {
                    MessageBox.Show("Không có thông tin để tra cứu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }   
        }
        private void BtnFindInfoStu_Click(object sender, EventArgs e)
        {
            try
            {
                TraCuuHS();
            }
            catch
            {
                MessageBox.Show("Thao tác tra cứu thông tin học sinh đã xảy ra lỗi. Mời nhập lại. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

        private void cbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb = sender as System.Windows.Forms.ComboBox;
            if (cb.SelectedValue != null)
            {
                var temp1 = cb.SelectedValue.ToString();
                var temp2 = cbSchoolYear.SelectedValue.ToString();

                dataEntities db = new dataEntities();

                var CBLop = from iter1 in db.LOPs
                            join iter2 in db.KHOIs on iter1.MaKhoi equals iter2.MaKhoi
                            join iter3 in db.NAMHOCs on iter1.MaNamHoc equals iter3.MaNamHoc
                            where iter2.TenKhoi.ToString() == temp1 && iter3.NamHoc1 == temp2
                            select iter1.TenLop;

                cbClass.DataSource = CBLop.ToList();
                cbClass.DisplayMember = "TenLop";
            }
        }
        private void cbSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cb1 = sender as System.Windows.Forms.ComboBox;
            if (cb1.SelectedValue != null)
            {
                var temp = cb1.SelectedValue.ToString();
                dataEntities db = new dataEntities();

                var CBKhoi = from iter1 in db.KHOIs
                             join iter2 in db.NAMHOCs on iter1.MaNamHoc equals iter2.MaNamHoc
                             where iter2.NamHoc1 == temp
                             select iter1.TenKhoi;

                cbGrade.DataSource = CBKhoi.ToList();
                cbGrade.DisplayMember = "TenKhoi";
            }    
            
        }
        private void BtnRefresh1_Click(object sender, EventArgs e)
        {
            tbStudentID.Clear();
            tbStudentID.ReadOnly = false;
            tbStudentID.Text = "";
            tbStudentID.Show();

            tbFindName.Clear();
            tbFindName.ReadOnly = false;
            tbFindName.Text = "";

            tbFindEmail.Clear();
            tbFindEmail.ReadOnly = false;
            tbFindEmail.Text = "";

            tbFindPhoneNum.Clear();
            tbFindPhoneNum.ReadOnly = false;
            tbFindPhoneNum.Text = "";

            cbGrade.ResetText();
            cbGrade.SelectedIndex = -1;
            cbClass.ResetText();
            cbClass.SelectedIndex = -1;
            cbGrade.Enabled = true;
            cbClass.Enabled = true;
            cbFindStudenID_2.SelectedIndex = -1;
            cbFindStudenID_2.Hide();

            pnStudent_info.Hide();
            pnParentInfo.Hide();
            //lbThongTinPhuHuynh.Hide();
            pnDadofStudent_Info.Hide();
            pnMomOfStudent_Info.Hide();
        }


        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            (this.formTraCuu as TrangChu).Show();
            this.Close();
        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void BtnProfileAccount_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void TraCuuHocSinh_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void BtnHuongDanTraCuu_Click(object sender, EventArgs e)
        {
            pnHuongDanTraCuu.Show();
            lbHuongDanTraCuu.Text = "Hướng dẫn Tra cứu: Có 2 cách tra cứu\n1.Tra cứu theo Mã số học sinh: Bạn cần nhập ít nhất thông tin Mã số học sinh để tra cứu" +
                "\n2.Tra cứu theo Họ tên (Không cần nhập Mã số học sinh): Bạn cần nhập ít nhất các thông tin sau: " +
                "\nHọ tên học sinh, Năm học hiện tại, Khối, Lớp hiện tại và 1 trong 2 thông tin SĐT hoặc Email ";    
        }

        private void BtnCloseHuongDanTraCuu_Click(object sender, EventArgs e)
        {
            pnHuongDanTraCuu.Hide();
        }

        private void ButtonSaveInfo_Click(object sender, EventArgs e)
        {
            DialogResult choose = MessageBox.Show("Lưu thay đổi?", "Lưu", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (choose == DialogResult.OK)
            {
                dataEntities db = new dataEntities();
                // Save Student Info code
                var hocsinh = db.HOCSINHs.First(m => m.MaHocSinh == tbStudentID.Text);
                hocsinh.SDT = tbSDT.Text;
                hocsinh.Email = this.tbEmail.Text;

                hocsinh.SDT_Cha = this.tbSDT_Cha.Text;
                hocsinh.SDT_Me = this.tbSDT_Me.Text;

                db.HOCSINHs.AddOrUpdate(hocsinh);
                db.SaveChanges();
                MessageBox.Show("Lưu thay đổi thành công",
                                "Lưu thành công",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }
}