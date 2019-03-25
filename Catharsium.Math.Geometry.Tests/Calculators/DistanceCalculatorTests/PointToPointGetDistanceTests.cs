using Catharsium.Math.Geometry.Calculators;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Geometry.Tests.Calculators.LengthCalculatorTests
{
    [TestClass]
    public class PointToPointGetDistanceTests : TestFixture<DistanceCalculator>
    {
        [TestMethod]
        public void GetDistance_HorizontalDifference_ReturnsDistance()
        {
            var distance = 2;
            var reference = new Point(0, 0);
            var point = new Point(reference.X + distance, reference.Y);

            var actual = this.Target.GetDistance(reference, point);
            Assert.AreEqual(distance, actual);
        }


        [TestMethod]
        public void GetDistance_VerticalDifference_ReturnsDistance()
        {
            var distance = 2;
            var reference = new Point(0, 0);
            var point = new Point(reference.X, reference.Y + distance);

            var actual = this.Target.GetDistance(reference, point);
            Assert.AreEqual(distance, actual);
        }


        [TestMethod]
        public void GetDistance_DiagonalDistance_ReturnsPythagoras()
        {
            var distance = 2;
            var reference = new Point(0, 0);
            var point = new Point(reference.X + distance, reference.Y + distance);

            var actual = this.Target.GetDistance(reference, point);
            Assert.AreEqual(System.Math.Sqrt((distance * distance) + (distance * distance)), actual);
        }


        [TestMethod]
        public void GetDistance_AngledDistance_ReturnsPythagoras()
        {
            var distanceX = 2;
            var distanceY = 2;
            var reference = new Point(0, 0);
            var point = new Point(reference.X + distanceX, reference.Y + distanceY);

            var actual = this.Target.GetDistance(reference, point);
            Assert.AreEqual(System.Math.Sqrt((distanceX * distanceX) + (distanceY * distanceY)), actual);
        }


        [TestMethod]
        public void GetDistance_PointToItself_Returns0()
        {
            var reference = new Point(0, 0);
            var point = new Point(reference.X, reference.Y);

            var actual = this.Target.GetDistance(reference, point);
            Assert.AreEqual(0, actual);
        }
    }
}