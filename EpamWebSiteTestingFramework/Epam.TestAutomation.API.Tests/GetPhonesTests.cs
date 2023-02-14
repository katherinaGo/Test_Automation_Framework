using System.Net;
using Epam.TestAutomation.API.Controllers;
using Epam.TestAutomation.API.Models.ResponseModels.Phone;
using FluentAssertions;
using RestSharp;

namespace Epam.TestAutomation.API.Tests;

[TestFixture]
public class GetPhonesTests
{
    [Test]
    public void CheckAllPhonesResponseTest()
    {
        var response = new PhoneController(new CustomRestClient()).GetPhones<RestResponse>();
        response.Response.StatusCode.Should()
            .Be(HttpStatusCode.OK, "Invalid status code was returned while sending GET request to /objects");
    }

    [Test]
    public void CheckGetSinglePhoneFromResponseTest()
    {
        var phones = new PhoneController(new CustomRestClient()).GetPhones<List<Phone>>();
        var listOfPhones = phones.Phones.ToList();
        var receivedPhone = new PhoneController(new CustomRestClient())
            .GetPhoneWithParameterId<List<Phone>>(listOfPhones.Select(item => item.id).Last());
        listOfPhones.Last().id.Should()
            .Be(receivedPhone.Phone.First().id,
                "Last object from '/objects' request doesn't not equal to object from '/objects?id={0}', that was found by ID.");
    }
}