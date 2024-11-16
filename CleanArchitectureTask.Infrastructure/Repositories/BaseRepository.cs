using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Domain.Commons;
using CleanArchitectureTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTask.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity :class, new()
    {
        protected readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(ApplicationDbContext context) { _context = context; }
        public async Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }
        public async Task<TEntity> GetById<Tkey>(Tkey id,CancellationToken cancellationToken)
        {
            if( typeof(TEntity).IsAssignableFrom(typeof(BaseEntityWithKey<>)) )
            {
                return await _dbSet.FirstOrDefaultAsync(obj => (obj as BaseEntityWithKey<Tkey>).Id.Equals(id),cancellationToken);
            }
            throw new Exception("Key For This Entity Is Complex");
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
