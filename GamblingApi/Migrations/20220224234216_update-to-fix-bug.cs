using Microsoft.EntityFrameworkCore.Migrations;

namespace GamblingApi.Migrations
{
    public partial class updatetofixbug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Userss");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userss",
                table: "Userss",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Userss_UserId",
                table: "Accounts",
                column: "UserId",
                principalTable: "Userss",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Userss_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Userss",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Userss_UserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Userss_UserId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Userss",
                table: "Userss");

            migrationBuilder.RenameTable(
                name: "Userss",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Users_UserId",
                table: "Accounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
