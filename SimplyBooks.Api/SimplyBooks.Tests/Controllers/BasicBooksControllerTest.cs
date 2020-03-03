using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Models;
using SimplyBooks.Models.Dtos;
using SimplyBooks.Services.Books;
using System;
using System.Collections.Generic;
using System.Net;
using SimplyBooks.Models.QueryModels;
using SimplyBooks.Web.Controllers.Books;
using Xunit;

namespace SimplyBooks.Tests.Controllers
{
    public class BasicBooksControllerTest
    {
        protected Mock<IBooksService> BasicBookServiceMock { get; }
        protected Mock<IMapper> MapperMock { get; }
        protected BooksController ControllerUnderTest { get; }
        protected Genre TestGenreOne { get; }
        protected Genre TestGenreTwo { get; }
        protected Author TestAuthorOne { get; }
        protected Author TestAuthorTwo { get; }

        public BasicBooksControllerTest()
        {
            BasicBookServiceMock = new Mock<IBooksService>();
            MapperMock = new Mock<IMapper>();
            ControllerUnderTest = new BooksController(BasicBookServiceMock.Object, MapperMock.Object);

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
                        DateRead = DateTime.Today
                    },
                    new Book
                    {
                        Title = "Lord of the Rings",
                        Author = TestAuthorTwo,
                        Genre = TestGenreTwo,
                        Rating = 10.0,
                        YearPublished = new DateTime(1945, 1, 1),
                        DateRead = DateTime.Now
                    }
                };
                var result = new Result<IList<Book>>(books);
                BasicBookServiceMock
                    .Setup(x => x.ListAllBooksAsync())
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.ListAllBooks();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }

            [Fact]
            public void Should_return_result_with_error()
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
                        DateRead = DateTime.Today
                    },
                    new Book
                    {
                        Title = "IT",
                        Author = TestAuthorTwo,
                        Genre = TestGenreTwo,
                        Rating = 8,
                        YearPublished = new DateTime(2011, 1, 1),
                        DateRead = DateTime.Now
                    }
                };
                var result = new Result<IList<Book>>();
                result.AddError("there was an error");
                BasicBookServiceMock
                    .Setup(x => x.ListAllBooksAsync())
                    .ReturnsAsync(result);

                // Act
                var requestResult = ControllerUnderTest.ListAllBooks();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult.Result);
                Assert.Same(result, okResult.Value);
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
                    DateRead = DateTime.Today
                };
                var result = new Result<Book>(book);
                BasicBookServiceMock
                    .Setup(x => x.GetBookAsync(book.BookId))
                    .ReturnsAsync(result);
                // Act
                var requestResult = await ControllerUnderTest.GetBook(book.BookId);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }

            [Fact]
            public async void Should_return_result_with_error()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Dune",
                    Author = TestAuthorTwo,
                    Genre = TestGenreTwo,
                    Rating = 7.7,
                    YearPublished = new DateTime(1908, 1, 1),
                    DateRead = DateTime.Today
                };
                var result = new Result<Book>();
                result.Errors.Add("there was an error");
                BasicBookServiceMock
                    .Setup(x => x.GetBookAsync(book.BookId))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.GetBook(book.BookId);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
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
                    DateRead = DateTime.Today
                };
                var result = new Result();
                BasicBookServiceMock
                    .Setup(x => x.AddBookAsync(book))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.AddBook(book);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
                Assert.Equal(result, okResult.Value);
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
            public async void Should_return_result_with_error_message()
            {
                // Arrange
                var book = new Book
                {
                    Title = "Pachinko",
                    Author = TestAuthorOne,
                    Genre = TestGenreTwo,
                    Rating = 4.4,
                    YearPublished = new DateTime(1919, 1, 1),
                    DateRead = DateTime.Now
                };
                var result = new Result();
                result.Errors.Add("an error happened");
                BasicBookServiceMock
                    .Setup(x => x.AddBookAsync(book))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.AddBook(book);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Equal(result, okResult.Value);
            }

        }

        public class UpdateBook : BasicBooksControllerTest
        {
            [Fact]
            public async void Should_return_ok()
            {
                // Arrange
                var bookDto = new BookDto
                {
                    Title = "The Wind in the Willows",
                    Rating = 5.8,
                    YearPublished = new DateTime(1970, 1, 1),
                    YearRead = DateTime.Now
                };
                var book = new Book
                {
                    Title = "The Wind in the Willows",
                    Rating = 5.8,
                    YearPublished = new DateTime(1970, 1, 1),
                    DateRead = DateTime.Now
                };
                var toUpdate = MapperMock
                    .Setup(x => x.Map<Book>(bookDto))
                    .Returns(book);
                var result = new Result();
                BasicBookServiceMock
                    .Setup(x => x.UpdateBookAsync(book))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.UpdateBook(bookDto);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
                Assert.Equal(result, okResult.Value);
            }

            [Fact]
            public async void Should_return_bad_request()
            {
                // Arrange
                var book = new BookDto();
                ControllerUnderTest.ModelState.AddModelError("key", "some error");

                // Act
                var result = await ControllerUnderTest.UpdateBook(book);

                // Assert
                var badRequest = Assert.IsType<BadRequestObjectResult>(result);
                Assert.IsType<SerializableError>(badRequest.Value);
            }

            [Fact]
            public async void Should_return__error_with_message()
            {
                // Arrange
                var bookDto = new BookDto
                {
                    Title = "Green Eggs and Ham",
                    Rating = 8.8,
                    YearPublished = new DateTime(1960, 1, 1),
                    YearRead = DateTime.Now
                };
                var book = new Book
                {
                    Title = "Green Eggs and Ham",
                    Rating = 8.8,
                    YearPublished = new DateTime(1960, 1, 1),
                    DateRead = DateTime.Now
                };
                var toUpdate= MapperMock
                    .Setup(x => x.Map<Book>(bookDto))
                    .Returns(book);

                var result = new Result();
                result.AddError("there was an error");
                BasicBookServiceMock
                    .Setup(x => x.UpdateBookAsync(book))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.UpdateBook(bookDto);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
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
                    DateRead = DateTime.Now
                };
                var result = new Result();
                result.Errors.Add("there was an error");
                BasicBookServiceMock
                    .Setup(x => x.DeleteBookAsync(book.BookId))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.DeleteBook(book.BookId);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }

            [Fact]
            public async void Should_return_result_with_error()
            {
                // Arrange
                var result = new Result();
                result.Errors.Add("there was an error");
                var book = new Book();
                BasicBookServiceMock
                    .Setup(x => x.DeleteBookAsync(book.BookId))
                    .ReturnsAsync(result);

                // Act
                var requestResult = await ControllerUnderTest.DeleteBook(book.BookId);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(requestResult);
                Assert.Same(result, okResult.Value);
            }

        }
    }
}
