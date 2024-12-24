using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Models.Repository
{
    public interface IConversationRepository : IBaseRepository<Conversation>
    {
    }

    public class ConversationRepository : BaseRepository<Conversation>, IConversationRepository
    {
        private readonly Context _context;

        public ConversationRepository(Context context) : base(context)
        {
            _context = context;
        }


    }
}
