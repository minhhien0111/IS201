--CREATE DATABASE QUANLYHOCSINH
--DROP DATABASE QUANLYHOCSINH 

--USE QUANLYHOCSINH

--TAO BANG
CREATE TABLE HOCSINH
(	MaHocSinh nvarchar(10) not null,
	HoTen nvarchar(30),
	GioiTinh nvarchar(5),
	NgaySinh smalldatetime,
	DiaChi nvarchar(50),
	QueQuan nvarchar(50),
	DanToc nvarchar(20),
	TonGiao nvarchar(20),
	SDT nvarchar(10),
	Email nvarchar(40),
	HoTenCha nvarchar (30),
	NamSinh_Cha smallint,
	CCCD_Cha nvarchar (12),
	SDT_Cha nvarchar (10),
	NgheNghiep_Cha nvarchar (50),
	HoTenMe nvarchar (30),
	NamSinh_Me smallint,
	CCCD_Me nvarchar (12),
	SDT_Me nvarchar (10),
	NgheNghiep_Me nvarchar (50),
	constraint pk_mhs primary key(MaHocSinh)
)

CREATE TABLE KHOI	
(	MaKhoi	nvarchar(20)	not null,
	TenKhoi	nvarchar(30),
	constraint pk_mk primary key(MaKhoi)
)

CREATE TABLE NAMHOC (
	MaNamHoc nvarchar(20) not null,
	NamHoc varchar(9),
	constraint pk_mnh primary key(MaNamHoc)
)

CREATE TABLE LOP
(	MaLop nvarchar(20) not null,
	TenLop nvarchar(30),
	MaKhoi nvarchar(20) not null,
	SiSo tinyint,
	MaNamHoc nvarchar(20) not null,
	constraint pk_ml primary key(MaLop),
)

CREATE TABLE HOCKY (
	MaHocKy nvarchar(20),
	HocKy nvarchar(20),
	TrongSo float,
	constraint pk_mhk primary key(MaHocKy)
)

CREATE TABLE MONHOC
(	MaMonHoc	nvarchar(20) not null,
	TenMonHoc	nvarchar(50),
	constraint pk_mmh primary key(MaMonHoc)
)

ALTER TABLE MONHOC ADD NamApDung nvarchar(20)
UPDATE MONHOC
SET NamApDung = 'NH2223'

CREATE TABLE CTLOP
(	MaCTL nvarchar(20) not null,
	MaHocSinh nvarchar(10) not null,
	MaLop nvarchar(20) not null,
	constraint pk_ctl primary key(MaCTL)
)

CREATE TABLE DIEM
(	MaDiem nvarchar(20) not null,
	MaKetQua nvarchar(20) not null,
	MaThanhPhan nvarchar(20),
	Diem float,
	constraint pk_md primary key(MaDiem)
)

CREATE TABLE THANHPHAN (
	MaThanhPhan nvarchar(20) not null,
	TenThanhPhan nvarchar(30),
	TrongSo float,
	constraint pk_mtp primary key(MaThanhPhan)
)
ALTER TABLE THANHPHAN ADD NamApDung nvarchar(20)
UPDATE THANHPHAN
SET NamApDung = 'NH2223'

CREATE TABLE KETQUA_MONHOC_HOCSINH (
	MaKetQua nvarchar(20) not null,
	MaHocSinh nvarchar(10) not null,
	MaNamHoc nvarchar(20) not null,
	MaHocKy nvarchar(20) not null,
	MaMonHoc nvarchar(20) not null,
	DiemTB float,
	MaXepLoai nvarchar(20)
	constraint pk_mkq primary key(MaKetQua)
)

CREATE TABLE XEPLOAI
(
	MaXepLoai nvarchar (20) not null,
	TenXepLoai nvarchar (30),
	DiemToiThieu float,
	DiemToiDa float,
	DiemKhongChe float, -- Ap dung khi xet Diem
	Constraint pk_xl primary key (MaXepLoai)
)
ALTER TABLE XEPLOAI ADD NamApDung nvarchar(20)
UPDATE XEPLOAI 
SET NamApDung = 'NH2223'

