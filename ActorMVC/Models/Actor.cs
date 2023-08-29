using System;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
	public class Actor
	{
		[Key]
		public int ActorID { get; set; }
		[Display(Name ="Profile Picture URL")]
		public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }

		public List<Movie> Movies { get; set; }
		public List<ActorMovie> ActorMovies { get; set; }
	}
}

