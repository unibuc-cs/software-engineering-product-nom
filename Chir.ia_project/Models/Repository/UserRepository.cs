using Chir.ia_project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chir.ia_project.Models.Repository
{
    public interface IUserRepository
    {

    }

    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

    }

}
