using Catharsium.Math.Geometry.Calculators;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Math;
namespace Catharsium.Math.Geometry.Tests.Calculators.DistanceCalculatorTests;

[TestClass]
public class GetDistanceLineToPointTests : TestFixture<DistanceCalculator>
{
    [TestMethod]
    public void GetDistance_HorizontalLine_PointOnLine_Returns0()
    {
        var reference = new Point(2, 0);
        var line = new Line {
            P = new Point(0, 0),
            Q = new Point(1, 0)
        };

        var actual = this.Target.GetDistance(line, reference);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void GetDistance_HorizontalLine_PointBelowLine_ReturnsVerticalDistance()
    {
        var verticalDistance = 2;
        var reference = new Point(0, verticalDistance);
        var line = new Line {
            P = new Point(0, 0),
            Q = new Point(1, 0)
        };

        var actual = this.Target.GetDistance(line, reference);
        Assert.AreEqual(verticalDistance, actual);
    }


    [TestMethod]
    public void GetDistance_VerticalLine_PointOnLine_Returns0()
    {
        var reference = new Point(0, 2);
        var line = new Line {
            P = new Point(0, 0),
            Q = new Point(0, 1)
        };

        var actual = this.Target.GetDistance(line, reference);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void GetDistance_VerticalLine_PointRightOfLine_ReturnsHorizontalDistance()
    {
        var horizontalDistance = 2;
        var reference = new Point(horizontalDistance, 1);
        var line = new Line {
            P = new Point(0, 0),
            Q = new Point(0, 1)
        };

        var actual = this.Target.GetDistance(line, reference);
        Assert.AreEqual(horizontalDistance, actual);
    }


    [TestMethod]
    public void GetDistance_DiagonalLine_PointOnLine_Returns0()
    {
        var step = 2;
        var reference = new Point(0 + step, 0 + step);
        var line = new Line {
            P = new Point(0, 0),
            Q = new Point(1, 1)
        };

        var actual = this.Target.GetDistance(line, reference);
        Assert.AreEqual(0, actual);
    }


    [TestMethod]
    public void GetDistance_DiagonalLine_OnPerpendicularLineThroughP_ReturnsPythagoras()
    {
        var reference = new Point(1, -1);
        var line = new Line {
            P = new Point(0, 0),
            Q = new Point(1, 1)
        };

        var actual = this.Target.GetDistance(line, reference);
        Assert.AreEqual(Sqrt(2), actual);
    }
}