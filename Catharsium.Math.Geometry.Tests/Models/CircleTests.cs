using Catharsium.Math.Geometry.Interfaces;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Math.Geometry.Tests.Models
{
    [TestClass]
    public class CircleTests : TestFixture<Circle>
    {
        #region GetCircumference

        [TestMethod]
        public void GetCircumference_ReturnsCircumferenceCalculatorGetCircumference()
        {
            var expected = 10;
            this.GetDependency<ICircumferenceCalculator>().GetCircumference(this.Target).Returns(expected);

            var actual = this.Target.GetCircumference();
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region GetArea

        [TestMethod]
        public void GetArea_ReturnsAreaCalculatorGetArea()
        {
            var expected = 10;
            this.GetDependency<IAreaCalculator>().GetArea(this.Target).Returns(expected);

            var actual = this.Target.GetArea();
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}