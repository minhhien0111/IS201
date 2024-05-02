CREATE PROCEDURE ThemXepLoai
	@MaXepLoai		nvarchar (20),
	@TenXepLoai		nvarchar (30),
	@DiemToiThieu	float,
	@DiemToiDa		float,
	@DiemKhongChe	float
AS
BEGIN
	IF(@TenXepLoai IN (SELECT TenXepLoai FROM XEPLOAI))
		PRINT(N'Loại xếp loại này đã tồn tại')
	ELSE
	BEGIN
		DECLARE @TSDiemToiThieu FLOAT = (SELECT DiemToiThieu FROM THAMSO)
		DECLARE @TSDiemToiDa FLOAT = (SELECT DiemToiDa FROM THAMSO)
		IF((@DiemToiThieu < @TSDiemToiThieu) OR (@DiemToiThieu > @TSDiemToiDa))
			PRINT(N'Điểm tối thiểu phải nằm trong đoạn từ ' + @TSDiemToiThieu + N' đến ' + @TSDiemToiDa)
		ELSE IF((@DiemToiDa < @TSDiemToiThieu) OR (@DiemToiDa > @TSDiemToiDa))
			PRINT(N'Điểm tối đa phải nằm trong đoạn từ ' + @TSDiemToiThieu + N' đến ' + @TSDiemToiDa)
		ELSE IF((@DiemKhongChe < @TSDiemToiThieu) OR (@DiemKhongChe > @TSDiemToiDa))
			PRINT(N'Điểm khống chế phải nằm trong đoạn từ ' + @TSDiemToiThieu + N' đến ' + @TSDiemToiDa)
		ELSE
		BEGIN
			INSERT INTO XEPLOAI(
				MaXepLoai,
				TenXepLoai,
				DiemToiThieu,
				DiemToiDa,
				DiemKhongChe
			)
			VALUES(
				@MaXepLoai,
				@TenXepLoai,
				@DiemToiThieu,
				@DiemToiDa,
				@DiemKhongChe
			)
			PRINT(N'Loại xếp loại đã được thêm vào thành công')
		END;
	END;
END