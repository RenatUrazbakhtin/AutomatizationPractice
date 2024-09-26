namespace Framework.Utils
{
    public class RandomGenerator
    {
        private static string chars = "ABCDE01234";
        private static Random random = new();

        public static string GetRandomText(int length = 10) => new(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
