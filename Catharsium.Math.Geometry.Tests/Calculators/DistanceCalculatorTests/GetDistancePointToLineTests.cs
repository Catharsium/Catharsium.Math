using Catharsium.Math.Geometry.Calculators;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Geometry.Tests.Calculators.DistanceCalculatorTests
{
    [TestClass]
    public class GetDistancePointToLineTests : TestFixture<DistanceCalculator>
    {
        [TestMethod]
        public void GetDistanceLine_ReturnsDistanceToOnLine()
        {
            var reference = new Line {
                P = new Point(1, 2),
                Q = new Point(3, 4)
            };
            var point = new Point(5, 6);
            var expected = this.Target.GetDistance(reference, point);

            var actual = this.Target.GetDistance(point, reference);
            Assert.AreEqual(expected, actual);
        }
    }
}