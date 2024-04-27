using System;
using System.Globalization;

namespace Meres3
{
    public struct MeasuredValue
    {
        public MeasuredValue(double value, Unit unit, double seconds)
        {
            Unit = unit;
            Value = value;
            Seconds = seconds;
        }

        public override string ToString()
        {
            var value = Value.ToString(CultureInfo.InvariantCulture);
            var seconds = Seconds.ToString(CultureInfo.InvariantCulture);
            return $"{value}, {seconds}\n";
        }

        public double Value { get; }
        public double Seconds { get; }
        public Unit Unit { get; }
    }
}