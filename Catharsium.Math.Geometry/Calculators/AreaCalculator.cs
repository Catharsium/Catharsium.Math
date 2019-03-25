using System;
using Catharsium.Math.Geometry.Interfaces;
using Catharsium.Math.Geometry.Models;

namespace Catharsium.Math.Geometry.Calculators
{
    public class AreaCalculator : IAreaCalculator
    {
        private readonly ICircumferenceCalculator circumferenceCalculator;
        private readonly IDistanceCalculator distanceCalculator;

        public AreaCalculator(ICircumferenceCalculator circumferenceCalculator, IDistanceCalculator distanceCalculator)
        {
            this.circumferenceCalculator = circumferenceCalculator;
            this.distanceCalculator = distanceCalculator;
        }


        public double GetArea(Circle c)
        {
            return System.Math.PI * System.Math.Pow(c.Radius, 2);
        }


        public double GetArea(Triangle t)
        {
            throw new NotImplementedException();
            // O^2 = s * (s - a) * (s - b) * (s - c)
            var s = this.circumferenceCalculator.GetCircumference(t) / 2;
            return System.Math.Sqrt(s * (s - this.distanceCalculator.GetLength(t.GetLineA())) *
                                    (s - this.distanceCalculator.GetLength(t.GetLineB())) * (s - this.distanceCalculator.GetLength(t.GetLineC())));
        }
    }
}