using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Domain.QueryModels;
using SimplyBooks.Services.Home;
using SimplyBooks.Web.Controllers.Home;
using System.Net;
using Xunit;

namespace SimpleBooks.Api.Tests.ControllerTests.HomeControllerTests
{
    public class HomeControllerTests : TestBase<HomeController, IHomeService>
    {
    }

    public class ListRecentBooks : HomeControllerTests
    {
        
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            ServiceMock
                .Setup(x => x.GetRecentBooks())
                .ReturnsAsync(It.IsAny<Result<RecentBooksList>>);

            // Act
            var requestResult = await ControllerUnderTest.ListRecentBooks();

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }
        
    }
}
