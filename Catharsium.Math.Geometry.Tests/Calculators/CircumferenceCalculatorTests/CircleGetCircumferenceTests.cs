using Catharsium.Math.Geometry.Calculators;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Geometry.Tests.Calculators.CircumferenceCalculatorTests
{
    [TestClass]
    public class CircleGetCircumferenceTests : TestFixture<CircumferenceCalculator>
    {
        #region Fixture

        protected double Radius => 3;

        #endregion

        #region GetCircumference

        [TestMethod]
        public void GetCircumference_SingleRadius_Returns2Pi()
        {
            var circle = new Circle(0, 0, 1);
            var actual = this.Target.GetCircumference(circle);
            Assert.AreEqual(System.Math.PI * 2, actual);
        }


        [TestMethod]
        public void GetCircumference_AnyRadius_Returns2PiTimesRadius()
        {
            var circle = new Circle(0, 0, this.Radius);
            var actual = this.Target.GetCircumference(circle);
            Assert.AreEqual(System.Math.PI * 2 * circle.Radius, actual);
        }


        [TestMethod]
        public void GetCircumference_LocationDoesNotInfluencePerimeter()
        {
            var referenceCircle = new Circle(2, 2, this.Radius);
            var circle = new Circle(referenceCircle.Center, referenceCircle.Radius);

            var expected = this.Target.GetCircumference(referenceCircle);
            var actual = this.Target.GetCircumference(circle);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
