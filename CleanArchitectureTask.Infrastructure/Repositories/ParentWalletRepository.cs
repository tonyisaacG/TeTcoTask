using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Domain.Entities;
using CleanArchitectureTask.Infrastructure.Persistence;

namespace CleanArchitectureTask.Infrastructure.Repositories
{
    public class ParentWalletRepository : BaseRepository<ParentWallet>, IParentWalletRepository
    {
        public ParentWalletRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
