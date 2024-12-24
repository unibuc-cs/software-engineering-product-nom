using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Chir.ia_project.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace Chir.ia_project.Models.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
