using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Chir.ia_project.Models.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService moviesService;

        public MovieController(IMovieService _movieService)
        {
            moviesService = _movieService;
        }

        public async Task<string> Index()
        {
            var allMovies = moviesService.GetAllMovies();
            return "added";
        }


        public void AddMovie(string description, int rating)
        {
        
        }
    }
}
