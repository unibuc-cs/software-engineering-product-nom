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

    }
}
