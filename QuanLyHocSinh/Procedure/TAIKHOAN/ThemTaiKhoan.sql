CREATE PROCEDURE ThemTaiKhoan
	@MaTaiKhoan		nvarchar(20),
	@TenDangNhap	nvarchar(60),
	@MatKhau		nvarchar(60)
AS
BEGIN
	IF(@TenDangNhap IN (SELECT TenDangNhap FROM TAIKHOAN))
		PRINT(N'Tên tài khoản đã tồn tại')
	ELSE
	BEGIN
		INSERT INTO TAIKHOAN (
			MaTaiKhoan,
			TenDangNhap,
			MatKhau	
		)
		VALUES (
			@MaTaiKhoan,
			@TenDangNhap,
			@MatKhau	
		)
		PRINT(N'Tài khoản đã được thêm thành công')
	END;
END