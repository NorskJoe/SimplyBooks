using Moq;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using SimplyBooks.Repository.Queries.Books;
using SimplyBooks.Services.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SimplyBooks.Tests.Services
{
    public class ListBooksByCriteriaServiceTest
    {
        protected Mock<IListBooksByAuthorNationalityQuery> ListBooksByAuthorNationalityQueryMock { get; }
        protected Mock<IListBooksByAuthorQuery> ListBooksByAuthorQueryMock { get; }
        protected Mock<IListBooksByGenreQuery> ListBooksByGenreQueryMock { get; }
        protected Mock<IListBooksByYearPublishedQuery> ListBooksByYearPublishedQueryMock { get; }
        protected Mock<IListBooksByDateReadQuery> ListBooksByYearReadQueryMock { get; }
        protected ListBooksByCriteriaService ServiceUnderTest { get; }
        public Genre TestGenreOne { get; private set; }
        public Genre TestGenreTwo { get; private set; }
        public Author TestAuthorOne { get; private set; }
        public Author TestAuthorTwo { get; private set; }


        public ListBooksByCriteriaServiceTest()
        {
            ListBooksByAuthorNationalityQueryMock = new Mock<IListBooksByAuthorNationalityQuery>();
            ListBooksByAuthorQueryMock = new Mock<IListBooksByAuthorQuery>();
            ListBooksByGenreQueryMock = new Mock<IListBooksByGenreQuery>();
            ListBooksByYearPublishedQueryMock = new Mock<IListBooksByYearPublishedQuery>();
            ListBooksByYearReadQueryMock = new Mock<IListBooksByDateReadQuery>();
            ServiceUnderTest = new ListBooksByCriteriaService(ListBooksByAuthorNationalityQueryMock.Object,
                ListBooksByAuthorQueryMock.Object,
                ListBooksByGenreQueryMock.Object,
                ListBooksByYearPublishedQueryMock.Object,
                ListBooksByYearReadQueryMock.Object);

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
                AuthorId = 2,
                Name = "Lemmings",
                Nationality = new Nationality { Name = "Norway" }
            };
        }

        public class ListBooksByAuthorNationalityAsync : ListBooksByCriteriaServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_books()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Away with the meeples",
                        Author = TestAuthorOne
                    }, 
                    new Book
                    {
                        Title = "Explained: Meeples",
                        Author = TestAuthorOne
                    }
                };
                var result = new Result<IList<Book>>(books);
                ListBooksByAuthorNationalityQueryMock
                    .Setup(x => x.Execute(TestAuthorOne.Nationality.NationalityId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListBooksByAuthorNationalityAsync(TestAuthorOne.Nationality.NationalityId);

                // Assert
                Assert.Same(books, serviceResult.Value);
                Assert.NotNull(serviceResult);
                Assert.Same(books.FirstOrDefault(), serviceResult.Value.FirstOrDefault());
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Away with the meeples",
                        Author = TestAuthorOne
                    },
                    new Book
                    {
                        Title = "Explained: Meeples",
                        Author = TestAuthorOne
                    }
                };
                var result = new Result<IList<Book>>();
                result.AddError("sorry there was an error");
                ListBooksByAuthorNationalityQueryMock
                    .Setup(x => x.Execute(TestAuthorOne.Nationality.NationalityId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListBooksByAuthorNationalityAsync(TestAuthorOne.Nationality.NationalityId);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.Null(serviceResult.Value);
                Assert.Equal(result.Errors.First(), serviceResult.Errors.First());
            }
        }

        public class ListBooksByAuthorAsync : ListBooksByCriteriaServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_books()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Away with the meeples",
                        Author = TestAuthorOne
                    },
                    new Book
                    {
                        Title = "Explained: Meeples",
                        Author = TestAuthorOne
                    }
                };
                var result = new Result<IList<Book>>(books);
                ListBooksByAuthorQueryMock
                    .Setup(x => x.Execute(TestAuthorOne.AuthorId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListBooksByAuthorAsync(TestAuthorOne.AuthorId);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult.Value);
                Assert.Same(books.FirstOrDefault(), serviceResult.Value.FirstOrDefault());
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Away with the meeples",
                        Author = TestAuthorOne
                    },
                    new Book
                    {
                        Title = "Explained: Meeples",
                        Author = TestAuthorOne
                    }
                };
                var result = new Result<IList<Book>>();
                result.AddError("sorry there was an error");
                ListBooksByAuthorQueryMock
                    .Setup(x => x.Execute(TestAuthorOne.AuthorId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListBooksByAuthorAsync(TestAuthorOne.AuthorId);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.Null(serviceResult.Value);
                Assert.Equal(result.Errors.First(), serviceResult.Errors.First());
            }
        }

        public class ListBooksByGenreAsync : ListBooksByCriteriaServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_books()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Away with the meeples",
                        Genre = TestGenreOne
                    },
                    new Book
                    {
                        Title = "Explained: Meeples",
                        Genre = TestGenreOne
                    }
                };
                var result = new Result<IList<Book>>(books);
                ListBooksByGenreQueryMock
                    .Setup(x => x.Execute(TestGenreOne.GenreId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListBooksByGenreAsync(TestGenreOne.GenreId);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult.Value);
                Assert.Same(books.FirstOrDefault(), serviceResult.Value.FirstOrDefault());
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Away with the meeples",
                        Genre = TestGenreOne
                    },
                    new Book
                    {
                        Title = "Explained: Meeples",
                        Genre = TestGenreOne
                    }
                };
                var result = new Result<IList<Book>>();
                result.AddError("sorry there was an error");
                ListBooksByGenreQueryMock
                    .Setup(x => x.Execute(TestGenreOne.GenreId))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListBooksByGenreAsync(TestGenreOne.GenreId);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.Null(serviceResult.Value);
                Assert.Equal(result.Errors.First(), serviceResult.Errors.First());
            }
        }

        public class ListBooksByYearPublishedAsync : ListBooksByCriteriaServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_books()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Away with the meeples",
                        YearPublished = new DateTime(2013, 1, 1)
                    },
                    new Book
                    {
                        Title = "Explained: Meeples",
                        YearPublished = new DateTime(2013, 1, 1)
                    }
                };
                var result = new Result<IList<Book>>(books);
                ListBooksByYearPublishedQueryMock
                    .Setup(x => x.Execute(new DateTime(2013, 1, 1)))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListBooksByYearPublishedAsync(new DateTime(2013, 1, 1));

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult.Value);
                Assert.Same(books.FirstOrDefault(), serviceResult.Value.FirstOrDefault());
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Away with the meeples",
                        YearPublished = new DateTime(2013, 1, 1)
                    },
                    new Book
                    {
                        Title = "Explained: Meeples",
                        YearPublished = new DateTime(2013, 1, 1)
                    }
                };
                var result = new Result<IList<Book>>();
                result.AddError("sorry there was an error");
                ListBooksByYearPublishedQueryMock
                    .Setup(x => x.Execute(new DateTime(2013, 1, 1)))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListBooksByYearPublishedAsync(new DateTime(2013, 1, 1));

                // Assert
                Assert.Same(result, serviceResult);
                Assert.Null(serviceResult.Value);
                Assert.Equal(result.Errors.First(), serviceResult.Errors.First());
            }
        }

        public class ListBooksByYearReadAsync : ListBooksByCriteriaServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_books()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Away with the meeples",
                        DateRead = new DateTime(2013, 1, 1)
                    },
                    new Book
                    {
                        Title = "Explained: Meeples",
                        DateRead = new DateTime(2013, 1, 1)
                    }
                };
                var result = new Result<IList<Book>>(books);
                ListBooksByYearReadQueryMock
                    .Setup(x => x.Execute(new DateTime(2013, 1, 1)))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListBooksByYearReadAsync(new DateTime(2013, 1, 1));

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult.Value);
                Assert.Same(books.FirstOrDefault(), serviceResult.Value.FirstOrDefault());
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Away with the meeples",
                        DateRead = new DateTime(2013, 1, 1)
                    },
                    new Book
                    {
                        Title = "Explained: Meeples",
                        DateRead = new DateTime(2013, 1, 1)
                    }
                };
                var result = new Result<IList<Book>>();
                result.AddError("sorry there was an error");
                ListBooksByYearReadQueryMock
                    .Setup(x => x.Execute(new DateTime(2013, 1, 1)))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListBooksByYearReadAsync(new DateTime(2013, 1, 1));

                // Assert
                Assert.Same(result, serviceResult);
                Assert.Null(serviceResult.Value);
                Assert.Equal(result.Errors.First(), serviceResult.Errors.First());
            }
        }
    }
}
