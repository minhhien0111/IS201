--INSERT INTO HOCKY
CREATE PROCEDURE ThemHocKy
	@MaHocKy nvarchar(20),
	@HocKy nvarchar(50),
	@TrongSo float
AS
BEGIN
	IF(@HocKy IN (SELECT HocKy FROM HOCKY))
		PRINT(N'Học kì đã tồn tại')
	ELSE
	BEGIN
		INSERT INTO HOCKY (MaHocKy, HocKy, TrongSo)
			VALUES (@MaHocKy, @HocKy, @TrongSo)
		PRINT(N'Thêm học kì thành công')
	END;
END