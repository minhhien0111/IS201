using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace QuanLyHocSinh
{
    public partial class BaoCaoTongKet : Form
    {
        public BaoCaoTongKet()
        {
            InitializeComponent();
            dataEntities data = new dataEntities();
            //Get source

            var ComboBoxYearsSource = from obj in data.NAMHOCs
                                      orderby obj.MaNamHoc descending
                                      select obj;

            guna2ComboBoxYears1.DataSource = ComboBoxYearsSource.ToList();
            guna2ComboBoxYears1.DisplayMember = "NamHoc1";
            guna2ComboBoxYears1.ValueMember = "MaNamHoc";

            guna2ComboBoxYears2.DataSource = ComboBoxYearsSource.ToList();
            guna2ComboBoxYears2.DisplayMember = "NamHoc1";
            guna2ComboBoxYears2.ValueMember = "MaNamHoc";

            guna2ComboBoxYears3.DataSource = ComboBoxYearsSource.ToList();
            guna2ComboBoxYears3.DisplayMember = "NamHoc1";
            guna2ComboBoxYears3.ValueMember = "MaNamHoc";

            guna2ComboBoxYears4.DataSource = ComboBoxYearsSource.ToList();
            guna2ComboBoxYears4.DisplayMember = "NamHoc1";
            guna2ComboBoxYears4.ValueMember = "MaNamHoc";
        }


        private void guna2ImageButtonSearch1_Click(object sender, EventArgs e)
        {
            try
            {
                dataEntities dtb = new dataEntities();
                DataTable tbl = new DataTable();

                var cls_list = dtb.TongKetMonHocKy(guna2ComboBoxSubjects1.SelectedValue.ToString(), guna2ComboBoxSemesters1.SelectedValue.ToString(), guna2ComboBoxYears1.SelectedValue.ToString()).Select(r => r.TenLop).Distinct().ToList();
                var sum = 0;


                if (cls_list.Count() == 0)
                {
                    MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tbl.Columns.Add("STT", typeof(string));
                    tbl.Columns.Add("Lớp", typeof(string));
                    tbl.Columns.Add("Sĩ số", typeof(int));
                    foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears1.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
                        {
                            tbl.Columns.Add(item.TenXepLoai, typeof(int));
                        }
                    }
                    var index = -1;
                    foreach (var item in cls_list)
                    {
                        int num = 0;
                        var cls = dtb.TongKetMonHocKy(guna2ComboBoxSubjects1.SelectedValue.ToString(), guna2ComboBoxSemesters1.SelectedValue.ToString(), guna2ComboBoxYears1.SelectedValue.ToString()).Where(r => r.TenLop == item.ToString()).ToList();
                        DataRow row = tbl.NewRow();
                        index += 1;
                        row["STT"] = index + 1;
                        row["Lớp"] = item.ToString();
                        foreach (var item2 in dtb.XepLoai_NamApDung(guna2ComboBoxYears1.SelectedValue.ToString()))
                        {
                            if (item2.MaXepLoai != "HSR")
                            {
                                row[item2.TenXepLoai] = "0";
                            }
                        }
                        foreach (var item2 in cls)
                        {
                            num += (int)item2.SoLuong;
                            sum += (int)item2.SoLuong;
                            var TenXepLoai = from obj in dtb.XepLoai_NamApDung(guna2ComboBoxYears1.SelectedValue.ToString())
                                             where obj.MaXepLoai == item2.MaXepLoai
                                             select obj.TenXepLoai;
                            row[TenXepLoai.FirstOrDefault().ToString()] = item2.SoLuong;

                        }
                        row["Sĩ số"] = num;
                        tbl.Rows.Add(row);
                    }

                    DataTable ratio_Source = new DataTable();
                    ratio_Source.Columns.Add("Xếp loại", typeof(string));
                    ratio_Source.Columns.Add("Số lượng", typeof(int));
                    ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
                    foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears1.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
                        {
                            DataRow row_ratio = ratio_Source.NewRow();
                            row_ratio["Xếp loại"] = item.TenXepLoai;
                            int count = Convert.ToInt32(tbl.Compute($"SUM([{item.TenXepLoai}])", string.Empty));
                            row_ratio["Số lượng"] = count;
                            double rat = Math.Round((float)(100 * count / sum), 2);
                            row_ratio["Tỉ lệ (%)"] = rat;
                            if (rat > 0)
                                ratio_Source.Rows.Add(row_ratio);
                        }
                    }


                    var TenMonHoc = from obj in dtb.MONHOCs
                                    where obj.MaMonHoc == guna2ComboBoxSubjects1.SelectedValue
                                    select obj.TenMonHoc;
                    var NamHoc = from obj in dtb.NAMHOCs
                                 where obj.MaNamHoc == guna2ComboBoxYears1.SelectedValue
                                 select obj.NamHoc1;


                    LabelNameReportGridview1.Text = $"BẢNG THỐNG KÊ MÔN {TenMonHoc.FirstOrDefault().ToString().ToUpper()} HỌC KỲ {guna2ComboBoxSemesters1.SelectedValue.ToString()} NĂM {NamHoc.FirstOrDefault().ToString().ToUpper()}";
                    LabelNameReportGridview1.Show();

                    LabelNameRatio1.Show();

                    guna2DataGridViewRatio1.DataSource = ratio_Source;
                    guna2DataGridViewRatio1.Show();


                    ChartRatio.DataSource = ratio_Source;
                    ChartRatio.Series[0].XValueMember = "Xếp loại";
                    ChartRatio.Series[0].YValueMembers = "Tỉ lệ (%)";
                    ChartRatio.Series[0].IsValueShownAsLabel = true;
                    ChartRatio.Show();

                    guna2DataGridViewReport1.DataSource = tbl;
                    guna2DataGridViewReport1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    guna2DataGridViewReport1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    guna2DataGridViewReport1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    guna2DataGridViewReport1.Show();
                    guna2ImageButtonPrint1.Show();
                }
            }
            catch
            {
                MessageBox.Show("Thao tác xảy ra lỗi, mời thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ImageButtonSearch2_Click(object sender, EventArgs e)
        {
            try
            {
                dataEntities dtb = new dataEntities();
                DataTable tbl = new DataTable();

                var cls_list = dtb.TongKetMonNamHoc(guna2ComboBoxSubjects2.SelectedValue.ToString(), guna2ComboBoxYears2.SelectedValue.ToString()).Select(r => r.TenLop).Distinct().ToList();


                if (cls_list.Count() == 0)
                {
                    MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tbl.Columns.Add("STT", typeof(string));
                    tbl.Columns.Add("Lớp", typeof(string));
                    tbl.Columns.Add("Sĩ số", typeof(int));
                    foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears2.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
                        {
                            tbl.Columns.Add(item.TenXepLoai, typeof(int));
                        }
                    }
                    int sum = 0;
                    int index = -1;
                    foreach (var item in cls_list)
                    {
                        DataRow row = tbl.NewRow();
                        index += 1;
                        row["STT"] = index + 1;
                        row["Lớp"] = item.ToString();
                        foreach (var item2 in dtb.XepLoai_NamApDung(guna2ComboBoxYears2.SelectedValue.ToString()))
                        {
                            if (item2.MaXepLoai != "HSR")
                            {
                                row[item2.TenXepLoai] = 0;
                            }
                        }
                        var std_list = dtb.TongKetMonNamHoc(guna2ComboBoxSubjects2.SelectedValue.ToString(), guna2ComboBoxYears2.SelectedValue.ToString()).Where(r => r.TenLop == item.ToString()).Select(r => r.MaHocSinh).Distinct().ToList();
                        sum += std_list.Count();
                        row["Sĩ số"] = std_list.Count();
                        tbl.Rows.Add(row);
                        foreach (var item2 in std_list)
                        {
                            var sub = dtb.TongKetMonNamHoc(guna2ComboBoxSubjects2.SelectedValue.ToString(), guna2ComboBoxYears2.SelectedValue.ToString()).Where(r => r.MaHocSinh == item2.ToString()).ToList();
                            double score = 0;
                            double sum_TS = 0;
                            foreach (var item3 in sub)
                            {
                                var TS = from obj in dtb.HocKy_NamApDung(guna2ComboBoxYears2.SelectedValue.ToString())
                                         where obj.MaHocKy == item3.HocKy
                                         select obj.TrongSo;
                                double ts_change = (double)TS.FirstOrDefault();
                                sum_TS += ts_change;
                                score += (double)item3.DiemTB * ts_change;
                            }
                            score = Math.Round(score / sum_TS, 2);
                            foreach (var item3 in dtb.XepLoai_NamApDung(guna2ComboBoxYears2.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                            {
                                    if (score >= item3.DiemToiThieu)
                                    {
                                        var temp = tbl.Rows[index][item3.TenXepLoai];
                                        temp = (int)temp + 1;
                                        tbl.Rows[index][item3.TenXepLoai] = temp;
                                        break;
                                    }
                            }
                        }
                    }
                    DataTable ratio_Source = new DataTable();
                    ratio_Source.Columns.Add("Xếp loại", typeof(string));
                    ratio_Source.Columns.Add("Số lượng", typeof(int));
                    ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
                    foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears2.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
                        {
                            DataRow row_ratio = ratio_Source.NewRow();
                            row_ratio["Xếp loại"] = item.TenXepLoai;
                            int count = Convert.ToInt32(tbl.Compute($"SUM([{item.TenXepLoai}])", string.Empty));
                            row_ratio["Số lượng"] = count;
                            double rat = Math.Round((float)(100 * count / sum), 2);
                            row_ratio["Tỉ lệ (%)"] = rat;
                            if (rat > 0)
                                ratio_Source.Rows.Add(row_ratio);
                        }
                    }

                    var TenMonHoc = from obj in dtb.MONHOCs
                                    where obj.MaMonHoc == guna2ComboBoxSubjects2.SelectedValue
                                    select obj.TenMonHoc;
                    var NamHoc = from obj in dtb.NAMHOCs
                                 where obj.MaNamHoc == guna2ComboBoxYears2.SelectedValue
                                 select obj.NamHoc1;


                    LabelNameReportGridview2.Text = $"BẢNG THỐNG KÊ MÔN {TenMonHoc.FirstOrDefault().ToString().ToUpper()} NĂM {NamHoc.FirstOrDefault().ToString().ToUpper()}";
                    LabelNameReportGridview2.Show();

                    LabelNameRatio2.Show();


                    guna2DataGridViewRatio2.DataSource = ratio_Source;
                    guna2DataGridViewRatio2.Show();


                    ChartRatio2.DataSource = ratio_Source;
                    ChartRatio2.Series[0].XValueMember = "Xếp loại";
                    ChartRatio2.Series[0].YValueMembers = "Tỉ lệ (%)";
                    ChartRatio2.Series[0].IsValueShownAsLabel = true;
                    ChartRatio2.Show();

                    guna2DataGridViewReport2.DataSource = tbl;
                    guna2DataGridViewReport2.Show();

                    guna2DataGridViewReport2.DataSource = tbl;
                    guna2DataGridViewReport2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    guna2DataGridViewReport2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    guna2DataGridViewReport2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    guna2DataGridViewReport2.Show();
                    guna2ImageButtonPrint2.Show();

                }
            }
            catch
            {
                MessageBox.Show("Thao tác xảy ra lỗi, mời thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ImageButtonSearch3_Click(object sender, EventArgs e)
        {
            try
            {
                dataEntities dtb = new dataEntities();
                DataTable tbl = new DataTable();
                var cls_list = dtb.TongKetHocKy(guna2ComboBoxSemesters2.SelectedValue.ToString(), guna2ComboBoxYears3.SelectedValue.ToString()).Select(r => r.TenLop).Distinct().ToList();

                if (cls_list.Count() == 0)
                {
                    MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tbl.Columns.Add("STT", typeof(string));
                    tbl.Columns.Add("Lớp", typeof(string));
                    tbl.Columns.Add("Sĩ số", typeof(int));
                    foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
                        {
                            tbl.Columns.Add(item.TenXepLoai, typeof(int));
                        }
                    }
                    var index = -1;
                    int sum = 0;
                    foreach (var item in cls_list)
                    {
                        DataRow row = tbl.NewRow();
                        index += 1;
                        row["STT"] = index + 1;
                        row["Lớp"] = item.ToString();
                        foreach (var item2 in dtb.XepLoai_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString()))
                        {
                            if (item2.MaXepLoai != "HSR")
                            {
                                row[item2.TenXepLoai] = 0;
                            }
                        }
                        var std_list = dtb.TongKetHocKy(guna2ComboBoxSemesters2.SelectedValue.ToString(), guna2ComboBoxYears3.SelectedValue.ToString()).Where(r => r.TenLop == item.ToString()).Select(r => r.MaHocSinh).ToList();
                        sum += std_list.Count();
                        row["Sĩ số"] = std_list.Count();
                        tbl.Rows.Add(row);
                        foreach (var item2 in std_list)
                        {
                            var std = dtb.TongKetHocKy(guna2ComboBoxSemesters2.SelectedValue.ToString(), guna2ComboBoxYears3.SelectedValue.ToString()).Where(r => r.MaHocSinh == item2.ToString()).FirstOrDefault();
                            double score = Math.Round((double)(std.DiemTB / std.SoLuong), 2);
                            foreach (var item3 in dtb.XepLoai_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                            {
                                    if (score >= item3.DiemToiThieu)
                                    {
                                        if (std.DiemKC >= item3.DiemKhongChe)
                                        {
                                            var temp = tbl.Rows[index][item3.TenXepLoai];
                                            temp = (int)temp + 1;
                                            tbl.Rows[index][item3.TenXepLoai] = temp;
                                        }
                                        else
                                        {
                                            bool find = false;
                                            var item4 = dtb.XepLoai_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString()).FirstOrDefault();
                                            foreach (var item5 in dtb.XepLoai_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                                            {
                                                if (score >= item5.DiemToiThieu)
                                                {
                                                    if (find)
                                                    {
                                                        item4 = item5;
                                                        break;
                                                    }
                                                    find = true;
                                                }
                                            }
                                            var temp = tbl.Rows[index][item4.TenXepLoai];
                                            temp = (int)temp + 1;
                                            tbl.Rows[index][item4.TenXepLoai] = temp;
                                        }
                                        break;
                                    }
                            }
                        }
                    }

                    DataTable ratio_Source = new DataTable();
                    ratio_Source.Columns.Add("Xếp loại", typeof(string));
                    ratio_Source.Columns.Add("Số lượng", typeof(int));
                    ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
                    foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
                        {
                            DataRow row_ratio = ratio_Source.NewRow();
                            row_ratio["Xếp loại"] = item.TenXepLoai;
                            int count = Convert.ToInt32(tbl.Compute($"SUM([{item.TenXepLoai}])", string.Empty));
                            row_ratio["Số lượng"] = count;
                            double rat = Math.Round((float)(100 * count / sum), 2);
                            row_ratio["Tỉ lệ (%)"] = rat;
                            if (rat > 0)
                                ratio_Source.Rows.Add(row_ratio);
                        }
                    }


                    var NamHoc = from obj in dtb.NAMHOCs
                                 where obj.MaNamHoc == guna2ComboBoxYears3.SelectedValue
                                 select obj.NamHoc1;


                    LabelNameReportGridview3.Text = $"BẢNG THỐNG KÊ HỌC KỲ {guna2ComboBoxSemesters2.SelectedValue.ToString()} NĂM {NamHoc.FirstOrDefault().ToString().ToUpper()}";
                    LabelNameReportGridview3.Show();

                    LabelNameRatio3.Show();


                    guna2DataGridViewRatio3.DataSource = ratio_Source;
                    guna2DataGridViewRatio3.Show();


                    ChartRatio3.DataSource = ratio_Source;
                    ChartRatio3.Series[0].XValueMember = "Xếp loại";
                    ChartRatio3.Series[0].YValueMembers = "Tỉ lệ (%)";
                    ChartRatio3.Series[0].IsValueShownAsLabel = true;
                    ChartRatio3.Show();

                    guna2DataGridViewReport3.DataSource = tbl;
                    guna2DataGridViewReport3.Show();

                    guna2DataGridViewReport3.DataSource = tbl;
                    guna2DataGridViewReport3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    guna2DataGridViewReport3.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    guna2DataGridViewReport3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    guna2DataGridViewReport3.Show();
                    guna2ImageButtonPrint3.Show();
                }
            }
            catch
            {
                MessageBox.Show("Thao tác xảy ra lỗi, mời thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool CheckDiemKC(string MaHS, string NamHoc, double DiemKC)
        {
            dataEntities dtb = new dataEntities();
            var check_source = dtb.TongKetMon_HocSinh(NamHoc, MaHS).ToList();
            var sub_list = check_source.Select(r => r.MaMonHoc).Distinct().ToList();
            
            foreach(var item in sub_list)
            {
                double score = 0;
                double sum_TS = 0;
                var sub = check_source.Where(r => r.MaMonHoc == item.ToString()).ToList();
                foreach(var item2 in sub)
                {
                    var TS = from obj in dtb.HocKy_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString())
                             where obj.MaHocKy == item2.MaHocKy
                             select obj.TrongSo;
                    double ts_change = (double)TS.FirstOrDefault();
                    sum_TS += ts_change;
                    score += (double)item2.DiemTB * ts_change;
                }
                score = Math.Round(score / sum_TS, 2);
                if (score < DiemKC)
                    return false;
            }            
            return true;
        }
        private void guna2ImageButtonSearch4_Click(object sender, EventArgs e)
        {
            try
            {
                dataEntities dtb = new dataEntities();
                DataTable tbl = new DataTable();
                var cls_list = dtb.TongKetNamHoc(guna2ComboBoxYears4.SelectedValue.ToString()).Select(r => r.TenLop).Distinct().ToList();
                if (cls_list.Count() == 0)
                {
                    MessageBox.Show("Không có dữ liệu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int index = -1;
                    int sum = 0;
                    tbl.Columns.Add("STT", typeof(string));
                    tbl.Columns.Add("Lớp", typeof(string));
                    tbl.Columns.Add("Sĩ số", typeof(int));
                    foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
                        {
                            tbl.Columns.Add(item.TenXepLoai, typeof(int));
                        }
                    }
                    foreach (var item in cls_list)
                    {
                        DataRow row = tbl.NewRow();
                        index += 1;
                        row["STT"] = index + 1;
                        row["Lớp"] = item.ToString();
                        foreach (var item2 in dtb.XepLoai_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString()))
                        {
                            if (item2.MaXepLoai != "HSR")
                            {
                                row[item2.TenXepLoai] = 0;
                            }
                        }
                        var std_list = dtb.TongKetNamHoc(guna2ComboBoxYears4.SelectedValue.ToString()).Where(r => r.TenLop == item.ToString()).Select(r => r.MaHocSinh).Distinct().ToList();
                        sum += std_list.Count();
                        row["Sĩ số"] = std_list.Count();
                        tbl.Rows.Add(row);
                        foreach (var item2 in std_list)
                        {
                            var check_source = dtb.TongKetMon_HocSinh(guna2ComboBoxYears4.SelectedValue.ToString(), item2.ToString()).ToList();
                            var sub_list = check_source.Select(r => r.MaMonHoc).Distinct().ToList();
                            double score = 0;

                            foreach (var item3 in sub_list)
                            {
                                double sub_score = 0;
                                double sum_TS = 0;
                                var sub = check_source.Where(r => r.MaMonHoc == item3.ToString()).ToList();
                                foreach (var item4 in sub)
                                {
                                    var TS = from obj in dtb.HocKy_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString())
                                             where obj.MaHocKy == item4.MaHocKy
                                             select obj.TrongSo;
                                    double ts_change = (double)TS.FirstOrDefault();
                                    sum_TS += ts_change;
                                    sub_score += (double)item4.DiemTB * ts_change;
                                }
                                sub_score = Math.Round(sub_score / sum_TS, 2);
                                score += sub_score;
                            }
                            score = Math.Round(score / sub_list.Count(), 2);
                            foreach (var item3 in dtb.XepLoai_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                            {
                                    if (score >= item3.DiemToiThieu)
                                    {
                                        if (CheckDiemKC(item2.ToString(), guna2ComboBoxYears4.SelectedValue.ToString(), (double)item3.DiemKhongChe))
                                        {
                                            var temp = tbl.Rows[index][item3.TenXepLoai];
                                            temp = (int)temp + 1;
                                            tbl.Rows[index][item3.TenXepLoai] = temp;
                                        }
                                        else
                                        {
                                            bool find = false;
                                            var item4 = dtb.XepLoai_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString()).FirstOrDefault();
                                            foreach (var item5 in dtb.XepLoai_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                                            {
                                                if (score >= item5.DiemToiThieu)
                                                {
                                                    if (find)
                                                    {
                                                        item4 = item5;
                                                        break;
                                                    }
                                                    find = true;
                                                }
                                            }
                                            var temp = tbl.Rows[index][item4.TenXepLoai];
                                            temp = (int)temp + 1;
                                            tbl.Rows[index][item4.TenXepLoai] = temp;
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                    DataTable ratio_Source = new DataTable();
                    ratio_Source.Columns.Add("Xếp loại", typeof(string));
                    ratio_Source.Columns.Add("Số lượng", typeof(int));
                    ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
                    foreach (var item in dtb.XepLoai_NamApDung(guna2ComboBoxYears4.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
                    {
                        if (item.MaXepLoai != "HSR")
                        {
                            DataRow row_ratio = ratio_Source.NewRow();
                            row_ratio["Xếp loại"] = item.TenXepLoai;
                            int count = Convert.ToInt32(tbl.Compute($"SUM([{item.TenXepLoai}])", string.Empty));
                            row_ratio["Số lượng"] = count;
                            double rat = Math.Round((float)(100 * count / sum), 2);
                            row_ratio["Tỉ lệ (%)"] = rat;
                            if (rat > 0)
                                ratio_Source.Rows.Add(row_ratio);
                        }
                    }


                    var NamHoc = from obj in dtb.NAMHOCs
                                 where obj.MaNamHoc == guna2ComboBoxYears4.SelectedValue
                                 select obj.NamHoc1;


                    LabelNameReportGridview4.Text = $"BẢNG THỐNG KÊ NĂM HỌC {NamHoc.FirstOrDefault().ToString()}";
                    LabelNameReportGridview4.Show();

                    LabelNameRatio4.Show();

                    guna2DataGridViewRatio4.DataSource = ratio_Source;
                    guna2DataGridViewRatio4.Show();


                    ChartRatio4.DataSource = ratio_Source;
                    ChartRatio4.Series[0].XValueMember = "Xếp loại";
                    ChartRatio4.Series[0].YValueMembers = "Tỉ lệ (%)";
                    ChartRatio4.Series[0].IsValueShownAsLabel = true;
                    ChartRatio4.Show();

                    guna2DataGridViewReport4.DataSource = tbl;
                    guna2DataGridViewReport4.Show();

                    guna2DataGridViewReport4.DataSource = tbl;
                    guna2DataGridViewReport4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    guna2DataGridViewReport4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    guna2DataGridViewReport4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    guna2DataGridViewReport4.Show();
                    guna2ImageButtonPrint4.Show();
                }
            }
            catch
            {
                MessageBox.Show("Thao tác xảy ra lỗi, mời thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel(DataGridView dataGridView,DataGridView dataGridView2)
        {
            try
            {
                Excel.Application excel = new Excel.Application();
                excel.Visible = true;
                Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                for (int i = 1; i <= dataGridView.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (dataGridView.Rows[i].Cells[j].Value != null)
                            worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.Sheets.Add(After: workbook.Sheets[workbook.Sheets.Count]);
                Excel.Worksheet worksheet2 = (Excel.Worksheet)workbook.Sheets[2];
                for (int i = 1; i <= dataGridView2.Columns.Count; i++)
                {
                    worksheet2.Cells[1, i] = dataGridView2.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView2.Columns.Count; j++)
                    {
                        if (dataGridView2.Rows[i].Cells[j].Value != null)
                            worksheet2.Cells[i + 2, j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.Close();
                excel.Quit();
            }
            catch
            {
                MessageBox.Show("Thao tác xảy ra lỗi, mời thực hiện lại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void guna2ImageButtonPrint1_Click(object sender, EventArgs e)
        {
            ExportToExcel(guna2DataGridViewReport1,guna2DataGridViewRatio1);
        }

        private void guna2ImageButtonPrint2_Click(object sender, EventArgs e)
        {
            ExportToExcel(guna2DataGridViewReport2, guna2DataGridViewRatio2);
        }

        private void guna2ImageButtonPrint3_Click(object sender, EventArgs e)
        {
            ExportToExcel(guna2DataGridViewReport3, guna2DataGridViewRatio3);
        }

        private void guna2ImageButtonPrint4_Click(object sender, EventArgs e)
        {
            ExportToExcel(guna2DataGridViewReport4, guna2DataGridViewRatio3);
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

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            TrangCaNhan newform = new TrangCaNhan();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }

        private void guna2ComboBoxYears1_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var ComboBoxSemestersSource = dtb.HocKy_NamApDung(guna2ComboBoxYears1.SelectedValue.ToString());
            guna2ComboBoxSemesters1.DataSource = ComboBoxSemestersSource.ToList();
            guna2ComboBoxSemesters1.DisplayMember = "HocKy";
            guna2ComboBoxSemesters1.ValueMember = "MaHocKy";

            var ComboBoxSubjectsSource = dtb.MonHoc_NamApDung(guna2ComboBoxYears1.SelectedValue.ToString());
            guna2ComboBoxSubjects1.DataSource = ComboBoxSubjectsSource.ToList();
            guna2ComboBoxSubjects1.DisplayMember = "TenMonHoc";
            guna2ComboBoxSubjects1.ValueMember = "MaMonHoc";
        }


        private void guna2ComboBoxYears2_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var ComboBoxSubjectsSource = dtb.MonHoc_NamApDung(guna2ComboBoxYears2.SelectedValue.ToString());
            guna2ComboBoxSubjects2.DataSource = ComboBoxSubjectsSource.ToList();
            guna2ComboBoxSubjects2.DisplayMember = "TenMonHoc";
            guna2ComboBoxSubjects2.ValueMember = "MaMonHoc";
        }

        private void guna2ComboBoxYears3_SelectedValueChanged(object sender, EventArgs e)
        {
            dataEntities dtb = new dataEntities();
            var ComboBoxSemestersSource = dtb.HocKy_NamApDung(guna2ComboBoxYears3.SelectedValue.ToString());
            guna2ComboBoxSemesters2.DataSource = ComboBoxSemestersSource.ToList();
            guna2ComboBoxSemesters2.DisplayMember = "HocKy";
            guna2ComboBoxSemesters2.ValueMember = "MaHocKy";
        }

        bool max = true;
    }
}
