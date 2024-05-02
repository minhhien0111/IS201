--RANG BUOC TOAN VEN
--INSERT INTO HOCSINH
--DROP PROCEDURE ThemHocSinh
CREATE PROCEDURE ThemHocSinh
	@MaHocSinh nvarchar(10),
	@HoTen nvarchar(30),
	@GioiTinh nvarchar(5),
	@NgaySinh smalldatetime,
	@DiaChi nvarchar(50),
	@QueQuan nvarchar(50),
	@DanToc nvarchar(20),
	@TonGiao nvarchar(20),
	@SDT nvarchar(10),
	@Email nvarchar(40),
	@HoTenCha nvarchar (30),
	@NamSinh_Cha smallint,
	@CCCD_Cha nvarchar (12),
	@SDT_Cha nvarchar (10),
	@NgheNghiep_Cha nvarchar (50),
	@HoTenMe nvarchar (30),
	@NamSinh_Me smallint,
	@CCCD_Me nvarchar (12),
	@SDT_Me nvarchar (10),
	@NgheNghiep_Me nvarchar (50)
AS
BEGIN
	INSERT INTO HOCSINH (
		MaHocSinh,
		HoTen,
		GioiTinh,
		NgaySinh,
		DiaChi,
		QueQuan,
		DanToc,
		TonGiao,
		SDT,
		Email,
		HoTenCha,
		NamSinh_Cha,
		CCCD_Cha,
		SDT_Cha,
		NgheNghiep_Cha,
		HoTenMe,
		NamSinh_Me,
		CCCD_Me,
		SDT_Me,
		NgheNghiep_Me
	)
	VALUES
	(
		@MaHocSinh,
		@HoTen,
		@GioiTinh,
		@NgaySinh,
		@DiaChi,
		@QueQuan,
		@DanToc,
		@TonGiao,
		@SDT,
		@Email,
		@HoTenCha,
		@NamSinh_Cha,
		@CCCD_Cha,
		@SDT_Cha,
		@NgheNghiep_Cha,
		@HoTenMe,
		@NamSinh_Me,
		@CCCD_Me,
		@SDT_Me,
		@NgheNghiep_Me
	)
END