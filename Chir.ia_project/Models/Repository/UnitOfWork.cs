namespace Chir.ia_project.Models.Repository
{
    public interface IUnitOfWork
    {
        Context Context { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {

        public Context _context => _context;
        public UnitOfWork(Context context)
        {
            _context = context;
        }

    }
}
