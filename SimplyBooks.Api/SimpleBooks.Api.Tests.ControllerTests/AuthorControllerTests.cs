using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Api.Tests.Common.Extensions;
using SimplyBooks.Domain;
using SimplyBooks.Domain.QueryModels;
using SimplyBooks.Repository.Queries.Authors;
using SimplyBooks.Services.Authors;
using SimplyBooks.Web.Controllers.Authors;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace SimpleBooks.Api.Tests.ControllerTests
{
    public class AuthorControllerTests : TestBase<AuthorsController, IAuthorsService>
    {

    }

    public class ListAuthors : AuthorControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            var criteria = new AuthorListCriteria();

            ServiceMock
                .Setup(x => x.ListAuthorsAsync(criteria))
                .ReturnsAsync(It.IsAny<Result<PagedResult<AuthorListItem>>>); 

            // Act
            var requestResult = await ControllerUnderTest.ListAuthors(criteria);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void Should_return_bad_request_when_no_criteria()
        {
            // Act
            var requestResult = await ControllerUnderTest.ListAuthors(null);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (requestResult.Result as BadRequestObjectResult).StatusCode);
        }
    }

    public class SelectList : AuthorControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            ServiceMock
                .Setup(x => x.SelectList())
                .ReturnsAsync(It.IsAny<Result<AuthorSelectList>>);

            // Act
            var requestResult = await ControllerUnderTest.SelectList();

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }
    }

    public class AddAuthor : AuthorControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            var author = new Author();

            ServiceMock
                .Setup(x => x.AddAuthorAsync(author))
                .ReturnsAsync(It.IsAny<Result>);

            // Act
            var requestResponse = await ControllerUnderTest.AddAuthor(author);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResponse.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void Should_return_bad_request()
        {
            // Act
            var requestResponse = await ControllerUnderTest.AddAuthor(null);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (requestResponse.Result as BadRequestObjectResult).StatusCode);
        }
    }

    public class UpdateAuthor : AuthorControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            var author = new Author();

            ServiceMock
                .Setup(x => x.UpdateAuthorAsync(author))
                .ReturnsAsync(It.IsAny<Result>);

            // Act
            var requestResult = await ControllerUnderTest.UpdateAuthor(author);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void Should_return_bad_request()
        {
            // Act 
            var requestResult = await ControllerUnderTest.UpdateAuthor(null);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (requestResult.Result as BadRequestObjectResult).StatusCode);
        }
    }
}
