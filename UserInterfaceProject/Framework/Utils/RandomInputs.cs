namespace UserInterfaceProject.Framework.FrameworkUtils
{
    public class RandomInputs
    {
        private static string chars = "ABCDE01234";
        private static Random random = new();

        public static string GetRandomPassword(int length = 10)
        {
            string password = new(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
            password += ".";

            return password;
        }

        public static string GetRandomEmail(int length = 5) => new(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());

        public static string GetRandomDomain(int length = 3) => new(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
