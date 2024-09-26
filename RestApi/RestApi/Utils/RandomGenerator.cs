using RestApi.RestApi.Models.Posts;

namespace RestApi.RestApi.Utils
{
    public class RandomGenerator
    {
        private static string chars = "ABCDE01234";
        private static Random random => new();

        public static string GetRandomContent(int length = 5) => new(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());

        public static PostDataModel GetRandomPostAsModel(int userId) => new ()
        {
            Title = GetRandomContent(),
            Body = GetRandomContent(),
            UserId = userId
        };
    }
}