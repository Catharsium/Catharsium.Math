using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Geometry.Tests.Models
{
    [TestClass]
    public class CircleTests : TestFixture<Circle>
    {
        #region Fixture

        protected double Radius => 3;

        #endregion

        #region GetPerimeter

        [TestMethod]
        public void GetPerimeter_SingleRadius_Returns2Pi()
        {
            this.Target = new Circle(0, 0, 1);
            var actual = this.Target.GetPerimeter();
            Assert.AreEqual(System.Math.PI * 2, actual);
        }


        [TestMethod]
        public void GetPerimeter_AnyRadius_Returns2PiTimesRadius()
        {
            this.Target = new Circle(0, 0, this.Radius);
            var actual = this.Target.GetPerimeter();
            Assert.AreEqual(System.Math.PI * 2 * this.Target.Radius, actual);
        }


        [TestMethod]
        public void GetPerimeter_LocationDoesNotInfluencePerimeter()
        {
            var referenceCircle = new Circle(2, 2, this.Radius);
            this.Target = new Circle(referenceCircle.Center, referenceCircle.Radius);

            var expected = referenceCircle.GetPerimeter();
            var actual = this.Target.GetPerimeter();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetArea

        [TestMethod]
        public void GetArea_SingleRadius_ReturnsPi()
        {
            this.Target = new Circle(0, 0, 1);
            var actual = this.Target.GetArea();
            Assert.AreEqual(System.Math.PI, actual);
        }


        [TestMethod]
        public void GetArea_AnyRadius_ReturnsPiTimesRadiusTimesRadius()
        {
            this.Target = new Circle(0, 0, this.Radius);
            var actual = this.Target.GetArea();
            Assert.AreEqual(System.Math.PI * this.Radius * this.Radius, actual);
        }


        [TestMethod]
        public void GetArea_LocationDoesNotInfluenceArea()
        {
            var referenceCircle = new Circle(2, 2, this.Radius);
            this.Target = new Circle(referenceCircle.Center, referenceCircle.Radius);

            var expected = referenceCircle.GetArea();
            var actual = this.Target.GetArea();
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}