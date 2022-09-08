CREATE DATABASE QLBH_MT;
GO
USE  QLBH_MT;
go
-- Bảng dữ liệu
----------------------
-- Tài khoản 
-- Chức năng: đăng nhập hoặc đăng ký
create table TaiKhoan(
TenTaiKhoan char(30),
MatKhau char(30),
SDT char(10)
);
go
--Bảng mặc định dữ liệu không thể thêm xóa sửa
------------------- TẠO BẢNG ---------------------
-- Bảng nhà cung cấp
create table NhaCC(
MaNCC char(5) not null,
TenNCC nvarchar(255),
constraint mancc_PK primary key (MaNCC),
); 
go
-- Bảng phân loại hàng hóa
create table PhanLoai(
MaLoai char(5) not null,
TenLoai nvarchar(255),
constraint maloai_PK primary key (MaLoai),
);
go
--------------------------------
-- Bảng có thể thay đổi dữ liệu
-- Bảng hàng hóa
create table MayTinh(
MaMay char(10) not null,
MaLoai char(5) not null,
MaNCC char(5) not null,
TenMay nvarchar(255),
Gia int,
SoLuong int,
constraint MaMay_PK primary key (MaMay),
constraint FK_mancc foreign key (MaNCC) references NhaCC(MaNCC),
constraint FK_maloai foreign key (MaLoai) references PhanLoai(MaLoai)
);
go
-- Bảng Nhân viên
create table NhanVien(
MaNV char(10) not null,
TenNV nvarchar(255),
SDT char(10),
DiaChi nvarchar(255),
constraint manv_PK primary key (MaNV)
);
go
-- Bảng khách hàng
create table KhachHang(
MaKH char(10) not null,
TenKH nvarchar(255),
SDT char(10),
DiaChi nvarchar(255),
LuotMua int,
GhiChu char(5) default null
constraint makh_PK primary key (MaKH)
);
go
-- Bảng hóa đơn
create table HoaDon(
MaHD char(10) not null,
MaMay char(10) not null,
MaNV char(10) not null,
MaKH char(10) not null,
NgayHD date,
ThanhToan int default null
constraint mahd_PK primary key (MaHD),
constraint FK_MaMay foreign key (MaMay) references MayTinh(MaMay),
constraint FK_MaNV foreign key (MaNV) references NhanVien(MaNV),
constraint FK_MaKH foreign key (MaKH) references KhachHang(MaKH)
);
go
----------------------- CHÈN DỮ LIỆU ---------------------------
----------------------------------------------------------------
----------------------- Bảng tài khoản -------------------------
insert into TaiKhoan values	('daovietbao','221221','0987667556'),
							('dinhkhachoat','221221','0987898777'),
							('tranductien','221221','0978764234')
select * from TaiKhoan

----------------------- Bảng nhà cung cấp ------------------------
insert into NhaCC values ('CC01',N'HC'),
						('CC02',N'FPT'),
						('CC03',N'Thế Giới Di Động'),
						('CC04',N'Điện Máy Xanh'),
						('CC05',N'SamSung'),
						('CC06',N'Hà Nội Computer'),
						('CC07',N'Nguyễn Kim'),
						('CC08',N'Siêu Thị điện Máy PICO'),
						('CC09',N'GEARVN'),
						('CC10',N'Điện máy Chợ Lớn');
select * from NhaCC;

----------------------- Bảng phân loại ----------------------------
insert into PhanLoai values	('PL01',N'LapTop Gaming'),
							('PL02',N'LapTop Văn Phòng'),
							('PL03',N'Workstation')
select * from PhanLoai;

---------------------- Bảng hàng hóa --------------------------------
insert into MayTinh values	('H01','PL01','CC05',N'Laptop Acer Aspire 7 A715 75G 58U4',620,5),
							('H02','PL01','CC06',N'Laptop Lenovo IdeaPad Gaming 3 15ACH6 82K201BCVN',700,10),
							('H03','PL02','CC01',N'HP 205 Pro G4 AIO R5',1200,7),
							('H04','PL02','CC02',N'Laptop ASUS Vivobook Flip TP470EA EC346W',420,15),
							('H05','PL02','CC03',N'Laptop MSI Modern 15 A5M 238VN',110,100),
							('H06','PL03','CC09',N'MSI WS66 10TMT',2200,100),
							('H07','PL03','CC04',N'HP ZBook Fury 17 G8',2500,30)
