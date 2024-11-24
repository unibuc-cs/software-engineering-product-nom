namespace Chir.ia_project.Models.Repository
{
    public interface IUnitOfWork
    {
        Context Context { get; }

        IMovieRepository Movie { get; }


        Task<bool> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public Context Context => _context;

        public IMovieRepository Movie { get; }

        public UnitOfWork(Context context, IMovieRepository movieRepository)
        {
            _context = context;
            Movie = movieRepository;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
