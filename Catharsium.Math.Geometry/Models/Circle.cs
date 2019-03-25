using System;
using Catharsium.Math.Geometry.Interfaces;

namespace Catharsium.Math.Geometry.Models
{
    public class Circle : Shape
    {
        private readonly IAreaCalculator areaCalculator;
        private readonly ICircumferenceCalculator circumferenceCalculator;


        public Circle(IAreaCalculator areaCalculator, ICircumferenceCalculator circumferenceCalculator)
        {
            this.areaCalculator = areaCalculator;
            this.circumferenceCalculator = circumferenceCalculator;
        }


        #region Properties

        private Point center;

        public Point Center {
            get => this.center;
            set => this.center = new Point(value);
        }


        public double Radius { get; set; }

        #endregion

        #region Mathematical Properties

        public double GetCircumference()
        {
            return this.circumferenceCalculator.GetCircumference(this);
        }


        public double GetArea()
        {
            return this.areaCalculator.GetArea(this);
        }

        #endregion

        public override string ToString()
        {
            return $"{this.Id}:[{this.Center},{this.Radius}:{System.Math.Round(this.Radius)}]";
        }
    }
}