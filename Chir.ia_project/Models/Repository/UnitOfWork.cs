namespace Chir.ia_project.Models.Repository
{
    public interface IUnitOfWork
    {
        Context Context { get; }
        IMovieRepository Movie { get; }
        IUserRepository User { get; }
        IConversationRepository Conversation { get; }
        Task<bool> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public Context Context => _context;
        public IMovieRepository Movie { get; }
        public IUserRepository User { get; }
        public IConversationRepository Conversation { get; }

        public UnitOfWork(Context context, IMovieRepository movieRepository, 
            IUserRepository user, IConversationRepository conversation)
        {
            _context = context;
            Movie = movieRepository;
            User = user;
            Conversation = conversation;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
