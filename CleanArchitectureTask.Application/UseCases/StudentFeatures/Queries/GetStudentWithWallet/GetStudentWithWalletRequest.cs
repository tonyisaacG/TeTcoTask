using CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetStudentWithWallet;
using MediatR;

namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetStudentWithWallet
{
    public class GetStudentWithWalletRequest : IRequest<GetStudentWithWalletResponse>
    {
        public int StudentId { get; set; }
    }
}
