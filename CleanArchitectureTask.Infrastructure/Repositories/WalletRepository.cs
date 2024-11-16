using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Domain.Entities;
using CleanArchitectureTask.Infrastructure.Persistence;

namespace CleanArchitectureTask.Infrastructure.Repositories
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
