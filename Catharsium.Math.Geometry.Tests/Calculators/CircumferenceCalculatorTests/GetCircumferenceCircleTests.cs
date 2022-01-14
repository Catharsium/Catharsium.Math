using Catharsium.Math.Geometry.Calculators;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Math;
namespace Catharsium.Math.Geometry.Tests.Calculators.CircumferenceCalculatorTests;

[TestClass]
public class GetCircumferenceCircleTests : TestFixture<CircumferenceCalculator>
{
    #region Fixture

    protected double Radius => 3;

    #endregion

    #region GetCircumference

    [TestMethod]
    public void GetCircumference_SingleRadius_Returns2Pi()
    {
        var circle = new Circle {
            Center = new Point(0, 0),
            Radius = 1
        };
        var actual = this.Target.GetCircumference(circle);
        Assert.AreEqual(PI * 2, actual);
    }


    [TestMethod]
    public void GetCircumference_AnyRadius_Returns2PiTimesRadius()
    {
        var circle = new Circle {
            Center = new Point(0, 0),
            Radius = this.Radius
        };
        var actual = this.Target.GetCircumference(circle);
        Assert.AreEqual(PI * 2 * circle.Radius, actual);
    }


    [TestMethod]
    public void GetCircumference_LocationDoesNotInfluencePerimeter()
    {
        var reference = new Circle {
            Center = new Point(0, 0),
            Radius = this.Radius
        };
        var circle = new Circle {
            Center = new Point(reference.Center.X + 2, reference.Center.Y + 2),
            Radius = reference.Radius
        };

        var expected = this.Target.GetCircumference(reference);
        var actual = this.Target.GetCircumference(circle);
        Assert.AreEqual(expected, actual);
    }

    #endregion
}