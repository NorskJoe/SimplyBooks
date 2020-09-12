using Moq;
using SimplyBooks.Models;
using SimplyBooks.Services.Authors;
using SimplyBooks.Web.Controllers.Authors;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SimplyBooks.Models.QueryModels;
using SimplyBooks.Repository.Queries.Authors;
using Xunit;

namespace SimplyBooks.Tests.Controllers
{
    public class AuthorControllerTest
    {
        protected Mock<IAuthorsService> AuthorServiceMock { get; }
        protected AuthorsController ControllerUnderTest { get; }

        public AuthorControllerTest()
        {
            AuthorServiceMock = new Mock<IAuthorsService>();
            ControllerUnderTest = new AuthorsController(AuthorServiceMock.Object);
        }

        public class ListAllAuthors : AuthorControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_authors()
            {
                // Arrange
                var authors = new List<AuthorListItem>
                {
                    new AuthorListItem
                    {
                        Name = "Peter Piper",
                        Nationality =  "Austrian" 
                    },
                    new AuthorListItem
                    {
                        Name = "Spiderman",
                        Nationality = "American" 
                    }
                };
                var result = new Result<IList<AuthorListItem>>(authors);
                AuthorServiceMock
                    .Setup(x => x.ListAuthorsAsync())
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.ListAuthors();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }

            [Fact]
            public void Should_return_result_with_error()
            {
                // Arrange
                var authors = new List<AuthorListItem>
                {
                    new AuthorListItem
                    {
                        Name = "Peter Piper",
                        Nationality =  "Austrian" 
                    },
                    new AuthorListItem
                    {
                        Name = "Spiderman",
                        Nationality = "American" 
                    }
                };
                var result = new Result<IList<AuthorListItem>>();
                result.AddError("there was an error");
                AuthorServiceMock
                    .Setup(x => x.ListAllAuthorsAsync())
                    .ReturnsAsync(result);

                // Act
                var requestResult = ControllerUnderTest.ListAllAuthors();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult.Result);
                Assert.Same(result, okResult.Value);
            }
        }

        public class AddAuthor : AuthorControllerTest
        {
            [Fact]
            public async void Should_return_OK_with_author()
            {
                // Arrange
                var expectedAuthor = new Author
                {
                    Name = "Katherine Man",
                    Nationality = new Nationality { Name = "Mountains" }
                };
                var result = new Result();

                AuthorServiceMock
                    .Setup(x => x.AddAuthorAsync(expectedAuthor))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.AddAuthor(expectedAuthor);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }

            [Fact]
            public async void Should_return_bad_request()
            {
                // Arrange
                var author = new Author
                {
                    Name = "Matherine Kan",
                    Nationality = new Nationality { Name = "Springwood" }
                };
                ControllerUnderTest.ModelState.AddModelError("Key", "This doesn't look right");

                // Act
                var result = await ControllerUnderTest.AddAuthor(author);

                // Assert
                var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.IsType<SerializableError>(badRequestResult.Value);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var duplicateAuthor = new Author
                {
                    Name = "Katherine Man",
                    Nationality = new Nationality { Name = "Mountains" }
                };
                var result = new Result();
                result.AddError("there was an error");

                AuthorServiceMock
                    .Setup(x => x.AddAuthorAsync(duplicateAuthor))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.AddAuthor(duplicateAuthor);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }

        }

        public class UpdateAuthor : AuthorControllerTest
        {
            [Fact]
            public async void Should_return_OK()
            {
                // Arrange
                var expectedAuthor = new Author
                {
                    Name = "Katherine Man",
                    Nationality = new Nationality { Name = "Mountains" }
                };
                var result = new Result();
                AuthorServiceMock
                    .Setup(x => x.UpdateAuthorAsync(expectedAuthor))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.UpdateAuthor(expectedAuthor);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }

            [Fact]
            public async void Should_return_bad_request()
            {
                // Arrange
                var author = new Author
                {
                    Name = "Harry Potter",
                    Nationality = new Nationality { Name = "English" }
                };
                ControllerUnderTest.ModelState.AddModelError("Key", "There is an error");

                // Act
                var result = await ControllerUnderTest.UpdateAuthor(author);

                // Assert
                var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.IsType<SerializableError>(badRequestResult.Value);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var authorDoesNotExist = new Author
                {
                    Name = "Schrödinger's Cat",
                    Nationality = new Nationality { Name = "Austria" }
                };
                var result = new Result();
                result.AddError("there was an error");
                AuthorServiceMock
                    .Setup(x => x.UpdateAuthorAsync(authorDoesNotExist))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.UpdateAuthor(authorDoesNotExist);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }

        }
    }
}
