using AutoMapper;
using CleanArchitectureTask.Application.Commons.Mapping;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetStudentWithWallet;
using CleanArchitectureTask.Domain.Entities;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.Commons
{
    public class StudentProfileMapperQuery : IHaveCustomMapping
    {
        public void SetProfiles(Profile profile)
        {
            profile.CreateMap<Student,StudentResponseQuery>();
            profile.CreateMap<Student,GetStudentWithWalletResponse>();
            profile.CreateMap<StudentWallet,StudentWalletResponse>();
        }
    }
}
