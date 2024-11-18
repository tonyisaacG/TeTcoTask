using AutoMapper;
using CleanArchitectureTask.Application.Commons.Mapping;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.CreateParent;
using CleanArchitectureTask.Domain.Entities;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Commands.Commons
{
    internal class ParentProfileMapperCommand : IHaveCustomMapping
    {
        public void SetProfiles(Profile profile)
        {
            profile.CreateMap<CreateParentRequest,Parent>();
            profile.CreateMap<Parent,ParentResponseCommand>();
        }
    }
}
