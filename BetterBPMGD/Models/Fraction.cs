namespace BetterBPMGD.Models
{
    public class Fraction : Common.Fraction
    {
        public Fraction(int numerator, int denominator) : base(numerator, denominator) { }

        public static Fraction? TryParse(string value)
        {
            string[] parts = value.Split('/');

            return new (int.Parse(parts[0]), int.Parse(parts[1]));
        }

        public override string? ToString() => $"{Numerator}/{Denominator}";
    }
}
