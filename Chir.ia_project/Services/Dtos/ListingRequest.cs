using Chir.ia_project.Models.Entities;
using Chir.ia_project.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Chir.ia_project.Services.Dtos
{
    public class ListingRequest
    {
        public SeismicRisk SeismicRisk { get; set; }
        public double TotalLivableArea { get; set; }
        [MaxLength(1024)]
        public string Details { get; set; }

        public Guid UserId { get; set; }

        public ImageRequest ImageRequest { get; set; }
    }
}
