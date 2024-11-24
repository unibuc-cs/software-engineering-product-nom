using Microsoft.EntityFrameworkCore;

namespace Chir.ia_project.Models.Repository
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        public Task<List<Movie>> GetByRating(int rating);
    }

    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {

        private readonly Context _context;

        public MovieRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetByRating(int rating)
        {
            return await Get().Where(m  => m.Rating == rating).ToListAsync();
        }

    }
}
