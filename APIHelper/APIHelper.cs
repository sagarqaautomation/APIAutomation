using APIGeneric.Environment;
using Newtonsoft.Json;
using RestSharp;

namespace APIGeneric.APIGeneric
{
    public partial class APIHelper
    {
        public RestClient setUrl(string endpoint)
        {
            var url = Path.Combine(APIGenericEnvironment.baseURL, endpoint);
            return new RestClient(url);
        }

        public RestRequest createRequest(HttpVerbs httpverb, RestClient restClient, string body = null)
        {
            RestRequest restRequest = new();
            switch (httpverb)
            {
                case HttpVerbs.GET:
                    restRequest = new RestRequest(restClient.ToString(), Method.Get);
                    break;
                case HttpVerbs.POST:
                    restRequest = new RestRequest(restClient.ToString(), Method.Post);
                    restRequest.AddBody(body);
                    break;
                case HttpVerbs.PUT:
                    restRequest = new RestRequest(restClient.ToString(), Method.Put);
                    restRequest.AddBody(body);
                    break;
                case HttpVerbs.DELETE:
                    restRequest = new RestRequest(restClient.ToString(), Method.Delete);
                    break;
                default:
                    throw new Exception("No implementation found");
            }
            restRequest.AddHeader("Content-Type", "application/json");
            //restRequest.AddHeader("Token", "Bearer ");
            return restRequest;
        }

        public RestResponse executeRequest(RestClient restClient, RestRequest restRequest)
        {
            return restClient.Execute(restRequest);
        }

        public RestResponse executeAPIEndPoint(string endpoint, HttpVerbs httpverb, string body = null)
        {
            var restclient = setUrl(endpoint);
            var restRequest = createRequest(httpverb, restclient, body);
            return executeRequest(restclient, restRequest);

        }
        public string checkResponseContent(RestResponse restResponse)
        {
            Console.WriteLine(restResponse.Content);
            return restResponse.Content;
        }
    }
}



