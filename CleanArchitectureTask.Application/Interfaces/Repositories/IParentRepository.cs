using CleanArchitectureTask.Application.Commons.Dtos;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetPaginationParent;
using CleanArchitectureTask.Domain.Entities;

namespace CleanArchitectureTask.Application.Interfaces.Repositories
{
    public interface IParentRepository : IBaseRepository<Parent>
    {
        public Task<(IEnumerable<Parent> Items,int TotalItem)> GetPaginatedParent(GetPaginatedParentRequest parameter,CancellationToken cancellationToken);
    }
}
