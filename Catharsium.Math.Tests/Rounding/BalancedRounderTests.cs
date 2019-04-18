using Catharsium.Math.Interfaces;
using Catharsium.Math.Rounding;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Catharsium.Math.Tests.Rounding
{
    [TestClass]
    public class BalancedRounderTests : TestFixture<BalancedRounder>
    {
        [TestMethod]
        public void PartitionedRounding_0Difference_DoesNotAddToNumbers()
        {
            var total = 30.00m;
            this.GetDependency<IPrecisionCalculator>().FindNumberOfDigits(total).Returns(2);
            var input = new[] {10.001m, 10.002m, 10.003m};

            var actual = this.Target.PartitionedRounding(input, total);
            Assert.AreEqual(10.00m, actual[0]);
            Assert.AreEqual(10.00m, actual[1]);
            Assert.AreEqual(10.00m, actual[2]);
        }


        [TestMethod]
        public void PartitionedRounding_1Difference_AddToNumberWithHighestRemainder()
        {
            var total = 30.01m;
            this.GetDependency<IPrecisionCalculator>().FindNumberOfDigits(total).Returns(2);
            var input = new[] { 10.001m, 10.002m, 10.003m };

            var actual = this.Target.PartitionedRounding(input, total);
            Assert.AreEqual(10.00m, actual[0]);
            Assert.AreEqual(10.00m, actual[1]);
            Assert.AreEqual(10.01m, actual[2]);
        }


        [TestMethod]
        public void PartitionedRounding_2Difference_AddToNumbersWithHighestRemainder()
        {
            var total = 30.02m;
            this.GetDependency<IPrecisionCalculator>().FindNumberOfDigits(total).Returns(2);
            var input = new[] { 10.001m, 10.002m, 10.003m };

            var actual = this.Target.PartitionedRounding(input, total);
            Assert.AreEqual(10.00m, actual[0]);
            Assert.AreEqual(10.01m, actual[1]);
            Assert.AreEqual(10.01m, actual[2]);
        }


        [TestMethod]
        public void PartitionedRounding_3Difference_AddToAllNumbers()
        {
            var total = 30.03m;
            this.GetDependency<IPrecisionCalculator>().FindNumberOfDigits(total).Returns(2);
            var input = new[] { 10.001m, 10.002m, 10.003m };

            var actual = this.Target.PartitionedRounding(input, total);
            Assert.AreEqual(10.01m, actual[0]);
            Assert.AreEqual(10.01m, actual[1]);
            Assert.AreEqual(10.01m, actual[2]);
        }


        [TestMethod]
        public void PartitionedRounding_LowerPrecision_IncreasesMostSignificantDigit()
        {
            var total = 31m;
            this.GetDependency<IPrecisionCalculator>().FindNumberOfDigits(total).Returns(0);
            var input = new[] { 10.001m, 10.002m, 10.003m };

            var actual = this.Target.PartitionedRounding(input, total);
            Assert.AreEqual(10m, actual[0]);
            Assert.AreEqual(10m, actual[1]);
            Assert.AreEqual(11m, actual[2]);
        }
    }
}