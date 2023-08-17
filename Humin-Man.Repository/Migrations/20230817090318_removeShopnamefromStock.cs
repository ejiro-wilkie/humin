using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Humin_Man.Repository.Migrations
{
    /// <inheritdoc />
    public partial class removeShopnamefromStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stocks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
