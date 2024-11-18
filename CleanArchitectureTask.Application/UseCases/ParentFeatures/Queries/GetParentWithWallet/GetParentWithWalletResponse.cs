namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetParentWithWallet
{
    public class GetParentWithWalletResponse
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ParentWalletResponse Wallet { get; set; }

    }
    public class ParentWalletResponse
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
    }
}
