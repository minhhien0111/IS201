<p align="center">
  <a href="https://www.uit.edu.vn/" title="Trường Đại học Công nghệ Thông tin" style="border: none;">
    <img src="https://i.imgur.com/WmMnSRt.png" alt="Trường Đại học Công nghệ Thông tin | University of Information Technology">
  </a>
</p>

# Nhập môn công nghệ phần mềm - IS201.O21
## Nhóm 1
| ID | Họ tên | Email |
|------:|------------|----------|
|21520229|Tăng Minh Hiển|21520229@gm.uit.edu.vn|
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
