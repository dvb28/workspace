CREATE DATABASE BTL_QLBH;
GO
USE BTL_QLBH;
GO
-- Bảng dữ liệu
----------------------
-- Tài khoản 
-- Chức năng: đăng nhập hoặc đăng ký
create table TaiKhoan(
TenTaiKhoan char(30),
MatKhau char(30),
SDT char(10)
);
GO
--Bảng mặc định dữ liệu không thể thêm xóa sửa
------------------- TẠO BẢNG ---------------------
----------------------- Bảng tài khoản -------------------------
GO
-- Bảng nhà cung cấp
create table NhaCC(
MaNCC char(5) not null,
TenNCC nvarchar(255),
constraint mancc_PK primary key (MaNCC),
); 
GO
-- Bảng phân loại hàng hóa
create table PhanLoai(
MaLoai char(5) not null,
TenLoai nvarchar(255),
constraint maloai_PK primary key (MaLoai),
);
GO
--------------------------------
-- Bảng có thể thay đổi dữ liệu
-- Bảng hàng hóa
create table HangHoa(
MaHang char(10) not null,
MaLoai char(5) not null,
MaNCC char(5) not null,
TenHang nvarchar(255),
Gia int,
SoLuong int,
constraint mahang_PK primary key (MaHang),
constraint FK_mancc foreign key (MaNCC) references NhaCC(MaNCC),
constraint FK_maloai foreign key (MaLoai) references PhanLoai(MaLoai)
);
GO
-- Bảng Nhân viên
create table NhanVien(
MaNV char(10) not null,
TenNV nvarchar(255),
SDT char(10),
DiaChi nvarchar(255),
constraint manv_PK primary key (MaNV)
);
GO
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
select DISTINCT GhiChu FROM KhachHang
GO
-- Bảng hóa đơn
create table HoaDon(
MaHD char(10) not null,
MaHang char(10) not null,
MaNV char(10) not null,
MaKH char(10) not null,
NgayHD date,
ThanhToan int default null
constraint mahd_PK primary key (MaHD),
constraint FK_MaHang foreign key (MaHang) references HangHoa(MaHang),
constraint FK_MaNV foreign key (MaNV) references NhanVien(MaNV),
constraint FK_MaKH foreign key (MaKH) references KhachHang(MaKH)
);
GO
----------------------- CHÈN DỮ LIỆU ---------------------------
----------------------------------------------------------------
----------------------- Bảng tài khoản -------------------------
insert into TaiKhoan values	('daovietbao','221221','0987667556'),
							('dinhkhachoat','221221','0987898777'),
							('tranductien','221221','0978764234')
SELECT * FROM TaiKhoan

----------------------- Bảng nhà cung cấp ------------------------
insert into NhaCC values ('CC01',N'Acer'),
						('CC02',N'MSI'),
						('CC03',N'Asus'),
						('CC04',N'Apple'),
						('CC05',N'Dell'),
						('CC06',N'HP'),
						('CC07',N'Acer');
SELECT * FROM NhaCC;

----------------------- Bảng phân loại ----------------------------
insert into PhanLoai values	('PL01',N'Màn Hình Máy Tính'),
							('PL02',N'Laptop'),
							('PL03',N'Case Máy Tính'),
							('PL04',N'Ghế Gaming'),
							('PL05',N'Card Đồ Họa'),
							('PL06',N'Bàn Phím Cơ'),
							('PL07',N'Tai Nghe Gaming')
SELECT * FROM PhanLoai;

---------------------- Bảng hàng hóa --------------------------------
insert into HangHoa values	('H01','PL02','CC06',N'Laptop Acer Nitro 5',330,10),
							('H02','PL03','CC01',N'HP 205 Pro G4 AIO R5',1200,7),
							('H03','PL05','CC06',N'Phím Cơ E-Dra EK387',120,15),
							('H04','PL06','CC05',N'NVIDIA GTX 1650',120,15),
							('H05','PL05','CC07',N'Tai Nghe Rapoo VH160',120,15),
							('H06','PL02','CC02',N'Laptop ROG Strix Scar 17',120,15),
							('H07','PL05','CC03',N'NVIDIA GTX 1050',110,100)
SELECT * FROM HangHoa;

