using System.Net;
using Epam.TestAutomation.API.Controllers;
using FluentAssertions;
using RestSharp;
using AllBiblesModel = Epam.TestAutomation.API.Models.ResponseModels.Bible.AllBiblesModel;

namespace Epam.TestAutomation.API.Tests;

[TestFixture]
public class BiblesTests
{
    [Test]
    public void CheckAllBiblesResponseWithValidParams()
    {
        var response = new BiblesController(new CustomRestClient()).GetBibles<RestResponse>();
        response.Response.StatusCode.Should()
            .Be(HttpStatusCode.OK,
                "Invalid status code was returned while sending GET request to /v1/bibles!");
    }

    [Test]
    public void CheckAllBiblesResponseWithoutAuthorization()
    {
        var response = new BiblesController(new CustomRestClient(), string.Empty).GetBibles<RestResponse>();
        response.Response.StatusCode.Should()
            .Be(HttpStatusCode.Unauthorized,
                "Invalid status code was returned while sending GET request to /v1/bibles without authorization!");
    }

    [Test]
    public void CheckAllBiblesResponseReturnObject()
    {
        var response = new BiblesController(new CustomRestClient()).GetBibles<AllBiblesModel>();
        response.Bibles.data.Any().Should().BeTrue("GET request to /v1/bibles should return any object!");
    }

    [Test]
    public void CheckSingleBibleResponseWithValidParams()
    {
        var bibles = new BiblesController(new CustomRestClient()).GetBibles<AllBiblesModel>().Bibles.data;
        var response = new BiblesController(new CustomRestClient()).GetBible<RestResponse>(bibles.First().id);
        response.Response.StatusCode.Should()
            .Be(HttpStatusCode.OK,
                "Invalid status code was returned while sending GET request to /v1/bibles{id}!");
    }
}