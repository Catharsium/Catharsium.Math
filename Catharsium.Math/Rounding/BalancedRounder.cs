using Catharsium.Math.Interfaces;
using System.Linq;

namespace Catharsium.Math.Rounding
{
    public partial class BalancedRounder : IBalancedRounder
    {
        private readonly IPrecisionCalculator precisionCalculator;


        public BalancedRounder(IPrecisionCalculator precisionCalculator)
        {
            this.precisionCalculator = precisionCalculator;
        }


        public decimal[] PartitionedRounding(decimal[] numbers, decimal total)
        {
            var precision = this.precisionCalculator.FindNumberOfDigits(total);
            var factor = (decimal)System.Math.Pow(10, precision);

            var result = numbers.Select((n, i) => new RoundedAmount
            {
                Index = i,
                Number = decimal.Floor(n),
                Remainder = n * factor % 1
            }).ToList();
            result = result.OrderByDescending(l => l.Remainder).ToList();

            var delta = (int)((total - result.Sum(l => l.Number)) * factor);
            var remainder = delta;

            while (remainder > 0)
            {
                result[delta - remainder].Number += 1 / factor;
                remainder--;
            }

            result = result.OrderBy(l => l.Index).ToList();
            return result.Select(l => l.Number).ToArray();
        }
    }
}