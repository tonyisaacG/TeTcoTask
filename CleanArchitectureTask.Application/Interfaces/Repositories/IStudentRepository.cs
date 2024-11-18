using CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetPaginationStudent;
using CleanArchitectureTask.Domain.Entities;

namespace CleanArchitectureTask.Application.Interfaces.Repositories
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        public Task<(IEnumerable<Student> Items, int TotalItem)> GetPaginatedStudent(GetPaginatedStudentRequest parameter,CancellationToken cancellationToken);
        public Task<Student> FindStudentByNationalId(string  nationalId);
    }
}
