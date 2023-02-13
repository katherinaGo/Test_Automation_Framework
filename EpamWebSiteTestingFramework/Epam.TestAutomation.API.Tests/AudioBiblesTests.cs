using System.Net;
using Epam.TestAutomation.API.Controllers;
using RestSharp;
using AllBiblesModel = Epam.TestAutomation.API.Models.ResponseModels.Bible.AllBiblesModel;

namespace Epam.TestAutomation.API.Tests;

[TestFixture]
public class AudioBiblesTests
{
    [Test]
    public void CheckAllAudioBiblesResponseTest()
    {
        var response = new BiblesController(new CustomRestClient()).GetAudioBibles<RestResponse>();
        Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            "Invalid status code was returned while sending GET request to /v1/audio-bibles!");
    }

    [Test]
    public void CheckSingleAudioBibleResponseTest()
    {
        var bibles = new BiblesController(new CustomRestClient()).GetBibles<AllBiblesModel>().Bibles.data;
        var response = new BiblesController(new CustomRestClient()).GetAudioBible<RestResponse>(bibles.First().id);
        Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            "Invalid status code was returned while sending GET request to /v1/audio-bibles/{0}!");
    }

    [Test]
    public void CheckAllAudioBiblesResponseWithoutAuthTest()
    {
        var response = new BiblesController(new CustomRestClient(), string.Empty).GetAudioBibles<RestResponse>();
        Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized),
            "Invalid status code was returned while sending GET request to /v1/audio-bibles without authorization!");
    }
}