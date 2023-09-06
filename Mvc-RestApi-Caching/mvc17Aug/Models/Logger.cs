using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc17Aug.Models
{
    public class Logger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogID { get; set; }
        public DateTime CreatedTime { get; set; }
        [ForeignKey("Users")]
        public int UserID { get; set; }  
        public string LogType { get; set; } 
        public virtual Users User { get; set; } 
    }
}
