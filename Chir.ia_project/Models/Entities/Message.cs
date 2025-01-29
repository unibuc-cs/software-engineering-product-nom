using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chir.ia_project.Models.Entities
{
    public class Message : BaseEntity
    {
        //[Required]
        //[MaxLength(2048)]
        //public string Content { get; set; }

        //public Guid UserId { get; set; }
        //public User User { get; set; }

        //public Guid ConversationId { get; set; }
        //public Conversation Conversation { get; set; }


        //public int Id { get; set; }
        public Guid SenderId { get; set; } // ID-ul utilizatorului care trimite
        public Guid ReceiverId { get; set; } // ID-ul utilizatorului care primește
        public Guid ListingId { get; set; }  // ID-ul listingului pentru care se incepe conversatia

        [Required]
        [MaxLength(2048)]
        public string Content { get; set; } // Conținutul mesajului
        public DateTime Timestamp { get; set; }

        //public User Sender { get; set; }

        //public User Receiver { get; set; }
    }
}
