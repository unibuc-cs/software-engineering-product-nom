using Chir.ia_project.Models.Entities;
using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services;
using Chir.ia_project.Services.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//using NuGet.Protocol.Plugins;
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
        public async Task<IActionResult> Chat(Guid receiverId)
        {
            var currentuserId = Guid.Parse(userManager.GetUserId(User));
            var request = messageService.GetMessageAsynk(currentuserId, receiverId);
            
            return View(request);
        }


        // Trimite mesaj (formular)
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageResponse response)
        {
            if (string.IsNullOrEmpty(response.Content))
            {
                return RedirectToAction("Chat", new { response.ReceiverId });
            }

            await messageService.AddMessageAsync(response);

            return RedirectToAction("Chat", new { response.ReceiverId }); // Reîmprospătează pagina cu mesajul nou
        }



    }
}
