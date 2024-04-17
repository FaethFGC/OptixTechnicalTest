using System;
using System.Collections.Generic;

namespace OptixTechnicalTest.Data.Models
{
    public partial class Movie
    {
        public string ReleaseDate { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public double Popularity { get; set; }
        public long VoteCount { get; set; }
        public double VoteAverage { get; set; }
        public string OriginalLanguage { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
    }
}
