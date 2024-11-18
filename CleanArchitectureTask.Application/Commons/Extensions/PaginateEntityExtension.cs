using CleanArchitectureTask.Application.Commons.Dtos;

namespace CleanArchitectureTask.Application.Commons.Extensions
{
    public static class PaginateEntityExtension
    {
        public static PaginatedResult<TEntity> ToPaginatedList<TEntity>(this IEnumerable<TEntity> Items,int countItems,int pageNumber,int pageSize) where TEntity : class
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = countItems;
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            List<TEntity> items = Items.ToList();
            return PaginatedResult<TEntity>.Create(items,count,pageNumber,pageSize);
        }
    }
}
