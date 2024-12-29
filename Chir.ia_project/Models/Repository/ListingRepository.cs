using Chir.ia_project.Models.Entities;
using Chir.ia_project.Services.Dtos;

namespace Chir.ia_project.Models.Repository
{
    public interface IListingRepository : IBaseRepository<Listing>
    {
    }

    public class ListingRepository : BaseRepository<Listing>, IListingRepository
    {
        private readonly Context _context;

        public ListingRepository(Context context) : base(context)
        {
            _context = context;
        }

    }

}
