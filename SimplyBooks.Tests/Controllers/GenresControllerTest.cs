using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Services.Genres;
using SimplyBooks.Web.Controllers.Genres;
using System.Net;
using System.Net.Http;
using Xunit;

namespace SimplyBooks.Tests.Controllers
{
    public class GenresControllerTest
    {
        protected Mock<IGenresService> GenreServiceMock { get; }
        protected GenresController ControllerUnderTest { get; }

        public GenresControllerTest()
        {
            GenreServiceMock = new Mock<IGenresService>();
            ControllerUnderTest = new GenresController(GenreServiceMock.Object);
        }

        public class AddGenre : GenresControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_genre()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Horror"
                };
                GenreServiceMock
                    .Setup(x => x.AddGenreAsync(genre))
                    .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

                // Act
                var result = await ControllerUnderTest.AddGenre(genre);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(genre, okResult.Value);
            }

            [Fact]
            public async void Should_return_bad_request()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Blabber"
                };
                ControllerUnderTest.ModelState.AddModelError("key", "there is an error");

                // Act
                var result = await ControllerUnderTest.AddGenre(genre);

                // Assert
                var badRequest = Assert.IsType<BadRequestObjectResult>(result);
                Assert.IsType<SerializableError>(badRequest.Value);
            }

            [Fact]
            public async void Should_return_conflict()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Fantasy"
                };
                GenreServiceMock
                    .Setup(x => x.AddGenreAsync(genre))
                    .ThrowsAsync(new EntityAlreadyExistsException(genre.Name));

                // Act
                var result = await ControllerUnderTest.AddGenre(genre);

                // Assert
                var conflictResult = Assert.IsType<ConflictObjectResult>(result);
                Assert.Equal($"'{genre.Name}' already exists in the database", conflictResult.Value);
            }
        }

        public class UpdateGenre : GenresControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_genre()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Sci Fi"
                };
                GenreServiceMock
                    .Setup(x => x.UpdateGenreAsync(genre))
                    .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

                // Act
                var result = await ControllerUnderTest.UpdateGenre(genre);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(genre, okResult.Value);
            }

            [Fact]
            public async void Should_return_bad_request()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Poop"
                };
                ControllerUnderTest.ModelState.AddModelError("key", "poop is not a genre");

                // Act
                var result = await ControllerUnderTest.UpdateGenre(genre);

                // Assert
                var badRequest = Assert.IsType<BadRequestObjectResult>(result);
                Assert.IsType<SerializableError>(badRequest.Value);
            }

            [Fact]
            public async void Should_return_not_found()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Where am I?"
                };
                GenreServiceMock
                    .Setup(x => x.UpdateGenreAsync(genre))
                    .ThrowsAsync(new EntityNotFoundException(genre.Name));

                // Act
                var result = await ControllerUnderTest.UpdateGenre(genre);

                // Assert
                var notFound = Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal($"'{genre.Name}' could not be found", notFound.Value);
            }


        }
    }
}
