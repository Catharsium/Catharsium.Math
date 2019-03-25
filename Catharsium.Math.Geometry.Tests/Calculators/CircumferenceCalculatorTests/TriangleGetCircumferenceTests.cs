using Catharsium.Math.Geometry.Calculators;
using Catharsium.Math.Geometry.Interfaces;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Math.Geometry.Tests.Calculators.CircumferenceCalculatorTests
{
    [TestClass]
    public class TriangleGetCircumferenceTests : TestFixture<CircumferenceCalculator>
    {
        [TestMethod]
        public void GetCircumference_ValidTriangle_ReturnsSumOfSidesLength()
        {
            var triangle = new Triangle(0, 1, 2, 3, 4, 5);
            this.GetDependency<IDistanceCalculator>().GetLength(Arg.Any<Line>()).Returns(1);

            var actual = this.Target.GetCircumference(triangle);
            Assert.AreEqual(3, actual);
        }
    }
}