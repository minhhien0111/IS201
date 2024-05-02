--RANG BUOC TOAN VEN
--UPDATE HOCSINH
--DROP PROCEDURE SuaHocSinh
CREATE PROCEDURE SuaHocSinh
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
	UPDATE HOCSINH
	SET HoTen				= @HoTen,
		GioiTinh			= @GioiTinh,
		NgaySinh			= @NgaySinh,
		DiaChi				= @DiaChi,
		QueQuan				= @QueQuan,
		DanToc				= @DanToc,
		TonGiao				= @TonGiao,
		SDT					= @SDT,
		Email				= @Email,
		HoTenCha			= @HoTenCha,
		NamSinh_Cha			= @NamSinh_Cha,
		CCCD_Cha			= @CCCD_Cha,
		SDT_Cha				= @SDT_Cha,
		NgheNghiep_Cha		= @NgheNghiep_Cha,
		HoTenMe				= @HoTenMe,
		NamSinh_Me			= @NamSinh_Me,
		CCCD_Me				= @CCCD_Me,
		SDT_Me				= @SDT_Me,
		NgheNghiep_Me		= @NgheNghiep_Me
	WHERE MaHocSinh = @MaHocSinh
END