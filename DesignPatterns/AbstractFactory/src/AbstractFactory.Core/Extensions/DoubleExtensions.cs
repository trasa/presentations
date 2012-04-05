using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactory.Core.Extensions
{
    public static class DoubleExtensions
    {
        public static bool Between(this double number, double low, double high)
        {
            return low <= number && number <= high;
        }

        public static bool IsApproximatelyEqualTo(this double left, double right)
        {
            // note: not the System.Double.Epsilon.
            const double Epsilon = 0.1;
            return Math.Abs(left - right) < Epsilon;
        }
    }
}
