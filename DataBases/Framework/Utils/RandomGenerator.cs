namespace DataBases.Framework.Utils
{
    public class RandomGenerator
    {
        private static Random random = new();

        public static string GetRandomNumber(int numberLength = 2)
        {
            var number = random.Next(1, 10);
            var fullNumber = string.Empty;
            for (int i = 0; i < numberLength; i++)
            {
                fullNumber += number;
            }
            return fullNumber;
        }
    }
}
