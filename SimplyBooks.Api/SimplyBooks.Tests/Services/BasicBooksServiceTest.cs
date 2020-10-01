using Moq;
using SimplyBooks.Domain;
using SimplyBooks.Repository.Commands.Books;
using SimplyBooks.Repository.Queries.Books;
using SimplyBooks.Services.Books;
using System.Collections.Generic;
using System.Linq;
using SimplyBooks.Domain.QueryModels;
using Xunit;

namespace SimplyBooks.Tests.Services
{
    public class BasicBooksServiceTest
    {
        protected Mock<IAddBookCommand> AddBookCommandMock { get; }
        protected Mock<IDeleteBookCommand> DeleteBookCommandMock { get; }
        protected Mock<IUpdateBookCommand> UpdateBookCommandMock { get; }
        protected Mock<IGetBookQuery> GetBookQueryMock { get; }
        protected Mock<IListAllBooksQuery> ListAllBooksQueryMock { get; }
        protected BooksService ServiceUnderTest { get; }

        public BasicBooksServiceTest()
        {
            AddBookCommandMock = new Mock<IAddBookCommand>();
            DeleteBookCommandMock = new Mock<IDeleteBookCommand>();
            UpdateBookCommandMock = new Mock<IUpdateBookCommand>();
            GetBookQueryMock = new Mock<IGetBookQuery>();
            ListAllBooksQueryMock = new Mock<IListAllBooksQuery>();
            ServiceUnderTest = new BooksService(AddBookCommandMock.Object,
                UpdateBookCommandMock.Object,
                DeleteBookCommandMock.Object,
                GetBookQueryMock.Object,
                ListAllBooksQueryMock.Object);
        }

        public class AddBookAsync : BasicBooksServiceTest
        {
            [Fact]
            public async void Should_return_ok()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Some book",
                };
                var result = new Result();
                AddBookCommandMock
                    .Setup(x => x.Execute(book))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.AddBookAsync(book);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Some book",
                };
                var result = new Result();
                result.AddError("there was an error");
                AddBookCommandMock
                    .Setup(x => x.Execute(book))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.AddBookAsync(book);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult);
                Assert.Equal(result.Errors.First(), serviceResult.Errors.First());
            }
        }

        public class DeleteBookAsync : BasicBooksServiceTest
        {
            [Fact]
            public async void Should_return_ok()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Some book",
                };
                var result = new Result();
                DeleteBookCommandMock
                    .Setup(x => x.Execute(book.BookId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.DeleteBookAsync(book.BookId);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Some book",
                };
                var result = new Result();
                result.AddError("there was an error");
                DeleteBookCommandMock
                    .Setup(x => x.Execute(book.BookId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.DeleteBookAsync(book.BookId);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult);
                Assert.Equal(result.Errors.First(), serviceResult.Errors.First());
            }
        }

        public class UpdateBookAsync : BasicBooksServiceTest
        {
            [Fact]
            public async void Should_return_ok()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Some book",
                };
                var result = new Result();
                UpdateBookCommandMock
                    .Setup(x => x.Execute(book))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.UpdateBookAsync(book);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Some book",
                };
                var result = new Result();
                result.AddError("there was an error");
                UpdateBookCommandMock
                    .Setup(x => x.Execute(book))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.UpdateBookAsync(book);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult);
                Assert.Equal(result.Errors.First(), serviceResult.Errors.First());
            }
        }

        public class GetBookAsync : BasicBooksServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_book()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Some book",
                };
                var result = new Result<Book>(book);
                GetBookQueryMock
                    .Setup(x => x.Execute(book.BookId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.GetBookAsync(book.BookId);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult.Value);
                Assert.Same(book, serviceResult.Value);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Some book",
                };
                var result = new Result<Book>();
                result.AddError("there was an error");
                GetBookQueryMock
                    .Setup(x => x.Execute(book.BookId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.GetBookAsync(book.BookId);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.Null(serviceResult.Value);
                Assert.Equal(result.Errors.First(), serviceResult.Errors.First());
            }
        }

        public class ListAllBooksAsync : BasicBooksServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_books()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Some book"
                    },
                    new Book
                    {
                        Title = "Another book"
                    }
                };
                var result = new Result<IList<Book>>(books);
                ListAllBooksQueryMock
                    .Setup(x => x.Execute())
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListAllBooksAsync();

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult.Value);
                Assert.Same(books.FirstOrDefault(), serviceResult.Value.FirstOrDefault());
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Some book",
                };
                var result = new Result<Book>();
                result.AddError("there was an error");
                GetBookQueryMock
                    .Setup(x => x.Execute(book.BookId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.GetBookAsync(book.BookId);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.Null(serviceResult.Value);
                Assert.Equal(result.Errors.First(), serviceResult.Errors.First());
            }
        }
    }
}
