using MediatR;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetParentWithWallet
{
    public class GetParentWithWalletRequest : IRequest<GetParentWithWalletResponse>
    {
        public int ParentId { get; set; }
    }
}
