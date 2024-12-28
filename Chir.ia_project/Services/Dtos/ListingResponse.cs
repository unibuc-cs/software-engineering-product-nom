using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Services.Dtos
{
    public class ListingResponse
    {
        public List<Listing> ListingsList { get; set; } = new();

    }
}
