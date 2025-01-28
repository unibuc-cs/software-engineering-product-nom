using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services.Common;
using Chir.ia_project.Services.Dtos;
using Chir.ia_project.Models.Entities;
//using NuGet.Protocol.Plugins;

namespace Chir.ia_project.Services
{
    public interface IMessageService 
    {
        Task<MessageRequest> GetMessageAsynk(Guid currentUser, Guid receiverId);
        Task AddMessageAsync(MessageResponse response);
    }

    public class MessageService : ServiceBase, IMessageService
    {

        public MessageService(IUnitOfWork unitOfWork) : base(unitOfWork) 
        {
        }

        public async Task<MessageRequest> GetMessageAsynk(Guid currentUserId, Guid receiverId)
        {
            MessageRequest request = new MessageRequest();

            var messages = await UnitOfWork.Message.GetMessageAsync(currentUserId, receiverId);

            request.Messages = messages;
            request.SenderId = currentUserId;
            request.ReceiverId = receiverId;

            return request;
        }

        public async Task AddMessageAsync(MessageResponse response)
        {
            var message = new Message
            {
                SenderId = response.SenderId,
                ReceiverId = response.ReceiverId,
                Content = response.Content,
                Timestamp = DateTime.UtcNow,
                //IsRead = false
            };

            UnitOfWork.Message.Add(message);
            await UnitOfWork.SaveChangesAsync();

        }


    }
}
