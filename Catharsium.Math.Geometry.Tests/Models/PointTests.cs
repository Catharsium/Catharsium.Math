using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Geometry.Tests.Models
{
    [TestClass]
    public class PointTests : TestFixture<Point>
    {
        #region DistanceTo(Point)

        [TestMethod]
        public void DistanceToPoint_HorizontalDifference_ReturnsDistance()
        {
            var distance = 2;
            var reference = new Point(0, 0);
            this.Target = new Point(reference.X + distance, reference.Y);

            var actual = this.Target.DistanceTo(reference);
            Assert.AreEqual(distance, actual);
        }


        [TestMethod]
        public void DistanceToPoint_VerticalDifference_ReturnsDistance()
        {
            var distance = 2;
            var reference = new Point(0, 0);
            this.Target = new Point(reference.X, reference.Y + distance);

            var actual = this.Target.DistanceTo(reference);
            Assert.AreEqual(distance, actual);
        }


        [TestMethod]
        public void DistanceToPoint_DiagonalDistance_ReturnsPythagoras()
        {
            var distance = 2;
            var reference = new Point(0, 0);
            this.Target = new Point(reference.X + distance, reference.Y + distance);

            var actual = this.Target.DistanceTo(reference);
            Assert.AreEqual(System.Math.Sqrt((distance * distance) + (distance * distance)), actual);
        }


        [TestMethod]
        public void DistanceToPoint_AngledDistance_ReturnsPythagoras()
        {
            var distanceX = 2;
            var distanceY = 2;
            var reference = new Point(0, 0);
            this.Target = new Point(reference.X + distanceX, reference.Y + distanceY);

            var actual = this.Target.DistanceTo(reference);
            Assert.AreEqual(System.Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY)), actual);
        }


        [TestMethod]
        public void DistanceToPoint_Itself_Returns0()
        {
            var reference = new Point(0, 0);
            this.Target = new Point(reference.X, reference.Y);

            var actual = this.Target.DistanceTo(reference);
            Assert.AreEqual(0, actual);
        }

        #endregion

        #region DistanceTo(Line)

        [TestMethod]
        public void DistanceToLine_ReturnsDistanceToOnLine()
        {
            var reference = new Line(1, 2, 3, 4);
            this.Target = new Point(5, 6);

            var actual = this.Target.DistanceTo(reference);
            Assert.AreEqual(reference.DistanceTo(this.Target), actual);
        }

        #endregion
    }
}