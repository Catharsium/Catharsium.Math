using Catharsium.Math.Geometry.Interfaces;
using Catharsium.Math.Geometry.Models;
using static System.Math;

namespace Catharsium.Math.Geometry.Calculators
{
    public class AngleCalculator : IAngleCalculator
    {
        public double GetAngle(Line l1, Line l2)
        {
            var radians = Atan2(l1.Q.Y - l1.P.Y, l1.Q.X - l1.P.X) - Atan2(l2.Q.Y - l2.P.Y, l2.Q.X - l2.P.X);
            return Abs(radians * 180 / PI);
        }
    }
}