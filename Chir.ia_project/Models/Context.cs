using Chir.ia_project.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chir.ia_project.Models
{
    public class Context : IdentityDbContext<User, AppRole, Guid>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingEngagement> ListingEngagements { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserConversation> UserConversations { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                         .SelectMany(entity => entity.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
            base.OnModelCreating(modelBuilder);
        }

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
