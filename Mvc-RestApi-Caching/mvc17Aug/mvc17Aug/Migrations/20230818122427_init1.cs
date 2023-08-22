using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc17Aug.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "studentPhone",
                table: "Students",
                newName: "StudentPhone");

            migrationBuilder.RenameColumn(
                name: "CourseSrudentID",
                table: "CourseStudents",
                newName: "CourseStudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentPhone",
                table: "Students",
                newName: "studentPhone");

            migrationBuilder.RenameColumn(
                name: "CourseStudentID",
                table: "CourseStudents",
                newName: "CourseSrudentID");
        }
    }
}
