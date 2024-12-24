using Chir.ia_project.Models.Entities;

namespace Chir.ia_project.Models.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {

    }

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context):base(context)
        {
            _context = context;
        }
    }

}
