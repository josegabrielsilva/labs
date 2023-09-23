using System.ComponentModel.DataAnnotations;

namespace Labs.Infrastructure.Contracts.Api.Transactions.Create
{
    public class CreateTransactionRequest
    {
        [Required]
        public double SaleValue { get; set; }
        [Required]
        public Guid MerchantId { get; set; }
    }
}
