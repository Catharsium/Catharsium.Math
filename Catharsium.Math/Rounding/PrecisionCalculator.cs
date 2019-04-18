using Catharsium.Math.Interfaces;

namespace Catharsium.Math
{
    public class PrecisionCalculator : IPrecisionCalculator
    {
        public int FindNumberOfDigits(decimal number)
        {
            var result = 0;
            while (number % 1 != 0)
            {
                number *= 10;
                result++;
            }

            return result;
        }


        public int FindNumberOfDigits(double number)
        {
            return this.FindNumberOfDigits((decimal)number);
        }
    }
}