using System.ComponentModel.DataAnnotations;
using Chir.ia_project.Models.Enum;

namespace Chir.ia_project.Models.Entities
{
    public class Listing : BaseEntity
    {
        public SeismicRisk SeismicRisk { get; set; }
        public double TotalLivableArea { get; set; }
        [MaxLength(1024)]
        public string Details { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public List<ListingEngagement> ListingEngagements { get; set; }
    }
}
