using Catharsium.Math.Geometry.Models;

namespace Catharsium.Math.Geometry.Interfaces
{
    public interface ICircumferenceCalculator
    {
        double GetCircumference(Circle circle);
        double GetCircumference(Triangle triangle);
    }
}