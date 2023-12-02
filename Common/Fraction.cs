namespace Common
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

        public static implicit operator double(Fraction a) => a.Calculate();
    }
}
