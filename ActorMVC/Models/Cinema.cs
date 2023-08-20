using System;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
	public class Cinema
	{
        [Key]
        public int CinemaID { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

