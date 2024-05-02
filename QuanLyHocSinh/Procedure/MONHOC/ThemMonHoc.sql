--INSERT INTO MONHOC
CREATE PROCEDURE ThemMonHoc
	@MaMonHoc	nvarchar(20),
	@TenMonHoc	nvarchar(50)
AS
BEGIN
	INSERT INTO MONHOC (MaMonHoc, TenMonHoc)
	VALUES (@MaMonHoc, @TenMonHoc)
	PRINT(N'Thêm môn học thành công')
END