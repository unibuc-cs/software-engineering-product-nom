using Chir.ia_project.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chir.ia_project.Models.Repository
{
    public interface IImageRepository : IBaseRepository<Image>
    {
        Task<List<Image>> GetAllByEntityIdAsync(Guid entityId);
    }

    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        private readonly Context _context;

        public ImageRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Image>> GetAllByEntityIdAsync(Guid entityId)
        {
            return await Get()
                .Where(i => i.EntityId == entityId)
                .ToListAsync();
        }
    }

}
