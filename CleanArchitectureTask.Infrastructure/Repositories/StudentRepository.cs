using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Domain.Entities;
using CleanArchitectureTask.Infrastructure.Persistence;

namespace CleanArchitectureTask.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
