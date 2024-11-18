using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetPaginationStudent;
using CleanArchitectureTask.Domain.Entities;
using CleanArchitectureTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTask.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Student> FindStudentByNationalId(string nationalId)
        {
            var student = await _context.Students.Where(obj=>obj.NationalId.Trim()== nationalId.Trim()).FirstOrDefaultAsync();
            return student;
        }

        public async Task<(IEnumerable<Student> Items, int TotalItem)> GetPaginatedStudent(GetPaginatedStudentRequest parameter,CancellationToken cancellationToken)
        {
            var students = await _context.Students.Skip(( parameter.PageNumber - 1 ) * parameter.PageSize).Take(parameter.PageSize).ToListAsync(cancellationToken);
            var totalStudent = await _context.Students.CountAsync();
            return (students, totalStudent);
        }
    }
}
