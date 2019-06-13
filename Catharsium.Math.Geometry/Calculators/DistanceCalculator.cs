using Catharsium.Math.Geometry.Interfaces;
using Catharsium.Math.Geometry.Models;
using static System.Math;

namespace Catharsium.Math.Geometry.Calculators
{
    public class DistanceCalculator : IDistanceCalculator
    {
        public double GetDistance(Point p, Point q)
        {
            var dx = Pow(p.X - q.X, 2);
            var dy = Pow(p.Y - q.Y, 2);
            return Sqrt(dx + dy);
        }


        public double GetDistance(Line l, Point p)
        {
            var v = l.ToVector();
            var r = new Point(-1 * v.Q.Y, v.Q.X);
            var x2 = r.X + p.X;
            var y2 = r.Y + p.Y;
            v = new Line {
                P = p,
                Q = new Point(x2, y2)
            };
            r = l.CutsWith(v);
            return this.GetDistance(r, v.P);
        }


        public double GetDistance(Point p, Line l)
        {
            return this.GetDistance(l, p);
        }


        public double GetLength(Line l)
        {
            return this.GetDistance(l.P, l.Q);
        }
    }
}