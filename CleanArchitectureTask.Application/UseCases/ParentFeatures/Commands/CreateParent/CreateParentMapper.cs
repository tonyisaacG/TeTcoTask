using AutoMapper;
using CleanArchitectureTask.Application.Commons.Mapping;
using CleanArchitectureTask.Domain.Entities;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent
{
    internal class CreateParentMapper : IHaveCustomMapping
    {
        public void SetProfiles(Profile profile)
        {
            profile.CreateMap<CreateParentRequest,Parent>();
            profile.CreateMap<Parent,CreateParentResponse>();
        }
    }
}
