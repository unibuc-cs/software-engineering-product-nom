using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services.Common;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Services
{

    public interface IMovieService
    {
        Task<string> GetAllMoviesFormatString();
        Task InsertMovie(string description, int rating);
        Task DeleteMovie(Guid Id);
        Task<Movie> GetById(Guid Id);
    }

    public class MovieService : ServiceBase, IMovieService
    {
        public MovieService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<string> GetAllMoviesFormatString()
        {
            var builder = new StringBuilder();

            var allMovies = await UnitOfWork.Movie.GetAllAsync();

            foreach (var movie in allMovies)
            {
                builder.Append(movie.Description);
            }
            var returnVal = builder.ToString();

            return returnVal;
        }

        public async Task InsertMovie(string description, int rating)
        {
            UnitOfWork.Movie.Add(new Movie { Description = description, Rating = rating });

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteMovie(Guid id)
        {
            var movie = await UnitOfWork.Movie.GetByIdAsync(id);
            UnitOfWork.Movie.Delete(movie);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<Movie> GetById(Guid Id)
        {
            return await UnitOfWork.Movie.GetByIdAsync(Id);
        }
    }
}
