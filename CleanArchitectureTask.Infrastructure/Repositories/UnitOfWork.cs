using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;

namespace CleanArchitectureTask.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; private set; }
        private Hashtable _repositories { get; set; }

        private bool _disposed;

        private IDbContextTransaction _objTran;
        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }
        public IRepository GetRepository<IRepository>()
        {
            if( _repositories == null )
                _repositories = new Hashtable();

            var type = typeof(IRepository).Name;

            if( !_repositories.ContainsKey(type) )
            {
                var repositoryType = typeof(IRepository);

                var concreteType = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => repositoryType.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract)
                    .FirstOrDefault();

                if( concreteType != null )
                {
                    var repositoryInstance = Activator.CreateInstance(concreteType,Context);
                    _repositories.Add(type,repositoryInstance);
                }
            }

            return (IRepository)_repositories[type];
        }
        public async Task CreateTransactionAsync()
        {
            _objTran = await Context.Database.BeginTransactionAsync();
        }
        public async Task CommitAsync()
        {
            await _objTran.CommitAsync();
        }
        public async Task RollbackAsync()
        {
            await _objTran.RollbackAsync();
            _objTran.Dispose();
        }
        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }
        protected void Dispose(bool disposing)
        {
            if( !_disposed )
                if( disposing )
                    Context.Dispose();
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
