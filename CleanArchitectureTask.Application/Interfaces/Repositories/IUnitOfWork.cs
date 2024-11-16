namespace CleanArchitectureTask.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IRepository GetRepository<IRepository>();
        Task CreateTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
