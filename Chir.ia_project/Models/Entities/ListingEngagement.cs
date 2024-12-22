using Chir.ia_project.Models.Enum;

namespace Chir.ia_project.Models.Entities
{
    public class ListingEngagement : BaseEntity
    {
        public LikeValue LikeValue { get; set; }
        public bool IsFavourited { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Guid ListingId { get; set; }
        public Listing Listing { get; set; }
    }
}
