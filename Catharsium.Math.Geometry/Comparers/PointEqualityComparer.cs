using System.Collections.Generic;

namespace Catharsium.Math.Geometry.Comparers
{
    public class PointEqualityComparer : IEqualityComparer<Point>
    {
        public bool Equals(Point p, Point q)
        {
            if (p == null || q == null) {
                return false;
            }

            return System.Math.Abs(p.X - q.X) < 0.0000001 && System.Math.Abs(p.Y - q.Y) < 0.0000001;
        }


        public int GetHashCode(Point obj)
        {
            return obj.GetHashCode();
        }
    }
}