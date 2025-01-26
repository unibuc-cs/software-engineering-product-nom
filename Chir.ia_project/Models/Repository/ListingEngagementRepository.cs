using Chir.ia_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Chir.ia_project.Models.Repository
{
    public interface IListingEngagementRepository : IBaseRepository<ListingEngagement>
    {
        Task<ListingEngagement> FirstOrDefaultAsync(Expression<Func<ListingEngagement, bool>> predicate);
        IQueryable<ListingEngagement> Query();

    }

    public class ListingEngagementRepository : BaseRepository<ListingEngagement>, IListingEngagementRepository
    {
        private readonly Context _context;

        public ListingEngagementRepository(Context context) : base(context)
        {
            _context = context;
        }

        public IQueryable<ListingEngagement> Query()
        {
            return _context.ListingEngagements.AsQueryable();
        }

        public async Task<ListingEngagement> FirstOrDefaultAsync(Expression<Func<ListingEngagement, bool>> predicate)
        {
            return await _context.ListingEngagements
                .FirstOrDefaultAsync(predicate);
        }
    }
}
