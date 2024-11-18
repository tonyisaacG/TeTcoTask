

using AutoMapper;
using CleanArchitectureTask.Application.Commons.Mapping;
using CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.CreateStudent;
using CleanArchitectureTask.Domain.Entities;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Commands.Commons
{
    internal class StudentProfileMapperCommand : IHaveCustomMapping
    {
        public void SetProfiles(Profile profile)
        {
            profile.CreateMap<CreateStudentRequest,Student>();
            profile.CreateMap<Student,StudentResponseCommand>();
        }
    }
}
