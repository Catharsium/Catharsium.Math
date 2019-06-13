using static System.Math;

namespace Catharsium.Math.Geometry.Models
{
    public class Circle : Shape
    {
        #region Properties

        private Point center;
        public Point Center
        {
            get => this.center;
            set => this.center = new Point(value);
        }


        public double Radius { get; set; }

        #endregion

        public override string ToString()
        {
            return $"{this.Id}:[{this.Center},{this.Radius}:{Round(this.Radius)}]";
        }
    }
}