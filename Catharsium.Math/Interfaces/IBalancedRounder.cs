namespace Catharsium.Math.Interfaces
{
    public interface IBalancedRounder
    {
        decimal[] PartitionedRounding(decimal[] amount, decimal total);
    }
}