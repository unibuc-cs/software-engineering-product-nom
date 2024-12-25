using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Models.Repository
{
    public interface IListingEngagementRepository : IBaseRepository<ListingEngagement>
    {
    }

    public class ListingEngagementRepository : BaseRepository<ListingEngagement>, IListingEngagementRepository
    {
        private readonly Context _context;

        public ListingEngagementRepository(Context context) : base(context)
        {
            _context = context;
        }

    }
}
