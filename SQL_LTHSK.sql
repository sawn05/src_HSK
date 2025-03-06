Create database QLSach

Use QLSach


-- Tạo bảng Thể loại
CREATE TABLE TheLoai (
    maTheLoai VARCHAR(20) PRIMARY KEY,
    tenTheLoai NVARCHAR(100) NOT NULL
);

-- Tạo bảng Nhà cung cấp
CREATE TABLE NhaCungCap (
    maNhaCungCap VARCHAR(20) PRIMARY KEY,
    tenNhaCungCap NVARCHAR(100) NOT NULL,
    diaChi NVARCHAR(255),
    thanhPho NVARCHAR(100),
    soDienThoai NVARCHAR(50)
);

-- Tạo bảng Sản phẩm
CREATE TABLE SanPham (
    maSanPham VARCHAR(20) PRIMARY KEY,
    tenSanPham NVARCHAR(255) NOT NULL,
    maTheLoai VARCHAR(20),
    gia DECIMAL(10, 2),
    maNhaCungCap VARCHAR(20),
    FOREIGN KEY (maTheLoai) REFERENCES TheLoai(maTheLoai),
    FOREIGN KEY (maNhaCungCap) REFERENCES NhaCungCap(maNhaCungCap)
);

ALTER TABLE sanpham
ADD soLuongTon INT CHECK (soLuongTon >= 0) DEFAULT 0;

UPDATE sanpham 
SET soLuongTon = 100;

-- Tạo bảng Khách hàng
CREATE TABLE KhachHang (
    maKhachHang VARCHAR(20) PRIMARY KEY,
    tenKhachHang NVARCHAR(255) NOT NULL,
    gioiTinh NVARCHAR(3) CHECK (gioiTinh IN (N'Nữ', N'Nam')) NOT NULL,
    soDienThoai VARCHAR(10),
    diaChi NVARCHAR(255)
);


ALTER TABLE KhachHang
ADD tongTienDaMua DECIMAL(10, 2) NOT NULL DEFAULT 0;

CREATE TABLE NhanVien (
    maNhanVien VARCHAR(20) PRIMARY KEY,
    tenNhanVien NVARCHAR(255) NOT NULL,
    gioiTinh NVARCHAR(3) CHECK (gioiTinh IN (N'Nữ', N'Nam')) NOT NULL,
    soDienThoai VARCHAR(10),
    diaChi NVARCHAR(255),
    ngaySinh DATE,
	chucDanh NVARCHAR(50)
);



INSERT INTO NhanVien (maNhanVien, tenNhanVien, gioiTinh, soDienThoai, diaChi, ngaySinh, chucDanh) VALUES
('NV001', N'Nguyễn Văn Dũng', N'Nam', '0901234567', N'123 Đường Hoa Bằng, Phường Yên Hòa, Quận Cầu Giấy, Hà Nội, Việt Nam', '1985-01-01', N'Quản lý'),
('NV002', N'Trần Thị Mai', N'Nữ', '0912345678', N'456 Đường Nguyễn Trãi, Quận Thanh Xuân, Hà Nội, Việt Nam', '1986-02-01', N'Nhân viên'),
('NV003', N'Lê Hoàng Phúc', N'Nam', '0923456789', N'789 Đường Láng Hạ, Quận Đống Đa, Hà Nội, Việt Nam', '1987-03-01', N'Thu ngân'),
('NV004', N'Phạm Thị Lan', N'Nữ', '0934567890', N'321 Đường Tôn Đức Thắng, Quận Đống Đa, Hà Nội, Việt Nam', '1988-04-01', N'Thu ngân'),
('NV005', N'Hoàng Văn Toàn', N'Nam', '0945678901', N'654 Đường Kim Mã, Quận Ba Đình, Hà Nội, Việt Nam', '1989-05-01', N'Nhân viên'),
('NV006', N'Đặng Thị Hạnh', N'Nữ', '0956789012', N'987 Đường Lê Duẩn, Quận Hai Bà Trưng, Hà Nội, Việt Nam', '1990-06-01', N'Nhân viên'),
('NV007', N'Vũ Hữu Thắng', N'Nam', '0967890123', N'111 Đường Bạch Mai, Quận Hai Bà Trưng, Hà Nội, Việt Nam', '1991-07-01', N'Nhân viên')

-- Tạo bảng Hóa đơn
CREATE TABLE HoaDon (
    maHD VARCHAR(20) PRIMARY KEY,
    maKhachHang VARCHAR(20),
    ngayLapHD DATETIME NOT NULL,
    tongTien DECIMAL(10, 2),
	ghiChu NVARCHAR(1000),
	phuongThucTT VARCHAR(2) CHECK (phuongThucTT IN ('TM', 'CK')) NOT NULL,
    FOREIGN KEY (maKhachHang) REFERENCES KhachHang(maKhachHang)
);

ALTER TABLE HoaDon ADD maNhanVien VARCHAR(20);
ALTER TABLE HoaDon ADD CONSTRAINT fk_HoaDon_NhanVien FOREIGN KEY (maNhanVien) REFERENCES NhanVien(maNhanVien);



-- Tạo bảng Chi tiết đơn hàng
CREATE TABLE ChiTietDonHang (
    maCTHD INT IDENTITY(1,1) PRIMARY KEY,
    maHD VARCHAR(20),
    maSanPham VARCHAR(20),
    soLuong INT,
    giaDonHang DECIMAL(10, 2),
    FOREIGN KEY (maHD) REFERENCES HoaDon(maHD),
    FOREIGN KEY (maSanPham) REFERENCES SanPham(maSanPham)
);

