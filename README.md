<p align="center">
  <a href="https://www.uit.edu.vn/" title="Trường Đại học Công nghệ Thông tin" style="border: none;">
    <img src="https://i.imgur.com/WmMnSRt.png" alt="Trường Đại học Công nghệ Thông tin | University of Information Technology">
  </a>
</p>

# Phân tích thiết kế hệ thống thông tin - IS201.O21
## Nhóm 24
| ID | Họ tên | Email |
|------:|------------|----------|
|21520229|Tăng Minh Hiển|21520229@gm.uit.edu.vn|
|21520765|Bùi Anh Duy|21520765@gm.uit.edu.vn|
|22520637|Lê Mai Quốc Khánh|22520637@gm.uit.edu.vn|
|22521224|Phan Thị Bích Quyên|22521224@gm.uit.edu.vn|
## Phần mềm Quản lí điểm học sinh
### Cách cài đặt phần mềm
- Yêu cầu phần mềm:
  + Visual Studio
  + Microsoft SQL Server 
- Cài đặt cấu hình:
  + Cơ sở dữ liệu ở trong thư mục QuanLyHocSinh (QUANLYHOCSINH.mdf, QUANLYHOCSINH_log.ldf)
  + Attach QUANLYHOCSINH.mdf, QUANLYHOCSINH.ldf vào server SQL đang sử dụng
  + App.config -> ConnectionString: name="dataEntities", data source= name SQL Server
  + dataModel.edmx -> Update Model from DataBase -> NewConnection -> Connect to SQL Server
- Cài đặt Guna.UI2:
  + Project -> NuGet Package Manager -> Guna.UI2.Winforms 
