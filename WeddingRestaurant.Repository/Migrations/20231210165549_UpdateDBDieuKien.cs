using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingRestaurant.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBDieuKien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DieuKienApDung",
                table: "DichVuUuDai",
                newName: "DieuKienBanToiThieu");

            migrationBuilder.RenameColumn(
                name: "DieuKienApDung",
                table: "DichVuTinhPhi",
                newName: "DieuKienBanToiThieu");

            migrationBuilder.RenameColumn(
                name: "DieuKienApDung",
                table: "DichVu",
                newName: "DieuKienBanToiThieu");

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "DichVuUuDai",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DieuKienBanToiDa",
                table: "DichVuUuDai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "DichVuTinhPhi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DieuKienBanToiDa",
                table: "DichVuTinhPhi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DieuKienBanToiDa",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DieuKienBanToiDa",
                table: "DichVuUuDai");

            migrationBuilder.DropColumn(
                name: "DieuKienBanToiDa",
                table: "DichVuTinhPhi");

            migrationBuilder.DropColumn(
                name: "DieuKienBanToiDa",
                table: "DichVu");

            migrationBuilder.RenameColumn(
                name: "DieuKienBanToiThieu",
                table: "DichVuUuDai",
                newName: "DieuKienApDung");

            migrationBuilder.RenameColumn(
                name: "DieuKienBanToiThieu",
                table: "DichVuTinhPhi",
                newName: "DieuKienApDung");

            migrationBuilder.RenameColumn(
                name: "DieuKienBanToiThieu",
                table: "DichVu",
                newName: "DieuKienApDung");

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "DichVuUuDai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "DichVuTinhPhi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
