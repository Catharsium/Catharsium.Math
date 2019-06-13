using Catharsium.Math.Geometry.Models;

namespace Catharsium.Math.Geometry.Interfaces
{
    public interface IAngleCalculator
    {
        double GetAngle(Line l1, Line l2);
    }
}