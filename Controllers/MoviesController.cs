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
        public List<Movie> GetMovies([FromQuery] string nameSearch, [FromQuery] string? genre, [FromQuery] int? page, [FromQuery] int? pageSize)
        {
            var searchString = $"%{string.Join("%", nameSearch.Split(" "))}%";
            var result = this._context.Movies.Where(x => EF.Functions.Like(x.Title, searchString) && (string.IsNullOrEmpty(genre) || x.Genre.Contains(genre))).ToList();

            return result.ToPagedList(page ?? 1, pageSize ?? 30).ToList();
        }
    }
}