select * from MayTinh;

---------------------- Bảng nhân viên --------------------------------
insert into NhanVien values ('NV01',N'Trần Đức Tiến','0983000',N'Phú Thọ'),
							('NV02',N'Đinh Khắc Hoạt','098743',N'Quảng Ninh'),
							('NV03',N'Đào Việt Bảo','098337254',N'Hà Nội'),
							('NV04',N'Nguyễn Phương Đông','0987436',N'Phú Thọ'),
							('NV05',N'Lê Duy Đăng','09834443',N'Nghệ An'),
							('NV06',N'Trần Đức Anh','0984540',N'Phú Thọ'),
							('NV07',N'Đinh Như Quỳnh','098743353',N'Vĩnh Phúc'),
							('NV08',N'Đào Việt Bảo Bá','09822463',N'Hà Nội'),
							('NV09',N'Nguyễn Phương Anh','098732436',N'Hải Phòng'),
							('NV10',N'Lê Duy Phát','0983666443',N'hà Nội')
select * from NhanVien

------------------------ Bảng khách hàng ----------------------------------
insert into KhachHang	(MaKH, TenKH, SDT, DiaChi, LuotMua)
				values	('KH01',N'Phan Thị Ðịnh','093497683',N'Hà Giang',7),
						('KH02',N'Trần Chung Kiên','093495763',N'Hà Nội',6),
						('KH03',N'Trần Văn Sơn','09349444',N'Hà Nội',6),
						('KH04',N'Nguyễn Văn Toàn','093666',N'Lào Cai',11),
						('KH05',N'Bùi Hoàng Việt Anh','09342223',N'Hà Nội',16),
						('KH06',N'Nguyễn Văn Dương','09344553',N'Thanh Hóa',2);
select * from KhachHang;

------------------------ Bảng hóa đơn ----------------------------------
insert into HoaDon	(MaHD, MaMay, MaNV, MaKH, NgayHD)
					values	('HD01','H01','NV01','KH01','2022/01/06'),
							('HD02','H02','NV01','KH02','2022/02/07'),
							('HD03','H06','NV02','KH03','2022/01/04'),
					    	('HD04','H04','NV03','KH04','2022/02/12'),
							('HD05','H05','NV02','KH01','2022/04/06'),
							('HD06','H03','NV10','KH04','2022/03/12'),
							('HD07','H02','NV06','KH02','2022/05/11'),
							('HD08','H05','NV07','KH03','2022/06/21'),
							('HD09','H07','NV03','KH06','2022/06/21'),
							('HD10','H04','NV06','KH06','2022/03/23'),
							('HD11','H02','NV08','KH05','2022/02/12'),
							('HD12','H01','NV07','KH02','2022/04/09'),
							('HD13','H04','NV10','KH02','2022/05/26'),
							('HD14','H05','NV03','KH02','2022/06/16')

select * from HoaDon;
----------------------------------------------------------------------
---------------- Tạo thủ tục, truy vấn, view -------------------------
----------------------------------------------------------------------

--Thủ Tục truy vấn show, thêm, xóa, sửa, máy tính
--Show máy tính
go
create procedure sp_showMayTinh
as
select a.MaMay, b.TenLoai, c.TenNCC, a.TenMay, a.Gia, a.SoLuong from dbo.MayTinh a
join dbo.PhanLoai b on a.MaLoai = b.MaLoai
join dbo.NhaCC c on a.MaNCC = c.MaNCC
go

-- Thêm hàng hóa
create procedure sp_insertMayTinh
(	@MaMay char(10),
	@MaLoai char(5),
	@MaNCC char(5),
	@TenMay nvarchar(255),
	@Gia int,
	@SoLuong int
)
as
	begin
		insert into dbo.MayTinh
		values (@MaMay,@MaLoai,@MaNCC,@TenMay,@Gia,@SoLuong)
		print N'Thêm mới thành công'
	end
go

-- Sửa hàng hóa
create procedure sp_updateMayTinh
(	@MaMay char(10),
	@MaLoai char(5),
	@MaNCC char(5),
	@TenMay nvarchar(255),
	@Gia int,
	@SoLuong int
)
as
	begin
		update dbo.MayTinh set
		MaLoai = @MaLoai,
		MaNCC = @MaNCC,
		TenMay = @TenMay,
		Gia = @Gia,
		SoLuong = @SoLuong
		where MaMay = @MaMay
		print N'Cập nhật thành công'
	end
