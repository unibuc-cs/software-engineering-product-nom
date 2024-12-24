using Chir.ia_project.Models.Enum;

namespace Chir.ia_project.Models.Entities
{
    public class ListingEngagement : BaseEntity
    {
        public LikeValue LikeValue { get; set; }
        public bool IsFavourited { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ListingId { get; set; }
        public Listing Listing { get; set; }
    }
}
