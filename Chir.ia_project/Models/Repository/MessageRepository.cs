using Azure;
using Chir.ia_project.Models.Entities;
using Chir.ia_project.Services.Dtos;

namespace Chir.ia_project.Models.Repository
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        Task<List<Message>> GetMessageAsync(Guid currentUserId, Guid receiverId);
    }

    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context) : base(context)
        {
            _context = context;
        }

        // returneaza mesajele dintre cei doi useri
        public async Task<List<Message>> GetMessageAsync(Guid currentUserId, Guid receiverId)
        {
            var messages = _context.Messages
                .Where(m => (m.SenderId == currentUserId && m.ReceiverId == receiverId) ||
                            (m.SenderId == receiverId && m.ReceiverId == currentUserId))
                .OrderBy(m => m.Timestamp)
                .ToList();

            return messages;
        }


    }
}
