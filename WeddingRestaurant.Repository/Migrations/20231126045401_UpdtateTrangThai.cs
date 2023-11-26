using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingRestaurant.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdtateTrangThai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DaXoa",
                table: "DichVuUuDai",
                newName: "TrangThai");

            migrationBuilder.RenameColumn(
                name: "DaXoa",
                table: "DichVuTinhPhi",
                newName: "TrangThai");

            migrationBuilder.RenameColumn(
                name: "DaXoa",
                table: "DichVu",
                newName: "TrangThai");

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "Token",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "Sanh",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "RefreshToken",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "PhuThu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "Nuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "NhanVienTrongTiec",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "NhanVien",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "NguoiDung",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "MonAnTrongMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "MonAn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "Menu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "LoaiNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "LoaiMonAn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "LoaiDichVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "LichSanhTiec",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TongTienThanhToan",
                table: "HoaDon",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "HoaDon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "DatTiec",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ChiTietPhuThuNuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ChiTietPhuThuMonAn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ChiTietPhuThuDichVu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ChiTietNuocUong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ChiTietMenu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ChiTietDichVuUuDai",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "ChiTietDichVuTinhPhi",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrangThai",
                table: "AccessToken",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "Token");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "RefreshToken");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "PhuThu");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "Nuoc");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "NhanVienTrongTiec");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "NhanVien");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "NguoiDung");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "MonAnTrongMenu");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "MonAn");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "LoaiNuoc");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "LoaiMonAn");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "LoaiDichVu");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "KhachHang");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "HoaDon");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietPhuThuNuoc");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietPhuThuMonAn");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietPhuThuDichVu");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietNuocUong");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietMenu");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietDichVuUuDai");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "ChiTietDichVuTinhPhi");

            migrationBuilder.DropColumn(
                name: "TrangThai",
                table: "AccessToken");

            migrationBuilder.RenameColumn(
                name: "TrangThai",
                table: "DichVuUuDai",
                newName: "DaXoa");

            migrationBuilder.RenameColumn(
                name: "TrangThai",
                table: "DichVuTinhPhi",
                newName: "DaXoa");

            migrationBuilder.RenameColumn(
                name: "TrangThai",
                table: "DichVu",
                newName: "DaXoa");

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "Sanh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "LichSanhTiec",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TongTienThanhToan",
                table: "HoaDon",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "DatTiec",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
