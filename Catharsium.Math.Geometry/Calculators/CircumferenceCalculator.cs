using Catharsium.Math.Geometry.Interfaces;
using Catharsium.Math.Geometry.Models;
using static System.Math;

namespace Catharsium.Math.Geometry.Calculators
{
    public class CircumferenceCalculator : ICircumferenceCalculator
    {
        private readonly IDistanceCalculator distanceCalculator;


        public CircumferenceCalculator(IDistanceCalculator distanceCalculator)
        {
            this.distanceCalculator = distanceCalculator;
        }


        public double GetCircumference(Circle circle)
        {
            return 2 * PI * circle.Radius;
        }


        public double GetCircumference(Triangle triangle)
        {
            return this.distanceCalculator.GetLength(triangle.GetLineA()) +
                   this.distanceCalculator.GetLength(triangle.GetLineB()) +
                   this.distanceCalculator.GetLength(triangle.GetLineC());
        }
    }
}