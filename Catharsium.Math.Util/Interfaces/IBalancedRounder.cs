namespace Catharsium.Math.Util.Interfaces;

public interface IBalancedRounder
{
    decimal[] PartitionedRounding(decimal[] amount, decimal total);
}