UPDATE XEPLOAI
ORDER BY DiemToiThieu DESC


CREATE TABLE THAMSO
(	
	MaThamSo nvarchar (20) not null default 'TS',
	TuoiToiThieu tinyint default 15,
	TuoiToiDa tinyint default 20,
	SiSoToiDa smallint default 40,
	DiemToiDa float default 10.0,
	DiemToiThieu float default 0.0,
	Constraint pk_ts primary key (MaThamSo)
)


CREATE TABLE PHANQUYEN (
	MaPhanQuyen nvarchar(20) not null,
	VaiTro nvarchar(50),
	constraint pk_pq primary key(MaPhanQuyen)
)

CREATE TABLE TAIKHOAN (
	MaTaiKhoan nvarchar(20) not null,
	TenDangNhap nvarchar(60),
	MatKhau nvarchar(60),
	MaPhanQuyen nvarchar(20) not null
	constraint pk_tk primary key(MaTaiKhoan)
)

ALTER TABLE TAIKHOAN ADD HoTen nvarchar(30)
ALTER TABLE TAIKHOAN ALTER COLUMN NgaySinh date
set dateformat dmy 
UPDATE TAIKHOAN
SET NgaySinh = '22/01/1997'
select NgaySinh from TAIKHOAN

ALTER TABLE TAIKHOAN ADD CONSTRAINT fk_tk_pq
	FOREIGN KEY(MaPhanQuyen) REFERENCES PHANQUYEN(MaPhanQuyen) 

--TAO KHOA NGOAI
--Bang LOP
ALTER TABLE LOP ADD CONSTRAINT fk_lop_mk
	FOREIGN KEY(MaKhoi) REFERENCES KHOI(MaKhoi)
ALTER TABLE LOP ADD CONSTRAINT fk_lop_mnh
	FOREIGN KEY(MaNamHoc) REFERENCES NAMHOC(MaNamHoc)

--Bang CTLOP
ALTER TABLE CTLOP ADD CONSTRAINT fk_ctl_hs
	FOREIGN KEY(MaHocSinh) REFERENCES HOCSINH(MaHocSinh)
ALTER TABLE CTLOP ADD CONSTRAINT fk_ctl_ml
	FOREIGN KEY(MaLop) REFERENCES LOP(MaLop)

--Bang KETQUA_MONHOC_HOCSINH
ALTER TABLE KETQUA_MONHOC_HOCSINH ADD CONSTRAINT fk_kq_hs
	FOREIGN KEY(MaHocSinh) REFERENCES HOCSINH(MaHocSinh)
ALTER TABLE KETQUA_MONHOC_HOCSINH ADD CONSTRAINT fk_kq_xl
	FOREIGN KEY(MaXepLoai) REFERENCES XEPLOAI(MaXepLoai)
ALTER TABLE KETQUA_MONHOC_HOCSINH ADD CONSTRAINT fk_kq_nh
	FOREIGN KEY(MaNamHoc) REFERENCES NAMHOC(MaNamHoc)
ALTER TABLE KETQUA_MONHOC_HOCSINH ADD CONSTRAINT fk_kq_hk
	FOREIGN KEY(MaHocKy) REFERENCES HOCKY(MaHocKy)
ALTER TABLE KETQUA_MONHOC_HOCSINH ADD CONSTRAINT fk_kq_mh
	FOREIGN KEY(MaMonHoc) REFERENCES MONHOC(MaMonHoc)

--Bang DIEM
ALTER TABLE DIEM ADD CONSTRAINT fk_diem_kq
	FOREIGN KEY(MaKetQua) REFERENCES KETQUA_MONHOC_HOCSINH(MaKetQua)
ALTER TABLE DIEM ADD CONSTRAINT fk_diem_tp
	FOREIGN KEY(MaThanhPhan) REFERENCES THANHPHAN(MaThanhPhan)

