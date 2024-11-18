using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Domain.Entities;
using CleanArchitectureTask.Infrastructure.Persistence;

namespace CleanArchitectureTask.Infrastructure.Repositories
{
    public class StudentWalletRepository : BaseRepository<StudentWallet>, IStudentWalletRepository
    {
        public StudentWalletRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