go

-- Xóa hàng hóa
create procedure sp_deleteMayTinh @MaMay char(10)
as
	begin
		-- Xóa hàng ở bảng Khách Hàng
		alter table HoaDon drop constraint FK_MaMay
		delete from dbo.MayTinh where MaMay = @MaMay
		-- Xóa hàng có liên quan tại bảng Hóa Đơn
		delete from dbo.HoaDon where MaMay = @MaMay
		alter table HoaDon add constraint FK_MaMay foreign key (MaMay) references MayTinh(MaMay)
		print N'Xóa thành công'
	end
go
-- Tìm kiếm hàng hóa
create procedure sp_selectMayTinh @MaMay char(10) as
begin
	if(exists(select * from dbo.MayTinh where MaMay = @MaMay))
		select * from dbo.MayTinh where MaMay = @MaMay
	else
		print 'Not found!'
end
go
--Test thủ tục Hang Hoa
/*
exec sp_showMayTinh
go
exec sp_insertMayTinh 'H08', 'PL02', 'CC09', N'MSI Steath', 970, 5
go
exec sp_updateMayTinh 'H05','PL03','CC03',N'Laptop MSI Modern 15 A5M 238VN',220,20
go
exec sp_selectMayTinh 'H06'
go
exec sp_deleteMayTinh 'H05'
go
exec sp_insertHoaDon 'HD15', 'H06', 'NV06', 'KH01', '2022-02-06'
go
exec sp_deleteMayTinh 'H08'
go
*/
-----------------------------------------------------------------
-----------------------------------------------------------------
--Nhân Viên
-- Show nhân viên
create procedure sp_showNhanVien as
select * from dbo.NhanVien
go
-- Thêm nhân viên
create procedure sp_insertNhanVien
(	@MaNV char(10),
	@TenNV nvarchar(255),
	@SDT char(10),
	@DiaChi nvarchar(255)
)
as
	begin
		insert into dbo.NhanVien
		values (@MaNV,@TenNV,@SDT,@DiaChi)
		print N'Thêm mới thành công'
	end
go
-- Sửa nhân viên
create procedure sp_updateNhanVien
(	@MaNV char(10),
	@TenNV nvarchar(255),
	@SDT char(10),
	@DiaChi nvarchar(255)
)as
	begin
		update dbo.NhanVien set
		TenNV = @TenNV,
		SDT = @SDT,
		DiaChi = @DiaChi
		where MaNV = @MaNV
		print N'Cập nhật thành công'
	end
go
-- Xóa nhân viên
create procedure sp_deleteNhanVien @MaNV char(10) as
begin
	--Xóa dữ liệu từ nhân viên
	alter table HoaDon drop constraint FK_MaNV
	delete from dbo.NhanVien where MaNV = @MaNV
	--Xóa dữ liệu từ hóa đơn
	delete from dbo.HoaDon where MaNV = @MaNV
	alter table dbo.HoaDon add constraint FK_MaNV foreign key (MaNV) references NhanVien(MaNV)
	print N'Xóa thành công'
end
go
-- Tìm kiếm nhân viên
create procedure sp_selectNhanVien @MaNV char(10) as
begin
	if(exists(select * from dbo.NhanVien where MaNV = @MaNV))
		select * from dbo.NhanVien where MaNV = @MaNV
	else
		print 'Not found!'
end
go
--Test thủ tục nhân viên
/*
exec sp_showNhanVien
go
exec sp_insertNhanVien 'NV11', N'Dương Thị Nga', '0938938432', N'Thái Nguyên'
go
exec sp_updateNhanVien 'NV10',N'Lê Duy Phát','0983666443',N'Hà Nội'
go
exec sp_selectNhanVien 'NV10'
go
exec sp_insertHoaDon 'HD15', 'H06', 'NV11', 'KH01', '2022-02-06'
go
select * from HoaDon
go
exec sp_deleteNhanVien 'NV11'
go
*/
-----------------------------------------------------------------
-----------------------------------------------------------------
-- Bảng khách hàng
-- Thông tin khách hàng
create procedure sp_showKhachHang as
select * from KhachHang
go
--Update ghi chú của khách hàng
create procedure sp_updateGhiChu as
update KhachHang set GhiChu = case
when LuotMua < 10 then 'BT'
when LuotMua >= 10 and LuotMua <= 15 then 'VIP1'
when LuotMua > 15  and LuotMua <= 20 then 'VIP2'
when LuotMua > 20 then 'VIP3'
else 'NULL'
end
go
--Thêm khách hàng
create procedure sp_insertKhachHang
(	@MaKH char(10),
	@TenKH nvarchar(255),
	@SDT char(10),
	@DiaChi nvarchar(255),
	@LuotMua int
)
as
	begin
		insert into dbo.KhachHang (MaKH, TenKH, SDT, DiaChi, LuotMua)
		values (@MaKH,@TenKH,@SDT,@DiaChi,@LuotMua)
		exec sp_updateGhiChu
		print N'Thêm mới thành công'
	end
