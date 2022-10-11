using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonWithMVC.Migrations
{
    public partial class addCartcols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBilled",
                table: "carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "IsBilled",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "carts");
        }
    }
}