-- Tạo bảng giỏ hàng lưu thông tin hàng hóa tại thời điểm mua hàng
CREATE TABLE GioHang (
    maGioHang INT IDENTITY(1,1) PRIMARY KEY,
    maSP VARCHAR(20),
    tenSP NVARCHAR(100), 
    soLuong INT,
    donGia DECIMAL(10,2),
    thanhTien AS (soLuong * donGia),
    FOREIGN KEY (maSP) REFERENCES SanPham(maSanPham) 
);

-- Trigger update số lượng tồn
CREATE TRIGGER TRG_CapNhatSoLuongTon_KhiXoaKhoiGioHang
ON GioHang
AFTER DELETE
AS
BEGIN
    -- Cập nhật lại số lượng sản phẩm trong bảng SanPham
    UPDATE SanPham
    SET soLuongTon = soLuongTon + d.soLuong
    FROM SanPham s
    INNER JOIN deleted d ON s.maSanPham = d.maSP;
END;

CREATE TRIGGER TRG_CapNhatSoLuongTon_KhiThemVaoGioHang
ON GioHang
AFTER INSERT
AS
BEGIN
    -- Cập nhật lại số lượng tồn trong bảng SanPham
    UPDATE SanPham
    SET soLuongTon = soLuongTon - i.soLuong
    FROM SanPham s
    INNER JOIN inserted i ON s.maSanPham = i.maSP
    WHERE s.soLuongTon >= i.soLuong;
    
    -- Kiểm tra nếu số lượng tồn bị âm thì rollback
    IF EXISTS (SELECT 1 FROM SanPham s INNER JOIN inserted i ON s.maSanPham = i.maSP WHERE s.soLuongTon < 0)
    BEGIN
        RAISERROR ('Số lượng tồn kho không đủ!', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;


-- Tạo bảng nhập hàng
CREATE TABLE NhapHang (
    maNhap VARCHAR(20) PRIMARY KEY,
    maNhaCungCap VARCHAR(20) NOT NULL,  
    maNhanVien VARCHAR(20) NOT NULL, 
    ngayNhap DATETIME DEFAULT GETDATE(), 
    tongTien DECIMAL(18, 2) DEFAULT 0, 
    FOREIGN KEY (maNhaCungCap) REFERENCES NhaCungCap(maNhaCungCap),
    FOREIGN KEY (maNhanVien) REFERENCES NhanVien(maNhanVien)
);

-- Tạo bảng chi tiết nhập hàng
CREATE TABLE ChiTietNhapHang (
    maNhap VARCHAR(20),
    maSanPham VARCHAR(20), 
    soLuong INT, 
    donGia DECIMAL(18, 2),  
    thanhTien AS (soLuong * donGia) PERSISTED,  
    FOREIGN KEY (maNhap) REFERENCES NhapHang(maNhap),
    FOREIGN KEY (maSanPham) REFERENCES SanPham(maSanPham)
);


-- Cập nhật số lượng tồn kho trong bảng SanPham khi có sản phẩm mới nhập
CREATE TRIGGER trg_CapNhatSoLuongSanPham
ON ChiTietNhapHang
AFTER INSERT
AS
BEGIN
    UPDATE SanPham
    SET soLuongTon = soLuongTon + i.soLuong
    FROM SanPham s
    INNER JOIN inserted i ON s.maSanPham = i.maSanPham;
END;

CREATE TRIGGER trg_UpdateTongTien_NhapHang
ON ChiTietNhapHang
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE NhapHang
    SET tongTien = tongTien + (
        SELECT SUM(ct.thanhTien) 
        FROM inserted ct 
        WHERE NhapHang.maNhap = ct.maNhap
    )
    WHERE maNhap IN (SELECT maNhap FROM inserted);
END;





CREATE TABLE Account (
    taiKhoan NVARCHAR(50) PRIMARY KEY,
    matKhau NVARCHAR(50) NOT NULL,
    maNhanVien VARCHAR(20),
    FOREIGN KEY (maNhanVien) REFERENCES NhanVien(maNhanVien)
);





-- Thêm các dữ liệu vào bảng Thể loại
INSERT INTO TheLoai VALUES ('SACH' ,N'Sách');
INSERT INTO TheLoai VALUES ('DCHT' ,N'Dụng cụ học tập');
INSERT INTO TheLoai VALUES ('TRUYEN' ,N'Truyện');
INSERT INTO TheLoai VALUES ('TBCN' ,N'Thiết bị công nghệ');
INSERT INTO TheLoai VALUES ('TCVB' ,N'Tạp chí và Báo');
INSERT INTO TheLoai VALUES ('DCGD' ,N'Đồ chơi giáo dục');


-- Thêm các dữ liệu vào bảng Nhà cung cấp
INSERT INTO NhaCungCap (maNhaCungCap, tenNhaCungCap, diaChi, thanhPho, soDienThoai)
VALUES ('NCC01', N'Công ty cổ phần phát hành Sách TP.HCM', N'123 Đường Sách, Quận 1', N'TP. Hồ Chí Minh', '0123456789');

INSERT INTO NhaCungCap (maNhaCungCap, tenNhaCungCap, diaChi, thanhPho, soDienThoai)
VALUES ('NCC02', N'Công ty Văn Phòng Phẩm Hoa Mai', N'456 Đường Văn Phòng, Quận 2', N'TP. Hà Nội', '0987654321');

INSERT INTO NhaCungCap (maNhaCungCap, tenNhaCungCap, diaChi, thanhPho, soDienThoai)
VALUES ('NCC03', N'Công ty Công Nghệ Tiến Mạnh LMN', N'789 Đường Công Nghệ, Quận 3', N'TP. Đà Nẵng', '0234567890');

INSERT INTO NhaCungCap (maNhaCungCap, tenNhaCungCap, diaChi, thanhPho, soDienThoai)
VALUES ('NCC04', N'Công ty Đồ Chơi Giáo Dục QRS', N'101 Đường Đồ Chơi, Quận 4', N'TP. Hải Phòng', '0345678901');

INSERT INTO NhaCungCap (maNhaCungCap, tenNhaCungCap, diaChi, thanhPho, soDienThoai)
VALUES ('NCC05', N'Công ty Tạp Chí và Báo UVW', N'202 Đường Báo Chí, Quận 5', N'TP. Cần Thơ', '0456789012');


-- Thêm các dữ liệu vào bảng Sản phẩm
-- Thể loại sách
INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, gia, maNhaCungCap)
VALUES 
('SACH123456', N'Harry Potter và Hòn Đá Phù Thủy', 'SACH', 150000.00, 'NCC01'),
('SACH234567', N'Truyện Kiều', 'SACH', 100000.00, 'NCC01'),
('SACH345678', N'Nhà Giả Kim', 'SACH', 120000.00, 'NCC01'),
('SACH456789', N'Thằng Cuội', 'SACH', 80000.00, 'NCC01'),
('SACH567890', N'Bí Mật Của Nicholas Flamel', 'SACH', 170000.00, 'NCC01'),
('SACH678901', N'Công Phá Toán 12', 'SACH', 200000.00, 'NCC01'),
('SACH789012', N'Luyện Đề Văn 12', 'SACH', 180000.00, 'NCC01'),
('SACH890123', N'Bí Mật Thế Giới Thực Vật', 'SACH', 200020.00, 'NCC01'),
('SACH901234', N'Lịch Sử Việt Nam', 'SACH', 200050.00, 'NCC01'),
('SACH012345', N'Tiếng Anh Cho Người Bắt Đầu', 'SACH', 150000.00, 'NCC01'),
('SACH123457', N'Phát Triển Kỹ Năng Tư Duy', 'SACH', 170000.00, 'NCC01'),
('SACH234568', N'Thế Giới Diệu Kỳ', 'SACH', 190000.00, 'NCC01'),
('SACH345679', N'Mạng Lưới Sinh Học', 'SACH', 210000.00, 'NCC01'),
('SACH456780', N'Giải Mã Giấc Mơ', 'SACH', 230000.00, 'NCC01'),
('SACH567891', N'Truy Tìm Vũ Trụ', 'SACH', 240000.00, 'NCC01');

