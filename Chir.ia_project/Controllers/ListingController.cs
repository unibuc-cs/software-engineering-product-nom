using Chir.ia_project.Models.Entities;
using Chir.ia_project.Models.Enum;
using Chir.ia_project.Services;
using Chir.ia_project.Services.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chir.ia_project.Controllers
{
    public class ListingController : Controller
    {
        private readonly IListingService listingService;
        private readonly UserManager<User> userManager;

        public ListingController(IListingService _listingsService, UserManager<User> _userManager)
        {
            listingService = _listingsService;
            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var returnVal = await listingService.GetAllListingsFormatStringAsync();
            return View(returnVal);
        }

        public async Task<IActionResult> AddListing()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddListing(Listing listing)
        {
            var userId = userManager.GetUserId(User);
            
            Console.WriteLine(userId);
            Guid userGuid;

            if (Guid.TryParse(userId, out userGuid))
            {
                // Conversia a reușit
                Console.WriteLine($"GUID valid");
            }
            else
            {
                // Conversia a eșuat
                throw new FormatException("User ID-ul nu este un GUID valid.");
            }
            await listingService.InsertListingAsync(listing, userGuid);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task DeleteListing(Guid id)
        {
            await listingService.DeleteListingAsync(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var response = await listingService.GetByIdAsync(id);
            return View(response);
        }


    }
}
