using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Models
{
    public class AuthInfo
    {
        public Guid UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