---------------------- Bảng nhân viên --------------------------------
insert into NhanVien values ('NV01',N'Trần Đức Tiến','0983000',N'Phú Thọ'),
							('NV02',N'Đinh Khắc Hoạt','098743',N'Quảng Ninh'),
							('NV03',N'Đào Việt Bảo','098337254',N'Hà Nội'),
							('NV04',N'Nguyễn Phương Đông','0987436',N'Phú Thọ'),
							('NV05',N'Lê Duy Đăng','09834443',N'Nghệ An'),
							('NV06',N'Trần Đức Anh','0984540',N'Phú Thọ'),
							('NV07',N'Đinh Như Quỳnh','098743353',N'Vĩnh Phúc')
SELECT * FROM NhanVien

------------------------ Bảng khách hàng ----------------------------------
insert into KhachHang	(MaKH, TenKH, SDT, DiaChi, LuotMua)
				values	('KH01',N'Phan Thị Ðịnh','093497683',N'Hà Giang',7),
						('KH02',N'Trần Chung Kiên','093495763',N'Hà Nội',6),
						('KH03',N'Trần Văn Sơn','09349444',N'Hà Nội',6),
						('KH04',N'Nguyễn Văn Toàn','093666',N'Lào Cai',11),
						('KH05',N'Bùi Hoàng Việt Anh','09342223',N'Hà Nội',16),
						('KH06',N'Nguyễn Quang Vinh','09342223',N'Hà Nội',16),
						('KH07',N'Lê Văn Vượng','09342223',N'Hà Nội',16)
SELECT * FROM KhachHang;

------------------------ Bảng hóa đơn ----------------------------------
insert into HoaDon	(MaHD, MaHang, MaNV, MaKH, NgayHD)
					values	('HD01','H01','NV01','KH01','2022/01/06'),
							('HD02','H02','NV01','KH02','2022/02/07'),
							('HD03','H03','NV02','KH03','2022/01/04'),
					    	('HD04','H04','NV03','KH04','2022/02/12'),
							('HD05','H05','NV02','KH01','2022/04/06'),
							('HD06','H03','NV07','KH04','2022/03/12'),
							('HD07','H02','NV06','KH02','2022/05/11')

SELECT * FROM HoaDon;
----------------------------------------------------------------------
---------------- Tạo thủ tục, truy vấn, view -------------------------
----------------------------------------------------------------------

--Thủ Tục truy vấn show, thêm, xóa, sửa, hàng hóa Hàng Hóa
--Show hàng hóa
GO
CREATE PROCEDURE sp_showHangHoa
AS
select a.MaHang, b.TenLoai, c.TenNCC, a.TenHang, a.Gia, a.SoLuong FROM dbo.HangHoa a
JOIN dbo.PhanLoai b on a.MaLoai = b.MaLoai
JOIN dbo.NhaCC c on a.MaNCC = c.MaNCC
GO
-- Thêm hàng hóa
CREATE PROCEDURE sp_insertHangHoa
(	@MaHang char(10),
	@MaLoai char(5),
	@MaNCC char(5),
	@TenHang nvarchar(255),
	@Gia int,
	@SoLuong int
)
AS
	begin
		insert into dbo.HangHoa
		values (@MaHang,@MaLoai,@MaNCC,@TenHang,@Gia,@SoLuong)
		print N'Thêm mới thành công'
	end
GO

EXEC sp_deleteHangHoa 'H08', 'PL02', 'CC05', N'MSI Steath', 970, 5
-- Sửa hàng hóa
CREATE PROCEDURE sp_updateHangHoa
(	@MaHang char(10),
	@MaLoai char(5),
	@MaNCC char(5),
	@TenHang nvarchar(255),
	@Gia int,
	@SoLuong int
)
AS
	begin
		update dbo.HangHoa SET
		MaLoai = @MaLoai,
		MaNCC = @MaNCC,
		TenHang = @TenHang,
		Gia = @Gia,
		SoLuong = @SoLuong
		where MaHang = @MaHang
		print N'Cập nhật thành công'
	end
GO

-- Xóa hàng hóa
create procedure sp_deleteHangHoa @MaHang char(10)
AS
	begin
		-- Xóa hàng ở bảng Khách Hàng
		alter table HoaDon drop constraint FK_MaHang
		delete FROM dbo.HangHoa where MaHang = @MaHang
		-- Xóa hàng có liên quan tại bảng Hóa Đơn
		delete FROM dbo.HoaDon where MaHang = @MaHang
		alter table HoaDon add constraint FK_MaHang foreign key (MaHang) references HangHoa(MaHang)
		print N'Xóa thành công'
	end
GO

