using System;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
	public class Producer
	{
        [Key]
		public int ProducerID { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
    }
}