-- Thêm 20 sản phẩm mới thuộc thể loại Sách (SACH) với nhà cung cấp NCC01
INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, gia, maNhaCungCap)
VALUES 
('SACH678902', N'Bí Ẩn Vũ Trụ', 'SACH', 250000.00, 'NCC01'),
('SACH789013', N'Cuộc Cách Mạng Công Nghệ 4.0', 'SACH', 220000.00, 'NCC01'),
('SACH890124', N'Bách Khoa Toàn Thư', 'SACH', 300000.00, 'NCC01'),
('SACH901235', N'Nghệ Thuật Giao Tiếp', 'SACH', 180000.00, 'NCC01'),
('SACH012346', N'Tư Duy Đột Phá', 'SACH', 210000.00, 'NCC01'),
('SACH123458', N'Hành Trình Về Phương Đông', 'SACH', 170000.00, 'NCC01'),
('SACH234569', N'Thế Giới Phẳng', 'SACH', 240000.00, 'NCC01'),
('SACH345680', N'Tâm Lý Học Hành Vi', 'SACH', 230000.00, 'NCC01'),
('SACH456781', N'Văn Học Dân Gian Việt Nam', 'SACH', 160000.00, 'NCC01'),
('SACH567892', N'Kinh Tế Học Cơ Bản', 'SACH', 250000.00, 'NCC01'),
('SACH678903', N'Sức Mạnh Tiềm Thức', 'SACH', 190000.00, 'NCC01'),
('SACH789014', N'Bí Quyết Thành Công', 'SACH', 200000.00, 'NCC01'),
('SACH890125', N'Bách Khoa Trẻ Em', 'SACH', 280000.00, 'NCC01'),
('SACH901236', N'Văn Hóa Và Đời Sống', 'SACH', 150000.00, 'NCC01'),
('SACH012347', N'Giải Mã Con Người', 'SACH', 220000.00, 'NCC01'),
('SACH123459', N'Triết Học Phương Tây', 'SACH', 270000.00, 'NCC01'),
('SACH234570', N'Triết Học Phương Đông', 'SACH', 260000.00, 'NCC01'),
('SACH345681', N'Chiến Lược Kinh Doanh', 'SACH', 290000.00, 'NCC01'),
('SACH456782', N'Chinh Phục Mục Tiêu', 'SACH', 240000.00, 'NCC01'),
('SACH567893', N'Lập Trình Cho Người Mới Bắt Đầu', 'SACH', 180000.00, 'NCC01');




