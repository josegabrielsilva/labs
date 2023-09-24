using Labs.Domain.Exceptions;

namespace Labs.Domain.Entities
{
    public class Transaction
    {
        public Transaction(Guid merchant, double saleValue)
        {
            if (!Guid.TryParse(merchant.ToString(), out _))
                throw new EntityValidationException(string.Format("Merchant {0} inválido.", merchant));

            if (saleValue <= 0)
                throw new EntityValidationException("Preço de venda deve ser maior que zero.");

            SaleValue = saleValue;
            TransactionId = Guid.NewGuid();
            Merchant = merchant;
            Date = DateTime.UtcNow;
        }

        public Guid Merchant { get; set; }
        public Guid TransactionId { get; private set; }
        public double SaleValue { get; private set; }
        public DateTime Date { get; private set; }
    }
}