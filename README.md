<p align="center">
  <a href="https://www.uit.edu.vn/" title="Trường Đại học Công nghệ Thông tin" style="border: none;">
    <img src="https://i.imgur.com/WmMnSRt.png" alt="Trường Đại học Công nghệ Thông tin | University of Information Technology">
  </a>
</p>

# Nhập môn công nghệ phần mềm - SE104.N21
## Nhóm 1
| ID | Họ tên | Email |
|------:|------------|----------|
|21520229|Tăng Minh Hiển|21520229@gm.uit.edu.vn|
|21520331|Châu Thiên Long|21520331@gm.uit.edu.vn|
|21520334|Nguyễn Thái Thành Long|21520334@gm.uit.edu.vn|
|21521416|Phạm Mạnh Tấn|21521416@gm.uit.edu.vn|
|21522814|Phan Quốc Vỹ|21522814@gm.uit.edu.vn
## Phần mềm Quản lí học sinh
- Yêu cầu phần mềm:
  + Visual Studio
  + Microsoft SQL Server 
- Cài đặt cấu hình:
  + Attach QUANLYHOCSINH.mdf, QUANLYHOCSINH.ldf vào server SQL đang sử dụng
  + App.config -> ConnectionString: name="dataEntities", data source= name SQL Server
  + dataModel.edmx -> Update Model from DataBase -> NewConnection -> Connect to SQL Server
- Cài đặt Guna.UI2:
  + Project -> NuGet Package Manager -> Guna.UI2.Winforms 