go
-- Sửa thông tin khách hàng
create procedure sp_updateKhachHang
(	@MaKH char(10),
	@TenKH nvarchar(255),
	@SDT char(10),
	@DiaChi nvarchar(255),
	@LuotMua int
)as
	begin
		update dbo.KhachHang set
		TenKH = @TenKH,
		SDT = @SDT,
		DiaChi = @DiaChi,
		LuotMua = @LuotMua
		where MaKH = @MaKH
		begin
		exec sp_updateGhiChu
		end
		print N'Cập nhật thành công'
	end
go
-- Xóa khách hàng
create procedure sp_deleteKhachHang @MaKH char(10) as
begin
		alter table dbo.HoaDon drop constraint FK_MaKH
		delete from dbo.KhachHang where MaKH = @MaKH
		delete from dbo.HoaDon where MaKH = @MaKH
		alter table HoaDon add constraint FK_MaKH foreign key (MaKH) references KhachHang(MaKH)
		print N'Xóa thành công'
end
go
--Tìm kiếm khách hàng
create procedure sp_selectKhachHang @MaKH char(10) as
begin
	if(exists(select * from dbo.KhachHang where MaKH = @MaKH))
		select * from dbo.KhachHang where MaKH = @MaKH
	else
		print 'Not found!'
end
go
--Test thủ tục bảng khách hàng
/*
exec sp_showKhachHang
go
exec sp_insertKhachHang 'KH07' , N'Nguyễn Lan Hương', '092304323', N'Quảng Ninh', 30
go
exec sp_updateKhachHang 'KH06',N'Nguyễn Văn Dương','09344553',N'Thanh Hóa',10
go 
exec sp_deleteKhachHang 'KH07'
go
exec sp_insertHoaDon 'HD15', 'H06', 'NV10', 'KH07', '2022-02-06'
go
exec sp_selectKhachHang 'KH05'
go
*/
-----------------------------------------------------------------
-----------------------------------------------------------------
-- Bảng hóa đơn
-- Show hóa đơn
create procedure sp_showHoaDon as
select a.MaHD, b.TenMay, c.TenNV, b.SoLuong,  d.TenKH, a.NgayHD, a.ThanhToan
from dbo.HoaDon a
join dbo.MayTinh b on a.MaMay = b.MaMay
join dbo.NhanVien c on a.MaNV = c.MaNV
join dbo.KhachHang d on a.MaKH = d.MaKH
exec sp_updateGhiChu
go

--Update thanh toán
create procedure sp_updateThanhToan as
update HoaDon set ThanhToan = 
case
	when d.GhiChu = 'BT' then b.Gia
	when d.GhiChu = 'VIP1' then (b.Gia - (b.Gia * 0.05))
	when d.GhiChu = 'VIP2' then (b.Gia - (b.Gia * 0.07))
	when d.GhiChu = 'VIP3' then (b.Gia - (b.Gia * 0.1))
	else 'Null'
end 
from dbo.HoaDon a
join dbo.MayTinh b on a.MaMay = b.MaMay
join dbo.NhanVien c on a.MaNV = c.MaNV
join dbo.KhachHang d on a.MaKH = d.MaKH;
go
-- Thêm hóa đơn
create procedure sp_insertHoaDon
(	@MaHD char(10),
	@MaMay char(10),
	@MaNV char(10),
	@MaKH char(10),
	@NgayHD date
)
as
	begin
		insert into dbo.HoaDon (MaHD, MaMay, MaNV, MaKH, NgayHD)
		values (@MaHD,@MaMay,@MaNV,@MaKH,@NgayHD)
		exec sp_updateThanhToan
		print N'Thêm mới thành công'
	end

