using Catharsium.Math.Geometry.Calculators;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Geometry.Tests.Calculators.AreaCalculatorTests
{
    [TestClass]
    public class GetAreaCircleTests : TestFixture<AreaCalculator>
    {
        [TestMethod]
        public void GetArea_NoRadius_Returns0()
        {
            var circle = new Circle(0, 0, 0);
            var actual = this.Target.GetArea(circle);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void GetArea_LocationIsIrrelevant()
        {
            var reference = new Circle(0, 0, 2);
            var circle = new Circle(1, 2, reference.Radius);

            var expected = this.Target.GetArea(reference);
            var actual = this.Target.GetArea(circle);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void GetArea_Radius1_ReturnsPi()
        {
            var circle = new Circle(0, 0, 1);
            var actual = this.Target.GetArea(circle);
            Assert.AreEqual(System.Math.PI, actual);
        }
        

        [TestMethod]
        public void GetArea_RadiusX_ReturnsRadiusSquaredTimesPi()
        {
            var circle = new Circle(0, 0, 10);
            var actual = this.Target.GetArea(circle);
            Assert.AreEqual(System.Math.PI * circle.Radius * circle.Radius, actual);
        }
    }
}