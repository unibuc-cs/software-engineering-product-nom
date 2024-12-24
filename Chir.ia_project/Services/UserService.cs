using Chir.ia_project.Models.Repository;
using Chir.ia_project.Services.Common;

namespace Chir.ia_project.Services
{
    public interface IUserService
    {
    }

    public class UserService : ServiceBase, IUserService
    {
        public UserService(IUnitOfWork unitOfWork):base(unitOfWork){}

    }
}
