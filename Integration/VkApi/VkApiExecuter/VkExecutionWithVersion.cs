using Framework.ApiUtils;
using Framework.Managers;
using RestSharp;

namespace Integration.VkApi.VkApiExecuter
{
    public class VkExecutionWithVersion : ClientExecutions
    {
        protected const string version = "v";

        private RestRequest GetRequest(string method, Dictionary<string, object> parameters, bool IsVersion = true)
        {
            if (IsVersion)
            {
                return GetRequestWithParameters(method, parameters).AddParameter(version, ApiConfigManager.Version, ParameterType.GetOrPost);
            }
            else
            {
                return GetRequestWithParameters(method, parameters);
            }
        }

        public RestResponse ExecutePost(string method, Dictionary<string, object> parameters)
        {
            var request = GetRequest(method, parameters);
            return clientObject.Post(request);
        }

        public RestResponse ExecuteGet(string method, Dictionary<string, object> parameters)
        {
            var request = GetRequest(method, parameters);
            return clientObject.Get(request);
        }
    }
}
