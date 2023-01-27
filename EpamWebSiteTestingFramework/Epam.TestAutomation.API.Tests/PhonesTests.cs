using System.Net;
using Epam.TestAutomation.API.Controllers;
using Epam.TestAutomation.API.Models.RequestModels.Phone;
using Epam.TestAutomation.API.Models.ResponseModels.Phone;
using Epam.TestAutomation.API.Models.SharedModels.Phone;
using RestSharp;

namespace Epam.TestAutomation.API.Tests;

[TestFixture]
public class PhonesTests
{
    [Test]
    public void CheckAllPhonesResponseTest()
    {
        var response = new PhoneController(new CustomRestClient()).GetPhones<RestResponse>();
        Assert.That(response.Response.StatusCode, Is.EqualTo(HttpStatusCode.OK),
            "Invalid status code was returned while sending GET request to /objects");
    }

    [Test]
    public void CheckGetSinglePhoneFromResponseTest()
    {
        var phones = new PhoneController(new CustomRestClient()).GetPhones<List<Phone>>();
        var listOfPhones = phones.Phones.ToList();
        var receivedPhone = new PhoneController(new CustomRestClient())
            .GetPhoneWithParameterId<List<Phone>>(listOfPhones.Select(item => item.id).Last());

        Assert.That(listOfPhones.Last().id, Is.EqualTo(receivedPhone.Phone.First().id),
            "Last object from '/objects' request doesn't not equal to object from '/objects?id={0}', that was found by ID.");
    }

    [Test]
    public void CheckIfPossibleToAddNewPhoneObjectTest()
    {
        var phoneToCreate = new PhoneModel
        {
            name = "Samsung Galaxy A71",
            data = new PhoneData
            {
                price = 170,
                year = 2019
            }
        };

        var createdPhone = new PhoneController(new CustomRestClient()).AddPhone<Phone>(phoneToCreate).Phone;
        var receivedPhone = new PhoneController(new CustomRestClient()).GetPhone<Phone>(createdPhone.id).Phone;

        Assert.That(receivedPhone, Is.Not.Null, $"Phone with id {createdPhone.id} was not created!");
    }
}