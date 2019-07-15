using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Models.ResultModels;
using SimplyBooks.Services.Genres;
using SimplyBooks.Web.Controllers.Genres;
using System.Collections.Generic;
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

        public class ListAllGenres : GenresControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_genres()
            {
                // Arrange
                var genres = new List<Genre>
                {
                    new Genre
                    {
                        Name = "Horror"
                    },
                    new Genre
                    {
                        Name = "Fantasy"
                    }
                };
                var result = new Result<IList<Genre>>(genres);
                GenreServiceMock
                    .Setup(x => x.ListAllGenresAsync())
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.ListAllGenres();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }

            [Fact]
            public void Should_return_result_with_error()
            {
                // Arrange
                var genres = new List<Genre>
                {
                    new Genre
                    {
                        Name = "Horror"
                    },
                    new Genre
                    {
                        Name = "Fantasy"
                    }
                };
                var result = new Result<IList<Genre>>();
                result.AddError("there was an error");
                GenreServiceMock
                    .Setup(x => x.ListAllGenresAsync())
                    .ReturnsAsync(result);

                // Act
                var requestResult = ControllerUnderTest.ListAllGenres();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult.Result);
                Assert.Same(result, okResult.Value);
            }
        }

        public class AddGenre : GenresControllerTest
        {
            [Fact]
            public async void Should_return_ok()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Horror"
                };
                var result = new Result();
                GenreServiceMock
                    .Setup(x => x.AddGenreAsync(genre))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.AddGenre(genre);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
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
            public async void Should_return_error_with_message()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Fantasy"
                };
                var result = new Result();
                result.AddError("there was an error");
                GenreServiceMock
                    .Setup(x => x.AddGenreAsync(genre))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.AddGenre(genre);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }
        }

        public class UpdateGenre : GenresControllerTest
        {
            [Fact]
            public async void Should_return_ok()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Sci Fi"
                };
                var result = new Result();
                GenreServiceMock
                    .Setup(x => x.UpdateGenreAsync(genre))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.UpdateGenre(genre);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
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
            public async void Should_return_error_with_message()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Where am I?"
                };
                var result = new Result();
                result.AddError("there was an error");
                GenreServiceMock
                    .Setup(x => x.UpdateGenreAsync(genre))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.UpdateGenre(genre);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }


        }
    }
}
