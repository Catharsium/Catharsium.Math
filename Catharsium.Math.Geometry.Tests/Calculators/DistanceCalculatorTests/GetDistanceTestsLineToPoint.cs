using Catharsium.Math.Geometry.Calculators;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Geometry.Tests.Calculators.DistanceCalculatorTests
{
    [TestClass]
    public class GetDistanceTestsLineToPoint  : TestFixture<DistanceCalculator>
    {
        #region GetDistance(Line, Point)

        [TestMethod]
        public void GetDistance_HorizontalLine_PointOnLine_Returns0()
        {
            var reference = new Point(2, 0);
            var line = new Line(0, 0, 1, 0);

            var actual = this.Target.GetDistance(line, reference);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void GetDistance_HorizontalLine_PointBelowLine_ReturnsVerticalDistance()
        {
            var verticalDistance = 2;
            var reference = new Point(0, verticalDistance);
            var line = new Line(0, 0, 1, 0);

            var actual = this.Target.GetDistance(line, reference);
            Assert.AreEqual(verticalDistance, actual);
        }


        [TestMethod]
        public void GetDistance_VerticalLine_PointOnLine_Returns0()
        {
            var reference = new Point(0, 2);
            var line = new Line(0, 0, 0, 1);

            var actual = this.Target.GetDistance(line, reference);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void GetDistance_VerticalLine_PointRightOfLine_ReturnsHorizontalDistance()
        {
            var horizontalDistance = 2;
            var reference = new Point(horizontalDistance, 1);
            var line = new Line(0, 0, 0, 1);

            var actual = this.Target.GetDistance(line, reference);
            Assert.AreEqual(horizontalDistance, actual);
        }


        [TestMethod]
        public void GetDistance_DiagonalLine_PointOnLine_Returns0()
        {
            var step = 2;
            var reference = new Point(0 + step, 0 + step);
            var line = new Line(0, 0, 1, 1);

            var actual = this.Target.GetDistance(line, reference);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void GetDistance_DiagonalLine_OnPerpendicularLineThroughP_ReturnsPythagoras()
        {
            var reference = new Point(1, -1);
            var line = new Line(0, 0, 1, 1);

            var actual = this.Target.GetDistance(line, reference);
            Assert.AreEqual(System.Math.Sqrt(2), actual);
        }

        #endregion

        #region GetDistance(Point, Line)

        [TestMethod]
        public void GetDistanceine_ReturnsDistanceToOnLine()
        {
            var reference = new Line(1, 2, 3, 4);
            var point = new Point(5, 6);

            var actual = this.Target.GetDistance(point, reference);
            Assert.AreEqual(this.Target.GetDistance(reference, point), actual);
        }

        #endregion
    }
}