using CleanArchitectureTask.Application.Commons.Dtos;
using CleanArchitectureTask.Application.Interfaces.Repositories;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetPaginationParent;
using CleanArchitectureTask.Domain.Entities;
using CleanArchitectureTask.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTask.Infrastructure.Repositories
{
    public class ParentRepository : BaseRepository<Parent>, IParentRepository
    {
        public ParentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<(IEnumerable<Parent> Items, int TotalItem)> GetPaginatedParent(GetPaginatedParentRequest parameter,CancellationToken cancellationToken)
        {
            var parents = await _context.Parents.Skip(( parameter.PageNumber - 1 ) * parameter.PageSize).Take(parameter.PageSize).ToListAsync(cancellationToken);
            var totalParent = await _context.Parents.CountAsync();
            return (parents, totalParent);
        }
    }
}
