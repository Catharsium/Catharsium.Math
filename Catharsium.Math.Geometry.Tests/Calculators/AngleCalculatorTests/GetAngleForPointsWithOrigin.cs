using Catharsium.Math.Geometry.Calculators;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Catharsium.Math.Geometry.Tests.Calculators.AngleCalculatorTests;

[TestClass]
public class GetAngleForPointsWithOrigin : TestFixture<AngleCalculator>
{
    [TestMethod]
    public void GetAngle_Points_ReturnsAngleBetweenLinesThroughPointsAndOrigin()
    {
        var origin = new Point(-5, -6);
        var p = new Point(1, 2);
        var q = new Point(3, 4);

        var expected = this.Target.GetAngle(
            new Line { P = p, Q = q },
            new Line { P = p, Q = q }
        );
        var actual = this.Target.GetAngle(origin, p, q);
        Assert.AreEqual(expected, actual);
    }
}