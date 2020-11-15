using SimplyBooks.Api.Tests.Common.Extensions;
using SimplyBooks.Domain;
using SimplyBooks.Repository.Queries.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SimplyBooks.Api.Tests.RepositoryTests.Queries.Books
{
    public class ListBooksQueryTests : QueryTest<ListBooksQuery>
    {
        [Fact]
        public async void Execute_should_return_all_books()
        {
            var books = new List<Book>
            {
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() }
                },
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() }
                },
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() }
                },
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() }
                }
            };

            using (var context = new SimplyBooksContext(Options))
            {
                context.Books.AddRange(books);
                context.SaveChanges();
            }

            using (var context = new SimplyBooksContext(Options))
            {
                // Act
                var query = CreateQuery(context);
                var result = await query.Execute(new BookListCriteria());

                // Assert
                Assert.NotNull(result);
                Assert.Equal(books.Count, result.Count);
            }
        }

        [Fact]
        public async void Execute_should_filter_by_author()
        {
            // Arrange
            var author1 = new Author
            {
                Name = StringExtensions.GenerateRandomString(),
                Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
            };

            var author2 = new Author
            {
                Name = StringExtensions.GenerateRandomString(),
                Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
            };

            var books = new List<Book>
            {
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Author = author1,
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() }
                },
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Author = author2,
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() }
                },
            };

            using (var context = new SimplyBooksContext(Options))
            {
                context.Books.AddRange(books);
                context.SaveChanges();
            }

            using (var context = new SimplyBooksContext(Options))
            {
                // Act
                var query = CreateQuery(context);
                var result = await query.Execute(new BookListCriteria { AuthorId = author1.AuthorId });

                // Assert
                Assert.NotNull(result);
                Assert.Single(result);
                Assert.Equal(author1.Name, result.First().AuthorName);

            }
        }

        [Fact]
        public async void Execute_should_filter_by_genre()
        {
            // Arrange 
            var genre1 = new Genre { Name = StringExtensions.GenerateRandomString() };
            var genre2 = new Genre { Name = StringExtensions.GenerateRandomString() };

            var books = new List<Book>
            {
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = genre1
                },
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = genre2
                },
            };

            using (var context = new SimplyBooksContext(Options))
            {
                context.Books.AddRange(books);
                context.SaveChanges();
            }

            using (var context = new SimplyBooksContext(Options))
            {
                // Act
                var query = CreateQuery(context);
                var result = await query.Execute(new BookListCriteria { GenreId = genre1.GenreId });

                // Assert
                Assert.NotNull(result);
                Assert.Single(result);
                Assert.Equal(genre1.Name, result.First().Genre);
            }
        }

        [Fact]
        public async void Execute_should_filter_by_title()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book
                {
                    Title = "1984",
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() }
                },
                new Book
                {
                    Title = "Farenheit 451",
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() }
                },
                new Book
                {
                    Title = "Brave New World",
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() }
                },
                new Book
                {
                    Title = "Lord of the Flies",
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() }
                }
            };

            using (var context = new SimplyBooksContext(Options))
            {
                context.Books.AddRange(books);
                context.SaveChanges();
            }

            using (var context = new SimplyBooksContext(Options))
            {
                // Act
                var query = CreateQuery(context);
                var result = await query.Execute(new BookListCriteria { BookTitle = "19" });

                // Assert
                Assert.NotNull(result);
                Assert.Single(result);
                Assert.Equal(books[0].Title, result.First().Title);
            }
        }

        [Fact]
        public async void Execute_should_filter_by_year_read()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() },
                    DateRead = new DateTime(2020, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() },
                    DateRead = new DateTime(1981, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() },
                    DateRead = new DateTime(1988, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() },
                    DateRead = new DateTime(2001, 12, 3)
                }
            };

            using (var context = new SimplyBooksContext(Options))
            {
                context.Books.AddRange(books);
                context.SaveChanges();
            }

            using (var context = new SimplyBooksContext(Options))
            {
                // Act
                var query = CreateQuery(context);
                var result = await query.Execute(new BookListCriteria { YearRead = 1988 });

                // Assert
                Assert.NotNull(result);
                Assert.Single(result);
                Assert.Equal(books[2].Title, result.First().Title);
            }
        }

        [Fact]
        public async void Execute_should_filter_by_year_published()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() },
                    YearPublished = new DateTime(2020, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() },
                    YearPublished = new DateTime(1981, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() },
                    YearPublished = new DateTime(1988, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.GenerateRandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    Genre = new Genre { Name = StringExtensions.GenerateRandomString() },
                    YearPublished = new DateTime(2001, 12, 3)
                }
            };

            using (var context = new SimplyBooksContext(Options))
            {
                context.Books.AddRange(books);
                context.SaveChanges();
            }

            using (var context = new SimplyBooksContext(Options))
            {
                // Act
                var query = CreateQuery(context);
                var result = await query.Execute(new BookListCriteria { YearPublished = 1988 });

                // Assert
                Assert.NotNull(result);
                Assert.Single(result);
                Assert.Equal(books[2].Title, result.First().Title);
            }
        }
    }
}
