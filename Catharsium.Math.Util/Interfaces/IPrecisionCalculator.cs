namespace Catharsium.Math.Util.Interfaces;

public interface IPrecisionCalculator
{
    int FindNumberOfDigits(decimal number);
    int FindNumberOfDigits(double number);
}