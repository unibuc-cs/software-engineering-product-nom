using Chir.ia_project.Models.Repository;

namespace Chir.ia_project.Services.Common
{
    public interface IServiceBase
    {
        IUnitOfWork UnitOfWork { get; }
    }

    public class ServiceBase : IServiceBase
    {
        public IUnitOfWork UnitOfWork { get; }
        public ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