--Tong Ket Mon Hoc Ky
CREATE PROCEDURE TongKetMonHocKy 
	@MaMonHoc nvarchar(20),
	@MaHocKy nvarchar(20) ,
	@MaNamHoc nvarchar(20)
AS
BEGIN
	select TenLop, MaXepLoai, Count(KQ.MaHocSinh) as SoLuong
	from KETQUA_MONHOC_HOCSINH KQ, CTLOP CT, LOP L
	where KQ.MaHocSinh = CT.MaHocSinh and CT.MaLop = L.MaLop 
			and KQ.MaMonHoc = @MaMonHoc and KQ.MaNamHoc = @MaNamHoc and KQ.MaHocKy = @MaHocKy and L.MaNamHoc = @MaNamHoc
	group by CT.MaLop, L.TenLop, KQ.MaXepLoai
	order by TenLop
END

select TenLop, MaXepLoai, Count(KQ.MaHocSinh) as SoLuong
	from KETQUA_MONHOC_HOCSINH KQ, CTLOP CT, LOP L
	where KQ.MaHocSinh = CT.MaHocSinh and CT.MaLop = L.MaLop 
			and KQ.MaMonHoc = 'NV10' and KQ.MaNamHoc = 'NH2223' and KQ.MaHocKy = '1' and L.MaNamHoc = 'NH2223'
	group by CT.MaLop, L.TenLop, KQ.MaXepLoai
	order by TenLop

--Tong Ket Mon Nam Hoc
CREATE PROCEDURE TongKetMonNamHoc
	@MaMonHoc nvarchar(20),
	@MaNamHoc nvarchar(20)
AS
BEGIN
	select TenLop, KQ.MaHocSinh, MaHocKy as HocKy, sum(DiemTB) as  DiemTB
	from KETQUA_MONHOC_HOCSINH KQ, CTLOP CT, LOP L
	where kq.MaHocSinh = CT.MaHocSinh and CT.MaLop = L.MaLop  
			and KQ.MaMonHoc = @MaMonHoc and KQ.MaNamHoc = @MaNamHoc and L.MaNamHoc = @MaNamHoc
	group by CT.MaLop, L.TenLop, KQ.MaHocSinh, KQ.MaHocKy
	order by TenLop
END

select TenLop, KQ.MaHocSinh, MaHocKy as HocKy, sum(DiemTB) as  DiemTB
	from KETQUA_MONHOC_HOCSINH KQ, CTLOP CT, LOP L
	where kq.MaHocSinh = CT.MaHocSinh and CT.MaLop = L.MaLop  
			and KQ.MaMonHoc = 'TO10' and KQ.MaNamHoc = 'NH2223' and L.MaNamHoc = 'NH2223'
	group by CT.MaLop, L.TenLop, KQ.MaHocSinh, KQ.MaHocKy
	order by TenLop


--Tong Ket Hoc Ky
CREATE PROCEDURE TongKetHocKy
	@MaHocKy nvarchar(20),
	@MaNamHoc nvarchar(20)
AS
BEGIN
	select TenLop, KQ.MaHocSinh, sum(KQ.DiemTB) as DiemTB, min(KQ.DiemTB) as DiemKC, count(KQ.MaMonHoc) as SoLuong
	from KETQUA_MONHOC_HOCSINH KQ, CTLOP CT, LOP L
	where KQ.MaHocSinh = CT.MaHocSinh and CT.MaLop = L.MaLop 
			and KQ.MaNamHoc = @MaNamHoc and KQ.MaHocKy = @MaHocKy and L.MaNamHoc = @MaNamHoc
	group by CT.MaLop, L.TenLop, KQ.MaHocSinh
	order by TenLop
END

select TenLop, KQ.MaHocSinh, sum(KQ.DiemTB) as DiemTB, min(KQ.DiemTB) as DiemKC, count(KQ.MaMonHoc) as SoLuong
	from KETQUA_MONHOC_HOCSINH KQ, CTLOP CT, LOP L
	where KQ.MaHocSinh = CT.MaHocSinh and CT.MaLop = L.MaLop 
			and KQ.MaNamHoc = 'NH2223' and KQ.MaHocKy = '1' and L.MaNamHoc = 'NH2223'
	group by CT.MaLop, L.TenLop, KQ.MaHocSinh
	order by TenLop


