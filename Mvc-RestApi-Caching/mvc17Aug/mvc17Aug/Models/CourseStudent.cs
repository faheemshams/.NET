using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc17Aug.Models
{
    public class CourseStudent
    {
        [Key]
        public int CourseStudentID { get; set; }
        [ForeignKey("Student")] 
        public int StudentID { get; set; }
        [ForeignKey("Course")]
        public int CourseID { get; set; }   
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
