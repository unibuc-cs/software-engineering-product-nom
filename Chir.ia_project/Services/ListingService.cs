using Chir.ia_project.Models.Entities;
using Chir.ia_project.Models.Enum;
using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services.Common;
using Chir.ia_project.Services.Dtos;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Chir.ia_project.Services
{
    public interface IListingService
    {
        Task<ListingsResponse> GetAllListingsAsync();
        Task InsertListingAsync(ListingRequest listing, Guid id);
        Task DeleteListingAsync(Guid Id, Guid userId);
        Task<Listing> GetByIdAsync(Guid Id);
        Task<ListingsResponse> GetMyListingsAsync(Guid userId);
        Task UpdateListingAsync(ListingRequest listing, Guid id, Guid guid);
        Task AddEngagementAsync(Guid listingId, Guid userId, LikeValue likeValue);
        Task<List<ListingEngagement>> GetUserEngagementsAsync(Guid userId, LikeValue likeValue);
    }

    public class ListingService : ServiceBase, IListingService
    {
        private readonly IImageService imageService;

        public ListingService(IUnitOfWork unitOfWork, IImageService _imageService) :
            base(unitOfWork)
        {
            imageService = _imageService;
        }


        public async Task<ListingsResponse> GetMyListingsAsync(Guid userId)
        {
            var ListingsDto = new ListingsResponse();

            var allListings = await UnitOfWork.Listing.GetAllByUserIdAsync(userId);

            foreach (var listing in allListings)
            {
                var images = await UnitOfWork.Image.GetAllByEntityIdAsync(listing.Id);
                ListingsDto.ListingsList.Add(new ListingResponse()
                {
                    Id = listing.Id,
                    SeismicRisk = listing.SeismicRisk,
                    TotalLivableArea = listing.TotalLivableArea,
                    Details = listing.Details,
                    UserId = listing.UserId,
                    Images = images.Select(i => new ImageResponse()
                    {
                        ContentBytes = i.ContentBytes,
                        ContentType = i.ContentType
                    }).ToList()
                });
            }

            return ListingsDto;
        }


        public async Task<ListingsResponse> GetAllListingsAsync()
        {
            var ListingsDto = new ListingsResponse();

            var allListings = await UnitOfWork.Listing.GetAllAsync();

            foreach (var listing in allListings)
            {
                var images = await UnitOfWork.Image.GetAllByEntityIdAsync(listing.Id);
                ListingsDto.ListingsList.Add(new ListingResponse()
                {
                    Id = listing.Id,
                    SeismicRisk = listing.SeismicRisk,
                    TotalLivableArea = listing.TotalLivableArea,
                    Details = listing.Details,
                    UserId = listing.UserId,
                    Images = images.Select(i => new ImageResponse()
                    {
                        ContentBytes = i.ContentBytes, ContentType = i.ContentType
                    }).ToList()
                });
            }
            
            return ListingsDto;
        }

        public async Task InsertListingAsync(ListingRequest listing, Guid id)
        {
            listing.UserId = id;
            var newListing = new Listing()
            {
                SeismicRisk = listing.SeismicRisk,
                TotalLivableArea = listing.TotalLivableArea,
                Details = listing.Details,
                UserId = listing.UserId,
            };
            UnitOfWork.Listing.Add(newListing);

            await UnitOfWork.SaveChangesAsync();

            listing.ImageRequest.EntityId = newListing.Id;
            await imageService.UploadImagesAsync(listing.ImageRequest); //calls SaveChangesAsync() inside
        }

        public async Task DeleteListingAsync(Guid id, Guid userId)
        {
            var listing = await UnitOfWork.Listing.GetByIdAsync(id);
            if (listing.UserId != userId)
            {
                throw new BadHttpRequestException("This user cannot modify the listing.");
            }

            var images = await UnitOfWork.Image.GetAllByEntityIdAsync(id);
            UnitOfWork.Image.DeleteRange(images);
            UnitOfWork.Listing.Delete(listing);
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<Listing> GetByIdAsync(Guid id)
        {
            return await UnitOfWork.Listing.GetByIdAsync(id);
        }

        public async Task UpdateListingAsync(ListingRequest listing, Guid id, Guid userId)
        {
            var existingListing = await UnitOfWork.Listing.GetByIdAsync(id);
            if (existingListing == null || existingListing.UserId != userId)
            {
                throw new BadHttpRequestException("This user cannot modify the listing.");
            }

            existingListing.SeismicRisk = listing.SeismicRisk;
            existingListing.TotalLivableArea = listing.TotalLivableArea;
            existingListing.Details = listing.Details;

            // Handle image updates
            if (listing.ImageRequest?.ImageFiles?.Any() == true)
            {
                var existingImages = await UnitOfWork.Image.GetAllByEntityIdAsync(listing.UserId);
                UnitOfWork.Image.DeleteRange(existingImages);
                listing.ImageRequest.EntityId = listing.UserId;
                await imageService.UploadImagesAsync(listing.ImageRequest);
            }

            UnitOfWork.Listing.Update(existingListing);
            await UnitOfWork.SaveChangesAsync();
        }


        public async Task AddEngagementAsync(Guid listingId, Guid userId, LikeValue likeValue)
        {
            var existing = await UnitOfWork.ListingEngagement
                .FirstOrDefaultAsync(le => le.ListingId == listingId && le.UserId == userId);

            if (existing != null)
            {
                existing.LikeValue = likeValue;
            }
            else
            {
                var engagement = new ListingEngagement
                {
                    ListingId = listingId,
                    UserId = userId,
                    LikeValue = likeValue,
                    IsFavourited = false
                };
                UnitOfWork.ListingEngagement.Add(engagement);
            }

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task<List<ListingEngagement>> GetUserEngagementsAsync(Guid userId, LikeValue likeValue)
        {
            return await UnitOfWork.ListingEngagement.Query()
                .Include(le => le.Listing)
                .Where(le => le.UserId == userId && le.LikeValue == likeValue)
                .ToListAsync();
        }
    }
}
