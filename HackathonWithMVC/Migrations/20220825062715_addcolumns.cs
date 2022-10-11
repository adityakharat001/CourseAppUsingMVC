using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonWithMVC.Migrations
{
    public partial class addcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "users");

            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "users");
        }
    }
}
