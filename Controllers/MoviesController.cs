using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptixTechnicalTest.Data;
using OptixTechnicalTest.Data.Models;
using PagedList;

namespace OptixTechnicalTest.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MoviesContext _context;

        public MoviesController(MoviesContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        [Route("MoviesByName")]
        public List<Movie> GetMovies(
            [FromQuery] string nameSearch,
            [FromQuery] string? genre,
            [FromQuery] int? page,
            [FromQuery] int? pageSize,
            [FromQuery] bool sortByTitle,
            [FromQuery] bool sortByRelease)
        {
            var result = new List<Movie>();
            if (string.IsNullOrEmpty(nameSearch))
            {
                 result = this._context.Movies.ToList();
            }
            else
            {
                var searchString = $"%{string.Join("%", nameSearch.Split(" "))}%";
                result = this._context.Movies.Where(x =>
                EF.Functions.Like(x.Title, searchString) && (string.IsNullOrEmpty(genre) || x.Genre.ToLower().Contains(genre.ToLower()))).ToList();
            }
            
            if (sortByTitle)
            {
                result = result.OrderBy(x => x.Title).ToList();
            }
            else if (sortByRelease)
            {
                result = result.OrderBy(x => x.ReleaseDate).ToList();
            }

            return result.ToPagedList(page ?? 1, pageSize ?? 30).ToList();
        }

        [HttpGet]
        [Route("GetGenres")]
        public List<string> GetGenres()
        {
            return new List<string>()
            {
                  "Action",
                  "Adventure",
                  "Animation",
                  "Comedy",
                  "Crime",
                  "Documentary",
                  "Drama",
                  "Family",
                  "Fantasy",
                  "History",
                  "Horror",
                  "Music",
                  "Mystery",
                  "Romance",
                  "Science Fiction",
                  "Thriller",
                  "TV Movie",
                  "War",
                  "Western",
            };
        }
    }
}
