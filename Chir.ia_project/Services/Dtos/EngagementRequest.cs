using Chir.ia_project.Models.Enum;

namespace Chir.ia_project.Services.Dtos
{
    public class EngagementRequest
    {
        public Guid ListingId { get; set; }
        public LikeValue LikeValue { get; set; }
    }
}
