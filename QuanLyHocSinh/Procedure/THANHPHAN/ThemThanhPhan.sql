CREATE PROCEDURE ThemThanhPhan
	@MaThanhPhan	nvarchar(20),
	@TenThanhPhan	nvarchar(30),
	@TrongSo		float
AS
BEGIN
	IF(@TenThanhPhan IN (SELECT TenThanhPhan FROM THANHPHAN))
	BEGIN
		PRINT(N'Loại điểm thành phần này đã tồn tại')
	END;
	ELSE
	BEGIN
		INSERT INTO THANHPHAN (
			MaThanhPhan,
			TenThanhPhan,
			TrongSo
		)
		VALUES (
			@MaThanhPhan,
			@TenThanhPhan,
			@TrongSo
		)
		PRINT(N'Thêm loại điểm thành phần thành công')
	END;
END