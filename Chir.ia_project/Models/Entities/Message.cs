using System.ComponentModel.DataAnnotations;

namespace Chir.ia_project.Models.Entities
{
    public class Message : BaseEntity
    {
        [Required]
        [MaxLength(2048)]
        public string Content { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
    }
}
