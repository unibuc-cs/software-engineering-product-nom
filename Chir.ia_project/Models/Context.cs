using Chir.ia_project.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chir.ia_project.Models
{
    public class Context : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e is { Entity: BaseEntity, State: EntityState.Modified });

            foreach (var entityEntry in entries)
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
