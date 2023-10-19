using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingRestaurant.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    MaDichVu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenDichVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonGiaDichVu = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVu", x => x.MaDichVu);
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
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    MaKM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DieuKien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaTri = table.Column<double>(type: "float", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.MaKM);
                });

            migrationBuilder.CreateTable(
                name: "LoaiMonAn",
                columns: table => new
                {
                    MaLoaiMon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiMon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiMonAn", x => x.MaLoaiMon);
                });

            migrationBuilder.CreateTable(
                name: "LoaiNuoc",
                columns: table => new
                {
                    MaLoaiNuoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenLoaiNuoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                    DonGiaMenu = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                    hoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "Sanh",
                columns: table => new
                {
                    MaSanh = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenSanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SucChucToiThieu = table.Column<int>(type: "int", nullable: false),
                    SucChucToiDa = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanh", x => x.MaSanh);
                });

            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatTiec",
                columns: table => new
                {
                    MaTiec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenTiec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoBan = table.Column<int>(type: "int", nullable: false),
                    PhiDichVu = table.Column<double>(type: "float", nullable: false),
                    NgayDatTiec = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NgayToChuc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KhachHangsMaKhachHang = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatTiec", x => x.MaTiec);
                    table.ForeignKey(
                        name: "FK_DatTiec_KhachHang_KhachHangsMaKhachHang",
                        column: x => x.KhachHangsMaKhachHang,
                        principalTable: "KhachHang",
                        principalColumn: "MaKhachHang",
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
                    MaLoaiMon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiMonAnsMaLoaiMon = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonAn", x => x.MaMonAn);
                    table.ForeignKey(
                        name: "FK_MonAn_LoaiMonAn_LoaiMonAnsMaLoaiMon",
                        column: x => x.LoaiMonAnsMaLoaiMon,
                        principalTable: "LoaiMonAn",
                        principalColumn: "MaLoaiMon");
                });

            migrationBuilder.CreateTable(
                name: "Nuoc",
                columns: table => new
                {
                    MaNuoc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenNuoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    DVT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaLoaiNuoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiNuocsMaLoaiNuoc = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nuoc", x => x.MaNuoc);
                    table.ForeignKey(
                        name: "FK_Nuoc_LoaiNuoc_LoaiNuocsMaLoaiNuoc",
                        column: x => x.LoaiNuocsMaLoaiNuoc,
                        principalTable: "LoaiNuoc",
                        principalColumn: "MaLoaiNuoc");
                });

            migrationBuilder.CreateTable(
                name: "AccessToken",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrTokenId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessToken_NguoiDung_userName",
                        column: x => x.userName,
                        principalTable: "NguoiDung",
                        principalColumn: "userName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessToken_Token_StrTokenId",
                        column: x => x.StrTokenId,
                        principalTable: "Token",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrTokenId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JwtID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    ExpireAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_NguoiDung_userName",
                        column: x => x.userName,
                        principalTable: "NguoiDung",
                        principalColumn: "userName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Token_StrTokenId",
                        column: x => x.StrTokenId,
                        principalTable: "Token",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDichVu",
                columns: table => new
                {
                    MaTiec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaDichVu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDichVu", x => new { x.MaTiec, x.MaDichVu });
                    table.ForeignKey(
                        name: "FK_ChiTietDichVu_DatTiec_MaTiec",
                        column: x => x.MaTiec,
                        principalTable: "DatTiec",
                        principalColumn: "MaTiec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDichVu_DichVu_MaDichVu",
                        column: x => x.MaDichVu,
                        principalTable: "DichVu",
                        principalColumn: "MaDichVu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietMenu",
                columns: table => new
                {
                    MaTiec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaMenu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuongMenuBan = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                    NgayToChuc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Ca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                name: "SuDungKhuyenMai",
                columns: table => new
                {
                    MaTiec = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaKM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuDungKhuyenMai", x => new { x.MaTiec, x.MaKM });
                    table.ForeignKey(
                        name: "FK_SuDungKhuyenMai_DatTiec_MaTiec",
                        column: x => x.MaTiec,
                        principalTable: "DatTiec",
                        principalColumn: "MaTiec",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuDungKhuyenMai_KhuyenMai_MaKM",
                        column: x => x.MaKM,
                        principalTable: "KhuyenMai",
                        principalColumn: "MaKM",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonAnTrongMenu",
                columns: table => new
                {
                    MaMenu = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaMonAn = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SoLuongMon = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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
                    TongTien = table.Column<double>(type: "float", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_StrTokenId",
                table: "AccessToken",
                column: "StrTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessToken_userName",
                table: "AccessToken",
                column: "userName");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDichVu_MaDichVu",
                table: "ChiTietDichVu",
                column: "MaDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietMenu_MaMenu",
                table: "ChiTietMenu",
                column: "MaMenu");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNuocUong_MaNuoc",
                table: "ChiTietNuocUong",
                column: "MaNuoc");

            migrationBuilder.CreateIndex(
                name: "IX_DatTiec_KhachHangsMaKhachHang",
                table: "DatTiec",
                column: "KhachHangsMaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_LichSanhTiec_MaSanh",
                table: "LichSanhTiec",
                column: "MaSanh");

            migrationBuilder.CreateIndex(
                name: "IX_MonAn_LoaiMonAnsMaLoaiMon",
                table: "MonAn",
                column: "LoaiMonAnsMaLoaiMon");

            migrationBuilder.CreateIndex(
                name: "IX_MonAnTrongMenu_MaMonAn",
                table: "MonAnTrongMenu",
                column: "MaMonAn");

            migrationBuilder.CreateIndex(
                name: "IX_Nuoc_LoaiNuocsMaLoaiNuoc",
                table: "Nuoc",
                column: "LoaiNuocsMaLoaiNuoc");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_StrTokenId",
                table: "RefreshToken",
                column: "StrTokenId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_userName",
                table: "RefreshToken",
                column: "userName");

            migrationBuilder.CreateIndex(
                name: "IX_SuDungKhuyenMai_MaKM",
                table: "SuDungKhuyenMai",
                column: "MaKM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessToken");

            migrationBuilder.DropTable(
                name: "ChiTietDichVu");

            migrationBuilder.DropTable(
                name: "ChiTietMenu");

            migrationBuilder.DropTable(
                name: "ChiTietNuocUong");

            migrationBuilder.DropTable(
                name: "LichSanhTiec");

            migrationBuilder.DropTable(
                name: "MonAnTrongMenu");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "SuDungKhuyenMai");

            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "Nuoc");

            migrationBuilder.DropTable(
                name: "Sanh");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "MonAn");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "Token");

            migrationBuilder.DropTable(
                name: "DatTiec");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "LoaiNuoc");

            migrationBuilder.DropTable(
                name: "LoaiMonAn");

            migrationBuilder.DropTable(
                name: "KhachHang");
        }
    }
}