-- Tìm kiếm hàng hóa
CREATE PROCEDURE sp_selectHangHoa @MaHang char(10) AS
begin
	if(exists(select * FROM dbo.HangHoa where MaHang = @MaHang))
		select * FROM dbo.HangHoa where MaHang = @MaHang
	else
		print 'Not found!'
end
GO
--Test thủ tục Hang Hoa
/*
EXEC sp_showHangHoa
GO
EXEC sp_insertHangHoa 'H06', 'PL02', 'CC09', N'MSI Steath', 970, 5
GO
EXEC sp_updateHangHoa 'H05','PL05','CC03',N'Chuột Không Dây Fuhlen',110,100
GO
EXEC sp_selectHangHoa 'H06'
GO
EXEC sp_deleteHangHoa 'H05'
GO
EXEC sp_insertHoaDon 'HD15', 'H06', 'NV06', 'KH01', '2022-02-06'
GO
EXEC sp_deleteHangHoa 'H06'
GO
*/
-----------------------------------------------------------------
-----------------------------------------------------------------
--Nhân Viên
-- Show nhân viên
CREATE PROCEDURE sp_showNhanVien AS
select * FROM dbo.NhanVien
GO
-- Thêm nhân viên
CREATE PROCEDURE sp_insertNhanVien
(	@MaNV char(10),
	@TenNV nvarchar(255),
	@SDT char(10),
	@DiaChi nvarchar(255)
)
AS
	begin
		insert into dbo.NhanVien
		values (@MaNV,@TenNV,@SDT,@DiaChi)
		print N'Thêm mới thành công'
	end
GO
GO
-- Sửa nhân viên
CREATE PROCEDURE sp_updateNhanVien
(	@MaNV char(10),
	@TenNV nvarchar(255),
	@SDT char(10),
	@DiaChi nvarchar(255)
)AS
	begin
		update dbo.NhanVien SET
		TenNV = @TenNV,
		SDT = @SDT,
		DiaChi = @DiaChi
		where MaNV = @MaNV
		print N'Cập nhật thành công'
	end
GO
-- Xóa nhân viên
CREATE PROCEDURE sp_deleteNhanVien @MaNV char(10) AS
begin
	--Xóa dữ liệu từ nhân viên
	alter table HoaDon drop constraint FK_MaNV
	delete FROM dbo.NhanVien where MaNV = @MaNV
	--Xóa dữ liệu từ hóa đơn
	delete FROM dbo.HoaDon where MaNV = @MaNV
	alter table dbo.HoaDon add constraint FK_MaNV foreign key (MaNV) references NhanVien(MaNV)
	print N'Xóa thành công'
end
EXEC sp_deleteNhanVien 'NV10'
select * FROM HoaDon
GO
-- Tìm kiếm nhân viên
CREATE PROCEDURE sp_selectNhanVien @MaNV char(10) AS
begin
	if(exists(select * FROM dbo.NhanVien where MaNV = @MaNV))
		select * FROM dbo.NhanVien where MaNV = @MaNV
	else
		print 'Not found!'
end
GO
--Test thủ tục nhân viên
/*
EXEC sp_showNhanVien
GO
EXEC sp_insertNhanVien 'NV11', N'Dương Thị Nga', '0938938432', N'Thái Nguyên'
GO
EXEC sp_updateNhanVien 'NV10',N'Lê Duy Phát','0983666443',N'Hà Nội'
GO
EXEC sp_selectNhanVien 'NV10'
GO
EXEC sp_insertHoaDon 'HD15', 'H06', 'NV11', 'KH01', '2022-02-06'
GO
select * FROM HoaDon
GO
EXEC sp_deleteNhanVien 'NV11'
GO
*/
-----------------------------------------------------------------
-----------------------------------------------------------------
-- Bảng khách hàng
--Update ghi chú của khách hàng
CREATE PROCEDURE sp_updateGhiChu AS
update KhachHang SET GhiChu = cASe
when LuotMua < 10 then 'BT'
when LuotMua > 10 and LuotMua < 15 then 'VIP1'
when LuotMua > 15  and LuotMua < 20 then 'VIP2'
when LuotMua > 20 then 'VIP3'
else 'Unknow'
end
GO
EXEC sp_updateGhiChu
GO
-- Thông tin khách hàng
CREATE PROCEDURE sp_showKhachHang AS
BEGIN
	select * FROM KhachHang
	EXEC sp_updateGhiChu
