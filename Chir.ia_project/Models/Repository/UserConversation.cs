using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Models.Repository
{
    public interface IUserConversationRepository : IBaseRepository<UserConversation>
    {
    }

    public class UserConversationRepository : BaseRepository<UserConversation>, IUserConversationRepository
    {
        private readonly Context _context;

        public UserConversationRepository(Context context) : base(context)
        {
            _context = context;
        }
    }


}
