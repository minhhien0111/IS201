--INSERT INTO LOP
CREATE PROCEDURE ThemLop
	@MaLop		nvarchar(20), 
	@TenLop		nvarchar(30),
	@MaKhoi		nvarchar(20),
	@MaNamHoc	nvarchar(20)
AS
BEGIN
	IF(@TenLop IN (SELECT TenLop FROM LOP WHERE MaNamHoc = @MaNamHoc))
		PRINT(N'Lớp đã tồn tại')
	ELSE
	BEGIN
		INSERT INTO LOP (
			MaLop,
			TenLop,
			MaKhoi,
			MaNamHoc
		)
		VALUES (
			@MaLop,
			@TenLop,
			@MaKhoi,
			0,
			@MaNamHoc
		)
		PRINT(N'Thêm lớp mới thành công')
	END;
END