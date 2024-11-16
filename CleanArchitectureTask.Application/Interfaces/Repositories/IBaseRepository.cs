namespace CleanArchitectureTask.Application.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken);
        public Task<TEntity> GetById<Tkey>(Tkey id,CancellationToken cancellationToken);
        public Task Create(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}
