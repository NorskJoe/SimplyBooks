using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Services.Nationalities;
using SimplyBooks.Web.Controllers.Nationalities;
using System.Net;
using System.Net.Http;
using Xunit;

namespace SimplyBooks.Tests.Controllers
{
    public class NationalityControllerTest
    {
        protected Mock<INationalityService> NationalityServiceMock { get; }
        protected NationalitiesController ControllerUnderTest { get; }

        public NationalityControllerTest()
        {
            NationalityServiceMock = new Mock<INationalityService>();
            ControllerUnderTest = new NationalitiesController(NationalityServiceMock.Object);
        }

        public class AddNationality : NationalityControllerTest
        {
            [Fact]
            public async void Should_return_OK_with_nationality()
            {
                // Arrange
                var nationality = new Nationality
                {
                    Name = "England"
                };
                NationalityServiceMock
                    .Setup(x => x.AddNationalityAsync(nationality))
                    .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

                // Act
                var result = await ControllerUnderTest.AddNationality(nationality);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(nationality, okResult.Value);
            }

            [Fact]
            public async void Should_return_bad_request()
            {
                // Arrange
                var nationality = new Nationality
                {
                    Name = "China"
                };
                ControllerUnderTest.ModelState.TryAddModelError("key", "there is an error");


                // Act
                var result = await ControllerUnderTest.AddNationality(nationality);

                // Assert
                var badRequest = Assert.IsType<BadRequestObjectResult>(result);
                Assert.IsType<SerializableError>(badRequest.Value);
            }

            [Fact]
            public async void Should_return_conflict()
            {
                // Arrange
                var nationality = new Nationality
                {
                    Name = "Austria"
                };
                NationalityServiceMock
                    .Setup(x => x.AddNationalityAsync(nationality))
                    .ThrowsAsync(new EntityAlreadyExistsException(nationality.Name));

                // Act
                var result = await ControllerUnderTest.AddNationality(nationality);

                // Assert
                var conflictResult = Assert.IsType<ConflictObjectResult>(result);
                Assert.Equal($"'{nationality.Name}' already exists", conflictResult.Value);
            }
        }

        public class UpdateNationality : NationalityControllerTest
        {
            [Fact]
            public async void Should_return_OK_with_nationality()
            {
                // Arrange
                var nationality = new Nationality
                {
                    Name = "Lithuania"
                };
                NationalityServiceMock
                    .Setup(x => x.UpdateNationalityAsync(nationality))
                    .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

                // Act
                var result = await ControllerUnderTest.UpdateNationality(nationality);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(nationality, okResult.Value);
            }

            [Fact]
            public async void Should_return_not_found()
            {
                // Arrange
                var nationality = new Nationality
                {
                    Name = "Australia"
                };
                NationalityServiceMock
                    .Setup(x => x.UpdateNationalityAsync(nationality))
                    .ThrowsAsync(new EntityNotFoundException(nationality.Name));

                // Act
                var result = await ControllerUnderTest.UpdateNationality(nationality);

                // Assert
                var notFound = Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal($"'{nationality.Name}' could not be found", notFound.Value);
            }

            [Fact]
            public async void Should_return_bad_request()
            {
                // Arrange
                var nationality = new Nationality
                {
                    Name = "New Zealand"
                };
                ControllerUnderTest.ModelState.AddModelError("key", "some error");

                // Act
                var result = await ControllerUnderTest.UpdateNationality(nationality);

                // Assert
                var badRequest = Assert.IsType<BadRequestObjectResult>(result);
                Assert.IsType<SerializableError>(badRequest.Value);
            }

        }
    }
}
