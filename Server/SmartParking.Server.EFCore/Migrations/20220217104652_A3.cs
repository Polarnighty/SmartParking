using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartParking.Server.EFCore.Migrations
{
    public partial class A3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SysUserInfo",
                newName: "UserId");

            migrationBuilder.CreateTable(
                name: "MenuInfo",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetView = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    MenuIcon = table.Column<string>(type: "nvarchar(4)", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    MenuType = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuInfo", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "RoleInfo",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleInfo", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "MenuInfoRoleInfo",
                columns: table => new
                {
                    MenuInfosMenuId = table.Column<int>(type: "int", nullable: false),
                    RoleInfosRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuInfoRoleInfo", x => new { x.MenuInfosMenuId, x.RoleInfosRoleId });
                    table.ForeignKey(
                        name: "FK_MenuInfoRoleInfo_MenuInfo_MenuInfosMenuId",
                        column: x => x.MenuInfosMenuId,
                        principalTable: "MenuInfo",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuInfoRoleInfo_RoleInfo_RoleInfosRoleId",
                        column: x => x.RoleInfosRoleId,
                        principalTable: "RoleInfo",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleInfoSysUserInfo",
                columns: table => new
                {
                    RoleInfosRoleId = table.Column<int>(type: "int", nullable: false),
                    UserInfosUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleInfoSysUserInfo", x => new { x.RoleInfosRoleId, x.UserInfosUserId });
                    table.ForeignKey(
                        name: "FK_RoleInfoSysUserInfo_RoleInfo_RoleInfosRoleId",
                        column: x => x.RoleInfosRoleId,
                        principalTable: "RoleInfo",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleInfoSysUserInfo_SysUserInfo_UserInfosUserId",
                        column: x => x.UserInfosUserId,
                        principalTable: "SysUserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuInfoRoleInfo_RoleInfosRoleId",
                table: "MenuInfoRoleInfo",
                column: "RoleInfosRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleInfoSysUserInfo_UserInfosUserId",
                table: "RoleInfoSysUserInfo",
                column: "UserInfosUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuInfoRoleInfo");

            migrationBuilder.DropTable(
                name: "RoleInfoSysUserInfo");

            migrationBuilder.DropTable(
                name: "MenuInfo");

            migrationBuilder.DropTable(
                name: "RoleInfo");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SysUserInfo",
                newName: "Id");
        }
    }
}
