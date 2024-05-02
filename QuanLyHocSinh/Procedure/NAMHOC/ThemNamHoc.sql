--INSERT INTO NAMHOC
CREATE PROCEDURE ThemNamHoc
	@MaNamHoc nvarchar(20),
	@NamHoc varchar(9)
AS
BEGIN
	PRINT('1');
	IF(@NamHoc != '*-*')
	BEGIN
		PRINT(N'Định dạng năm học không đúng')
	END;
	ELSE IF(@NamHoc IN (SELECT NamHoc FROM NAMHOC))
	BEGIN
		PRINT(N'Năm học đã tồn tại')
	END;
	ELSE
	BEGIN
		INSERT INTO NAMHOC (
			MaNamHoc,
			NamHoc
		)
		VALUES (
			@MaNamHoc,
			@NamHoc
		)
		PRINT(N'Thêm năm học thành công')
	END;
END