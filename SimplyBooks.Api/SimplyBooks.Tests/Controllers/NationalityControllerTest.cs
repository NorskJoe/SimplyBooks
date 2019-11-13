using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using SimplyBooks.Services.Nationalities;
using SimplyBooks.Web.Controllers.Nationalities;
using System.Collections.Generic;
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

        public class ListAllNationalities : NationalityControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_nationalities()
            {
                // Arrange
                var nationalities = new List<Nationality>
                {
                    new Nationality
                    {
                        Name = "English",
                    },
                    new Nationality
                    {
                        Name = "Irish"
                    }
                };
                var result = new Result<IList<Nationality>>(nationalities);
                NationalityServiceMock
                    .Setup(x => x.ListAllNationalitiesAsync())
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.ListAllNationalities();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }

            [Fact]
            public void Should_return_result_with_error()
            {
                // Arrange
                var nationalities = new List<Nationality>
                {
                    new Nationality
                    {
                        Name = "English",
                    },
                    new Nationality
                    {
                        Name = "Irish"
                    }
                };
                var result = new Result<IList<Nationality>>();
                result.AddError("there was an error");
                NationalityServiceMock
                    .Setup(x => x.ListAllNationalitiesAsync())
                    .ReturnsAsync(result);

                // Act
                var requestResult = ControllerUnderTest.ListAllNationalities();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult.Result);
                Assert.Same(result, okResult.Value);
            }
        }

        public class AddNationality : NationalityControllerTest
        {
            [Fact]
            public async void Should_return_OK()
            {
                // Arrange
                var nationality = new Nationality
                {
                    Name = "England"
                };
                var result = new Result();
                NationalityServiceMock
                    .Setup(x => x.AddNationalityAsync(nationality))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.AddNationality(nationality);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
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
            public async void Should_return_error_with_message()
            {
                // Arrange
                var nationality = new Nationality
                {
                    Name = "Austria"
                };
                var result = new Result();
                result.AddError("there was an error");
                NationalityServiceMock
                    .Setup(x => x.AddNationalityAsync(nationality))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.AddNationality(nationality);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }
        }

        public class UpdateNationality : NationalityControllerTest
        {
            [Fact]
            public async void Should_return_OK()
            {
                // Arrange
                var nationality = new Nationality
                {
                    Name = "Lithuania"
                };
                var result = new Result();
                NationalityServiceMock
                    .Setup(x => x.UpdateNationalityAsync(nationality))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.UpdateNationality(nationality);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var nationality = new Nationality
                {
                    Name = "Australia"
                };
                var result = new Result();
                result.AddError("there was an error");
                NationalityServiceMock
                    .Setup(x => x.UpdateNationalityAsync(nationality))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.UpdateNationality(nationality);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
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
