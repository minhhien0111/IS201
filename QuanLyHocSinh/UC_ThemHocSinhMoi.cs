using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class UC_ThemHocSinhMoi : UserControl
    {
        public UC_ThemHocSinhMoi()
        {
            InitializeComponent();
            this.cbGender.SelectedIndex = 0;
            this.dtpBirthday.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthday.Format = DateTimePickerFormat.Custom;
        }

        private bool IsOnlySpace(String str)
        {
            for (int i = 0; i < str.Length; i++) {
                if (str[i] != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        private void AddNewStudent()
        {
            this.tbName.Text.Trim();
            this.tbOrigin.Text.Trim();
            this.tbAddress.Text.Trim();
            this.tbNumPhone.Text.Trim();

            if(tbName.Text.Length > 0
                && tbOrigin.Text.Length > 0
                && tbAddress.Text.Length > 0
                && tbNumPhone.Text.Length > 0
                && !IsOnlySpace(tbName.Text)
                && !IsOnlySpace(tbOrigin.Text)
                && !IsOnlySpace(tbAddress.Text)
                && !IsOnlySpace(tbNumPhone.Text))
            {
                try {
                    short sNamSinhCha = 0;
                    short sNamSinhMe = 0;
                    if (this.tbDadBirthyear.Text != "")
                    {
                        sNamSinhCha = short.Parse(this.tbDadBirthyear.Text);

                    }
                    if (this.tbMomBirthyear.Text != "")
                    {
                        sNamSinhMe = short.Parse(this.tbMomBirthyear.Text);
                    }

                    dataEntities db = new dataEntities();
                    List<String> listID = (from obj in db.HOCSINHs
                                           where obj.MaHocSinh.Substring(0, 4) == "2252"
                                           orderby obj.MaHocSinh descending
                                           select obj.MaHocSinh).ToList();

                    String strID = "2252";
                    if (listID.Count > 0)
                    {
                        short sIndex = short.Parse(listID.First().Substring(4));
                        sIndex++;
                        String strIndex = sIndex.ToString();
                        for (int i = 0; i < 4 - strIndex.Length; i++)
                        {
                            strID += "0";
                        }
                        strID += strIndex;
                    }
                    else
                    {
                        strID = "22520001";
                    }

                    byte sTuoiToiThieu = (byte)(from obj in db.THAMSOes
                                                select obj.TuoiToiThieu).ToList().First();
                    byte sTuoiToiDa = (byte)(from obj in db.THAMSOes
                                             select obj.TuoiToiDa).ToList().First();
                    byte sTuoi = (byte)(DateTime.Now.Year - dtpBirthday.Value.Year);

                    if (sTuoi >= sTuoiToiThieu && sTuoi <= sTuoiToiDa)
                    {
                        HOCSINH hs = new HOCSINH();
                        hs.MaHocSinh = strID;
                        hs.HoTen = this.tbName.Text;
                        hs.GioiTinh = this.cbGender.Text;

                        // Birthday
                        DateTime dateTime = new DateTime();
                        dateTime = dateTime.AddDays(this.dtpBirthday.Value.Day);
                        dateTime = dateTime.AddMonths(this.dtpBirthday.Value.Month);
                        dateTime = dateTime.AddYears(this.dtpBirthday.Value.Year);
                        hs.NgaySinh = dateTime;

                        hs.DiaChi = this.tbAddress.Text;
                        hs.QueQuan = this.tbOrigin.Text;
                        hs.DanToc = this.tbEthnicity.Text;
                        hs.TonGiao = this.tbReligion.Text;
                        hs.SDT = this.tbNumPhone.Text;
                        hs.Email = this.tbEmail.Text;
                        hs.HoTenCha = this.tbDadName.Text;
                        if(this.tbDadBirthyear.Text != "")
                        {
                            hs.NamSinh_Cha = sNamSinhCha;
                        }
                        hs.CCCD_Cha = this.tbDadID.Text;
                        hs.SDT_Cha = this.tbDadPhoneNum.Text;
                        hs.NgheNghiep_Cha = this.tbDadJob.Text;
                        hs.HoTenMe = this.tbMomName.Text;
                        if (this.tbMomBirthyear.Text != "")
                        {
                            hs.NamSinh_Me = sNamSinhMe;
                        }
                        hs.CCCD_Me = this.tbMomID.Text;
                        hs.SDT_Me = this.tbMomPhoneNum.Text;
                        hs.NgheNghiep_Me = this.tbMomJob.Text;

                        db.HOCSINHs.Add(hs);
                        db.SaveChanges();
                        MessageBox.Show("Thêm học sinh thành công\nMSHS là " + strID,
                                        "Thêm thành công",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Tuổi học sinh phải từ " + sTuoiToiThieu + " đến " + sTuoiToiDa + " tuổi.\n" +
                                        "Thêm học sinh không thành công.",
                                        "Lỗi",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                catch(FormatException) {
                    MessageBox.Show("Giá trị nhập vào cho năm sinh không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch(OverflowException)
                {
                    MessageBox.Show("Giá trị nhập vào cho năm sinh vượt quá giới hạn lưu trữ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
            else
            {
                MessageBox.Show("Các trường bắt buộc không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddNewStudent();
        }

    
    }
}
