namespace Chir.ia_project.Models.Entities
{
    public class UserConversation : BaseEntity
    {
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
