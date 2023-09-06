using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc17Aug.Migrations
{
    public partial class ghdj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Log",
                table: "Logger");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Log",
                table: "Logger",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