-- Thể loại Dụng cụ học tập
INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, gia, maNhaCungCap)
VALUES 
('DCHT123456', N'Bút Bi Thiên Long', 'DCHT', 5000.00, 'NCC02'),
('DCHT234567', N'Tẩy Gôm', 'DCHT', 2000.00, 'NCC02'),
('DCHT345678', N'Vở Kẻ Ngang', 'DCHT', 10000.00, 'NCC02'),
('DCHT456789', N'Thước Kẻ 30cm', 'DCHT', 3000.00, 'NCC02'),
('DCHT567890', N'Bút Chì 2B', 'DCHT', 4000.00, 'NCC02'),
('DCHT678901', N'Hộp Đựng Bút', 'DCHT', 15000.00, 'NCC02'),
('DCHT789012', N'Bảng Viết', 'DCHT', 25000.00, 'NCC02'),
('DCHT890123', N'Giấy Ghi Chú', 'DCHT', 7000.00, 'NCC02'),
('DCHT901234', N'Compas', 'DCHT', 20000.00, 'NCC02'),
('DCHT012345', N'Keo Dán', 'DCHT', 8000.00, 'NCC02'),
('DCHT112233', N'Túi Đựng Hồ Sơ', 'DCHT', 12000.00, 'NCC02'),
('DCHT223344', N'Bút Dạ Quang', 'DCHT', 6000.00, 'NCC02'),
('DCHT334455', N'Tập Vở Cao Cấp', 'DCHT', 20000.00, 'NCC02'),
('DCHT445566', N'Bảng Tính', 'DCHT', 18000.00, 'NCC02'),
('DCHT556677', N'Bút Gel', 'DCHT', 4000.00, 'NCC02'),
('DCHT667788', N'Keo Dán Giấy', 'DCHT', 7000.50, 'NCC02'),
('DCHT778899', N'Sổ Ghi Chép', 'DCHT', 9000.00, 'NCC02'),
('DCHT889900', N'Hộp Màu Nước', 'DCHT', 30000.00, 'NCC02'),
('DCHT990011', N'Bút Xóa', 'DCHT', 5000.50, 'NCC02'),
('DCHT101112', N'Giấy In A4', 'DCHT', 35000.00, 'NCC02');

-- Thêm 20 sản phẩm mới thuộc thể loại Dụng cụ học tập (DCHT) với nhà cung cấp NCC02
INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, gia, maNhaCungCap)
VALUES 
('DCHT102113', N'Tập Vẽ', 'DCHT', 15000.00, 'NCC02'),
('DCHT103214', N'Mực Viết Máy', 'DCHT', 12000.00, 'NCC02'),
('DCHT104315', N'Bút Lông Kim', 'DCHT', 8000.00, 'NCC02'),
('DCHT105416', N'Thước Đo Độ', 'DCHT', 5000.00, 'NCC02'),
('DCHT106517', N'Bút Sáp Màu', 'DCHT', 25000.00, 'NCC02'),
('DCHT107618', N'Bảng Từ Trắng', 'DCHT', 40000.00, 'NCC02'),
('DCHT108719', N'Giấy Ghi Chép', 'DCHT', 6000.00, 'NCC02'),
('DCHT109820', N'Túi Đựng Bút', 'DCHT', 10000.00, 'NCC02'),
('DCHT110921', N'Bút Dạ Bảng', 'DCHT', 9000.00, 'NCC02'),
('DCHT111022', N'Keo Xịt Dán', 'DCHT', 12000.00, 'NCC02'),
('DCHT112123', N'Sổ Tay Mini', 'DCHT', 7000.00, 'NCC02'),
('DCHT113224', N'Hộp Mực Dấu', 'DCHT', 15000.00, 'NCC02'),
('DCHT114325', N'Giấy Note Dán', 'DCHT', 5000.00, 'NCC02'),
('DCHT115426', N'Bút Bi Đỏ', 'DCHT', 4000.00, 'NCC02'),
('DCHT116527', N'Bút Bi Xanh', 'DCHT', 4000.00, 'NCC02'),
('DCHT117628', N'Bút Lông Bảng', 'DCHT', 10000.00, 'NCC02'),
('DCHT118729', N'Tập Kẻ Ô Ly', 'DCHT', 8000.00, 'NCC02'),
('DCHT119830', N'Hộp Bút Gỗ', 'DCHT', 20000.00, 'NCC02'),
('DCHT120931', N'Bìa Hồ Sơ', 'DCHT', 11000.00, 'NCC02'),
('DCHT121032', N'Giấy Can', 'DCHT', 18000.00, 'NCC02');



