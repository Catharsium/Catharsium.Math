namespace Catharsium.Math.Rounding;

public partial class BalancedRounder
{
    public class RoundedAmount
    {
        public int Index { get; set; }
        public decimal Number { get; set; }
        public decimal Remainder { get; set; }
    }
}