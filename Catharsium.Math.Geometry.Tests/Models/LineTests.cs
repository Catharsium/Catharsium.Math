using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Geometry.Tests.Models
{
    [TestClass]
    public class LineTests : TestFixture<Line>
    {
        #region

        [TestMethod]
        public void GetLength_ReturnsDistanceBetweenEndPoints()
        {
            var p = new Point(1, 2);
            var q = new Point(3, 4);

            var actual = this.Target = new Line(p, q);
            Assert.AreEqual(p.DistanceTo(q), actual);
        }

        #endregion

        #region DistanceTo

        [TestMethod]
        public void DistanceToPoint_HorizontalLine_PointOnLine_Returns0()
        {
            var reference = new Point(2, 0);
            this.Target = new Line(0, 0, 1, 0); 

            var actual = this.Target.DistanceTo(reference);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void DistanceToPoint_HorizontalLine_PointBelowLine_ReturnsVerticalDistance()
        {
            var verticalDistance = 2;
            var reference = new Point(0, verticalDistance); 
            this.Target = new Line(0, 0, 1, 0);

            var actual = this.Target.DistanceTo(reference);
            Assert.AreEqual(verticalDistance, actual);
        }


        [TestMethod]
        public void DistanceToPoint_VerticalLine_PointOnLine_Returns0()
        {
            var reference = new Point(0, 2);
            this.Target = new Line(0, 0, 0, 1);

            var actual = this.Target.DistanceTo(reference);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void DistanceToPoint_VerticalLine_PointRightOfLine_ReturnsHorizontalDistance()
        {
            var horizontalDistance = 2;
            var reference = new Point(horizontalDistance, 1);
            this.Target = new Line(0, 0, 0, 1);

            var actual = this.Target.DistanceTo(reference);
            Assert.AreEqual(horizontalDistance, actual);
        }


        [TestMethod]
        public void DistanceToPoint_DiagonalLine_PointOnLine_Returns0()
        {
            var step = 2;
            var reference = new Point(0 + step, 0 + step);
            this.Target = new Line(0, 0, 1, 1);

            var actual = this.Target.DistanceTo(reference);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void DistanceToPoint_DiagonalLine_OnPerpendicularLineThroughP_ReturnsPythagoras()
        {
            var reference = new Point(1, -1); 
            this.Target = new Line(0, 0, 1, 1);

            var actual = this.Target.DistanceTo(reference);
            Assert.AreEqual(System.Math.Sqrt(2), actual);
        }

        #endregion
    }
}
