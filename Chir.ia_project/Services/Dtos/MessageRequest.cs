using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Services.Dtos
{
    public class MessageRequest
    {
        public Guid ReceiverId { get; set; }
        public Guid SenderId { get; set; }
        public Guid ListingId { get; set; }
        public List<Message> Messages { get; set; } = new();

    }
}
