using RestSharp;

namespace Epam.TestAutomation.API.Controllers;

/// <summary>
/// Class that contains methods and resources for /v1 micro service
/// </summary>
public class BiblesController : BaseController
{
    public BiblesController(CustomRestClient client, string apiKey = "") : base(client, Service.Bibles, apiKey)
    {
    }

    public BiblesController(CustomRestClient client) : base(client, Service.Bibles, client._apiConfig.ApiKey)
    {
    }

    private const string AllBiblesResource = "/v1/bibles";
    private const string SingleBibleResource = "/v1/bibles/{0}";
    private const string AllAudioBiblesResource = "/v1/audio-bibles";
    private const string SingleAudioBibleResource = "/v1/audio-bibles/{0}";

    /// <summary>
    /// Request that receive all list of bibles
    /// </summary>
    /// <typeparam name="T"><see cref="AllBiblesModel"/></typeparam>
    /// <returns>response typeof <see cref="RestResponse"/> and <see cref="AllBiblesModel"/></returns>
    public (RestResponse Response, T Bibles) GetBibles<T>()
    {
        return Get<T>(AllBiblesResource);
    }

    /// <summary>
    /// Request that receive all list of audioBibles
    /// </summary>
    /// <typeparam name="T"><see cref="AllBiblesModel"/></typeparam>
    /// <returns>response typeof <see cref="RestResponse"/> and <see cref="AllBiblesModel"/></returns>
    public (RestResponse Response, T Bibles) GetAudioBibles<T>()
    {
        return Get<T>(AllAudioBiblesResource);
    }

    /// <summary>
    /// Request that receive one bible
    /// </summary>
    /// <typeparam name="T"><see cref="AllBiblesModel"/></typeparam>
    /// <returns>response typeof <see cref="RestResponse"/> and <see cref="AllBiblesModel"/></returns>
    public (RestResponse Response, T Bibles) GetBible<T>(string id)
    {
        return Get<T>(string.Format(SingleBibleResource, id));
    }

    /// <summary>
    /// Request that receive one audioBible
    /// </summary>
    /// <typeparam name="T"><see cref="AllBiblesModel"/></typeparam>
    /// <returns>response typeof <see cref="RestResponse"/> and <see cref="AllBiblesModel"/></returns>
    public (RestResponse Response, T Bibles) GetAudioBible<T>(string id)
    {
        return Get<T>(string.Format(SingleAudioBibleResource, id));
    }
}