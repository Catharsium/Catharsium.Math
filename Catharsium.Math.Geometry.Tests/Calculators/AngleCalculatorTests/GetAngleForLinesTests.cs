using Catharsium.Math.Geometry.Calculators;
using Catharsium.Math.Geometry.Models;
using Catharsium.Util.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catharsium.Math.Geometry.Tests.Calculators.AngleCalculatorTests
{
    [TestClass]
    public class GetAngleForLinesTests : TestFixture<AngleCalculator>
    {
        [TestMethod]
        public void GetAngle_LineAndItself_Returns0()
        {
            var line1 = new Line {
                P = new Point(1, 2),
                Q = new Point(3, 4)
            };

            var actual = this.Target.GetAngle(line1, line1);
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void GetAngle_HorizontalAndVerticalLine_Returns90()
        {
            var line1 = new Line {
                P = new Point(0, 0),
                Q = new Point(1, 0)
            };
            var line2 = new Line {
                P = new Point(0, 0),
                Q = new Point(0, 1)
            };

            var actual = this.Target.GetAngle(line1, line2);
            Assert.AreEqual(90, actual);
        }


        [TestMethod]
        public void GetAngle_HorizontalAnd45DegreeLine_Returns45()
        {
            var line1 = new Line {
                P = new Point(0, 0),
                Q = new Point(1, 0)
            };
            var line2 = new Line {
                P = new Point(0, 0),
                Q = new Point(1, 1)
            };

            var actual = this.Target.GetAngle(line1, line2);
            Assert.AreEqual(45, actual);
        }


        [TestMethod]
        public void GetAngle_VerticalAnd45DegreeLine_Returns45()
        {
            var line1 = new Line {
                P = new Point(0, 0),
                Q = new Point(0, 1)
            };
            var line2 = new Line {
                P = new Point(0, 0),
                Q = new Point(1, 1)
            };

            var actual = this.Target.GetAngle(line1, line2);
            Assert.AreEqual(45, actual);
        }
    }
}