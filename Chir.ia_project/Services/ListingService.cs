using Chir.ia_project.Models.Entities;
using Chir.ia_project.Models.Enum;
using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services.Common;
using Chir.ia_project.Services.Dtos;
using System.Text;

namespace Chir.ia_project.Services
{
    public interface IListingService
    {
        Task<ListingResponse> GetAllListingsFormatStringAsync();
        Task InsertListingAsync(Listing listing, Guid id);
        Task DeleteListingAsync(Guid Id);
        Task<Listing> GetByIdAsync(Guid Id);

    }

    public class ListingService : ServiceBase, IListingService
    {
        public ListingService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<ListingResponse> GetAllListingsFormatStringAsync()
        {
            var ListingsDto = new ListingResponse();

            var allListings = await UnitOfWork.Listing.GetAllAsync();

            foreach (var listing in allListings)
            {
                ListingsDto.ListingsList.Add(listing);
            }
            

            return ListingsDto;
        }

        public async Task InsertListingAsync(Listing listing, Guid id)
        {
            listing.UserId = id;
            UnitOfWork.Listing.Add(listing);
            await UnitOfWork.SaveChangesAsync();

        }

        public async Task DeleteListingAsync(Guid id)
        {
            var listing = await UnitOfWork.Listing.GetByIdAsync(id);
            UnitOfWork.Listing.Delete(listing);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<Listing> GetByIdAsync(Guid id)
        {
            return await UnitOfWork.Listing.GetByIdAsync(id);
        }

    }
}
