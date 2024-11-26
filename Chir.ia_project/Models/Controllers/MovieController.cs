using System.Text;
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

        [HttpGet]
        public async Task<string> Index()
        {
            var returnVal = await moviesService.GetAllMoviesFormatString();

            return returnVal;
        }

        [HttpGet]
        public async Task AddMovie(string description, int rating)
        {
           await moviesService.InsertMovie(description, rating);
        }

        [HttpGet]
        public async Task DeleteMovie(Guid Id)
        {
            await moviesService.DeleteMovie(Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid Id)
        {
            var response = await moviesService.GetById(Id);

            return View(response);
        }

    }
}
