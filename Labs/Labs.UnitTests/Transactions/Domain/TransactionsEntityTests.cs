using FluentAssertions;
using Labs.Domain.Entities;
using Labs.Domain.Exceptions;

namespace Labs.UnitTests.Transactions.Domain
{
    public class TransactionsEntityTests
    {
        [Fact]
        public void When_Sale_Value_Is_Invalid_Should_Not_Create_Transaction()
            => Assert.Throws<EntityValidationException>(() => { new Transaction(Guid.NewGuid(), 0); });

        [Fact]
        public void When_Sale_Value_Is_Valid_Should_Create_Transaction()
        {
            var transaction = new Transaction(Guid.NewGuid(), saleValue: 100);

            transaction.Should().NotBeNull();
            transaction.SaleValue.Should().Be(100);
            transaction.TransactionId.Should().NotBeEmpty();
        }

        [Fact]
        public void When_Merchant_Is_Invalid_Should_Not_Create_Transaction()
            => Assert.Throws<EntityValidationException>(() => { new Transaction(Guid.Empty, 1); });
    }
}