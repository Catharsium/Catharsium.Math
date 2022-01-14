using Catharsium.Math.Geometry.Models;
namespace Catharsium.Math.Geometry.Interfaces;

public interface IAreaCalculator
{
    double GetArea(Circle c);
    double GetArea(Triangle t);
}