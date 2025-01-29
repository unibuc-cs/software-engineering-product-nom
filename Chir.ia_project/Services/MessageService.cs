using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services.Common;
using Chir.ia_project.Services.Dtos;
using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Services
{
    public interface IMessageService 
    {
        Task<MessageRequest> GetMessageAsync(Guid currentUser, Guid receiverId, Guid listingId);
        Task AddMessageAsync(MessageResponse response);
        Task<List<UserIdAndName>> GetUsersAsync(Guid ReceiverId, Guid ListingId);
    }

    public class MessageService : ServiceBase, IMessageService
    {
        private readonly IUserService userService;

        public MessageService(IUnitOfWork unitOfWork, IUserService _userService) : base(unitOfWork) 
        {
            userService = _userService;
        }

        public async Task<MessageRequest> GetMessageAsync(Guid currentUserId, Guid receiverId, Guid listingId)
        {
            MessageRequest request = new MessageRequest();

            var messages = await UnitOfWork.Message.GetMessageAsync(currentUserId, receiverId, listingId);

            request.Messages = messages;
            request.SenderId = currentUserId;
            request.ReceiverId = receiverId;
            request.ListingId = listingId;

            return request;
        }


        // returneaza userii care au conversatii cu ReceiverId despre ListingId
        public async Task<List<UserIdAndName>> GetUsersAsync(Guid ReceiverId, Guid ListingId)
        {
            var userIds = await UnitOfWork.Message.GetUsersIdAsync(ReceiverId, ListingId);
            var users = await userService.GetUserIdAndNamesAsync(userIds);
            
            return users;
        }

        public async Task AddMessageAsync(MessageResponse response)
        {
            var message = new Message
            {
                SenderId = response.SenderId,
                ReceiverId = response.ReceiverId,
                ListingId = response.ListingId,
                Content = response.Content,
                Timestamp = DateTime.UtcNow,
                //IsRead = false
            };

            UnitOfWork.Message.Add(message);
            await UnitOfWork.SaveChangesAsync();

        }


    }
}
