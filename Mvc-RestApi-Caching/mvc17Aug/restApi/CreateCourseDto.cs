using System.ComponentModel.DataAnnotations;

namespace restApi
{
    public class CreateCourseDto
    {
        public string? CourseName { get; set; }
        public int CourseCredit { get; set; }
        public string? CourseDescription { get; set; }
    }
}
