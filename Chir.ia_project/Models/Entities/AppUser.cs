using System.ComponentModel.DataAnnotations;
using Chir.ia_project.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace Chir.ia_project.Models.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        [MaxLength(32)]
        public string FirstName { get; set; }
        [MaxLength(32)]
        public string LastName { get; set; }
        [MaxLength(128)] 
        public string Email { get; set; }
        public UserType UserType { get; set; }

        public DateTime CreatedAt {get;set; }

        public List<Listing> Listings { get; set; }
    }
}
