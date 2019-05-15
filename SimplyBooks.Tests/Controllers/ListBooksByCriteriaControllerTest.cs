using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplyBooks.Models;
using SimplyBooks.Models.Exceptions;
using SimplyBooks.Services.Books.Interfaces;
using SimplyBooks.Web.Controllers.Books;
using SimplyBooksApi.Controllers.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SimplyBooks.Tests.Controllers
{
    public class ListBooksByCriteriaControllerTest
    {
        protected Mock<IListBooksByCriteriaService> ListBooksByCriteriaServiceMock { get; }
        protected ListBooksByCriteriaController ControllerUnderTest { get; }
        public Genre TestGenreOne { get; private set; }
        public Genre TestGenreTwo { get; private set; }
        public Author TestAuthorOne { get; private set; }
        public Author TestAuthorTwo { get; private set; }

        public ListBooksByCriteriaControllerTest()
        {
            ListBooksByCriteriaServiceMock = new Mock<IListBooksByCriteriaService>();
            ControllerUnderTest = new ListBooksByCriteriaController(ListBooksByCriteriaServiceMock.Object);

            TestGenreOne = new Genre
            {
                GenreId = 1,
                Name = "Fantasy"
            };
            TestGenreTwo = new Genre
            {
                GenreId = 2,
                Name = "Erotica"
            };

            TestAuthorOne = new Author
            {
                AuthorId = 1,
                Name = "Harvey Norman",
                Nationality = new Nationality { Name = "Australia" }
            };
            TestAuthorTwo = new Author
            {
                AuthorId =2,
                Name = "Lemmings",
                Nationality = new Nationality { Name = "Norway" }
            };
        }

        public class ListBooksByAuthor : ListBooksByCriteriaControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_list()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "MTGA: A guide",
                        Author = TestAuthorOne,
                        Genre = TestGenreOne,
                        Rating = 2.2,
                        YearRead = DateTime.Now,
                        YearPublished = new DateTime(2012, 1, 1)
                    },
                    new Book
                    {
                        Title = "WW2: A History",
                        Author = TestAuthorOne,
                        Genre = TestGenreTwo,
                        Rating = 2.5,
                        YearRead = DateTime.Now,
                        YearPublished = new DateTime(2012, 1, 1)
                    }
                };
                ListBooksByCriteriaServiceMock
                    .Setup(x => x.ListBooksByAuthorAsync(TestAuthorOne.AuthorId))
                    .ReturnsAsync(books);

                // Act
                var result = await ControllerUnderTest.ListBooksByAuthor(TestAuthorOne.AuthorId);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(books, okResult.Value);
            }

            [Fact]
            public async void Should_return_not_found()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "MTGA: A guide",
                        Author = TestAuthorOne,
                        Genre = TestGenreOne,
                        Rating = 2.2,
                        YearRead = DateTime.Now,
                        YearPublished = new DateTime(2012, 1, 1)
                    },
                    new Book
                    {
                        Title = "WW2: A History",
                        Author = TestAuthorOne,
                        Genre = TestGenreTwo,
                        Rating = 2.5,
                        YearRead = DateTime.Now,
                        YearPublished = new DateTime(2012, 1, 1)
                    }
                };
                ListBooksByCriteriaServiceMock
                    .Setup(x => x.ListBooksByAuthorAsync(5))
                    .ThrowsAsync(new EntityNotFoundException(5, typeof(Author).Name));

                // Act
                var result = await ControllerUnderTest.ListBooksByAuthor(5);

                // Assert
                var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal($"A {typeof(Author).Name} with an ID of {5} could not be found", notFoundResult.Value);
            }

        }

        public class ListBooksByGenre : ListBooksByCriteriaControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_list()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "MTGA: A guide",
                        Author = TestAuthorOne,
                        Genre = TestGenreOne,
                        Rating = 2.2,
                        YearRead = DateTime.Now,
                        YearPublished = new DateTime(2012, 1, 1)
                    },
                    new Book
                    {
                        Title = "WW2: A History",
                        Author = TestAuthorOne,
                        Genre = TestGenreOne,
                        Rating = 2.5,
                        YearRead = DateTime.Now,
                        YearPublished = new DateTime(2012, 1, 1)
                    }
                };
                ListBooksByCriteriaServiceMock
                    .Setup(x => x.ListBooksByGenreAsync(TestGenreOne.GenreId))
                    .ReturnsAsync(books);


                // Act
                var result = await ControllerUnderTest.ListBooksByGenre(TestGenreOne.GenreId);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(books, okResult.Value);
            }

            [Fact]
            public async void Should_return_not_found()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "MTGA: A guide",
                        Author = TestAuthorOne,
                        Genre = TestGenreOne,
                        Rating = 2.2,
                        YearRead = DateTime.Now,
                        YearPublished = new DateTime(2012, 1, 1)
                    },
                    new Book
                    {
                        Title = "WW2: A History",
                        Author = TestAuthorOne,
                        Genre = TestGenreTwo,
                        Rating = 2.5,
                        YearRead = DateTime.Now,
                        YearPublished = new DateTime(2012, 1, 1)
                    }
                };
                ListBooksByCriteriaServiceMock
                    .Setup(x => x.ListBooksByGenreAsync(5))
                    .ThrowsAsync(new EntityNotFoundException(5, typeof(Genre).Name));

                // Act
                var result = await ControllerUnderTest.ListBooksByGenre(5);

                // Assert
                var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal($"A {typeof(Genre).Name} with an ID of {5} could not be found", notFoundResult.Value);

            }


        }

        public class ListBooksByAuthorNationality : ListBooksByCriteriaControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_list()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "MTGA: A guide",
                        Author = TestAuthorOne,
                        Genre = TestGenreOne,
                        Rating = 2.2,
                        YearRead = DateTime.Now,
                        YearPublished = new DateTime(2012, 1, 1)
                    },
                    new Book
                    {
                        Title = "WW2: A History",
                        Author = TestAuthorOne,
                        Genre = TestGenreTwo,
                        Rating = 2.5,
                        YearRead = DateTime.Now,
                        YearPublished = new DateTime(2012, 1, 1)
                    }
                };
                ListBooksByCriteriaServiceMock
                    .Setup(x => x.ListBooksByAuthorNationalityAsync(TestAuthorOne.Nationality.NationalityId))
                    .ReturnsAsync(books);

                // Act
                var result = await ControllerUnderTest.ListBooksByAuthorNationality(TestAuthorOne.Nationality.NationalityId);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(books, okResult.Value);
            }

            [Fact]
            public async void Should_return_not_found()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "MTGA: A guide",
                        Author = TestAuthorOne,
                        Genre = TestGenreOne,
                        Rating = 2.2,
                        YearRead = DateTime.Now,
                        YearPublished = new DateTime(2012, 1, 1)
                    },
                    new Book
                    {
                        Title = "WW2: A History",
                        Author = TestAuthorOne,
                        Genre = TestGenreTwo,
                        Rating = 2.5,
                        YearRead = DateTime.Now,
                        YearPublished = new DateTime(2012, 1, 1)
                    }
                };
                ListBooksByCriteriaServiceMock
                    .Setup(x => x.ListBooksByAuthorNationalityAsync(5))
                    .ThrowsAsync(new EntityNotFoundException(5, typeof(Nationality).Name));

                // Act
                var result = await ControllerUnderTest.ListBooksByAuthorNationality(5);

                // Assert
                var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal($"A {typeof(Nationality).Name} with an ID of {5} could not be found", notFoundResult.Value);
            }
        }

        public class ListBooksByYearRead : ListBooksByCriteriaControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_list()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "MTGA: A guide",
                        Author = TestAuthorOne,
                        Genre = TestGenreOne,
                        Rating = 2.2,
                        YearRead = new DateTime(2013, 1, 1),
                        YearPublished = new DateTime(2012, 1, 1)
                    },
                    new Book
                    {
                        Title = "WW2: A History",
                        Author = TestAuthorOne,
                        Genre = TestGenreTwo,
                        Rating = 2.5,
                        YearRead = new DateTime(2013, 1, 1),
                        YearPublished = new DateTime(2012, 1, 1)
                    }
                };
                ListBooksByCriteriaServiceMock
                    .Setup(x => x.ListBooksByYearReadAsync(new DateTime(2013, 1, 1)))
                    .ReturnsAsync(books);

                // Act
                var result = await ControllerUnderTest.ListBooksByYearRead(new DateTime(2013, 1, 1));

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(books, okResult.Value);
            }

            [Fact]
            public async void Should_return_not_found()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "MTGA: A guide",
                        Author = TestAuthorOne,
                        Genre = TestGenreOne,
                        Rating = 2.2,
                        YearRead = new DateTime(2013, 1, 1),
                        YearPublished = new DateTime(2012, 1, 1)
                    },
                    new Book
                    {
                        Title = "WW2: A History",
                        Author = TestAuthorOne,
                        Genre = TestGenreTwo,
                        Rating = 2.5,
                        YearRead = new DateTime(2013, 1, 1),
                        YearPublished = new DateTime(2012, 1, 1)
                    }
                };
                ListBooksByCriteriaServiceMock
                    .Setup(x => x.ListBooksByYearReadAsync(new DateTime(2012, 1, 1)))
                    .ThrowsAsync(new EntityNotFoundException(new DateTime(2012, 1, 1), typeof(Book).Name));

                // Act
                var result = await ControllerUnderTest.ListBooksByYearRead(new DateTime(2012, 1, 1));

                // Assert
                var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal($"A {typeof(Book).Name} matching the year {new DateTime(2012, 1, 1).Year} could not be found", notFoundResult.Value);
            }
        }

        public class ListBooksByYearPublished : ListBooksByCriteriaControllerTest
        {
            [Fact]
            public async void Should_return_ok_with_list()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "MTGA: A guide",
                        Author = TestAuthorOne,
                        Genre = TestGenreOne,
                        Rating = 2.2,
                        YearRead = new DateTime(2013, 1, 1),
                        YearPublished = new DateTime(2012, 1, 1)
                    },
                    new Book
                    {
                        Title = "WW2: A History",
                        Author = TestAuthorOne,
                        Genre = TestGenreTwo,
                        Rating = 2.5,
                        YearRead = new DateTime(2013, 1, 1),
                        YearPublished = new DateTime(2012, 1, 1)
                    }
                };
                ListBooksByCriteriaServiceMock
                    .Setup(x => x.ListBooksByYearPublishedAsync(new DateTime(2012, 1, 1)))
                    .ReturnsAsync(books);

                // Act
                var result = await ControllerUnderTest.ListBooksByYearPublished(new DateTime(2012, 1, 1));

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                Assert.Same(books, okResult.Value);
            }

            [Fact]
            public async void Should_return_not_found()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "MTGA: A guide",
                        Author = TestAuthorOne,
                        Genre = TestGenreOne,
                        Rating = 2.2,
                        YearRead = new DateTime(2013, 1, 1),
                        YearPublished = new DateTime(2012, 1, 1)
                    },
                    new Book
                    {
                        Title = "WW2: A History",
                        Author = TestAuthorOne,
                        Genre = TestGenreTwo,
                        Rating = 2.5,
                        YearRead = new DateTime(2013, 1, 1),
                        YearPublished = new DateTime(2012, 1, 1)
                    }
                };
                ListBooksByCriteriaServiceMock
                    .Setup(x => x.ListBooksByYearPublishedAsync(new DateTime(2013, 1, 1)))
                    .ThrowsAsync(new EntityNotFoundException(new DateTime(2013, 1, 1), typeof(Book).Name));

                // Act
                var result = await ControllerUnderTest.ListBooksByYearPublished(new DateTime(2013, 1, 1));

                // Assert
                var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
                Assert.Equal($"A {typeof(Book).Name} matching the year {new DateTime(2013, 1, 1).Year} could not be found", notFoundResult.Value);
            }
        }
    }
}
