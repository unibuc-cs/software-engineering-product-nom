using Chir.ia_project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Chir.ia_project.Models.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity record);
        void AddRange(IEnumerable<TEntity> records);
        void Delete(TEntity record, bool removeFromDb = false);
        void DeleteRange(IEnumerable<TEntity> records, bool removeFromDb = false);
        Task<TEntity> GetByIdAsync(Guid id, bool includeDeleted = false);
        Task<IEnumerable<TEntity>> GetAllByIdsAsync(IEnumerable<Guid> ids, bool includeDeleted = false);
        Task<IEnumerable<TEntity>> GetAllAsync(bool includeDeleted = false);
        Task<bool> ExistsAsync(Guid id);

        void Update(TEntity record);
    }
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        protected IQueryable<TEntity> Get(bool includeDeleted = false)
        {
            return includeDeleted
                ? _dbSet.IgnoreQueryFilters()
                : _dbSet;
        }

        public void Add(TEntity record)
        {
            _dbSet.Add(record);
        }

        public void AddRange(IEnumerable<TEntity> records)
        {
            foreach (var record in records)
            {
                _dbSet.Add(record);
            }
        }

        public void Delete(TEntity record, bool removeFromDb = false)
        {
            _dbSet.Remove(record);
        }

        public void DeleteRange(IEnumerable<TEntity> records, bool removeFromDb = false)
        {
            if (!removeFromDb)
            {
                var now = DateTime.UtcNow;

                foreach (var record in records)
                {
                    record.IsDeleted = true;
                    Update(record);
                }
            }
            else
            {
                _dbSet.RemoveRange(records);
            }
        }

        public async Task<TEntity> GetByIdAsync(Guid id, bool includeDeleted = false)
        {
            return await Get(includeDeleted).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllByIdsAsync(IEnumerable<Guid> ids, bool includeDeleted = false)
        {
            return await Get(includeDeleted).Where(e => ids.Contains(e.Id)).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool includeDeleted = false)
        {
            return await Get(includeDeleted).ToListAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }

        public void Update(TEntity record)
        {
            foreach (var property in _context.Entry(record).Properties.Where(p => !p.Metadata.IsKey()))
                property.IsModified = true;
        }
    }
}
