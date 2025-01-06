using System;


namespace Calculator
{
    internal class Calculate
    {
        public double add(double a, double b)
        {
            return (a + b);
        }

        public double subtract(double a, double b)
        {
            return (a - b);
        }

        public double multiply(double a, double b)
        {
            return (a * b);
        }

        public double divide(double a, double b)
        {
            return (a / b);
        }

        public double power(double baseValue, double exponent)
        {
            return Math.Pow(baseValue, exponent);
        }


    }
}