END
GO
select DISTINCT GhiChu FROM KhachHang
GO
--Thêm khách hàng
CREATE PROCEDURE sp_insertKhachHang
(	@MaKH char(10),
	@TenKH nvarchar(255),
	@SDT char(10),
	@DiaChi nvarchar(255),
	@LuotMua int
)
AS
	begin
		insert into dbo.KhachHang (MaKH, TenKH, SDT, DiaChi, LuotMua)
		values (@MaKH,@TenKH,@SDT,@DiaChi,@LuotMua)
		EXEC sp_updateGhiChu
		print N'Thêm mới thành công'
	end
GO
-- Sửa thông tin khách hàng
CREATE PROCEDURE sp_updateKhachHang
(	@MaKH char(10),
	@TenKH nvarchar(255),
	@SDT char(10),
	@DiaChi nvarchar(255),
	@LuotMua int
)AS
	begin
		update dbo.KhachHang SET
		TenKH = @TenKH,
		SDT = @SDT,
		DiaChi = @DiaChi,
		LuotMua = @LuotMua
		where MaKH = @MaKH
		EXEC sp_updateGhiChu
		print N'Cập nhật thành công'
	end

GO
-- Xóa khách hàng
CREATE PROCEDURE sp_deleteKhachHang @MaKH char(10) AS
begin
		alter table dbo.HoaDon drop constraint FK_MaKH
		delete FROM dbo.KhachHang where MaKH = @MaKH
		delete FROM dbo.HoaDon where MaKH = @MaKH
		alter table HoaDon add constraint FK_MaKH foreign key (MaKH) references KhachHang(MaKH)
		print N'Xóa thành công'
end
GO
--Tìm kiếm khách hàng
CREATE PROCEDURE sp_selectKhachHang @MaKH char(10) AS
begin
	if(exists(select * FROM dbo.KhachHang where MaKH = @MaKH))
		select * FROM dbo.KhachHang where MaKH = @MaKH
	else
		print 'Not found!'
end
GO
--Test thủ tục bảng khách hàng
/*
EXEC sp_showKhachHang
GO
EXEC sp_insertKhachHang 'KH07' , N'Nguyễn Lan Hương', '092304323', N'Quảng Ninh', 30
GO
EXEC sp_updateKhachHang 'KH06',N'Nguyễn Văn Dương','09344553',N'Thanh Hóa',7
GO 
EXEC sp_deleteKhachHang 'KH07'
GO
EXEC sp_insertHoaDon 'HD15', 'H06', 'NV10', 'KH07', '2022-02-06'
GO
EXEC sp_selectKhachHang 'KH05'
GO
*/
-----------------------------------------------------------------
-----------------------------------------------------------------
-- Bảng hóa đơn
--Update thanh toán
CREATE PROCEDURE sp_updateThanhToan AS
update HoaDon SET ThanhToan = 
cASe
	when d.GhiChu = 'BT' then b.Gia
	when d.GhiChu = 'VIP1' then (b.Gia - (b.Gia * 0.05))
	when d.GhiChu = 'VIP2' then (b.Gia - (b.Gia * 0.07))
	when d.GhiChu = 'VIP3' then (b.Gia - (b.Gia * 0.1))
	else 'Null'
end
FROM dbo.HoaDon a
JOIN dbo.HangHoa b on a.MaHang = b.MaHang
JOIN dbo.NhanVien c on a.MaNV = c.MaNV
JOIN dbo.KhachHang d on a.MaKH = d.MaKH;
GO
EXEC sp_updateThanhToan
GO
-- Show hóa đơn
	CREATE PROCEDURE sp_showHoaDon AS
	select a.MaHD, b.TenHang, c.TenNV,  b.SoLuong, d.TenKH, a.NgayHD, a.ThanhToan

	FROM dbo.HoaDon a
	JOIN dbo.HangHoa b on a.MaHang = b.MaHang
	JOIN dbo.NhanVien c on a.MaNV = c.MaNV
	JOIN dbo.KhachHang d on a.MaKH = d.MaKH
	EXEC sp_updateGhiChu
GO
EXEC sp_showHoaDon
GO
-- Thêm hóa đơn
CREATE PROCEDURE sp_insertHoaDon
(	@MaHD char(10),
	@MaHang char(10),
	@MaNV char(10),
	@MaKH char(10),
	@NgayHD date
)
AS
	begin
		insert into dbo.HoaDon (MaHD, MaHang, MaNV, MaKH, NgayHD)
		values (@MaHD,@MaHang,@MaNV,@MaKH,@NgayHD)
		EXEC sp_updateThanhToan
		print N'Thêm mới thành công'
	end

