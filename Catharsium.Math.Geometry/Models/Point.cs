using static System.Math;

namespace Catharsium.Math.Geometry.Models
{
    public class Point : Shape
    {
        #region Properties

        public double X { get; set; }
        public double Y { get; set; }

        #endregion

        #region Construction

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
            this.Id = "P";
        }


        public Point(double x, double y, string id) : this(x, y)
        {
            this.Id = id;
        }


        public Point(Point p) : this(p.X, p.Y, p.Id) { }

        #endregion

        public override string ToString()
        {
            return this.Id + ":[" + Round(this.X) + "," + Round(this.Y) + "]";
        }


        public string ToStringDouble()
        {
            return $"{this.Id}:[{this.X},{this.Y}]";
        }
    }
}