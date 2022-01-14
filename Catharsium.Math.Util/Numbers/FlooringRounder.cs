using Catharsium.Math.Util.Interfaces;
namespace Catharsium.Math.Util.Numbers;

public class FlooringRounder : IRounder
{
    public decimal Round(decimal input, int decimals = 0)
    {
        var factor = (int)System.Math.Pow(10, decimals);
        var integralValue = input * factor;
        var roundedValue = System.Math.Floor(integralValue);
        return roundedValue / factor;
    }
}