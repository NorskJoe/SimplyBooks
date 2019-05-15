using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Services.Authors.Interfaces;
using SimplyBooks.Web.Controllers.Authors;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
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

                AuthorServiceMock
                    .Setup(x => x.AddAuthorAsync(expectedAuthor))
                    .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

                // Act
                var result = await ControllerUnderTest.AddAuthor(expectedAuthor);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(expectedAuthor, okResult.Value);
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
            public async void Should_return_conflict()
            {
                // Arrange
                var duplicateAuthor = new Author
                {
                    Name = "Katherine Man",
                    Nationality = new Nationality { Name = "Mountains" }
                };
                AuthorServiceMock
                    .Setup(x => x.AddAuthorAsync(duplicateAuthor))
                    .ThrowsAsync(new EntityAlreadyExistsException(duplicateAuthor.Name));

                // Act
                var result = await ControllerUnderTest.AddAuthor(duplicateAuthor);

                // Assert
                var conflictResult = Assert.IsType<ConflictObjectResult>(result);
                Assert.Equal($"'{duplicateAuthor.Name}' already exists in the database", conflictResult.Value);
            }

        }

        public class UpdateAuthor : AuthorControllerTest
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

                AuthorServiceMock
                    .Setup(x => x.UpdateAuthorAsync(expectedAuthor))
                    .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

                // Act
                var result = await ControllerUnderTest.UpdateAuthor(expectedAuthor);

                // Assert
                var createdResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(expectedAuthor, createdResult.Value);
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
            public async void Should_return_not_found()
            {
                // Arrange
                var authorDoesNotExist = new Author
                {
                    Name = "Schrödinger's Cat",
                    Nationality = new Nationality { Name = "Austria" }
                };
                AuthorServiceMock
                    .Setup(x => x.UpdateAuthorAsync(authorDoesNotExist))
                    .ThrowsAsync(new EntityNotFoundException(authorDoesNotExist.Name));

                // Act
                var result = await ControllerUnderTest.UpdateAuthor(authorDoesNotExist);

                // Assert
                var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal($"'{authorDoesNotExist.Name}' could not be found",
                    notFoundResult.Value);
            }

        }
    }
}
