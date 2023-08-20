using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcApp.Models
{
	public class ActorMovie
	{
		[ForeignKey("Actor")]
		public int ActorID;
		[ForeignKey("Movie")]
		public int MovieID;

		public virtual Movie Movie { get; set; }
		public virtual Actor Actor { get; set; }
	}
}

