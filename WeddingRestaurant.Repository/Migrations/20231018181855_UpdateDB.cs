using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingRestaurant.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "quyen",
                table: "NguoiDung",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quyen",
                table: "NguoiDung");
        }
    }
}
