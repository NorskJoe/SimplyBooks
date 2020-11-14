using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Api.Tests.Common.Extensions;
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

    public class ListAllAuthors : AuthorControllerTests
    {
        [Fact]
        public async void Should_return_ok_with_all_authors()
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
}
