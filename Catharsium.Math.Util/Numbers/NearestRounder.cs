﻿using Catharsium.Math.Util.Interfaces;
namespace Catharsium.Math.Util.Numbers;

public class NearestRounder : IRounder
{
    public decimal Round(decimal input, int decimals = 0)
    {
        var factor = (int)System.Math.Pow(10, decimals);
        var integralValue = input * factor;
        var roundedValue = System.Math.Round(integralValue);
        return roundedValue / factor;
    }
}