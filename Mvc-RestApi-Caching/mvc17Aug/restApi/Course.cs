using System.ComponentModel.DataAnnotations;

namespace restApi
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Required]
        public string CourseName { get; set; }
        public int CourseCredit { get; set; }
        public string? CourseDescription { get; set; }
    }
}
