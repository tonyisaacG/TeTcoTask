using CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetPaginationParent;
using CleanArchitectureTask.Domain.Entities;

namespace CleanArchitectureTask.Application.Interfaces.Repositories
{
    public interface IParentRepository : IBaseRepository<Parent>
    {
        public Task<(IEnumerable<Parent> Items, int TotalItem)> GetPaginatedParent(GetPaginatedParentRequest parameter,CancellationToken cancellationToken);
        public Task<Parent> FindParentByNationalIdOrPhoneNum(string nationalId,string phoneNum);
    }
}
