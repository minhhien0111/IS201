--INSERT INTO KHOI
CREATE PROCEDURE ThemKhoi
	@MaKhoi		nvarchar(20),
	@TenKhoi	nvarchar(30)
AS
BEGIN
	IF(@TenKhoi IN (SELECT TenKhoi FROM KHOI))
		PRINT(N'Khối đã tồn tại')
	ELSE
	BEGIN
		INSERT INTO KHOI (MaKhoi, TenKhoi)
			VALUES (@MaKhoi, @TenKhoi)
		PRINT(N'Thêm lớp thành công')
	END;
END