﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcApp.Data;

#nullable disable

namespace MvcApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MvcApp.Models.Actor", b =>
                {
                    b.Property<int>("ActorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActorID"), 1L, 1);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorID");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("MvcApp.Models.ActorMovie", b =>
                {
                    b.Property<int>("ActorID")
                        .HasColumnType("int");

                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.HasKey("ActorID", "MovieID");

                    b.HasIndex("MovieID");

                    b.ToTable("ActorMovies");
                });

            modelBuilder.Entity("MvcApp.Models.Cinema", b =>
                {
                    b.Property<int>("CinemaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CinemaID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CinemaID");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("MvcApp.Models.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieID"), 1L, 1);

                    b.Property<int?>("ActorID")
                        .HasColumnType("int");

                    b.Property<int>("CinemaID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieCategory")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProducerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MovieID");

                    b.HasIndex("ActorID");

                    b.HasIndex("CinemaID");

                    b.HasIndex("ProducerID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MvcApp.Models.Producer", b =>
                {
                    b.Property<int>("ProducerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProducerID"), 1L, 1);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePictureURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProducerID");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("MvcApp.Models.ActorMovie", b =>
                {
                    b.HasOne("MvcApp.Models.Actor", "Actor")
                        .WithMany("ActorMovies")
                        .HasForeignKey("ActorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcApp.Models.Movie", "Movie")
                        .WithMany("ActorMovies")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("MvcApp.Models.Movie", b =>
                {
                    b.HasOne("MvcApp.Models.Actor", null)
                        .WithMany("Movies")
                        .HasForeignKey("ActorID");

                    b.HasOne("MvcApp.Models.Cinema", "Cinema")
                        .WithMany("Movies")
                        .HasForeignKey("CinemaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MvcApp.Models.Producer", "Producer")
                        .WithMany("Movies")
                        .HasForeignKey("ProducerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("MvcApp.Models.Actor", b =>
                {
                    b.Navigation("ActorMovies");

                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MvcApp.Models.Cinema", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("MvcApp.Models.Movie", b =>
                {
                    b.Navigation("ActorMovies");
                });

            modelBuilder.Entity("MvcApp.Models.Producer", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
