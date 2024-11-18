namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.Commons
{
    public class ParentResponseQuery
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BalanceWallet { get; set; }
    }
}