--Tong Ket Nam Hoc
CREATE PROCEDURE TongKetNamHoc
	@MaNamHoc nvarchar(20)
AS
BEGIN
	select TenLop, KQ.MaHocSinh, KQ.MaMonHoc, avg(KQ.DiemTB) as DiemTB,count(MaHocKy) as SoLuongKy
	from KETQUA_MONHOC_HOCSINH KQ, CTLOP CT, LOP L
	where KQ.MaHocSinh = CT.MaHocSinh and CT.MaLop = L.MaLop 
			and KQ.MaNamHoc = @MaNamHoc  and L.MaNamHoc = @MaNamHoc
	group by CT.MaLop, L.TenLop, KQ.MaHocSinh, KQ.MaMonHoc
	order by TenLop
END


select TenLop, KQ.MaHocSinh, KQ.MaMonHoc, avg(KQ.DiemTB) as DiemTB,count(MaHocKy) as SoLuongKy
	from KETQUA_MONHOC_HOCSINH KQ, CTLOP CT, LOP L
	where KQ.MaHocSinh = CT.MaHocSinh and CT.MaLop = L.MaLop 
			and KQ.MaNamHoc ='NH2223'  and L.MaNamHoc = 'NH2223'
	group by CT.MaLop, L.TenLop, KQ.MaHocSinh, KQ.MaMonHoc
	order by TenLop



--Tong Ket Mon - Hoc Sinh
CREATE PROCEDURE TongKetMon_HocSinh
	@MaNamHoc nvarchar(20),
	@MaHocSinh nvarchar(10)
AS
BEGIN
	select MaMonHoc, MaHocKy, DiemTB
	from KETQUA_MONHOC_HOCSINH
	where MaNamHoc = @MaNamHoc and MaHocSinh = @MaHocSinh
	order by MaMonHoc
END
select MaMonHoc, MaHocKy, DiemTB
	from KETQUA_MONHOC_HOCSINH
	where MaNamHoc = 'NH2223' and MaHocSinh = '22100113'
	order by MaMonHoc

select MaMonHoc, MaHocKy, DiemTB
	from KETQUA_MONHOC_HOCSINH
	where MaNamHoc = 'NH2223' and MaHocSinh = '22101000'
	order by MaMonHoc

CREATE PROCEDURE XepLoai_NamApDung
	@NamApDung nvarchar(20)
AS
BEGIN
	select *
	from XEPLOAI
	where NamApDung in (select top 1 NamApDung from XEPLOAI where NamApDung<=@NamApDung order by NamApDung DESC)
END

CREATE PROCEDURE HocKy_NamApDung
	@NamApDung nvarchar(20)
AS
BEGIN
	select *
	from HOCKY
	where NamApDung in (select top 1 NamApDung from HOCKY where NamApDung<=@NamApDung order by NamApDung DESC)
END

CREATE PROCEDURE MonHoc_NamApDung
	@NamApDung nvarchar(20)
AS
BEGIN
	select *
	from MONHOC
	where NamApDung in (select top 1 NamApDung from MONHOC where NamApDung<=@NamApDung order by NamApDung DESC)
END

select *
	from MONHOC
	where NamApDung in (select top 1 NamApDung from MONHOC where NamApDung<='NH2122' order by NamApDung DESC)
CREATE PROCEDURE KhoiLop_NamApDung
	@NamApDung nvarchar(20)
AS
BEGIN
	select * from KHOI
	where MaNamHoc in (select top 1 MaNamHoc from KHOI where MaNamHoc<=@NamApDung order by MaNamHoc DESC)
END
select *
	from KHOI
	where MaNamHoc in (select top 1 MaNamHoc from KHOI where MaNamHoc<='NH2324' order by MaNamHoc DESC)