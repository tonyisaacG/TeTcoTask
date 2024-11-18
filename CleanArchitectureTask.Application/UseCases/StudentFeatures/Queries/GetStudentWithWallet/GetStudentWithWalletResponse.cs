namespace CleanArchitectureTask.Application.UseCases.StudentFeatures.Queries.GetStudentWithWallet
{
    public class GetStudentWithWalletResponse
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public StudentWalletResponse Wallet { get; set; }

    }
    public class StudentWalletResponse
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
    }
}
