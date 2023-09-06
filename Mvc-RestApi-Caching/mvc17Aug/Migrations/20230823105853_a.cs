using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc17Aug.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logger_Users_UserID1",
                table: "Logger");

            migrationBuilder.DropIndex(
                name: "IX_Logger_UserID1",
                table: "Logger");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Logger");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Logger",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Logger_UserID",
                table: "Logger",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Logger_Users_UserID",
                table: "Logger",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logger_Users_UserID",
                table: "Logger");

            migrationBuilder.DropIndex(
                name: "IX_Logger_UserID",
                table: "Logger");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Logger",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "Logger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Logger_UserID1",
                table: "Logger",
                column: "UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Logger_Users_UserID1",
                table: "Logger",
                column: "UserID1",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
