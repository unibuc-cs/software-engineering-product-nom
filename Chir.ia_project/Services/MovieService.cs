using Chir.ia_project.Models;
using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services.Common;

namespace Chir.ia_project.Services
{

    public interface IMovieService
    {
        Task<List<Movie>> GetAllMovies();
        Task InsertMovie(string description, int rating);

    }

    public class MovieService : ServiceBase, IMovieService
    {
        public MovieService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<List<Movie>> GetAllMovies()
        {

            return await UnitOfWork.Movie.GetAllAsync();
        }

        public async Task InsertMovie(string description, int rating)
        {
            UnitOfWork.Movie.Add(new Movie { Description = description, Rating = rating });

            await UnitOfWork.SaveChangesAsync();
        }
    }
}
