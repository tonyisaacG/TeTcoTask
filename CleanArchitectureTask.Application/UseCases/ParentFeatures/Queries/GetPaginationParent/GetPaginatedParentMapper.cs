using AutoMapper;
using CleanArchitectureTask.Application.Commons.Mapping;
using CleanArchitectureTask.Domain.Entities;


namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetPaginationParent
{
    internal class GetPaginatedParentMapper : IHaveCustomMapping
    {
        public void SetProfiles(Profile profile)
        {
            profile.CreateMap<Parent,GetPaginatedParentResponse>();
        }
    }
}
