using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Models.Repository
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
    }

    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context) : base(context)
        {
            _context = context;
        }

    }
}
