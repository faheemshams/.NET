using System;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.Models
{
	public class Actor
	{
		[Key]
		public int ActorID { get; set; }
		public string ProfilePictureURL { get; set; }
		public string FullName { get; set; }
		public string Bio { get; set; }

		public List<ActorMovie> ActorMovies { get; set; }
	}
}

