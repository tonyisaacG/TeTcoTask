namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.Commons
{
    public class StudentResponseQuery
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public decimal BalanceWallet { get; set; }
    }
}
