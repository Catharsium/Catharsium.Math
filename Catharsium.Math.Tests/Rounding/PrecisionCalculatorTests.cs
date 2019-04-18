using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Tests
{
    [TestClass]
    public class PrecisionCalculatorTests : TestFixture<PrecisionCalculator>
    {
        #region FindNumberOfDigits(decimal)

        [TestMethod]
        public void FindNumberOfDigits_NoDecimals_Returns0()
        {
            var actual = this.Target.FindNumberOfDigits(1m);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void FindNumberOfDigits_SingDecimal_Returns1()
        {
            var actual = this.Target.FindNumberOfDigits(1.1m);
            Assert.AreEqual(1, actual);
        }

        
        [TestMethod]
        public void FindNumberOfDigits_MultipleDecimals_ReturnsNumberOfDecimals()
        {
            var number = 1m;
            var expected = 10;
            for(var i = 0; i < expected; i++)
            {
                number /= 10;
            }

            var actual = this.Target.FindNumberOfDigits(number);
            Assert.AreEqual(expected, actual);
        }

        #endregion
        
        #region FindNumberOfDigits(double)

        [TestMethod]
        public void FindNumberOfDigits_DoubleWithMultipleDecimals_ReturnsNumberOfDecimals()
        {
            var number = 0.00001;
            var expected = this.Target.FindNumberOfDigits((decimal)number);

            var actual = this.Target.FindNumberOfDigits(number);
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}