go
-- Sửa hóa đơn
create procedure sp_updateHoaDon
(	@MaHD char(10),
	@MaMay char(10),
	@MaNV char(10),
	@MaKH char(10),
	@NgayHD date
)
as
	begin
		update dbo.HoaDon set
		MaMay = @MaMay,
		MaNV = @MaNV,
		MaKH = @MaKH,
		NgayHD = @NgayHD
		where MaHD = @MaHD
		exec sp_updateThanhToan
		print N'Cập nhật thành công'
	end
go
-- Xóa hóa đơn
create procedure sp_deleteHoaDon @MaHD char(10)
as
	begin
		delete from dbo.HoaDon
		where MaHD = @MaHD
		print N'Xóa thành công'
	end
go
-- Tìm kiếm hóa đơn
create procedure sp_selectHoaDon @MaHD char(10) as
begin
	if(exists(select * from dbo.HoaDon where MaHD = @MaHD))
		select * from dbo.HoaDon where MaHD = @MaHD
	else
		print 'Not found!'
end
go
--Test thủ tục bảng hóa đơn
/*
exec sp_showHoaDon
go
exec sp_insertHoaDon 'HD15', 'H02', 'NV06', 'KH01', '2022-02-06'
go
exec sp_updateHoaDon 'HD15', 'H03', 'NV06', 'KH02', '2022-02-10'
go
exec sp_deleteHoaDon 'HD15'
go
exec sp_selectHoaDon 'HD12'
go
*/
-- Dữ liệu để load lên mainForm
create procedure Dashboard
@SLHang int output, --Số lượng hàng hóa
@SLNhanVien int output, --Số lượng nhân viên
@SLHoaDon int output, --Số lượng hóa đơn
@SLKH int output, --Số lượng khách hàng
@DoanhThu int output --Tổng doanh thu theo tháng
as
set @DoanhThu = (select sum(ThanhToan) as 'Doanh Thu' from dbo.HoaDon)
set @SLKH = (select count(MaKH) as 'So Luong Khach Hang' from dbo.KhachHang)
set @SLHang = (select count(MaMay) as 'So Luong Hang' from dbo.MayTinh)
set @SLNhanVien = (select count(MaNV) as 'So Luong Nhan Vien' from dbo.NhanVien)
set @SLHoaDon = (select count(MaHD) as 'So Luong Hoa Don' from  dbo.HoaDon)
go

--Doanh số của top 5 nhân viên
create procedure sp_DoanhSo as
select top 1 b.TenNV, CONCAT(COUNT(a.MaNV), ' SP') as 'Doanh So' from HoaDon a 
join NhanVien b on a.MaNV = b.MaNV
group by a.MaNV, b.TenNV
order by COUNT(1) desc
go
exec sp_DoanhSo
go

--Doanh thu theo tháng
create procedure sp_DoanhThuThang as
exec sp_updateThanhToan
select CONCAT('T', max(month(NgayHD))) as 'Thang',CONCAT(SUM(ThanhToan),'') as 'Doanh Thu' from HoaDon
group by MONTH(NgayHD)
go
exec sp_DoanhThuThang
go
-- Diagram top 5 Hàng hóa bán chạy
create procedure sp_topHang as
select top 5  b.TenMay, concat(N'Bán ', count(a.MaMay))  as 'So Luong' from HoaDon a 
join MayTinh b on a.MaMay = b.MaMay
group by a.MaMay, b.TenMay
order by count(1) desc
go
exec sp_topHang
go
-- Nhân viên có doanh thu cao nhất
create procedure sp_topNhanVien as
select top 1 b.TenNV, count(a.MaNV) as 'So Luong' from HoaDon a
join NhanVien b on a.MaNV = b.MaNV
group by b.TenNV, a.MaNV
order by COUNT(1) desc
--Thêm tài khoản mới
go
exec sp_topNhanVien
go
create procedure sp_insertTaiKhoan (
	@TenTaiKhoan char(30),
	@MatKhau char(30),
	@SDT char(10)
) as
begin
	if(not exists(select TenTaiKhoan, SDT  from TaiKhoan
	where TenTaiKhoan = @TenTaiKhoan or SDT = @SDT))
	begin
	insert into TaiKhoan (TenTaiKhoan, MatKhau, SDT)
	values(@TenTaiKhoan, @MatKhau, @SDT)
	end
else
	print 'Failse'
end
go
exec sp_insertTaiKhoan 'NuNu', '221221', '9012352923'


exec sp_showHoaDon