-- Thể loại Truyện
INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, gia, maNhaCungCap)
VALUES 
('TRUYEN123456', N'Đôrêmon Tập 1', 'TRUYEN', 25000.00, 'NCC01'),
('TRUYEN234567', N'Thám Tử Lừng Danh Conan Tập 2', 'TRUYEN', 30000.00, 'NCC01'),
('TRUYEN345678', N'Tiểu Đội Anh Hùng Tập 3', 'TRUYEN', 28000.00, 'NCC01'),
('TRUYEN456789', N'Naruto Tập 4', 'TRUYEN', 27000.00, 'NCC01'),
('TRUYEN567890', N'Truyện Tranh Cổ Tích Việt Nam', 'TRUYEN', 40000.00, 'NCC01'),
('TRUYEN678901', N'Tranh Truyện Danh Nhân Thế Giới', 'TRUYEN', 30005.00, 'NCC01'),
('TRUYEN789012', N'Bảy Viên Ngọc Rồng Tập 5', 'TRUYEN', 32000.00, 'NCC01'),
('TRUYEN890123', N'Truyện Tranh Kinh Dị Nhật Bản', 'TRUYEN', 29000.00, 'NCC01'),
('TRUYEN901234', N'Đảo Hải Tặc Tập 6', 'TRUYEN', 30000.00, 'NCC01'),
('TRUYEN012345', N'Truyện Tranh Thiếu Nhi', 'TRUYEN', 20000.00, 'NCC01'),
('TRUYEN112233', N'Truyện Tranh 4 Màu', 'TRUYEN', 22000.00, 'NCC01'),
('TRUYEN223344', N'Truyện Tranh Học Đường', 'TRUYEN', 26000.00, 'NCC01'),
('TRUYEN334455', N'Truyện Tranh Phép Thuật', 'TRUYEN', 35000.00, 'NCC01'),
('TRUYEN445566', N'Truyện Tranh Khoa Học', 'TRUYEN', 33000.00, 'NCC01'),
('TRUYEN556677', N'Truyện Tranh Tình Yêu', 'TRUYEN', 28000.00, 'NCC01'),
('TRUYEN667788', N'Truyện Tranh Giả Tưởng', 'TRUYEN', 31000.00, 'NCC01'),
('TRUYEN778899', N'Truyện Tranh Phiêu Lưu', 'TRUYEN', 27000.00, 'NCC01'),
('TRUYEN889900', N'Truyện Tranh Hài Hước', 'TRUYEN', 29000.00, 'NCC01'),
('TRUYEN990011', N'Truyện Tranh Trinh Thám', 'TRUYEN', 34000.00, 'NCC01'),
('TRUYEN101112', N'Truyện Tranh Siêu Anh Hùng', 'TRUYEN', 30000.00, 'NCC01');

INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, gia, maNhaCungCap)
VALUES 
('TRUYEN102113', N'Truyện Cổ Tích Andersen', 'TRUYEN', 25000.00, 'NCC01'),
('TRUYEN103214', N'One Piece Tập 7', 'TRUYEN', 32000.00, 'NCC01'),
('TRUYEN104315', N'Truyện Ngụ Ngôn Việt Nam', 'TRUYEN', 27000.00, 'NCC01'),
('TRUYEN105416', N'Truyện Ngắn Nguyễn Nhật Ánh', 'TRUYEN', 35000.00, 'NCC01'),
('TRUYEN106517', N'Bảy Viên Ngọc Rồng Tập 6', 'TRUYEN', 34000.00, 'NCC01'),
('TRUYEN107618', N'Truyện Tranh Kinh Dị Phương Tây', 'TRUYEN', 30000.00, 'NCC01'),
('TRUYEN108719', N'Truyện Tranh Đen Trắng', 'TRUYEN', 28000.00, 'NCC01'),
('TRUYEN109820', N'Truyện Thiếu Nhi Nhật Bản', 'TRUYEN', 26000.00, 'NCC01'),
('TRUYEN110921', N'Truyện Tranh Hành Động', 'TRUYEN', 29000.00, 'NCC01'),
('TRUYEN111022', N'Truyện Tranh Tâm Lý Xã Hội', 'TRUYEN', 31000.00, 'NCC01')


-- Thể loại Thiết bị công nghệ
INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, gia, maNhaCungCap)
VALUES 
('TBCN123456', N'Laptop Dell Inspiron', 'TBCN', 1500000.00, 'NCC03'),
('TBCN234567', N'Máy Tính Bảng Apple iPad', 'TBCN', 1200000.00, 'NCC03'),
('TBCN345678', N'Smartphone Samsung Galaxy', 'TBCN', 1000000.00, 'NCC03'),
('TBCN456789', N'Tai Nghe Bluetooth Sony', 'TBCN', 150000.00, 'NCC03'),
('TBCN567890', N'Máy Ảnh Canon EOS', 'TBCN', 900000.00, 'NCC03'),
('TBCN678901', N'Smartwatch Apple Watch', 'TBCN', 500000.00, 'NCC03'),
('TBCN789012', N'Loa Bluetooth JBL', 'TBCN', 200000.00, 'NCC03'),
('TBCN890123', N'Màn Hình LG 24 inch', 'TBCN', 300000.00, 'NCC03'),
('TBCN901234', N'Máy In HP LaserJet', 'TBCN', 250000.00, 'NCC03'),
('TBCN012345', N'Ổ Cứng Di Động Seagate', 'TBCN', 100000.00, 'NCC03'),
('TBCN112233', N'Router WiFi TP-Link', 'TBCN', 80000.00, 'NCC03'),
('TBCN223344', N'Bàn Phím Cơ Razer', 'TBCN', 150000.00, 'NCC03'),
('TBCN334455', N'Chuột Gaming Logitech', 'TBCN', 60000.00, 'NCC03'),
('TBCN445566', N'Sạc Dự Phòng Anker', 'TBCN', 50000.00, 'NCC03'),
('TBCN556677', N'Camera An Ninh Xiaomi', 'TBCN', 70000.00, 'NCC03'),
('TBCN667788', N'Máy Chiếu Epson', 'TBCN', 600000.00, 'NCC03'),
('TBCN778899', N'Tablet Samsung Galaxy Tab', 'TBCN', 800000.00, 'NCC03'),
('TBCN889900', N'Loa Di Động Bose', 'TBCN', 250000.00, 'NCC03'),
('TBCN990011', N'Sạc Nhanh Aukey', 'TBCN', 40000.00, 'NCC03'),
('TBCN101112', N'Tai Nghe Gaming HyperX', 'TBCN', 100000.00, 'NCC03');

