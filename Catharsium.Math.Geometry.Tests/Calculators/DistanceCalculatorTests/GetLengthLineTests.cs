using Catharsium.Math.Geometry.Calculators;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Geometry.Tests.Calculators.DistanceCalculatorTests
{
    [TestClass]
    public class GetLengthLineTests : TestFixture<DistanceCalculator>
    {
        [TestMethod]
        public void GetLengthLine_ReturnsDistanceToOnLine()
        {
            var line = new Line {
                P = new Point(1, 2),
                Q = new Point(3, 4)
            };
            var expected = this.Target.GetDistance(line.P, line.Q);

            var actual = this.Target.GetLength(line);
            Assert.AreEqual(expected, actual);
        }
    }
}