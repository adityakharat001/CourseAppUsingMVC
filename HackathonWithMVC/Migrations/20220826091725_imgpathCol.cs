using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonWithMVC.Migrations
{
    public partial class imgpathCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "courses");
        }
    }
}
