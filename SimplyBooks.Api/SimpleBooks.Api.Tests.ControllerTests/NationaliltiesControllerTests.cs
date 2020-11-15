using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Domain;
using SimplyBooks.Domain.QueryModels;
using SimplyBooks.Services.Nationalities;
using SimplyBooks.Web.Controllers.Nationalities;
using System.Net;
using Xunit;

namespace SimpleBooks.Api.Tests.ControllerTests.NationaliltiesControllerTests
{
    public class NationaliltiesControllerTests : TestBase<NationalitiesController, INationalityService>
    {
    }

    public class SelectList : NationaliltiesControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            ServiceMock
                .Setup(x => x.SelectList())
                .ReturnsAsync(It.IsAny<Result<NationalitySelectList>>);

            // Act
            var requestResult = await ControllerUnderTest.SelectList();

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }
    }

    public class AddNationality : NationaliltiesControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            var nationality = new Nationality();

            ServiceMock
                .Setup(x => x.AddNationalityAsync(nationality))
                .ReturnsAsync(It.IsAny<Result>);

            // Act
            var requestResult = await ControllerUnderTest.AddNationality(nationality);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void Should_return_bad_request()
        {
            // Act
            var requestResult = await ControllerUnderTest.AddNationality(null);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (requestResult.Result as BadRequestObjectResult).StatusCode);
        }
    }

    public class UpdateNationality : NationaliltiesControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            var nationality = new Nationality();

            ServiceMock
                .Setup(x => x.UpdateNationalityAsync(nationality))
                .ReturnsAsync(It.IsAny<Result>);

            // Act
            var requestResult = await ControllerUnderTest.UpdateNationality(nationality);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void Should_return_bad_request()
        {
            // Act
            var requestResult = await ControllerUnderTest.UpdateNationality(null);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (requestResult.Result as BadRequestObjectResult).StatusCode);
        }
    }
}
