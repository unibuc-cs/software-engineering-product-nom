using System.ComponentModel.DataAnnotations;

namespace Chir.ia_project.Models.Entities
{
    public class Message : BaseEntity
    {
        [Required]
        [MaxLength(2048)]
        public string Content { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
    }
}
