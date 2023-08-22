using System.ComponentModel.DataAnnotations;

namespace mvc17Aug.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        public string StudentName { get; set; }

        public string StudentPhone { get; set; }    
    }
}
