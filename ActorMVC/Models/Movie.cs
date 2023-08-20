using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcApp.Data;

namespace MvcApp.Models
{
	public class Movie
	{
        [Key]
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        public List<ActorMovie> ActorMovies { get; set; }
        [ForeignKey("Cinema")]
        public int CinemaID { get; set; }
        public virtual Cinema Cinema { get; set; }
        [ForeignKey("Producer")]
        public int ProducerID { get; set; }
        public virtual Producer Producer { get; set; }
    }
}

