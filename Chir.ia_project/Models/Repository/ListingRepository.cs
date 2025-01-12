using Chir.ia_project.Models.Entities;
using Chir.ia_project.Services.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Chir.ia_project.Models.Repository
{
    public interface IListingRepository : IBaseRepository<Listing>
    {
        public Task<List<Listing>> GetAllByUserIdAsync(Guid userId);
    }

    public class ListingRepository : BaseRepository<Listing>, IListingRepository
    {
        private readonly Context _context;

        public ListingRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Listing>> GetAllByUserIdAsync(Guid userId)
        {
            return await Get()
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }
    }

}
