using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcProject.Migrations
{
    /// <inheritdoc />
    public partial class changeCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "NumOfBooks",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumOfBooks",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "DisplayOrder",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
