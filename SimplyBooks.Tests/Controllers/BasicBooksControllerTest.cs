using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Services.Books.Interfaces;
using SimplyBooksApi.Controllers.Books;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace SimplyBooks.Tests.Controllers
{
    public class BasicBooksControllerTest
    {
        protected Mock<IBasicBooksService> BasicBookServiceMock { get; }
        protected BasicBooksController ControllerUnderTest { get; }
        protected Genre TestGenreOne { get; }
        protected Genre TestGenreTwo { get; }
        protected Author TestAuthorOne { get; }
        protected Author TestAuthorTwo { get; }

        public BasicBooksControllerTest()
        {
            BasicBookServiceMock = new Mock<IBasicBooksService>();
            ControllerUnderTest = new BasicBooksController(BasicBookServiceMock.Object);

            TestGenreOne = new Genre
            {
                Name = "Fantasy"
            };
            TestGenreTwo = new Genre
            {
                Name = "Erotica"
            };

            TestAuthorOne = new Author
            {
                Name = "Harvey Norman",
                Nationality = new Nationality { Name = "Australia" }
            };
            TestAuthorTwo = new Author
            {
                Name = "Lemmings",
                Nationality = new Nationality { Name = "Norway" }
            };
        }

        public class ListAllBooks : BasicBooksControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_books()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Harry Potter",
                        Author = TestAuthorOne,
                        Genre = TestGenreOne,
                        Rating = 9.9,
                        YearPublished = new DateTime(2010, 1, 1),
                        YearRead = DateTime.Today
                    },
                    new Book
                    {
                        Title = "Lord of the Rings",
                        Author = TestAuthorTwo,
                        Genre = TestGenreTwo,
                        Rating = 10.0,
                        YearPublished = new DateTime(1945, 1, 1),
                        YearRead = DateTime.Now
                    }
                };
                BasicBookServiceMock
                    .Setup(x => x.ListAllBooksAsync())
                    .ReturnsAsync(books);

                // Act
                var result = await ControllerUnderTest.ListAllBooks();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(books, okResult.Value);
            }

            [Fact]
            public void Should_return_not_found()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "The Shining",
                        Author = TestAuthorOne,
                        Genre = TestGenreTwo,
                        Rating = 9.8,
                        YearPublished = new DateTime(2013, 1, 1),
                        YearRead = DateTime.Today
                    },
                    new Book
                    {
                        Title = "IT",
                        Author = TestAuthorTwo,
                        Genre = TestGenreTwo,
                        Rating = 8,
                        YearPublished = new DateTime(2011, 1, 1),
                        YearRead = DateTime.Now
                    }
                };
                BasicBookServiceMock
                    .Setup(x => x.ListAllBooksAsync())
                    .ThrowsAsync(new EntityNotFoundException());

                // Act
                var result = ControllerUnderTest.ListAllBooks();

                // Assert
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }

        public class GetBook : BasicBooksControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_book()
            {
                // Arrange
                var book = new Book
                {
                    Title = "The Prisoner of Azkaban",
                    Author = TestAuthorOne,
                    Genre = TestGenreOne,
                    Rating = 8.8,
                    YearPublished = new DateTime(1999, 1, 1),
                    YearRead = DateTime.Today
                };
                BasicBookServiceMock
                    .Setup(x => x.GetBookAsync(book.BookId))
                    .ReturnsAsync(book);

                // Act
                var result = await ControllerUnderTest.GetBook(book.BookId);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(book, okResult.Value);
            }

            [Fact]
            public async void Should_return_not_found()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Dune",
                    Author = TestAuthorTwo,
                    Genre = TestGenreTwo,
                    Rating = 7.7,
                    YearPublished = new DateTime(1908, 1, 1),
                    YearRead = DateTime.Today
                };
                BasicBookServiceMock
                    .Setup(x => x.GetBookAsync(book.BookId))
                    .ThrowsAsync(new EntityNotFoundException());

                // Act
                var result = await ControllerUnderTest.GetBook(book.BookId);

                // Assert
                var notFound = Assert.IsType<NotFoundResult>(result);
            }

        }

        public class AddBook : BasicBooksControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_book()
            {
                // Arrange
                var book = new Book
                {
                    Title = "The Bible",
                    Author = TestAuthorOne,
                    Genre = TestGenreOne,
                    Rating = 0,
                    YearPublished = new DateTime(1, 1, 1),
                    YearRead = DateTime.Today
                };
                BasicBookServiceMock
                    .Setup(x => x.AddBookAsync(book))
                    .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

                // Act
                var result = await ControllerUnderTest.AddBook(book);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(book, okResult.Value);
            }

            [Fact]
            public async void Should_return_bad_request()
            {
                // Arrange
                var book = new Book();
                ControllerUnderTest.ModelState.AddModelError("key", "there is an error");

                // Act
                var result = await ControllerUnderTest.AddBook(book);

                // Assert
                var badRequest = Assert.IsType<BadRequestObjectResult>(result);
                Assert.IsType<SerializableError>(badRequest.Value);
            }

            [Fact]
            public async void Should_return_conflict_with_message()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Pachinko",
                    Author = TestAuthorOne,
                    Genre = TestGenreTwo,
                    Rating = 4.4,
                    YearPublished = new DateTime(1919, 1, 1),
                    YearRead = DateTime.Now
                };
                BasicBookServiceMock
                    .Setup(x => x.AddBookAsync(book))
                    .ThrowsAsync(new EntityAlreadyExistsException(book.Title));

                // Act
                var result = await ControllerUnderTest.AddBook(book);

                // Assert
                var conflict = Assert.IsType<ConflictObjectResult>(result);
                Assert.Equal($"'{book.Title}' already exists in the database", conflict.Value);
            }

        }

        public class UpdateBook : BasicBooksControllerTest
        {
            [Fact]
            public async void Should_ok_with_book()
            {
                // Arrange
                var book = new Book
                {
                    Title = "The Wind in the Willows",
                    Author = TestAuthorTwo,
                    Genre = TestGenreOne,
                    Rating = 5.8,
                    YearPublished = new DateTime(1970, 1, 1),
                    YearRead = DateTime.Now
                };
                BasicBookServiceMock
                    .Setup(x => x.UpdateBookAsync(book))
                    .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

                // Act
                var result = await ControllerUnderTest.UpdateBook(book);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(book, okResult.Value);
            }

            [Fact]
            public async void Should_return_bad_request()
            {
                // Arrange
                var book = new Book();
                ControllerUnderTest.ModelState.AddModelError("key", "some error");

                // Act
                var result = await ControllerUnderTest.UpdateBook(book);

                // Assert
                var badRequest = Assert.IsType<BadRequestObjectResult>(result);
                Assert.IsType<SerializableError>(badRequest.Value);
            }

            [Fact]
            public async void Should_return_not_found()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Green Eggs and Ham",
                    Author = TestAuthorOne,
                    Genre = TestGenreTwo,
                    Rating = 8.8,
                    YearPublished = new DateTime(1960, 1, 1),
                    YearRead = DateTime.Now
                };
                BasicBookServiceMock
                    .Setup(x => x.UpdateBookAsync(book))
                    .ThrowsAsync(new EntityNotFoundException(book.Title));

                // Act
                var result = await ControllerUnderTest.UpdateBook(book);

                // Assert
                var notFound = Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal($"'{book.Title}' could not be found in the database", notFound.Value);
            }

        }

        public class DeleteBook : BasicBooksControllerTest
        {
            [Fact]
            public async void Should_return_ok()
            {
                // Arrange
                var book = new Book
                {
                    Title = "The Hobbit",
                    Author = TestAuthorOne,
                    Genre = TestGenreTwo,
                    Rating = 6.6,
                    YearPublished = new DateTime(1939, 1, 1),
                    YearRead = DateTime.Now
                };
                BasicBookServiceMock
                    .Setup(x => x.DeleteBookAsync(book.BookId))
                    .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

                // Act
                var result = await ControllerUnderTest.DeleteBook(book.BookId);

                // Assert
                var okResult = Assert.IsType<OkResult>(result);
            }

            [Fact]
            public async void Should_return_not_found()
            {
                // Arrange
                var book = new Book();
                BasicBookServiceMock
                    .Setup(x => x.DeleteBookAsync(book.BookId))
                    .ThrowsAsync(new EntityNotFoundException());

                // Act
                var result = await ControllerUnderTest.DeleteBook(book.BookId);

                // Assert
                var notFound = Assert.IsType<NotFoundResult>(result);
            }

        }
    }
}
