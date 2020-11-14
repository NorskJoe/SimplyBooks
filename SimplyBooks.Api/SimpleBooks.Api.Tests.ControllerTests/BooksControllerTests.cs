using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Domain;
using SimplyBooks.Domain.QueryModels;
using SimplyBooks.Repository.Commands.Books;
using SimplyBooks.Repository.Queries.Books;
using SimplyBooks.Services.Books;
using SimplyBooks.Web.Controllers.Books;
using System.Net;
using Xunit;

namespace SimpleBooks.Api.Tests.ControllerTests.BookControllerTests
{
    public class BooksControllerTests : TestBase<BooksController, IBooksService>
    {
    }

    public class ListBooks : BooksControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            var criteria = new BookListCriteria();

            ServiceMock
                .Setup(x => x.ListBooksAsync(criteria))
                .ReturnsAsync(It.IsAny<Result<PagedResult<BookListItem>>>);

            // Act
            var requestResponse = await ControllerUnderTest.ListBooks(criteria);

            var temp = requestResponse.Result as OkObjectResult;

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResponse.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void Should_return_bad_request()
        {
            // Act
            var requestResult = await ControllerUnderTest.ListBooks(null);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (requestResult.Result as BadRequestObjectResult).StatusCode);
        }
    }

    public class GetBook : BooksControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            var criteria = new BookItemCriteria
            {
                BookId = 1
            };

            ServiceMock
                .Setup(x => x.GetBookAsync(criteria))
                .ReturnsAsync(It.IsAny<Result<BookItem>>);

            // Act
            var requestResult = await ControllerUnderTest.GetBook(criteria.BookId);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void Should_return_bad_request()
        {
            // Act
            var requestResult = await ControllerUnderTest.GetBook(0);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (requestResult.Result as BadRequestObjectResult).StatusCode);
        }
    }

    public class AddBook : BooksControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            var book = new Book();

            ServiceMock
                .Setup(x => x.AddBookAsync(book))
                .ReturnsAsync(It.IsAny<Result>);

            // Act
            var requestResult = await ControllerUnderTest.AddBook(book);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void Should_return_bad_request()
        {
            // Act
            var requestResult = await ControllerUnderTest.AddBook(null);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (requestResult.Result as BadRequestObjectResult).StatusCode);
        }
    }

    public class UpdateBook : BooksControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Arrange
            var book = new Book();

            ServiceMock
                .Setup(x => x.UpdateBookAsync(book))
                .ReturnsAsync(It.IsAny<Result>);

            // Act
            var requestResult = await ControllerUnderTest.UpdateBook(book);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void Should_return_bad_request()
        {
            // Act
            var requestResult = await ControllerUnderTest.UpdateBook(null);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (requestResult.Result as BadRequestObjectResult).StatusCode);
        }
    }

    public class DeleteBook : BooksControllerTests
    {
        [Fact]
        public async void Should_return_ok()
        {
            // Act
            var criteria = new DeleteBookCriteria
            {
                BookId = 1
            };

            ServiceMock
                .Setup(x => x.DeleteBookAsync(criteria))
                .ReturnsAsync(It.IsAny<Result>);

            // Act
            var requestResult = await ControllerUnderTest.DeleteBook(criteria.BookId);

            // Assert
            Assert.Equal((int)HttpStatusCode.OK, (requestResult.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async void Should_return_bad_request()
        {
            // Act
            var requestResult = await ControllerUnderTest.DeleteBook(0);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, (requestResult.Result as BadRequestObjectResult).StatusCode);
        }
    }
}
