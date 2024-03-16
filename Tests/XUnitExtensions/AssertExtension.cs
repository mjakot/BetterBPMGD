namespace XUnitExtensions
{
    public static class AssertExtension
    {
        public static void EqualSkip(string expected, string actual, int[] skip)
        {
            if (expected.Length != actual.Length) throw new ArgumentException("Strings must be of equal length for comparison with skipping.");

            for (int i = 0; i < expected.Length; i++)
                if (Array.IndexOf(skip, i) == -1)
                    Assert.Equal(expected[i], actual[i]);
        }

        public static void EqualSkip(string expected, string actual, int beginIndex, int endIndex)
        {
            if (expected.Length != actual.Length) throw new ArgumentException("Strings must be of equal length for comparison with skipping.");

            for (int i = 0; i < expected.Length; i++)
                if (i >= beginIndex && i < endIndex)
                    Assert.Equal(expected[i], actual[i]);
        }
    }
}
