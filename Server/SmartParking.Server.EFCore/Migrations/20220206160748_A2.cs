using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartParking.Server.EFCore.Migrations
{
    public partial class A2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserIcon",
                table: "SysUserInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIcon",
                table: "SysUserInfo");
        }
    }
}
