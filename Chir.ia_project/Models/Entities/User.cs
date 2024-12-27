using Chir.ia_project.Models.Enum;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Chir.ia_project.Models.Entities
{
    public class User : IdentityUser<Guid>
    {
        public UserType UserType { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Listing> Listings { get; set; }
        public List<ListingEngagement> ListingEngagements { get; set; }
        public List<UserConversation> UserConversations { get; set; }
        public List<Message> Messages { get; set; }
    }
}
