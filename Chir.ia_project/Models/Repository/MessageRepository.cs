using Azure;
using Chir.ia_project.Models.Entities;
using Chir.ia_project.Services.Dtos;
//using NuGet.Protocol.Plugins;

namespace Chir.ia_project.Models.Repository
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
        Task<List<Message>> GetMessageAsync(Guid currentUserId, Guid receiverId, Guid listingId);
        Task<List<Guid>> GetUsersIdAsync(Guid ReceiverId, Guid ListingId);
    }

    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context) : base(context)
        {
            _context = context;
        }

        // returneaza mesajele dintre cei doi useri
        public async Task<List<Message>> GetMessageAsync(Guid currentUserId, Guid receiverId, Guid listingId)
        {
            var messages = _context.Messages
                .Where(m => (m.ListingId == listingId && m.SenderId == currentUserId && m.ReceiverId == receiverId) ||
                            (m.ListingId == listingId && m.SenderId == receiverId && m.ReceiverId == currentUserId))
                .OrderBy(m => m.Timestamp)
                .ToList();
             
            return messages;
        }

        public async Task<List<Guid>> GetUsersIdAsync(Guid receiverId, Guid listingId)
        {
            var users = _context.Messages
                .Where(m => (m.ListingId == listingId && m.ReceiverId == receiverId))
                .Select(m => m.SenderId)
                .Distinct()
                .ToList();

            return users;
        }
    }
}
