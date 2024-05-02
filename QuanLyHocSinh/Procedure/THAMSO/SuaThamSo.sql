CREATE PROCEDURE SuaThamSo
	@TuoiToiThieu	tinyint		,	
	@TuoiToiDa		tinyint		,
	@SiSoToiDa		smallint	,
	@DiemToiDa		float		,
	@DiemToiThieu	float
AS
BEGIN
	UPDATE THAMSO
	SET	TuoiToiThieu	= @TuoiToiThieu	,
		TuoiToiDa		= @TuoiToiDa	,
		SiSoToiDa		= @SiSoToiDa	,
		DiemToiDa		= @DiemToiDa	,
		DiemToiThieu	= @DiemToiThieu
	PRINT(N'Cập nhật tham số thành công')
END