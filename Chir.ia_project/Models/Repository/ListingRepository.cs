using Chir.ia_project.Models.Entities;
using Chir.ia_project.Services.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Chir.ia_project.Models.Repository
{
    public interface IListingRepository : IBaseRepository<Listing>
    {
        public Task<List<Listing>> GetAllByUserIdAsync(Guid userId);
        Task<List<Listing>> GetNotSwipedListingsAsync(Guid userId, List<Guid> swipedListings);
     
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

        public async Task<List<Listing>> GetNotSwipedListingsAsync(Guid userId, List<Guid> swipedListings)
        {

            if (swipedListings == null || !swipedListings.Any())
            {
                return await Get().ToListAsync();
            }

            // Filtrează înregistrările al căror Id NU este în lista excludedIds
            return await Get()
                .Where(listing => !swipedListings.Contains(listing.Id))
                .ToListAsync();

        }
    }

}
