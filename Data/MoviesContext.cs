using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OptixTechnicalTest.Data.Models;

namespace OptixTechnicalTest.Data
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext()
        {
        }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movies");

                entity.Property(e => e.OriginalLanguage).HasColumnName("Original_Language");

                entity.Property(e => e.PosterUrl).HasColumnName("Poster_Url");

                entity.Property(e => e.ReleaseDate).HasColumnName("Release_Date");

                entity.Property(e => e.VoteAverage).HasColumnName("Vote_Average");

                entity.Property(e => e.VoteCount).HasColumnName("Vote_Count");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