-- Thêm 10 sản phẩm mới thuộc thể loại Thiết bị công nghệ (TBCN) với nhà cung cấp NCC03
INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, gia, maNhaCungCap)
VALUES 
('TBCN111213', N'Micro Không Dây Shure', 'TBCN', 200000.00, 'NCC03'),
('TBCN121314', N'Bộ Phát WiFi Mesh Asus', 'TBCN', 300000.00, 'NCC03'),
('TBCN131415', N'Ổ SSD Samsung 1TB', 'TBCN', 400000.00, 'NCC03'),
('TBCN141516', N'Màn Hình Cong Samsung 27 inch', 'TBCN', 700000.00, 'NCC03'),
('TBCN151617', N'Bộ Loa Vi Tính Logitech', 'TBCN', 150000.00, 'NCC03'),
('TBCN161718', N'Webcam Logitech Full HD', 'TBCN', 120000.00, 'NCC03'),
('TBCN171819', N'Bàn Di Chuột RGB Corsair', 'TBCN', 50000.00, 'NCC03'),
('TBCN181920', N'Ổ Cứng Di Động WD 2TB', 'TBCN', 350000.00, 'NCC03'),
('TBCN192021', N'Máy Quét Mã Vạch Honeywell', 'TBCN', 250000.00, 'NCC03'),
('TBCN202122', N'Micro Thu Âm Rode NT1-A', 'TBCN', 450000.00, 'NCC03');



-- Thể loại Tạp chí và báo
INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, gia, maNhaCungCap)
VALUES 
('TCVB123456', N'Tạp Chí Khoa Học Và Đời Sống', 'TCVB', 50000.00, 'NCC05'),
('TCVB234567', N'Tạp Chí National Geographic', 'TCVB', 80000.00, 'NCC05'),
('TCVB345678', N'Báo Tuổi Trẻ', 'TCVB', 12000.00, 'NCC05'),
('TCVB456789', N'Tạp Chí Thế Giới Vi Tính', 'TCVB', 60000.00, 'NCC05'),
('TCVB567890', N'Tạp Chí Thời Trang', 'TCVB', 70000.00, 'NCC05'),
('TCVB678901', N'Báo Người Lao Động', 'TCVB', 10000.00, 'NCC05'),
('TCVB789012', N'Tạp Chí Địa Lý', 'TCVB', 55000.00, 'NCC05'),
('TCVB890123', N'Tạp Chí Lịch Sử', 'TCVB', 65000.00, 'NCC05'),
('TCVB901234', N'Báo Thanh Niên', 'TCVB', 15000.00, 'NCC05'),
('TCVB012345', N'Tạp Chí Kinh Tế Việt Nam', 'TCVB', 45000.00, 'NCC05'),
('TCVB112233', N'Tạp Chí Sức Khỏe', 'TCVB', 40000.00, 'NCC05'),
('TCVB223344', N'Tạp Chí Công Nghệ', 'TCVB', 50000.00, 'NCC05'),
('TCVB334455', N'Báo Phụ Nữ', 'TCVB', 12000.00, 'NCC05'),
('TCVB445566', N'Tạp Chí Giáo Dục', 'TCVB', 60000.00, 'NCC05'),
('TCVB556677', N'Tạp Chí Thể Thao', 'TCVB', 55000.00, 'NCC05'),
('TCVB667788', N'Tạp Chí Văn Học Nghệ Thuật', 'TCVB', 70000.00, 'NCC05'),
('TCVB778899', N'Báo Văn Hóa', 'TCVB', 10000.00, 'NCC05'),
('TCVB889900', N'Tạp Chí Kinh Doanh', 'TCVB', 45000.00, 'NCC05'),
('TCVB990011', N'Tạp Chí Đời Sống Gia Đình', 'TCVB', 35000.00, 'NCC05'),
('TCVB101112', N'Tạp Chí Du Lịch', 'TCVB', 60000.00, 'NCC05');

-- Thêm 10 sản phẩm mới thuộc thể loại Tạp chí và báo (TCVB) với nhà cung cấp NCC05
INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, gia, maNhaCungCap)
VALUES 
('TCVB111213', N'Tạp Chí Doanh Nhân', 'TCVB', 55000.00, 'NCC05'),
('TCVB121314', N'Báo Khoa Học & Công Nghệ', 'TCVB', 18000.00, 'NCC05'),
('TCVB131415', N'Tạp Chí Văn Nghệ Trẻ', 'TCVB', 48000.00, 'NCC05'),
('TCVB141516', N'Báo Nông Nghiệp Việt Nam', 'TCVB', 20000.00, 'NCC05'),
('TCVB151617', N'Tạp Chí Môi Trường & Đô Thị', 'TCVB', 65000.00, 'NCC05'),
('TCVB161718', N'Báo Pháp Luật', 'TCVB', 15000.00, 'NCC05'),
('TCVB171819', N'Tạp Chí Kinh Tế Quốc Tế', 'TCVB', 70000.00, 'NCC05'),
('TCVB181920', N'Tạp Chí Ẩm Thực', 'TCVB', 35000.00, 'NCC05'),
('TCVB192021', N'Báo Tiền Phong', 'TCVB', 14000.00, 'NCC05'),
('TCVB202122', N'Tạp Chí Nghệ Thuật Sân Khấu', 'TCVB', 50000.00, 'NCC05');




