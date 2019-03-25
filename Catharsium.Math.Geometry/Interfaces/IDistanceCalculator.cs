using Catharsium.Math.Geometry.Models;

namespace Catharsium.Math.Geometry.Interfaces
{
    public interface IDistanceCalculator
    {
        double GetDistance(Point p, Point q);

        double GetDistance(Line l, Point p);
        double GetDistance(Point p, Line l);

        double GetLength(Line l);
    }
}