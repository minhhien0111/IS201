using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyHocSinh
{   public partial class LapBangDiemMonHoc : Form
    {
        dataEntities data = new dataEntities();
        public TrangChu formTraCuu { get; set; }
        public LapBangDiemMonHoc(TrangChu mainform)
        {
            InitializeComponent();
            this.formTraCuu = mainform;
            dataEntities data = new dataEntities();
            var comBoxYear = from obj in data.NAMHOCs select obj;
            var comBoxYear1 = comBoxYear.OrderByDescending(p => p.MaNamHoc);
            ComboBoxYear.DataSource = comBoxYear1.ToList();
            ComboBoxYear.DisplayMember = "NamHoc1";
            ComboBoxYear.ValueMember = "MaNamHoc";
            var comboxClassSource = from obj in data.LOPs where obj.MaNamHoc == ComboBoxYear.SelectedValue select obj;
            ComboBoxClass.DataSource = comboxClassSource.ToList();
            ComboBoxClass.DisplayMember = "TenLop";
            ComboBoxClass.ValueMember = "MaLop";
            var comboxClassSemester = from obj in data.HocKy_NamApDung(ComboBoxYear.SelectedValue.ToString()) select obj;
            ComboBoxSemester.DataSource = comboxClassSemester.ToList();
            ComboBoxSemester.DisplayMember = "HocKy";
            ComboBoxSemester.ValueMember = "MaHocKy";
            var ComboBoxSubjectsSource = from obj in data.MonHoc_NamApDung(ComboBoxYear.SelectedValue.ToString())
                                         where obj.MaMonHoc.Substring(obj.MaMonHoc.Length - 2) == ComboBoxClass.Text.Substring(0, 2)
                                         select obj;
            ComboBoxSubject.DataSource = ComboBoxSubjectsSource.ToList();
            ComboBoxSubject.DisplayMember = "TenMonHoc";
            ComboBoxSubject.ValueMember = "MaMonHoc";
            PanelInputScore.Hide();
            PanelShowScore.Hide();
            DataGridViewScore1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewScore1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DataGridViewScore2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewScore2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; 

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
        private void comboBoxYear_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBoxSubject.Enabled = false;
            var comboxClassSource = from obj in data.LOPs.AsEnumerable() where obj.MaNamHoc == ComboBoxYear.SelectedValue.ToString() select obj;
            ComboBoxClass.DataSource = comboxClassSource.ToList();
            ComboBoxClass.DisplayMember = "TenLop";
            ComboBoxClass.ValueMember = "MaLop";
            var comboxClassSemester = from obj in data.HocKy_NamApDung(ComboBoxYear.SelectedValue.ToString()) select obj;
            ComboBoxSemester.DataSource = comboxClassSemester.ToList();
            ComboBoxSemester.DisplayMember = "HocKy";
            ComboBoxSemester.ValueMember = "MaHocKy";
            string class_text = ComboBoxClass.Text;
            var ComboBoxSubjectsSource = from obj in data.MonHoc_NamApDung(ComboBoxYear.SelectedValue.ToString())
                                         select obj;
            ComboBoxSubject.DataSource = ComboBoxSubjectsSource.ToList();
            ComboBoxSubject.DisplayMember = "TenMonHoc";
            ComboBoxSubject.ValueMember = "MaMonHoc";
        }
        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ComboBoxSubjectsSource = from obj in data.MonHoc_NamApDung(ComboBoxYear.SelectedValue.ToString())
                                         where obj.MaMonHoc.Substring(obj.MaMonHoc.Length - 2) == ComboBoxClass.Text.Substring(0, 2)
                                         select obj;
            ComboBoxSubject.DataSource = ComboBoxSubjectsSource.ToList();
            ComboBoxSubject.DisplayMember = "TenMonHoc";
            ComboBoxSubject.ValueMember = "MaMonHoc";
        }
        private void comboBoxClass_Click(object sender, EventArgs e)
        {
            ComboBoxSubject.Enabled = true;
        }
        private void textBoxScore_TextChanged(object sender, EventArgs e)
        {
            TextBox txb = (TextBox)sender;
            if (Double.TryParse(txb.Text, out double score))
            {
                if (score < 0 || score > 10)
                {
                    MessageBox.Show("Điểm phải là một số thực không bé hơn 0 và không lớn hơn 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (txb.Text != string.Empty)
            {
                MessageBox.Show("Điểm phải là một số thực không bé hơn 0 và không lớn hơn 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        List<TextBox> list = new List<TextBox>();
        void LoadPanel_Score()
        {
            PanelIngredientScore.Controls.Clear();
            list.Clear();
            var Score = from scr in data.ThanhPhan_NamApDung(ComboBoxYear.SelectedValue.ToString())
                        select new { scr.MaThanhPhan, scr.TenThanhPhan };
            int x = 120;
            int y = 0;
            PanelIngredientScore.AutoSize = true;
            foreach (var i in Score)
            {
                TextBox textBox = new TextBox();
                Label lb = new Label();
                lb.AutoSize = true;
                lb.Text = i.TenThanhPhan.ToString();
                textBox.Name = i.MaThanhPhan.ToString();
                textBox.Location = new Point(x, y);
                lb.Location = new Point(x - 120, y + 5);
                textBox.TextChanged += textBoxScore_TextChanged;
                lb.Font = new Font("Segoe UI", 10);
                textBox.Font = new Font("Segoe UI", 10);
                PanelIngredientScore.Controls.Add(textBox);
                PanelIngredientScore.Controls.Add(lb);
                list.Add(textBox);
                y += 65;
            }
        }
        struct DIEMformat
        {
            private int stt;
            private string MaHocSinh;
            private string Hoten;
            private List<string> list_score;
            private string DiemTB;
            private string Xeploai;

            public List<string> List_score
            {
                get { return list_score; }
                set { list_score = value; }
            }
            public int STT { get { return stt; } set { stt = value; } }
            public string MHS { get { return MaHocSinh; } set { MaHocSinh = value; } }
            public string HOTEN { get { return Hoten; } set { Hoten = value; } }
            public string DIEMTB { get { return DiemTB; } set { DiemTB = value; } }
            public string XEPLOAI { get { return Xeploai; } set { Xeploai = value; } }
        }
        void ShowGrid(string i_o)
        {
            Dictionary<string, int> ScoreDict = new Dictionary<string, int>();
            int k = 0;
            int count = 0;
            foreach (var item in data.ThanhPhan_NamApDung(ComboBoxYear.SelectedValue.ToString()))
            {
                    ScoreDict.Add(item.MaThanhPhan.ToString(), k++);
                    count ++;    
            }
            var reSourceXL_2 = from scr1 in data.XepLoai_NamApDung(ComboBoxYear.SelectedValue.ToString()).AsEnumerable() 
                                select new {MaXepLoai = scr1.MaXepLoai,  TenXepLoai = scr1.TenXepLoai, NamApDung = scr1.NamApDung};
            
            var reSource1 = from scr1 in data.KETQUA_MONHOC_HOCSINH.AsEnumerable()
                           join scr in data.DIEMs.AsEnumerable() on scr1.MaKetQua equals scr.MaKetQua
                           join cls in data.CTLOPs.AsEnumerable() on scr1.MaHocSinh equals cls.MaHocSinh    
                           join cls1 in data.HOCSINHs.AsEnumerable() on cls.MaHocSinh equals cls1.MaHocSinh
                           where (ComboBoxSubject.SelectedValue.ToString() == scr1.MaMonHoc && ComboBoxYear.SelectedValue.ToString() == scr1.MaNamHoc && cls.MaLop == ComboBoxClass.SelectedValue.ToString() && scr1.MaHocKy == ComboBoxSemester.SelectedValue.ToString())      
                           group new {scr, scr1, cls}
                           by new { scr1.MaKetQua,Hoten = cls1.HoTen, scr1.MaHocSinh, scr.MaThanhPhan, scr.Diem1, scr1.DiemTB, scr1.MaXepLoai }
                           into g
                           select new { MaKQ = g.Key.MaKetQua, Hoten = g.Key.Hoten,MaHocSinh = g.Key.MaHocSinh, MaThanhPhan = g.Key.MaThanhPhan, Diem = g.Key.Diem1, DiemTB = g.Key.DiemTB, Xeploai = g.Key.MaXepLoai };
            var reSource = from scr in reSource1
                     join cls1 in reSourceXL_2 on scr.Xeploai equals cls1.MaXepLoai.ToString()
                     select new { MaKQ = scr.MaKQ, Hoten = scr.Hoten, MaHocSinh = scr.MaHocSinh, MaThanhPhan = scr.MaThanhPhan, Diem = scr.Diem, DiemTB = scr.DiemTB, Xeploai = (cls1.TenXepLoai == "Không") ? string.Empty : cls1.TenXepLoai };
            List<DIEMformat> reS = new List<DIEMformat> { };
            DIEMformat temp = new DIEMformat();
            int index = -1;
            foreach (var i in reSource)
            {
                if (index == -1 || (index != -1 && reS[index].MHS != i.MaHocSinh))
                {
                    List<string> list_temp = new List<string>();
                    for (int j = 0; j < count; j++)
                        list_temp.Add(null);
                    index += 1;
                    temp.STT = index + 1;
                    temp.MHS = i.MaHocSinh;
                    temp.HOTEN = i.Hoten;
                    temp.DIEMTB = i.DiemTB.ToString();
                    temp.XEPLOAI = i.Xeploai.ToString();
                    temp.List_score = list_temp;
                    reS.Add(temp);
                }
                temp.List_score[ScoreDict[i.MaThanhPhan]] = i.Diem.ToString();
                reS[index] = temp;
            }
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Mã học sinh", typeof(string));
            dt.Columns.Add("Họ tên", typeof(string));
            foreach (var ktem in data.ThanhPhan_NamApDung(ComboBoxYear.SelectedValue.ToString()))
            {
                dt.Columns.Add(ktem.TenThanhPhan, typeof(string));
            }    
            dt.Columns.Add("Điểm TB", typeof(string));
            dt.Columns.Add("Xếp loại", typeof(string));
                
            for (int i = 0; i< reS.Count(); i++)
            {
                    DataRow row1 = dt.NewRow();
                    row1["STT"] = reS[i].STT;
                    row1["Mã học sinh"] = reS[i].MHS;
                    row1["Họ tên"] = reS[i].HOTEN;
                    int i_temp = 0;
                    foreach (var ktem in data.ThanhPhan_NamApDung(ComboBoxYear.SelectedValue.ToString()))
                    {
                        row1[ktem.TenThanhPhan] = reS[i].List_score[i_temp];
                        i_temp++;  
                    }
                    row1["Điểm TB"] = reS[i].DIEMTB;
                    row1["Xếp loại"] = reS[i].XEPLOAI;
                    dt.Rows.Add(row1);
            }
            if (i_o == "1")
            {
                DataGridViewScore1.DataSource = null;
                DataGridViewScore1.Controls.Clear();
                DataGridViewScore1.Refresh();
                    DataGridViewScore1.DataSource = dt;
                    DataGridViewScore1.Show(); 
            }
            else
            {
                DataGridViewScore2.DataSource = null;
                DataGridViewScore2.Controls.Clear();
                DataGridViewScore2.Refresh();
                DataGridViewScore2.DataSource = dt;
                    DataGridViewScore2.Show();
            }
        }
        private void buttonInput_Click(object sender, EventArgs e)
        {
            if (ComboBoxSubject.Enabled == false)
            {
                MessageBox.Show("Vui lòng chọn lớp trước", "Error", MessageBoxButtons.OK);
                return;
            }    
            if (PanelShowScore.Visible) { PanelShowScore.Hide(); }
            LoadPanel_Score();
            if (ComboBoxClass.Text.ToString() == string.Empty || ComboBoxSubject.Text.ToString() == string.Empty || ComboBoxSemester.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ", "Error", MessageBoxButtons.OK);
            }
            else
            {
                var comboxID = from obj in data.CTLOPs
                               join obj1 in data.LOPs on obj.MaLop equals obj1.MaLop
                               where obj.MaLop == ComboBoxClass.SelectedValue.ToString() && obj1.MaNamHoc == ComboBoxYear.SelectedValue.ToString()
                               select obj.MaHocSinh;
                ComboBoxID.DataSource = comboxID.ToList();
                string nameofgrid;
                nameofgrid = "Bảng điểm môn " + ComboBoxSubject.Text.ToString() + " của lớp " + ComboBoxClass.Text.ToString() + " học kỳ " + ComboBoxSemester.Text.ToString() + " năm học " + ComboBoxYear.Text.ToString();
                LabelNameOfDGV1.Text = nameofgrid;
                int x = DataGridViewScore1.Location.X + (DataGridViewScore1.Width / 2);
                x -= LabelNameOfDGV1.Width / 2;
                int y = DataGridViewScore1.Location.Y + DataGridViewScore1.Height + 20;
                LabelNameOfDGV1.Location = new System.Drawing.Point(x, y);
                if(ComboBoxID.Text == string.Empty)
                {
                    TextBoxName.Text = string.Empty;
                    TextBoxAverageScore.Text = string.Empty;
                    TextBoxClassify.Text = string.Empty;
                }    
                ShowGrid("1");
                PanelInputScore.Show();
            }
            
        }
        private void comboBoxID_SelectedValueChanged(object sender, EventArgs e)
        {
            if (list.Count() == 0) return;
            var a = from obj in data.HOCSINHs where obj.MaHocSinh == ComboBoxID.Text select obj.HoTen;
            TextBoxName.Text = a.ToList().SingleOrDefault();
            var reSource1 = from scr in data.KETQUA_MONHOC_HOCSINH
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            join cls1 in data.XEPLOAIs on scr.MaXepLoai equals cls1.MaXepLoai
                            where  ComboBoxID.Text == scr.MaHocSinh && ComboBoxSubject.SelectedValue == scr.MaMonHoc && ComboBoxYear.SelectedValue == scr.MaNamHoc && ComboBoxSemester.SelectedValue == scr.MaHocKy && cls.MaLop == ComboBoxClass.SelectedValue
                            select new {MaKQ = scr.MaKetQua,  DiemTB = scr.DiemTB.ToString(), Xeploai = (cls1.TenXepLoai == "Không" ? string.Empty : cls1.TenXepLoai) };

            if (reSource1.Count() != 0)
            {
                string maKQ = reSource1.ToList().SingleOrDefault().MaKQ;
                var re = from scr in data.DIEMs
                         where scr.MaKetQua == maKQ
                         select new { scr.MaThanhPhan, scr.Diem1 };
                foreach (var j in list)
                {
                    int check = 1;
                    foreach (var i in re)
                    {
                        if (j.Name == i.MaThanhPhan)
                        {
                            j.Text = i.Diem1.ToString();
                            check = 0;
                        }
                    }
                    if(check == 1)
                    {
                        j.Text = null;
                    }    
                }
                TextBoxAverageScore.Text = reSource1.ToList().SingleOrDefault().DiemTB;
                TextBoxClassify.Text = reSource1.ToList().SingleOrDefault().Xeploai.ToString();
            }
            else
            {
                foreach (var j in list)
                {
                        j.Text = null;
                }
                TextBoxAverageScore.Text = null;
                TextBoxClassify.Text = null;
            }
        }
        private void buttonLook_Click(object sender, EventArgs e)
        {
            ShowGrid("1");
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name;
            if (e.RowIndex > -1 && DataGridViewScore1.Rows[e.RowIndex].Cells[1].Value != null)
            {
                name = DataGridViewScore1.Rows[e.RowIndex].Cells[1].Value.ToString();
                ComboBoxID.Text = name;
            }

        }
        string funcXepLoai(string t)
        {
            var reSource = from r in data.XepLoai_NamApDung(ComboBoxYear.SelectedValue.ToString())
                           select r;
            double a;
            var str_K = reSource.Where(p => p.TenXepLoai == "Không");
            string str_Khong = str_K.SingleOrDefault().MaXepLoai.ToString();
            if (t != string.Empty)
                a = Convert.ToDouble(t);
            else
                return str_Khong;
            foreach (var item in data.XepLoai_NamApDung(ComboBoxYear.SelectedValue.ToString()))
            {
                if (a >= Convert.ToDouble(item.DiemToiThieu) && a <= Convert.ToDouble(item.DiemToiDa))
                {
                    return item.MaXepLoai;
                }
            }
            return str_Khong;
        }
        double getTrongSo(string a)
        {
            foreach (var item in data.ThanhPhan_NamApDung(ComboBoxYear.SelectedValue.ToString()))
            {
                if (item.MaThanhPhan == a)
                {
                    return Convert.ToDouble(item.TrongSo);
                }
            }
            return 0;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            var reSource1 = from scr in data.KETQUA_MONHOC_HOCSINH
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            where ComboBoxID.Text == scr.MaHocSinh && ComboBoxSubject.SelectedValue == scr.MaMonHoc && ComboBoxYear.SelectedValue == scr.MaNamHoc && ComboBoxSemester.SelectedValue == scr.MaHocKy && cls.MaLop == ComboBoxClass.SelectedValue
                            select scr.MaKetQua;
            var temp = from scr in data.DIEMs
                       select scr.MaDiem;
            var temp_kq = data.KETQUA_MONHOC_HOCSINH.OrderByDescending(row => row.MaKetQua).Select(row=>row.MaKetQua).FirstOrDefault();
            var temp_index = data.DIEMs.OrderByDescending(row => row.MaDiem).Select(row => row.MaDiem).FirstOrDefault();
            string temp2_kq = temp_kq.ToString();
            string temp2_index = temp_index.ToString();
            int index_kq = Convert.ToInt32(temp2_kq.Substring(2));
            string stringWithoutLastTwo = temp2_kq.Substring(0, 2);
            int index = Convert.ToInt32(temp2_index.Substring(1));
            string stringWithoutLastTwo_index = temp2_index.Substring(0, 1);
            KETQUA_MONHOC_HOCSINH new_hs;
            double DIEMTB = 0;
            int check = 0;
            if (reSource1.Count() == 0)
            {
                new_hs = new KETQUA_MONHOC_HOCSINH() { MaKetQua = stringWithoutLastTwo + (index_kq + 1).ToString(), MaMonHoc = ComboBoxSubject.SelectedValue.ToString(), MaHocSinh = ComboBoxID.SelectedValue.ToString(), MaNamHoc = ComboBoxYear.SelectedValue.ToString(), MaHocKy = ComboBoxSemester.SelectedValue.ToString() };
                foreach (TextBox txb in list)
                {
                    DIEM diemTP = new DIEM();
                    diemTP.MaDiem = stringWithoutLastTwo_index + (++index).ToString() ;
                    diemTP.MaKetQua = new_hs.MaKetQua;
                    diemTP.MaThanhPhan = txb.Name;
                    if (txb.Text != string.Empty)
                    {
                        diemTP.Diem1 = Convert.ToDouble(txb.Text);
                        DIEMTB += Convert.ToDouble(txb.Text) * getTrongSo(txb.Name);
                    }
                    else
                    {
                        diemTP.Diem1 = null;
                        check = 1;
                    }
                    data.DIEMs.Add(diemTP);
                }
                data.KETQUA_MONHOC_HOCSINH.Add(new_hs);
            }
            else
            {
                string ID = reSource1.ToList().SingleOrDefault();
                new_hs = data.KETQUA_MONHOC_HOCSINH.Where(p => p.MaKetQua == ID).FirstOrDefault();
                var check_E = from scr in data.DIEMs
                              where scr.MaKetQua == ID
                              select new { MaThanhPhan = scr.MaThanhPhan };
                foreach (var tb in data.ThanhPhan_NamApDung(ComboBoxYear.SelectedValue.ToString()))
                {
                        int isE = 0;
                        foreach (var t in check_E)
                        {
                            if (tb.MaThanhPhan == t.MaThanhPhan)
                                isE = 1;
                        }
                        if (isE == 0)
                        {
                            DIEM diemTP = new DIEM();
                            diemTP.MaDiem = stringWithoutLastTwo_index + (++index).ToString();
                            diemTP.MaKetQua = new_hs.MaKetQua;
                            diemTP.MaThanhPhan = tb.MaThanhPhan;
                            TextBox txb_temp = list.FirstOrDefault(b => b.Name == tb.MaThanhPhan);
                            if (txb_temp.Text != string.Empty)
                            {
                                diemTP.Diem1 = Convert.ToDouble(txb_temp.Text);
                                DIEMTB += Convert.ToDouble(txb_temp.Text) * getTrongSo(tb.MaThanhPhan);
                            }
                            else
                            {
                                check = 1;
                                diemTP.Diem1 = null;
                            }
                            data.DIEMs.Add(diemTP);
                        }               
                }
                foreach (TextBox txb in list)
                {
                    foreach (var k in data.DIEMs)
                    {
                        if (k.MaKetQua == ID && k.MaThanhPhan == txb.Name)
                        {
                            if (txb.Text != string.Empty)
                            {
                                k.Diem1 = Convert.ToDouble(txb.Text);
                                DIEMTB += Convert.ToDouble(txb.Text) * getTrongSo(txb.Name);
                            }
                            else
                            {
                                k.Diem1 = null;
                                check = 1;
                            }
                        }           
                    }
                }
            }
            if (check == 1)
            {
                DIEMTB = Math.Round(DIEMTB, 1);
                new_hs.DiemTB = DIEMTB;
            }
            else
            {
                DIEMTB = Math.Round(DIEMTB, 1);
                new_hs.DiemTB = DIEMTB;
            }
            TextBoxAverageScore.Text = new_hs.DiemTB.ToString();
            new_hs.MaXepLoai = funcXepLoai(new_hs.DiemTB.ToString());
            
            try
            {
                data.SaveChanges();
            }
            catch (DbEntityValidationException e1)
            {
                Console.WriteLine(e1);
            }
            string tenxl = data.XEPLOAIs.Where(p => p.MaXepLoai == new_hs.MaXepLoai).Select(p => p.TenXepLoai).SingleOrDefault().ToString();
            if (tenxl != "Không")
                TextBoxClassify.Text = tenxl;
            else
                TextBoxClassify.Text = string.Empty;
            ShowGrid("1");
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var reSource1 = from scr in data.KETQUA_MONHOC_HOCSINH
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            where ComboBoxID.Text == scr.MaHocSinh && ComboBoxSubject.SelectedValue == scr.MaMonHoc && ComboBoxYear.SelectedValue == scr.MaNamHoc && ComboBoxSemester.SelectedValue == scr.MaHocKy && cls.MaLop == ComboBoxClass.SelectedValue
                            select scr.MaKetQua;
            if (reSource1.Count() == 0)
            {
                MessageBox.Show("Không thể xóa vì chưa tồn tại điểm của học sinh này trong bảng điểm", "Error", MessageBoxButtons.OK);
            }
            else
            {
                string ID = reSource1.ToList().SingleOrDefault();
                var reSource_diem = data.DIEMs.Where(p => p.MaKetQua == ID);
                foreach (var i in reSource_diem)
                {
                    DIEM temp = i as DIEM;
                    data.DIEMs.Remove(temp);
                }
                KETQUA_MONHOC_HOCSINH hs = data.KETQUA_MONHOC_HOCSINH.Where(p => p.MaKetQua == ID).FirstOrDefault();
                data.KETQUA_MONHOC_HOCSINH.Remove(hs);
                data.SaveChanges();
                ComboBoxID.Text = string.Empty;
                foreach (TextBox i in list)
                {
                    i.Text = null;
                }
                TextBoxAverageScore.Text = string.Empty;
                TextBoxClassify.Text = string.Empty;
                ShowGrid("1");
            }
        }
        DataTable ratio_Source;
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (ComboBoxClass.Text.ToString() == string.Empty || ComboBoxSubject.Text.ToString() == string.Empty || ComboBoxSemester.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ", "Error", MessageBoxButtons.OK);
                return;
            }
            if (ComboBoxSubject.Enabled == false)
            {
                MessageBox.Show("Vui lòng chọn lớp trước", "Error", MessageBoxButtons.OK);
                return;
            }
            PanelSummary.Controls.Clear();
            if (PanelInputScore.Visible) { PanelInputScore.Hide(); }
            var reSource = from scr in data.KETQUA_MONHOC_HOCSINH
                            join cls in data.CTLOPs on scr.MaHocSinh equals cls.MaHocSinh
                            where ComboBoxSubject.SelectedValue == scr.MaMonHoc && ComboBoxYear.SelectedValue == scr.MaNamHoc && ComboBoxSemester.SelectedValue == scr.MaHocKy && cls.MaLop == ComboBoxClass.SelectedValue
                            select new  { MaKQ = scr.MaKetQua, MaHS = scr.MaHocSinh, DiemTB = scr.DiemTB, Xeploai = scr.MaXepLoai};
            List<int> list_xeploai = new List<int>();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            List<TextBox> list_txb_xeploai = new List<TextBox>();
            List<TextBox> list_txb_ratio = new List<TextBox>();
            int index = 0;
            int x = 100;
            int y = 0;
            PanelSummary.AutoSize = true;
            foreach (var i in data.XepLoai_NamApDung(ComboBoxYear.SelectedValue.ToString()).OrderByDescending(r => r.DiemToiThieu))
            {
                    if(i.TenXepLoai != "Không")
                    {
                        Label lb = new Label();
                        Label lb_ratio = new Label();
                        lb.Text = "Số học sinh xếp loại " + i.TenXepLoai;
                        lb.Location = new System.Drawing.Point(x, y);
                        lb.AutoSize = true;
                        lb_ratio.Text = "Tỉ lệ học sinh xếp loại " + i.TenXepLoai;
                        lb_ratio.Location = new System.Drawing.Point(x + 500, y);
                        lb_ratio.AutoSize = true;
                        lb.Font = new Font("Segoe UI", 10);
                        lb_ratio.Font = new Font("Segoe UI", 10);
                        TextBox txb = new TextBox();
                        txb.ReadOnly = true;
                        txb.Name = i.TenXepLoai;
                        txb.Location = new System.Drawing.Point(x + 250, y);
                        txb.AutoSize = true;
                        txb.Font = new Font("Segoe UI", 10);
                        list_txb_xeploai.Add(txb);
                        TextBox txb_ratio = new TextBox();
                        txb_ratio.ReadOnly = true;
                        txb_ratio.Name = i.TenXepLoai;
                        txb_ratio.Location = new System.Drawing.Point(x + 750, y);
                        txb_ratio.AutoSize = true;
                        txb_ratio.Font = new Font("Segoe UI", 10);
                        list_txb_ratio.Add(txb_ratio);
                        txb.BackColor = Color.White;
                        txb_ratio.BackColor = Color.White;
                        PanelSummary.Controls.Add(txb);
                        PanelSummary.Controls.Add(txb_ratio);
                        PanelSummary.Controls.Add(lb);
                        PanelSummary.Controls.Add(lb_ratio);
                        y += 40;
                    }
                    keyValuePairs.Add(i.TenXepLoai, index);
                    index++;
                    list_xeploai.Add(0);
            }
            var numberofclass_ = from scr in reSource
                                 join scr1 in data.XEPLOAIs on scr.Xeploai equals scr1.MaXepLoai
                                 where scr1.TenXepLoai != "Không"
                                 select scr;
            int numberofClass = numberofclass_.Count();
            ratio_Source = new DataTable();
            if (numberofClass > 0)
            {
                ButtonExportExcelFile2.Enabled = true;
                foreach (var i in reSource)
                {
                    foreach (var j in data.XepLoai_NamApDung(ComboBoxYear.SelectedValue.ToString()))
                    {
                        if (i.Xeploai == j.MaXepLoai)
                        {
                            list_xeploai[keyValuePairs[j.TenXepLoai]]++;
                        }
                    }
                }
                foreach (var i in list_txb_xeploai)
                {
                    i.Text = list_xeploai[keyValuePairs[i.Name]].ToString();
                }
                foreach (var i in list_txb_ratio)
                {
                    i.Text = (list_xeploai[keyValuePairs[i.Name]] * 100 / numberofClass).ToString() + "%";
                }
                ratio_Source.Columns.Add("Xếp loại", typeof(string));
                ratio_Source.Columns.Add("Số lượng", typeof(int));
                ratio_Source.Columns.Add("Tỉ lệ (%)", typeof(float));
                foreach (var item in list_txb_xeploai)
                {
                    if (list_xeploai[keyValuePairs[item.Name]] > 0)
                    {
                        DataRow row_ratio = ratio_Source.NewRow();
                        row_ratio["Xếp loại"] = item.Name;
                        row_ratio["Số lượng"] = list_xeploai[keyValuePairs[item.Name]].ToString();
                        row_ratio["Tỉ lệ (%)"] = (list_xeploai[keyValuePairs[item.Name]] * 100 / numberofClass);
                        ratio_Source.Rows.Add(row_ratio);
                    }
                }
                ChartRatio.DataSource = ratio_Source;
                ChartRatio.Series[0].XValueMember = "Xếp loại";
                ChartRatio.Series[0].YValueMembers = "Tỉ lệ (%)";
                ChartRatio.Series[0].IsValueShownAsLabel = true;
                ChartRatio.Show();
            }
            else ButtonExportExcelFile2.Enabled = false;
            string nameofgrid;
            nameofgrid = "Bảng điểm môn " + ComboBoxSubject.Text.ToString() + " của lớp " + ComboBoxClass.Text.ToString() + " học kỳ " + ComboBoxSemester.Text.ToString() + " năm học " + ComboBoxYear.Text.ToString();
            LabelNameOfDGV2.Text = nameofgrid;
            int x_ = DataGridViewScore2.Location.X + (DataGridViewScore2.Width / 2);
            x_ -= LabelNameOfDGV2.Width / 2;
            int y_ = DataGridViewScore2.Location.Y + DataGridViewScore2.Height + 20;
            LabelNameOfDGV2.Location = new System.Drawing.Point(x_, y_);
            PanelShowScore.Show();
            ShowGrid("2");
        }

        private void ButtonExportExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
            worksheet.Name = "Bảng điểm";
            for (int i = 1; i <= DataGridViewScore1.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = DataGridViewScore1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < DataGridViewScore1.Rows.Count; i++)
            {
                for (int j = 0; j < DataGridViewScore1.Columns.Count; j++)
                {
                    if (DataGridViewScore1.Rows[i].Cells[j].Value != null)
                        worksheet.Cells[i + 2, j + 1] = DataGridViewScore1.Rows[i].Cells[j].Value.ToString();
                }
            }
            workbook.Close();
            excel.Quit();
        }

        private void ButtonExportExcel2_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
            worksheet.Name = "Bảng điểm";
            for (int i = 1; i <= DataGridViewScore2.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = DataGridViewScore2.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < DataGridViewScore2.Rows.Count; i++)
            {
                for (int j = 0; j < DataGridViewScore2.Columns.Count; j++)
                {
                    if (DataGridViewScore2.Rows[i].Cells[j].Value != null)
                        worksheet.Cells[i + 2, j + 1] = DataGridViewScore2.Rows[i].Cells[j].Value.ToString();
                }
            }
            workbook.Sheets.Add(After: workbook.Sheets[workbook.Sheets.Count]);
            if (ratio_Source.Rows.Count > 0)
            {
                Excel.Worksheet worksheet2 = (Excel.Worksheet)workbook.Sheets[2];
                worksheet2.Name = "Tổng kết";
                worksheet2.Cells[1, 1] = "Xếp loại";
                worksheet2.Cells[1, 2] = "Số lượng";
                worksheet2.Cells[1, 3] = "Tỉ lệ (%)";
                for (int i = 0; i < ratio_Source.Rows.Count; i++)
                {
                    worksheet2.Cells[1][i + 2] = ratio_Source.Rows[i]["Xếp loại"];
                    worksheet2.Cells[2][i + 2] = ratio_Source.Rows[i]["Số lượng"];
                    worksheet2.Cells[3][i + 2] = ratio_Source.Rows[i]["Tỉ lệ (%)"];
                }
            }    
            workbook.Close();
            excel.Quit();
        }

        private void BtnHomeScreen_Click(object sender, EventArgs e)
        {
            (this.formTraCuu as TrangChu).Show();
            this.Close();
        }

        private void guna2ImageButtonHome_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ImageButtonMinimize1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButtonClose1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
                TrangCaNhan newform = new TrangCaNhan();
                this.Hide();
                newform.ShowDialog();
                this.Show();
        }


    }
}
