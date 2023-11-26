using System;

namespace BetterBPMGD.Models
{
    public class Fraction
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        public double Calculate() => (double)Numerator / Denominator;

        public static Fraction? TryParse(string value)
        {
            string[] parts = value.Split('/');

            return new(int.Parse(parts[0]), int.Parse(parts[1]));
        }

        public override string? ToString() => $"{Numerator}/{Denominator}";

        public static implicit operator double(Fraction a) => a.Calculate();
    }
}
