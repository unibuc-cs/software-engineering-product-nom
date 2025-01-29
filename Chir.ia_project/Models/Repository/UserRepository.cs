using Chir.ia_project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chir.ia_project.Models.Repository
{
    public interface IUserRepository
    {
        Task<string> GetNameByIdAsync(Guid id);
    }

    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }


        public async Task<string> GetNameByIdAsync(Guid id)
        {
            var name = await _context.Users
                .Where(u => u.Id == id)
                .Select(u => u.UserName)
                .FirstOrDefaultAsync();

            return name;
        }

    }

}
