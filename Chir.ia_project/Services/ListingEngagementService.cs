using Chir.ia_project.Models.Entities;
using Chir.ia_project.Models.Enum;
using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace Chir.ia_project.Services
{

    public interface IListingEngagementService
    {
        Task AddEngagementAsync(Guid listingId, Guid userId, LikeValue likeValue);
        Task<List<ListingEngagement>> GetUserEngagementsAsync(Guid userId, LikeValue likeValue);
    }

    public class ListingEngagementService : ServiceBase, IListingEngagementService
    {

        public ListingEngagementService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task AddEngagementAsync(Guid listingId, Guid userId, LikeValue likeValue)
        {
            var existing = await UnitOfWork.ListingEngagement
                .FirstOrDefaultAsync(le => le.ListingId == listingId && le.UserId == userId);

            if (existing != null)
            {
                existing.LikeValue = likeValue;
            }
            else
            {
                var engagement = new ListingEngagement
                {
                    ListingId = listingId,
                    UserId = userId,
                    LikeValue = likeValue,
                    IsFavourited = false
                };
                UnitOfWork.ListingEngagement.Add(engagement);
            }

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<List<ListingEngagement>> GetUserEngagementsAsync(Guid userId, LikeValue likeValue)
        {
            return await UnitOfWork.ListingEngagement.Query()
                .Include(le => le.Listing)
                .Where(le => le.UserId == userId && le.LikeValue == likeValue)
                .ToListAsync();
        }

        public async Task<List<Guid>> GetListingIdsFromListingsEngagementsByUserIdAsync(Guid userId)
        {
            return await UnitOfWork.ListingEngagement.GetListingIdsFromListingsEngagementsByUserIdAsync(userId);
        }
    }
}
