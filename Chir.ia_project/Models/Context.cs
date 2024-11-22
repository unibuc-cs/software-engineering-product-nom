using Chir.ia_project.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chir.ia_project.Models
{
    public class Context : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public Context(DbContextOptions<Context> options) : base(options){ }
    }
}