-- Thể loại Đồ chơi giáo dục
INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, gia, maNhaCungCap)
VALUES 
('DCGD123456', N'Bộ Đồ Chơi Lắp Ráp Lego', 'DCGD', 300000.00, 'NCC04'),
('DCGD234567', N'Bảng Vẽ Từ Tính', 'DCGD', 200000.00, 'NCC04'),
('DCGD345678', N'Bộ Đồ Chơi Xếp Hình', 'DCGD', 150000.00, 'NCC04'),
('DCGD456789', N'Bộ Đồ Chơi Sáng Tạo', 'DCGD', 250000.00, 'NCC04'),
('DCGD567890', N'Truyện Tranh Tương Tác', 'DCGD', 80000.00, 'NCC04'),
('DCGD678901', N'Bộ Đồ Chơi Thí Nghiệm Khoa Học', 'DCGD', 350000.00, 'NCC04'),
('DCGD789012', N'Bộ Đồ Chơi Dạy Toán', 'DCGD', 120000.00, 'NCC04'),
('DCGD890123', N'Bộ Đồ Chơi Âm Nhạc', 'DCGD', 180000.00, 'NCC04'),
('DCGD901234', N'Bộ Đồ Chơi Làm Vườn', 'DCGD', 160000.00, 'NCC04'),
('DCGD012345', N'Bộ Đồ Chơi Làm Bánh', 'DCGD', 140000.00, 'NCC04'),
('DCGD112233', N'Bộ Đồ Chơi Mô Hình Nhà Cửa', 'DCGD', 210000.00, 'NCC04'),
('DCGD223344', N'Bộ Đồ Chơi Tàu Hỏa', 'DCGD', 260000.00, 'NCC04'),
('DCGD334455', N'Bộ Đồ Chơi Ô Tô Điều Khiển', 'DCGD', 280000.00, 'NCC04'),
('DCGD445566', N'Bộ Đồ Chơi Địa Cầu', 'DCGD', 320000.00, 'NCC04'),
('DCGD556677', N'Bộ Đồ Chơi Dạy Đọc', 'DCGD', 170000.00, 'NCC04'),
('DCGD667788', N'Bộ Đồ Chơi Thú Yêu', 'DCGD', 190000.00, 'NCC04'),
('DCGD778899', N'Bộ Đồ Chơi Robot', 'DCGD', 300000.00, 'NCC04'),
('DCGD889900', N'Bộ Đồ Chơi Thám Hiểm', 'DCGD', 220000.00, 'NCC04'),
('DCGD990011', N'Bộ Đồ Chơi Xếp Gạch', 'DCGD', 130000.00, 'NCC04'),
('DCGD101112', N'Bộ Đồ Chơi Nấu Ăn', 'DCGD', 150000.00, 'NCC04');

-- Thêm 10 sản phẩm mới thuộc thể loại Đồ chơi giáo dục (DCGD) với nhà cung cấp NCC04
INSERT INTO SanPham (maSanPham, tenSanPham, maTheLoai, gia, maNhaCungCap)
VALUES 
('DCGD111213', N'Bộ Đồ Chơi Học Chữ Cái', 'DCGD', 100000.00, 'NCC04'),
('DCGD121314', N'Bộ Đồ Chơi Toán Học', 'DCGD', 120000.00, 'NCC04'),
('DCGD131415', N'Bộ Đồ Chơi Lắp Ghép Cơ Khí', 'DCGD', 250000.00, 'NCC04'),
('DCGD141516', N'Bộ Đồ Chơi Khoa Học Vũ Trụ', 'DCGD', 350000.00, 'NCC04'),
('DCGD151617', N'Bộ Đồ Chơi Tranh Ghép Hình Động Vật', 'DCGD', 180000.00, 'NCC04'),
('DCGD161718', N'Bộ Đồ Chơi Lập Trình Robot', 'DCGD', 400000.00, 'NCC04'),
('DCGD171819', N'Bộ Đồ Chơi Nhạc Cụ Mini', 'DCGD', 160000.00, 'NCC04'),
('DCGD181920', N'Bộ Đồ Chơi Sáng Tạo Nghệ Thuật', 'DCGD', 200000.00, 'NCC04'),
('DCGD192021', N'Bộ Đồ Chơi Định Hình Nghề Nghiệp', 'DCGD', 220000.00, 'NCC04'),
('DCGD202122', N'Bộ Đồ Chơi Kỹ Năng Sống', 'DCGD', 140000.00, 'NCC04');


