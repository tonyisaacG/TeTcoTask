using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Domain.Commons;
using CleanArchitectureTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitectureTask.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(ApplicationDbContext context) { _context = context; _dbSet = _context.Set<TEntity>(); }
        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken = default,params string[]? includes)
        {
            var entity = _dbSet.AsQueryable();
            if( includes.Count() > 0 )
            {
                entity = includes.Aggregate(entity,
                          (current,include) => current.Include(include));
            }
            return await entity.ToListAsync(cancellationToken);
        }
        public async Task<TEntity> GetById<Tkey>(Tkey id,CancellationToken cancellationToken = default,params string[]? includes)
        {
            var entity = _dbSet.AsQueryable();


            if( includes.Count() > 0 )
            {
                entity = includes.Aggregate(entity,
                          (current,include) => current.Include(include));
            }

            return await entity.FirstOrDefaultAsync(obj => ( obj as BaseEntityWithKey<Tkey> ).Id.Equals(id),cancellationToken);
        }
        public async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

    }
}
