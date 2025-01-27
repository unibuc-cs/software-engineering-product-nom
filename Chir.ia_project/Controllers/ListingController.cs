using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Chir.ia_project.Models.Entities;
using Chir.ia_project.Models.Enum;
using Chir.ia_project.Services;
using Chir.ia_project.Services.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chir.ia_project.Controllers
{
    public class ListingController : Controller
    {
        private readonly IListingService listingService;
        protected readonly UserManager<User> userManager;

        public ListingController(IListingService _listingsService, UserManager<User> _userManager)
        {
            listingService = _listingsService;
            userManager = _userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(User);

            var returnVal = await listingService.GetMyListingsAsync(Guid.Parse(userId));
            return View(returnVal);
        }


        [HttpGet]
        public async Task<IActionResult> AddListing()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddListing(ListingRequest listing)
        {
            var userId = userManager.GetUserId(User);

            await listingService.InsertListingAsync(listing, Guid.Parse(userId));

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteListing(Guid id)
        {
            var userId = userManager.GetUserId(User);

            await listingService.DeleteListingAsync(id, Guid.Parse(userId));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await listingService.GetByIdAsync(id);
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> IndexSwipe()
        { 
            var returnVal = await listingService.GetAllListingsAsync();
            return View(returnVal);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditListing(Guid id)
        {
            var listing = await listingService.GetByIdAsync(id);
            if (listing == null)
            {
                return NotFound();
            }

            // Map Listing entity to a ListingRequest DTO
            var listingRequest = new ListingRequest
            {
                SeismicRisk = listing.SeismicRisk,
                TotalLivableArea = listing.TotalLivableArea,
                Details = listing.Details,
                ImageRequest = new ImageRequest { EntityId = listing.Id }
            };

            return View(listingRequest);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditListing(Guid id, ListingRequest listing)
        {
            var userId = userManager.GetUserId(User);
            await listingService.UpdateListingAsync(listing, id, Guid.Parse(userId));
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LikedListings()
        {
            var userId = userManager.GetUserId(User);
            var engagements = await listingService.GetUserEngagementsAsync(Guid.Parse(userId), LikeValue.Liked);
            return View(engagements);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddEngagement([FromBody] EngagementRequest request)
        {
            var userId = userManager.GetUserId(User);
            await listingService.AddEngagementAsync(request.ListingId, Guid.Parse(userId), request.LikeValue);
            return Ok();
        }

        public class EngagementRequest
        {
            public Guid ListingId { get; set; }
            public LikeValue LikeValue { get; set; }
        }
    }
}
