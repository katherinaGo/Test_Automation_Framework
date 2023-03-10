using System.Net;
using Epam.TestAutomation.API.Controllers;
using Epam.TestAutomation.API.Models.RequestModels.Phone;
using Epam.TestAutomation.API.Models.SharedModels.Phone;
using Epam.TestAutomation.API.Models.ResponseModels.Phone;
using FluentAssertions;
using FluentAssertions.Execution;
using RestSharp;

namespace Epam.TestAutomation.API.Tests;

[TestFixture]
public class PhoneCreationTests
{
    private string phoneIdToDelete;

    [Test]
    public void CheckIfPossibleToAddNewPhoneObjectTest()
    {
        var phoneToCreate = new PhoneModel
        {
            name = "Google Pixel 6 pro",
            data = new PhoneData
            {
                price = 700,
                year = 2022
            }
        };

        var createdPhone = new PhoneController(new CustomRestClient()).AddPhone<Phone>(phoneToCreate).Phone;
        var receivedPhone = new PhoneController(new CustomRestClient()).GetPhone<Phone>(createdPhone.id).Phone;
        phoneIdToDelete = receivedPhone.id;
        var deletedPhone = new PhoneController(new CustomRestClient()).DeletePhone<RestResponse>(phoneIdToDelete);
        var isPhoneDeleted = new PhoneController(new CustomRestClient()).GetPhone<RestResponse>(phoneIdToDelete);

        using (new AssertionScope())
        {
            receivedPhone.Should().NotBeNull("Phone with id {createdPhone.id} was not created!");
            deletedPhone.Response.StatusCode.Should()
                .Be(HttpStatusCode.OK,
                    "Phone with '{phoneIdToDelete}' wasn't deleted. Status code: '{deletedPhone.Response.StatusCode}'");
            isPhoneDeleted.Response.StatusCode.Should().Be(HttpStatusCode.NotFound,
                "Status code doesn't correspond 404 when get deleted item.");
        }
    }

    [Test]
    public void CheckIfNewAddedPhoneHasNeededFieldsTest()
    {
        var phoneToCreate = new PhoneModel
        {
            name = "iPhone 14 Pro",
            data = new PhoneData
            {
                price = 1350,
                year = 2022,
                capacity = "128 GB"
            }
        };
        var createdPhone = new PhoneController(new CustomRestClient()).AddPhone<Phone>(phoneToCreate).Phone;
        var receivedPhone = new PhoneController(new CustomRestClient()).GetPhone<Phone>(createdPhone.id).Phone;
        phoneIdToDelete = receivedPhone.id;
        var deletedPhone = new PhoneController(new CustomRestClient()).DeletePhone<RestResponse>(phoneIdToDelete);
        var isPhoneDeleted = new PhoneController(new CustomRestClient()).GetPhone<RestResponse>(phoneIdToDelete);

        using (new AssertionScope())
        {
            receivedPhone.data.capacity.Should()
                .Be(createdPhone.data.capacity,
                    $"Phone with id {createdPhone.id} was not created or capacity differs from '{phoneToCreate.data.capacity}'!");
            deletedPhone.Response.StatusCode.Should()
                .Be(HttpStatusCode.OK,
                    $"Phone with '{phoneIdToDelete}' wasn't deleted. Status code: '{deletedPhone.Response.StatusCode}'");
            isPhoneDeleted.Response.StatusCode.Should()
                .Be(HttpStatusCode.NotFound,
                    "Status code doesn't correspond 404 when get deleted item.");
        }
    }

    [Test]
    public void CheckIfPossibleToUpdateExistingObjectTest()
    {
        var phone = new PhoneModel
        {
            name = "iPhone 14 Pro",
            data = new PhoneData
            {
                price = 1350,
                year = 2022,
                capacity = "128 GB",
                color = "gold"
            }
        };
        var createdPhone = new PhoneController(new CustomRestClient()).AddPhone<Phone>(phone).Phone;
        var receivedPhone = new PhoneController(new CustomRestClient()).GetPhone<Phone>(createdPhone.id).Phone;
        phoneIdToDelete = receivedPhone.id;
        phone.data.color = "purple";
        new PhoneController(new CustomRestClient()).UpdateExistingPhone<Phone>(receivedPhone.id, phone);
        receivedPhone = new PhoneController(new CustomRestClient()).GetPhone<Phone>(receivedPhone.id).Phone;
        var deletedPhone = new PhoneController(new CustomRestClient()).DeletePhone<RestResponse>(phoneIdToDelete);
        var isPhoneDeleted = new PhoneController(new CustomRestClient()).GetPhone<RestResponse>(phoneIdToDelete);

        using (new AssertionScope())
        {
            createdPhone.data.color.Should()
                .Be(receivedPhone.data.color, "Color field wasn't updated to the new one.");
            deletedPhone.Response.StatusCode.Should()
                .Be(HttpStatusCode.OK,
                    $"Phone with '{phoneIdToDelete}' wasn't deleted. Status code: '{deletedPhone.Response.StatusCode}'");
            isPhoneDeleted.Response.StatusCode.Should()
                .Be(HttpStatusCode.NotFound, "Status code doesn't correspond 404 when get deleted item.");
        }
    }
}