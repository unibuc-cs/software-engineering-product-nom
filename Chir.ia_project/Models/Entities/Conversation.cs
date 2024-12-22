using System.ComponentModel.DataAnnotations;

namespace Chir.ia_project.Models.Entities
{
    public class Conversation : BaseEntity
    {
        [MaxLength(128)]
        public string Title { get; set; }

        public List<UserConversation> UserConversations { get; set; } //basically participants
        public List<Message> Messages { get; set; }
    }
}
