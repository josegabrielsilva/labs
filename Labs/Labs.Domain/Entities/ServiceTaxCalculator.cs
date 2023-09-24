namespace Labs.Domain.Entities
{
    public static class ServiceTaxCalculator
    {
        public static double Calculate(double saleValue, double taxPercentual)
            => saleValue * (taxPercentual / 100);
    }
}
