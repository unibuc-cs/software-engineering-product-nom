using Chir.ia_project.Models.Entities;
using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services;
using Chir.ia_project.Services.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Chir.ia_project.Controllers
{
    public class MessageController : Controller
    {

        private readonly IMessageService messageService;
        protected readonly UserManager<User> userManager;

        public MessageController(IMessageService _messageService, UserManager<User> _userManager)
        {
            messageService = _messageService;
            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(GetMessagesRequest request)
        {
            var currentuserId = Guid.Parse(userManager.GetUserId(User));
            var response = await messageService.GetMessageAsync(currentuserId, request.ReceiverId, request.ListingId);
            
            return View(response);
        }

        // returneaza userii care au dat mesaje pentru listingul respectiv
        public async Task<IActionResult> Messages(GetMessagesRequest request)
        {
            List<UserIdAndName> users = await messageService.GetUsersAsync(request.ReceiverId, request.ListingId);

            var response = new UsersAndListingId();
            response.Users = users;
            response.ListingId = request.ListingId;
            return View(response);

        }


        // Trimite mesaj (formular)
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageResponse response)
        {
            //if (string.IsNullOrEmpty(response.Content))
            //{
            //    return RedirectToAction("Index", new { response.ReceiverId });
            //}

            await messageService.AddMessageAsync(response);
            
            var param = new GetMessagesRequest { ReceiverId = response.ReceiverId,
            ListingId = response.ListingId};

            return RedirectToAction("Index", param ); // Reîmprospătează pagina cu mesajul nou
        }



    }
}
