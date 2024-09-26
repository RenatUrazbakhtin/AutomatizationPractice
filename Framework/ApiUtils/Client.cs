using Framework.Managers;
using RestSharp;
using RestSharp.Authenticators;
using VkApi.Framework.Manager;

namespace Framework.ApiUtils
{
    public class Client
    {
        private static RestClientOptions Options = new(ConfigManager.ApiUrl)
        {
            Authenticator = new JwtAuthenticator(ApiConfigManager.Token),
        };

        protected RestClient clientObject = new(Options);
    }
}
