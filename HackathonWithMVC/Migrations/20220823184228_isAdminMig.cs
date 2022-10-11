using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackathonWithMVC.Migrations
{
    public partial class isAdminMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "users");
        }
    }
}