-- Thêm thông tin khách hàng
INSERT INTO KhachHang (maKhachHang, tenKhachHang, gioiTinh, soDienThoai, diaChi)
VALUES 
('KH001', N'Nguyễn Thị Hà'	 , N'Nữ',  '0971234567', N'Hà Nội'),
('KH002', N'Trần Văn Đức'	 , N'Nam', '0972345678', N'Hồ Chí Minh'),
('KH003', N'Phạm Thị Mai'	 , N'Nữ',  '0973456789', N'Đà Nẵng'),
('KH004', N'Lê Văn Tùng'	 , N'Nam', '0974567890', N'Cần Thơ'),
('KH005', N'Nguyễn Thị Hoa'	 , N'Nữ',  '0975678901', N'Hải Phòng'),
('KH006', N'Võ Văn Tuấn'	 , N'Nam', '0976789012', N'Buôn Ma Thuột'),
('KH007', N'Hoàng Thị Lan'	 , N'Nữ',  '0977890123', N'Nha Trang'),
('KH008', N'Lê Văn Hoàng'	 , N'Nam', '0978901234', N'Huế'),
('KH009', N'Nguyễn Thị Trang', N'Nữ',  '0979012345', N'Hải Dương'),
('KH010', N'Trần Văn Minh'	 , N'Nam', '0970123456', N'Bắc Giang'),
('KH011', N'Phạm Văn Hải'	 , N'Nam', '0971234567', N'Hà Nội'),
('KH012', N'Lê Thị Lan'		 , N'Nữ',  '0972345678', N'Hồ Chí Minh'),
('KH013', N'Nguyễn Văn Đông' , N'Nam', '0973456789', N'Đà Nẵng'),
('KH014', N'Vũ Thị Thanh'	 , N'Nữ',  '0974567890', N'Cần Thơ'),
('KH015', N'Lê Văn Bình'	 , N'Nam', '0975678901', N'Hải Phòng'),
('KH016', N'Nguyễn Thị Nga'	 , N'Nữ',  '0976789012', N'Buôn Ma Thuột'),
('KH017', N'Hoàng Văn Khánh' , N'Nam', '0977890123', N'Nha Trang'),
('KH018', N'Lê Thị Hương'	 , N'Nữ',  '0978901234', N'Huế'),
('KH019', N'Nguyễn Văn Tuấn' , N'Nam', '0979012345', N'Hải Dương'),
('KH020', N'Phạm Thị Lan'	 , N'Nữ',  '0970123456', N'Bắc Giang'),
('KH021', N'Trần Văn Hùng'	 , N'Nam', '0971234567', N'Hà Nội'),
('KH022', N'Nguyễn Thị Loan' , N'Nữ',  '0972345678', N'Hồ Chí Minh'),
('KH023', N'Vũ Văn Đức'		 , N'Nam', '0973456789', N'Đà Nẵng'),
('KH024', N'Phạm Thị Hà'	 , N'Nữ',  '0974567890', N'Cần Thơ'),
('KH025', N'Nguyễn Văn Tâm'	 , N'Nam', '0975678901', N'Hải Phòng'),
('KH026', N'Lê Thị Thùy'	 , N'Nữ',  '0976789012', N'Buôn Ma Thuột'),
('KH027', N'Trần Văn Dũng'	 , N'Nam', '0977890123', N'Nha Trang'),
('KH028', N'Hoàng Thị Ngọc'	 , N'Nữ',  '0978901234', N'Huế'),
('KH029', N'Nguyễn Văn An'	 , N'Nam', '0979012345', N'Hải Dương'),
('KH030', N'Phạm Thị Thu'	 , N'Nữ',  '0970123456', N'Bắc Giang');

CREATE PROCEDURE sp_GetChiTietPhieuNhap
    @maNhap NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        nh.maNhap,
        nh.ngayNhap,
        nv.tenNhanVien,
        ncc.tenNhaCungCap,
        ncc.diaChi,
        ncc.soDienThoai,
        sp.maSanPham,
        sp.tenSanPham,
        ct.soLuong,
        ct.donGia,
        (ct.soLuong * ct.donGia) AS thanhTien,
        nh.tongTien
    FROM NhapHang nh
    JOIN ChiTietNhapHang ct ON nh.maNhap = ct.maNhap
    JOIN SanPham sp ON ct.maSanPham = sp.maSanPham
    JOIN NhaCungCap ncc ON nh.maNhaCungCap = ncc.maNhaCungCap
    JOIN NhanVien nv ON nh.maNhanVien = nv.maNhanVien
    WHERE nh.maNhap = @maNhap;
END;


CREATE PROCEDURE sp_GetChiTietHoaDon
    @maHoaDon NVARCHAR(50)  -- Tham số đầu vào: mã hóa đơn cần lấy dữ liệu
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        hd.maHD,
        hd.ngayLapHD,
        kh.tenKhachHang,
        kh.soDienThoai,
        kh.diaChi,
        hd.tongTien,
        hd.phuongThucTT,
        sp.maSanPham,
        sp.tenSanPham,
        cthd.soLuong,
        cthd.giaDonHang,
        (cthd.soLuong * cthd.giaDonHang) AS thanhTien
    FROM HoaDon hd
    INNER JOIN KhachHang kh ON hd.maKhachHang = kh.maKhachHang
    INNER JOIN ChiTietDonHang cthd ON hd.maHD = cthd.maHD
    INNER JOIN SanPham sp ON cthd.maSanPham = sp.maSanPham
    WHERE hd.maHD = @maHoaDon;
END;

ALTER PROCEDURE sp_GetChiTietHoaDon
    @maHoaDon NVARCHAR(50)  -- Tham số đầu vào: mã hóa đơn cần lấy dữ liệu
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        hd.maHD,
        hd.ngayLapHD,
        kh.tenKhachHang,
        kh.soDienThoai,
        kh.diaChi,
        hd.tongTien,
        hd.phuongThucTT,
        sp.maSanPham,
        sp.tenSanPham,
        cthd.soLuong,
        sp.gia,
        (cthd.soLuong * sp.gia) AS thanhTien
    FROM HoaDon hd
    INNER JOIN KhachHang kh ON hd.maKhachHang = kh.maKhachHang
    INNER JOIN ChiTietDonHang cthd ON hd.maHD = cthd.maHD
    INNER JOIN SanPham sp ON cthd.maSanPham = sp.maSanPham
    WHERE hd.maHD = @maHoaDon;
END;



EXEC sp_GetChiTietHoaDon @maHoaDon = 'HD004';
