using Newtonsoft.Json;
using RestSharp;

namespace Epam.TestAutomation.API;

public class BaseController
{
    private readonly RestClient _restClient;

    protected BaseController(CustomRestClient client, Service service, string apiKey = "")
    {
        _restClient = client.CreateRestClient(service);
        if (service == Service.Bibles)
        {
            _restClient.AddDefaultHeader("api-key", apiKey);
        }
    }

    protected (RestResponse Response, T ResponseModel) Get<T>(string resource)
    {
        var request = new RestRequest(resource, Method.Get);
        var response = _restClient.ExecuteGet(request);

        return typeof(T) == typeof(RestResponse)
            ? (response, default)
            : (response, GetDeserializedView<T>(response));
    }

    protected (RestResponse Response, T ResponseModel) Post<T, TPayload>(string resource, TPayload? payload = null)
        where TPayload : class
    {
        var request = new RestRequest(resource, Method.Post);
        if (payload != null)
            request.AddJsonBody(payload);

        var response = _restClient.ExecutePost(request);
        return (typeof(T) == typeof(RestResponse))
            ? (response, default)
            : (response, GetDeserializedView<T>(response));
    }

    private T? GetDeserializedView<T>(RestResponse response)
    {
        return JsonConvert.DeserializeObject<T>(response.Content);
    }
}