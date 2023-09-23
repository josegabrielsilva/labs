using FluentAssertions;
using Labs.Domain.Entities;

namespace Labs.UnitTests.Transactions.Domain
{
    public class ServiceTaxCalculatorTests
    {
        [Theory]
        [InlineData(100, 10, 10)]
        [InlineData(100, 1, 1)]
        [InlineData(100, 2.5, 2.5)]
        public void When_Is_Called_With_This_Values(double saleValue, double taxPercentual, double expectedResult)
        {
            ServiceTaxCalculator.Calculate(saleValue: saleValue, taxPercentual: taxPercentual)
                .Should()
                .Be(expectedResult);
        }
    }
}
