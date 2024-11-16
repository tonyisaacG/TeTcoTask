using CleanArchitectureTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTask.Application.UseCases.ParentFeatures.Queries.GetPaginationParent
{
    public class GetPaginatedParentResponse
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
