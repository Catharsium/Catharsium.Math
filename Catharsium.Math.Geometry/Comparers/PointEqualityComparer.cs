using Catharsium.Math.Geometry.Models;
using static System.Math;
namespace Catharsium.Math.Geometry.Comparers;

public class PointEqualityComparer : IEqualityComparer<Point>
{
    public bool Equals(Point p, Point q)
    {
        return p != null
            && q != null
            && Abs(p.X - q.X) < 0.0000001
            && Abs(p.Y - q.Y) < 0.0000001;
    }


    public int GetHashCode(Point obj)
    {
        return obj.GetHashCode();
    }
}