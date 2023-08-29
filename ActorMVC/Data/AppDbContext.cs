using System;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;

namespace MvcApp.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many-many relationship
            modelBuilder.Entity<ActorMovie>().HasKey(am => new
            {
                am.ActorID,
                am.MovieID
            });

            modelBuilder.Entity<ActorMovie>().HasOne(m => m.Movie).WithMany(am => am.ActorMovies).HasForeignKey(m => m.MovieID);
            modelBuilder.Entity<ActorMovie>().HasOne(a => a.Actor).WithMany(am => am.ActorMovies).HasForeignKey(a => a.ActorID);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
    }
}

