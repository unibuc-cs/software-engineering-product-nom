using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Services.Dtos
{
    public class ListingsResponse
    {
        public List<ListingResponse> ListingsList { get; set; } = new();

    }
}