GO
-- Sửa hóa đơn
CREATE PROCEDURE sp_updateHoaDon
(	@MaHD char(10),
	@MaHang char(10),
	@MaNV char(10),
	@MaKH char(10),
	@NgayHD date
)
AS
	begin
		update dbo.HoaDon SET
		MaHang = @MaHang,
		MaNV = @MaNV,
		MaKH = @MaKH,
		NgayHD = @NgayHD
		where MaHD = @MaHD
		EXEC sp_updateThanhToan
		print N'Cập nhật thành công'
	end
GO
-- Xóa hóa đơn
CREATE PROCEDURE sp_deleteHoaDon @MaHD char(10)
AS
	begin
		delete FROM dbo.HoaDon
		where MaHD = @MaHD
		print N'Xóa thành công'
	end
GO
-- Tìm kiếm hóa đơn
CREATE PROCEDURE sp_selectHoaDon @MaHD char(10) AS
begin
	if(exists(select * FROM dbo.HoaDon where MaHD = @MaHD))
		select * FROM dbo.HoaDon where MaHD = @MaHD
	else
		print 'Not found!'
end
GO
--Test thủ tục bảng hóa đơn
/*
EXEC sp_showHoaDon
GO
EXEC sp_insertHoaDon 'HD15', 'H02', 'NV06', 'KH01', '2022-02-06'
GO
EXEC sp_updateHoaDon 'HD15', 'H03', 'NV06', 'KH02', '2022-02-10'
GO
EXEC sp_deleteHoaDon 'HD15'
GO
EXEC sp_selectHoaDon 'HD14'
GO
*/
-- Dữ liệu để load lên mainForm
CREATE PROCEDURE Dashboard
@SLHang int output, --Số lượng hàng hóa
@SLNhanVien int output, --Số lượng nhân viên
@SLHoaDon int output, --Số lượng hóa đơn
@SLKH int output, --Số lượng khách hàng
@DoanhThu int output --Tổng doanh thu theo tháng
AS
SET @DoanhThu = (select sum(ThanhToan) AS 'Doanh Thu' FROM dbo.HoaDon)
SET @SLKH = (select count(MaKH) AS 'So Luong Khach Hang' FROM dbo.KhachHang)
SET @SLHang = (select count(MaHang) AS 'So Luong Hang' FROM dbo.HangHoa)
SET @SLNhanVien = (select count(MaNV) AS 'So Luong Nhan Vien' FROM dbo.NhanVien)
SET @SLHoaDon = (select count(MaHD) AS 'So Luong Hoa Don' FROM  dbo.HoaDon)
GO
--Doanh số của top 5 nhân viên
CREATE PROCEDURE sp_DoanhSo AS
select TOP 1 b.TenNV, CONCAT(COUNT(a.MaNV), ' SP') AS 'Doanh So' FROM HoaDon a 
JOIN NhanVien b on a.MaNV = b.MaNV
GROUP BY a.MaNV, b.TenNV
ORDER BY COUNT(1) DESC
GO
EXEC sp_DoanhSo
GO

--Doanh thu theo tháng
CREATE PROCEDURE sp_DoanhThuThang AS
select CONCAT('T', max(month(NgayHD))) AS 'Thang',CONCAT(SUM(ThanhToan),'') AS 'Doanh Thu' FROM HoaDon
GROUP BY MONTH(NgayHD)
GO
EXEC sp_DoanhThuThang
GO
-- Diagram top 5 Hàng hóa bán chạy
CREATE PROCEDURE sp_topHang AS
select TOP 5 b.TenHang, CONCAT(N'Bán ', count(a.MaHang), ' SP') AS 'So Luong' FROM HoaDon a 
JOIN HangHoa b on a.MaHang = b.MaHang
GROUP BY a.MaHang, b.TenHang
ORDER BY count(1) DESC
GO
DROP PROC sp_topHang
EXEC sp_topHang
GO
--Thêm tài khoản mới
GO
CREATE PROCEDURE sp_insertTaiKhoan (
	@TenTaiKhoan char(30),
	@MatKhau char(30),
	@SDT char(10)
) AS
begin
	if(not exists(select TenTaiKhoan, SDT  FROM TaiKhoan
	where TenTaiKhoan = @TenTaiKhoan or SDT = @SDT))
	begin
	insert into TaiKhoan (TenTaiKhoan, MatKhau, SDT)
	values(@TenTaiKhoan, @MatKhau, @SDT)
	end
else
	print 'Failse'
end
GO
EXEC sp_insertTaiKhoan 'NuNu', '221221', '9012352923'
