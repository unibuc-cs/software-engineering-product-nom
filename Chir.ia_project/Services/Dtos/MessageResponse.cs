using System.ComponentModel.DataAnnotations;

namespace Chir.ia_project.Services.Dtos
{
    public class MessageResponse
    {
        public Guid SenderId { get; set; } 
        public Guid ReceiverId { get; set; } 
        public Guid ListingId { get; set; }
        public string Content { get; set; }

    }
}
