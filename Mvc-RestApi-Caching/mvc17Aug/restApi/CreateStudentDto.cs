using System.ComponentModel.DataAnnotations;

namespace restApi
{
    public class CreateStudentDto
    {
        public string StudentName { get; set; }
        public string StudentPhone { get; set; }
    }
}
