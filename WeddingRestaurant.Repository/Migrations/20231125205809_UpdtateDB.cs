using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingRestaurant.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdtateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayLap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongTienPhuThu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongTienThanhToan = table.Column<double>(type: "float", nullable: false),
                    MaTiec = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MaHoaDon);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "LoaiDichVu",
                columns: table => new
                {
                    MaLoaiDichVu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiDichVu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiDichVu", x => x.MaLoaiDichVu);
                });

            migrationBuilder.CreateTable(
                name: "LoaiMonAn",
                columns: table => new
                {
                    MaLoaiMonAn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiMon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiMonAn", x => x.MaLoaiMonAn);
                });

            migrationBuilder.CreateTable(
                name: "LoaiNuoc",
                columns: table => new
                {
                    MaLoaiNuoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiNuoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiNuoc", x => x.MaLoaiNuoc);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MaMenu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenMenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonGiaMenu = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MaMenu);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    userName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayVaoLam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayNghiViec = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNhanVien);
                });

            migrationBuilder.CreateTable(
                name: "Sanh",
                columns: table => new
                {
                    MaSanh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SucChuaToiThieu = table.Column<int>(type: "int", nullable: false),
                    SucChuaToiDa = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanh", x => x.MaSanh);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    IDToken = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.IDToken);
                });

            migrationBuilder.CreateTable(
                name: "PhuThu",
                columns: table => new
                {
                    MaPhuThu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiPhuThu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTaPhuThu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false),
                    MaHoaDon = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuThu", x => x.MaPhuThu);
                    table.ForeignKey(
                        name: "FK_PhuThu_HoaDon_MaHoaDon",
                        column: x => x.MaHoaDon,
                        principalTable: "HoaDon",
                        principalColumn: "MaHoaDon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatTiec",
                columns: table => new
                {
                    MaTiec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoaiHinhTiec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayDatTiec = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayToChuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianToChuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuongBanChinhThuc = table.Column<int>(type: "int", nullable: false),
                    SoLuongBanTang = table.Column<int>(type: "int", nullable: false),
                    SoLuongBanChay = table.Column<int>(type: "int", nullable: false),
                    SoLuongBanDuPhong = table.Column<int>(type: "int", nullable: false),
                    TongBanSetup = table.Column<int>(type: "int", nullable: false),
                    LoaiBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhiDichVu = table.Column<double>(type: "float", nullable: false),
                    TongTienDuKien = table.Column<double>(type: "float", nullable: false),
                    TongTienGiam = table.Column<double>(type: "float", nullable: false),
                    TongTienPhaiTra = table.Column<double>(type: "float", nullable: false),
                    TienCocLan1 = table.Column<double>(type: "float", nullable: false),
                    TienCocLan2 = table.Column<double>(type: "float", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatTiec", x => x.MaTiec);
                    table.ForeignKey(
                        name: "FK_DatTiec_HoaDon_MaTiec",
                        column: x => x.MaTiec,
                        principalTable: "HoaDon",
                        principalColumn: "MaHoaDon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatTiec_KhachHang_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    MaDichVu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDichVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiDichVu = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVu", x => x.MaDichVu);
                    table.ForeignKey(
                        name: "FK_DichVu_LoaiDichVu_MaLoaiDichVu",
                        column: x => x.MaLoaiDichVu,
                        principalTable: "LoaiDichVu",
                        principalColumn: "MaLoaiDichVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonAn",
                columns: table => new
                {
                    MaMonAn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenMonAn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    DVT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaLoaiMonAn = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonAn", x => x.MaMonAn);
                    table.ForeignKey(
                        name: "FK_MonAn_LoaiMonAn_MaLoaiMonAn",
                        column: x => x.MaLoaiMonAn,
                        principalTable: "LoaiMonAn",
                        principalColumn: "MaLoaiMonAn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nuoc",
                columns: table => new
                {
                    MaNuoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNuoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DVT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    MaLoaiNuoc = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nuoc", x => x.MaNuoc);
                    table.ForeignKey(
                        name: "FK_Nuoc_LoaiNuoc_MaLoaiNuoc",
                        column: x => x.MaLoaiNuoc,
                        principalTable: "LoaiNuoc",
                        principalColumn: "MaLoaiNuoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessToken",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrTokenIDToken = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_AccessToken_NguoiDung_userName",
                        column: x => x.userName,
                        principalTable: "NguoiDung",
                        principalColumn: "userName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessToken_Token_StrTokenIDToken",
                        column: x => x.StrTokenIDToken,
                        principalTable: "Token",
                        principalColumn: "IDToken");
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StrTokenIDToken = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JwtID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => new { x.Token, x.userName });
                    table.ForeignKey(
                        name: "FK_RefreshToken_NguoiDung_userName",
                        column: x => x.userName,
                        principalTable: "NguoiDung",
                        principalColumn: "userName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Token_StrTokenIDToken",
                        column: x => x.StrTokenIDToken,
                        principalTable: "Token",
                        principalColumn: "IDToken");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietMenu",
                columns: table => new
                {
                    MaTiec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaMenu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuongMenuCuaTiec = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietMenu", x => new { x.MaTiec, x.MaMenu });
                    table.ForeignKey(
                        name: "FK_ChiTietMenu_DatTiec_MaTiec",
                        column: x => x.MaTiec,
                        principalTable: "DatTiec",
                        principalColumn: "MaTiec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietMenu_Menu_MaMenu",
                        column: x => x.MaMenu,
                        principalTable: "Menu",
                        principalColumn: "MaMenu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichSanhTiec",
                columns: table => new
                {
                    MaTiec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaSanh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NgayDienRa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TienPhuThu = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichSanhTiec", x => new { x.MaTiec, x.MaSanh });
                    table.ForeignKey(
                        name: "FK_LichSanhTiec_DatTiec_MaTiec",
                        column: x => x.MaTiec,
                        principalTable: "DatTiec",
                        principalColumn: "MaTiec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LichSanhTiec_Sanh_MaSanh",
                        column: x => x.MaSanh,
                        principalTable: "Sanh",
                        principalColumn: "MaSanh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVienTrongTiec",
                columns: table => new
                {
                    MaTiec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNhanVien = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVienTrongTiec", x => new { x.MaTiec, x.MaNhanVien });
                    table.ForeignKey(
                        name: "FK_NhanVienTrongTiec_DatTiec_MaTiec",
                        column: x => x.MaTiec,
                        principalTable: "DatTiec",
                        principalColumn: "MaTiec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhanVienTrongTiec_NhanVien_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DichVuTinhPhi",
                columns: table => new
                {
                    MaDichVuTinhPhi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDichVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonGiaDichVu = table.Column<double>(type: "float", nullable: false),
                    DaXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDichVu = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVuTinhPhi", x => x.MaDichVuTinhPhi);
                    table.ForeignKey(
                        name: "FK_DichVuTinhPhi_DichVu_MaDichVu",
                        column: x => x.MaDichVu,
                        principalTable: "DichVu",
                        principalColumn: "MaDichVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DichVuUuDai",
                columns: table => new
                {
                    MaDichVuUuDai = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDichVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DieuKienApDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaXoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDichVu = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVuUuDai", x => x.MaDichVuUuDai);
                    table.ForeignKey(
                        name: "FK_DichVuUuDai_DichVu_MaDichVu",
                        column: x => x.MaDichVu,
                        principalTable: "DichVu",
                        principalColumn: "MaDichVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhuThuMonAn",
                columns: table => new
                {
                    MaPhuThu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaMonAn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhuThuMonAn", x => new { x.MaPhuThu, x.MaMonAn });
                    table.ForeignKey(
                        name: "FK_ChiTietPhuThuMonAn_MonAn_MaMonAn",
                        column: x => x.MaMonAn,
                        principalTable: "MonAn",
                        principalColumn: "MaMonAn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhuThuMonAn_PhuThu_MaPhuThu",
                        column: x => x.MaPhuThu,
                        principalTable: "PhuThu",
                        principalColumn: "MaPhuThu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonAnTrongMenu",
                columns: table => new
                {
                    MaMenu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaMonAn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuongMon = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonAnTrongMenu", x => new { x.MaMenu, x.MaMonAn });
                    table.ForeignKey(
                        name: "FK_MonAnTrongMenu_Menu_MaMenu",
                        column: x => x.MaMenu,
                        principalTable: "Menu",
                        principalColumn: "MaMenu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MonAnTrongMenu_MonAn_MaMonAn",
                        column: x => x.MaMonAn,
                        principalTable: "MonAn",
                        principalColumn: "MaMonAn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietNuocUong",
                columns: table => new
                {
                    MaTiec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNuoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietNuocUong", x => new { x.MaTiec, x.MaNuoc });
                    table.ForeignKey(
                        name: "FK_ChiTietNuocUong_DatTiec_MaTiec",
                        column: x => x.MaTiec,
                        principalTable: "DatTiec",
                        principalColumn: "MaTiec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietNuocUong_Nuoc_MaNuoc",
                        column: x => x.MaNuoc,
                        principalTable: "Nuoc",
                        principalColumn: "MaNuoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhuThuNuoc",
                columns: table => new
                {
                    MaPhuThu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaNuoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    ThanhTien = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhuThuNuoc", x => new { x.MaPhuThu, x.MaNuoc });
                    table.ForeignKey(
                        name: "FK_ChiTietPhuThuNuoc_Nuoc_MaNuoc",
                        column: x => x.MaNuoc,
                        principalTable: "Nuoc",
                        principalColumn: "MaNuoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhuThuNuoc_PhuThu_MaPhuThu",
                        column: x => x.MaPhuThu,
                        principalTable: "PhuThu",
                        principalColumn: "MaPhuThu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDichVuTinhPhi",
                columns: table => new
                {
                    MaTiec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDichVuTinhPhi = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDichVuTinhPhi", x => new { x.MaTiec, x.MaDichVuTinhPhi });
                    table.ForeignKey(
                        name: "FK_ChiTietDichVuTinhPhi_DatTiec_MaTiec",
                        column: x => x.MaTiec,
                        principalTable: "DatTiec",
                        principalColumn: "MaTiec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDichVuTinhPhi_DichVuTinhPhi_MaDichVuTinhPhi",
                        column: x => x.MaDichVuTinhPhi,
                        principalTable: "DichVuTinhPhi",
                        principalColumn: "MaDichVuTinhPhi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhuThuDichVu",
                columns: table => new
                {
                    MaPhuThu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDichVuTinhPhi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhuThuDichVu", x => new { x.MaPhuThu, x.MaDichVuTinhPhi });
                    table.ForeignKey(
                        name: "FK_ChiTietPhuThuDichVu_DichVuTinhPhi_MaDichVuTinhPhi",
                        column: x => x.MaDichVuTinhPhi,
                        principalTable: "DichVuTinhPhi",
                        principalColumn: "MaDichVuTinhPhi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhuThuDichVu_PhuThu_MaPhuThu",
                        column: x => x.MaPhuThu,
                        principalTable: "PhuThu",
                        principalColumn: "MaPhuThu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDichVuUuDai",
                columns: table => new
                {
                    MaTiec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDichVuUuDai = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDichVuUuDai", x => new { x.MaTiec, x.MaDichVuUuDai });
                    table.ForeignKey(
                        name: "FK_ChiTietDichVuUuDai_DatTiec_MaTiec",
                        column: x => x.MaTiec,
                        principalTable: "DatTiec",
                        principalColumn: "MaTiec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDichVuUuDai_DichVuUuDai_MaDichVuUuDai",
                        column: x => x.MaDichVuUuDai,
                        principalTable: "DichVuUuDai",
                        principalColumn: "MaDichVuUuDai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_StrTokenIDToken",
                table: "AccessToken",
                column: "StrTokenIDToken");

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_userName",
                table: "AccessToken",
                column: "userName");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDichVuTinhPhi_MaDichVuTinhPhi",
                table: "ChiTietDichVuTinhPhi",
                column: "MaDichVuTinhPhi");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDichVuUuDai_MaDichVuUuDai",
                table: "ChiTietDichVuUuDai",
                column: "MaDichVuUuDai");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMenu_MaMenu",
                table: "ChiTietMenu",
                column: "MaMenu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNuocUong_MaNuoc",
                table: "ChiTietNuocUong",
                column: "MaNuoc");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhuThuDichVu_MaDichVuTinhPhi",
                table: "ChiTietPhuThuDichVu",
                column: "MaDichVuTinhPhi");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhuThuMonAn_MaMonAn",
                table: "ChiTietPhuThuMonAn",
                column: "MaMonAn");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhuThuNuoc_MaNuoc",
                table: "ChiTietPhuThuNuoc",
                column: "MaNuoc");

            migrationBuilder.CreateIndex(
                name: "IX_DatTiec_MaKhachHang",
                table: "DatTiec",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DichVu_MaLoaiDichVu",
                table: "DichVu",
                column: "MaLoaiDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_DichVuTinhPhi_MaDichVu",
                table: "DichVuTinhPhi",
                column: "MaDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_DichVuUuDai_MaDichVu",
                table: "DichVuUuDai",
                column: "MaDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_LichSanhTiec_MaSanh",
                table: "LichSanhTiec",
                column: "MaSanh");

            migrationBuilder.CreateIndex(
                name: "IX_MonAn_MaLoaiMonAn",
                table: "MonAn",
                column: "MaLoaiMonAn");

            migrationBuilder.CreateIndex(
                name: "IX_MonAnTrongMenu_MaMonAn",
                table: "MonAnTrongMenu",
                column: "MaMonAn");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVienTrongTiec_MaNhanVien",
                table: "NhanVienTrongTiec",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_Nuoc_MaLoaiNuoc",
                table: "Nuoc",
                column: "MaLoaiNuoc");

            migrationBuilder.CreateIndex(
                name: "IX_PhuThu_MaHoaDon",
                table: "PhuThu",
                column: "MaHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_StrTokenIDToken",
                table: "RefreshToken",
                column: "StrTokenIDToken");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_userName",
                table: "RefreshToken",
                column: "userName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessToken");

            migrationBuilder.DropTable(
                name: "ChiTietDichVuTinhPhi");

            migrationBuilder.DropTable(
                name: "ChiTietDichVuUuDai");

            migrationBuilder.DropTable(
                name: "ChiTietMenu");

            migrationBuilder.DropTable(
                name: "ChiTietNuocUong");

            migrationBuilder.DropTable(
                name: "ChiTietPhuThuDichVu");

            migrationBuilder.DropTable(
                name: "ChiTietPhuThuMonAn");

            migrationBuilder.DropTable(
                name: "ChiTietPhuThuNuoc");

            migrationBuilder.DropTable(
                name: "LichSanhTiec");

            migrationBuilder.DropTable(
                name: "MonAnTrongMenu");

            migrationBuilder.DropTable(
                name: "NhanVienTrongTiec");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "DichVuUuDai");

            migrationBuilder.DropTable(
                name: "DichVuTinhPhi");

            migrationBuilder.DropTable(
                name: "Nuoc");

            migrationBuilder.DropTable(
                name: "PhuThu");

            migrationBuilder.DropTable(
                name: "Sanh");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "MonAn");

            migrationBuilder.DropTable(
                name: "DatTiec");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "LoaiNuoc");

            migrationBuilder.DropTable(
                name: "LoaiMonAn");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "LoaiDichVu");
        }
    }
}
