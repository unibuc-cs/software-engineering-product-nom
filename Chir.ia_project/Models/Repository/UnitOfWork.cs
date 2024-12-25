namespace Chir.ia_project.Models.Repository
{
    public interface IUnitOfWork
    {
        Context Context { get; }
        IMovieRepository Movie { get; }
        IUserRepository User { get; }
        IConversationRepository Conversation { get; }
        IListingRepository Listing { get; }
        IListingEngagementRepository ListingEngagement { get; }
        IMessageRepository Message { get; }
        IUserConversationRepository UserConversation { get; }
        Task<bool> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public Context Context => _context;
        public IMovieRepository Movie { get; }
        public IUserRepository User { get; }
        public IConversationRepository Conversation { get; }
        public IListingRepository Listing { get; }
        public IListingEngagementRepository ListingEngagement { get; }
        public IMessageRepository Message { get; }
        public IUserConversationRepository UserConversation { get; }
        

        public UnitOfWork(Context context, IMovieRepository movieRepository, 
            IUserRepository user, IConversationRepository conversation, 
            IListingRepository listingRepository, IListingEngagementRepository listingEngagementRepository,
            IMessageRepository messageRepository, IUserConversationRepository userConversationRepository)
        {
            _context = context;
            Movie = movieRepository;
            User = user;
            Conversation = conversation;
            Listing = listingRepository;
            ListingEngagement = listingEngagementRepository;
            Message = messageRepository;
            UserConversation = userConversationRepository;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
