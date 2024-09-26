using RestSharp;

namespace Framework.ApiUtils
{
    public class ClientExecutions : Client
    {
        public RestResponse ExecutePost(string method, Dictionary<string, object> dict)
        {
            var request = GetRequestWithParameters(method, dict);
            return clientObject.Post(request);
        }

        public RestResponse ExecutePostWithFile(string url, string filePath, string fileName, string type)
        {
            return clientObject.Post(new RestRequest(url).AddFile(fileName, filePath, type));
        }

        public RestResponse ExecuteGet(string method, Dictionary<string, object> dict)
        {
            var request = GetRequestWithParameters(method, dict);
            return clientObject.Get(request);
        }

        public RestRequest GetRequestWithParameters(string method, Dictionary<string, object> parameters)
        {
            RestRequest request = new(method);
            foreach (var key in parameters.Keys)
            {
                request.AddParameter(key, parameters[key], ParameterType.GetOrPost);
            }

            return request;
        }
    }
}
