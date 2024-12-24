﻿using Chir.ia_project.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Chir.ia_project.Models.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(32)]
        public string FirstName { get; set; }
        [MaxLength(32)]
        public string LastName { get; set; }
        [MaxLength(128)]
        public string Email { get; set; }
        public UserType UserType { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Listing> Listings { get; set; }
        public List<ListingEngagement> ListingEngagements { get; set; }
        public List<UserConversation> UserConversations { get; set; }
        public List<Message> Messages { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}