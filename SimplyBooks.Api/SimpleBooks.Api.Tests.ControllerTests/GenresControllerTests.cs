using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Domain;
using SimplyBooks.Domain.QueryModels;
using SimplyBooks.Services.Genres;
using SimplyBooks.Web.Controllers.Genres;
using System.Net;
using Xunit;

namespace SimpleBooks.Api.Tests.ControllerTests.GenreControllerTests
{
    public class GenresControllerTests : TestBase<GenresController, IGenresService>
    {
    }

    public class SelectList : GenresControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            ServiceMock
                .Setup(x => x.SelectList())
                .ReturnsAsync(It.IsAny<Result<GenreSelectList>>);

            // Act
            var requestResult = await ControllerUnderTest.SelectList();

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }
    }

    public class AddGenre : GenresControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            var genre = new Genre();

            ServiceMock
                .Setup(x => x.AddGenreAsync(genre))
                .ReturnsAsync(It.IsAny<Result>);

            // Act
            var requestResult = await ControllerUnderTest.AddGenre(genre);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void Should_return_bad_request()
        {
            // Act
            var requestResult = await ControllerUnderTest.AddGenre(null);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (requestResult.Result as BadRequestObjectResult).StatusCode);
        }
    }

    public class UpdateGenre : GenresControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            var genre = new Genre();

            ServiceMock
                .Setup(x => x.UpdateGenreAsync(genre))
                .ReturnsAsync(It.IsAny<Result>); ;

            // Act
            var requestResult = await ControllerUnderTest.UpdateGenre(genre);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void Should_return_bad_request()
        {
            // Act
            var requestResult = await ControllerUnderTest.UpdateGenre(null);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (requestResult.Result as BadRequestObjectResult).StatusCode);
        }
    }
}
