namespace Chir.ia_project.Models.Repository
{
    public interface IUnitOfWork
    {
        Context Context { get; }
        Task<bool> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public Context Context => _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
