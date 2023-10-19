using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingRestaurant.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatTiec_KhachHang_KhachHangsMaKhachHang",
                table: "DatTiec");

            migrationBuilder.AlterColumn<string>(
                name: "KhachHangsMaKhachHang",
                table: "DatTiec",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_DatTiec_KhachHang_KhachHangsMaKhachHang",
                table: "DatTiec",
                column: "KhachHangsMaKhachHang",
                principalTable: "KhachHang",
                principalColumn: "MaKhachHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatTiec_KhachHang_KhachHangsMaKhachHang",
                table: "DatTiec");

            migrationBuilder.AlterColumn<string>(
                name: "KhachHangsMaKhachHang",
                table: "DatTiec",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DatTiec_KhachHang_KhachHangsMaKhachHang",
                table: "DatTiec",
                column: "KhachHangsMaKhachHang",
                principalTable: "KhachHang",
                principalColumn: "MaKhachHang",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
