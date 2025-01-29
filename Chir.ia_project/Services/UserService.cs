using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services.Common;
using Chir.ia_project.Services.Dtos;

namespace Chir.ia_project.Services
{
    public interface IUserService
    {
        Task<List<UserIdAndName>> GetUserIdAndNamesAsync(List<Guid> ids);
    }

    public class UserService : ServiceBase, IUserService
    {
        public UserService(IUnitOfWork unitOfWork):base(unitOfWork){}


        public async Task<List<UserIdAndName>> GetUserIdAndNamesAsync(List<Guid> ids)
        {
            var idAndNames = new List<UserIdAndName>();

            foreach (var id in ids)
            {
                string name = await UnitOfWork.User.GetNameByIdAsync(id);
                idAndNames.Add(new UserIdAndName { Id = id, Name = name});
            }

            return idAndNames;
        }

    }

}
