﻿using Moq;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using SimplyBooks.Repository.Commands.Books;
using SimplyBooks.Repository.Queries.Books;
using SimplyBooks.Services.Books;
using System;
using System.Collections.Generic;
using System.Text;
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
        protected BasicBooksService ServiceUnderTest { get; }

        public BasicBooksServiceTest()
        {
            AddBookCommandMock = new Mock<IAddBookCommand>();
            DeleteBookCommandMock = new Mock<IDeleteBookCommand>();
            UpdateBookCommandMock = new Mock<IUpdateBookCommand>();
            GetBookQueryMock = new Mock<IGetBookQuery>();
            ListAllBooksQueryMock = new Mock<IListAllBooksQuery>();
            ServiceUnderTest = new BasicBooksService(AddBookCommandMock.Object,
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
            }
        }

        public class GetBookAsync : BasicBooksServiceTest
        {
            [Fact]
            public async void Should_return_ok()
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
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Some book",
                };
                var result = new Result<Book>(book);
                result.AddError("there was an error");
                GetBookQueryMock
                    .Setup(x => x.Execute(book.BookId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.GetBookAsync(book.BookId);

                // Assert
                Assert.Same(result, serviceResult);
            }
        }

        public class ListAllBooksAsync : BasicBooksServiceTest
        {
            [Fact]
            public async void Should_return_ok()
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
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Some book",
                };
                var result = new Result<Book>(book);
                result.AddError("there was an error");
                GetBookQueryMock
                    .Setup(x => x.Execute(book.BookId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.GetBookAsync(book.BookId);

                // Assert
                Assert.Same(result, serviceResult);
            }
        }
    }
}
