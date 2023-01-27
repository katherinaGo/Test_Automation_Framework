using Epam.TestAutomation.API.Models.RequestModels.Phone;
using Epam.TestAutomation.API.Models.ResponseModels.Phone;
using RestSharp;

namespace Epam.TestAutomation.API.Controllers;

/// <summary>
/// Class that contains methods and resources for /objects micro service
/// </summary>
public class PhoneController : BaseController
{
    public PhoneController(CustomRestClient client) : base(client, Service.Phones)
    {
    }

    private const string AllObjectsPhoneResource = "/objects";
    private const string SingleObjectPhoneResource = "/objects/{0}";
    private const string SingleObjectPhoneResourceWithParam = "/objects?id={0}";
    private const string AddObjectPhoneResource = "/objects";

    /// <summary>
    /// Request that receive all list of phones
    /// </summary>
    /// <typeparam name="T"><see cref="Phone"/></typeparam>
    /// <returns>response typeof <see cref="RestResponse"/> and <see cref="Phone"/></returns>
    public (RestResponse Response, T Phones) GetPhones<T>()
    {
        return Get<T>(AllObjectsPhoneResource);
    }

    /// <summary>
    /// Request that receive one phone
    /// </summary>
    /// <typeparam name="T"><see cref="Phone"/></typeparam>
    /// <returns>response typeof <see cref="RestResponse"/> and <see cref="Phone"/></returns>
    public (RestResponse Response, T Phone) GetPhone<T>(string phoneId)
    {
        return Get<T>(string.Format(SingleObjectPhoneResource, phoneId));
    }

    /// <summary>
    /// Request that receive one phone by ID with params
    /// </summary>
    /// <typeparam name="T"><see cref="Phone"/></typeparam>
    /// <returns>response typeof <see cref="RestResponse"/> and <see cref="Phone"/></returns>
    public (RestResponse Response, T Phone) GetPhoneWithParameterId<T>(string phoneId)
    {
        return Get<T>(string.Format(SingleObjectPhoneResourceWithParam, phoneId));
    }

    /// <summary>
    /// Request that create one phone
    /// </summary>
    /// <typeparam name="T"><see cref="Phone"/></typeparam>
    /// <returns>response typeof <see cref="RestResponse"/> and <see cref="Phone"/></returns>
    public (RestResponse Response, T Phone) AddPhone<T>(PhoneModel model)
    {
        return Post<T, PhoneModel>(AddObjectPhoneResource, model);
    }
}