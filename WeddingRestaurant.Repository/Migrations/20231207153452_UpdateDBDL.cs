using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingRestaurant.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDBDL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DonGiaDichVu",
                table: "DichVuTinhPhi",
                newName: "GiaTronGoi");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "DichVuUuDai",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "DichVuTinhPhi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DieuKienApDung",
                table: "DichVuTinhPhi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "GiaGiam30",
                table: "DichVuTinhPhi",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GiaLe",
                table: "DichVuTinhPhi",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "DieuKienApDung",
                table: "DichVu",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "GiaGiam30",
                table: "DichVu",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GiaLe",
                table: "DichVu",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "GiaTronGoi",
                table: "DichVu",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DieuKienApDung",
                table: "DichVuTinhPhi");

            migrationBuilder.DropColumn(
                name: "GiaGiam30",
                table: "DichVuTinhPhi");

            migrationBuilder.DropColumn(
                name: "GiaLe",
                table: "DichVuTinhPhi");

            migrationBuilder.DropColumn(
                name: "DieuKienApDung",
                table: "DichVu");

            migrationBuilder.DropColumn(
                name: "GiaGiam30",
                table: "DichVu");

            migrationBuilder.DropColumn(
                name: "GiaLe",
                table: "DichVu");

            migrationBuilder.DropColumn(
                name: "GiaTronGoi",
                table: "DichVu");

            migrationBuilder.RenameColumn(
                name: "GiaTronGoi",
                table: "DichVuTinhPhi",
                newName: "DonGiaDichVu");

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "DichVuUuDai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
                table: "DichVuTinhPhi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MoTa",
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
