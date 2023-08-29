using System.ComponentModel.DataAnnotations;

namespace mvc17Aug.Models
{
    public class Users
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
