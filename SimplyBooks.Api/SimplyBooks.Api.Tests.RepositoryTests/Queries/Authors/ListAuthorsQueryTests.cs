using SimplyBooks.Api.Tests.Common;
using SimplyBooks.Api.Tests.Common.Extensions;
using SimplyBooks.Domain;
using SimplyBooks.Repository.Queries.Authors;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SimplyBooks.Api.Tests.RepositoryTests.Queries.Authors
{
    public class ListAuthorsQueryTests : QueryTest<ListAuthorsQuery>
    {
        [Fact]
        public async void Execute_should_return_all_authors()
        {
            // Arrange 
            var books = new List<Book>
            {
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Rating = 10,
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    }
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Rating = 9,
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    }
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Rating = 8,
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    }
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Rating = 7,
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    }
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
                var result = await query.Execute(new AuthorListCriteria());

                // Assert
                Assert.NotNull(result);
                Assert.Equal(books.Count, result.Count);
            }
        }

        [Fact]
        public async void Execute_should_filter_by_author_name()
        {
            // Arrange
            var author1 = new Author
            {
                Name = "Peter Parker",
                Nationality = new Nationality { Name = StringExtensions.RandomString() }
            };

            var author2 = new Author
            {
                Name = "Peter Piper",
                Nationality = new Nationality { Name = StringExtensions.RandomString() }
            };

            var author3 = new Author
            {
                Name = "Harry Potter",
                Nationality = new Nationality { Name = StringExtensions.RandomString() }
            };

            var books = new List<Book>
            {
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Rating = 10,
                    Author = author1
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Rating = 10,
                    Author = author2
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Rating = 10,
                    Author = author3
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
                var result = await query.Execute(new AuthorListCriteria { AuthorName = "Peter" });

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count);
                Assert.Empty(result.Where(x => x.Name.Equals(author3.Name)));
            }
        }

        [Fact]
        public async void Execute_should_filter_by_nationality()
        {
            // Arrange
            var nationality1 = new Nationality
            {
                Name = "Colombian"
            };

            var nationality2 = new Nationality
            {
                Name = "Honduran"
            };

            var books = new List<Book>
            {
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Rating = 10,
                    Author = new Author { Name = StringExtensions.RandomString(), Nationality = nationality1 }
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Rating = 10,
                    Author = new Author { Name = StringExtensions.RandomString(), Nationality = nationality1 }
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Rating = 10,
                    Author = new Author { Name = StringExtensions.RandomString(), Nationality = nationality2 }
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
                var result = await query.Execute(new AuthorListCriteria { NationalityId = nationality2.NationalityId });

                // Assert
                Assert.NotNull(result);
                Assert.Single(result);
            }
        }
    }
}
