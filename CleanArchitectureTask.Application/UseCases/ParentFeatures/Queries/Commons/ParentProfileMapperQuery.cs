using AutoMapper;
using CleanArchitectureTask.Application.Commons.Mapping;
using CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetParentWithWallet;
using CleanArchitectureTask.Domain.Entities;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.Commons
{
    public class ParentProfileMapperQuery : IHaveCustomMapping
    {
        public void SetProfiles(Profile profile)
        {
            profile.CreateMap<Parent,ParentResponseQuery>();
            profile.CreateMap<Parent,GetParentWithWalletResponse>();
            profile.CreateMap<ParentWallet,ParentWalletResponse>();
            
        }
    }
}
