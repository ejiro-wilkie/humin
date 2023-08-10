using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Humin_Man.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryEntity1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Categories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
