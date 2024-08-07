using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Footwear.Persistance.Migrations
{
    public partial class appuser_modelcreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_AppRole_AppRoleId",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_AppRoleId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "AppRoleId",
                table: "AppUser");

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_RoleId",
                table: "AppUser",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_AppRole_RoleId",
                table: "AppUser",
                column: "RoleId",
                principalTable: "AppRole",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_AppRole_RoleId",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_RoleId",
                table: "AppUser");

            migrationBuilder.AddColumn<int>(
                name: "AppRoleId",
                table: "AppUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_AppRoleId",
                table: "AppUser",
                column: "AppRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_AppRole_AppRoleId",
                table: "AppUser",
                column: "AppRoleId",
                principalTable: "AppRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
