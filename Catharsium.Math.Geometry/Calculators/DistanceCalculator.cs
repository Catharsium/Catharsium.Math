using Catharsium.Math.Geometry.Interfaces;

namespace Catharsium.Math.Geometry.Calculators
{
    public class DistanceCalculator : IDistanceCalculator
    {
        public double GetDistance(Point p, Point q)
        {
            var dx = System.Math.Pow(p.X - q.X, 2);
            var dy = System.Math.Pow(p.Y - q.Y, 2);
            return System.Math.Sqrt(dx + dy);
        }


        public double GetDistance(Line l, Point p)
        {
            var v = l.ToVector();
            var r = new Point(-1 * v.Q.Y, v.Q.X);
            var x2 = r.X + p.X;
            var y2 = r.Y + p.Y;
            v = new Line(p, new Point(x2, y2));
            r = l.CutsWith(v);
            return this.GetDistance(r, v.P);
        }


        public double GetDistance(Point p, Line l)
        {
            return this.GetDistance(l, p);
        }


        public double GetLength(Line l)
        {
            throw new System.NotImplementedException();
        }
    }
}