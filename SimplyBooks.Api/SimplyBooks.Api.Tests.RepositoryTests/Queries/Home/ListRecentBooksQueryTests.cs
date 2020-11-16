using SimplyBooks.Api.Tests.Common.Extensions;
using SimplyBooks.Domain;
using SimplyBooks.Repository.Queries.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SimplyBooks.Api.Tests.RepositoryTests.Queries.Home
{
    public class ListRecentBooksQueryTests : QueryTest<ListRecentBooksQuery>
    {
        [Fact]
        public async void Execute_should_get_first_ten_books_only()
        {
            // Arrange
            var books = new List<Book>
            {
                // 12 books here, 10 most recent return only (first ten in this list)
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    },
                    DateRead = new DateTime(2020, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    },
                    DateRead = new DateTime(2019, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    },
                    DateRead = new DateTime(2018, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    },
                    DateRead = new DateTime(2017, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    },
                    DateRead = new DateTime(2016, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    },
                    DateRead = new DateTime(2016, 12, 2)
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    },
                    DateRead = new DateTime(2015, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    },
                    DateRead = new DateTime(2014, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    },
                    DateRead = new DateTime(2013, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    },
                    DateRead = new DateTime(2012, 12, 3)
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    },
                    DateRead = new DateTime(2012, 12, 2)
                },
                new Book
                {
                    Title = StringExtensions.RandomString(),
                    Author = new Author
                    {
                        Name = StringExtensions.RandomString(),
                        Nationality = new Nationality { Name = StringExtensions.RandomString() }
                    },
                    DateRead = new DateTime(2011, 12, 2)
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
                var result = await query.Execute();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(10, result.Count);
                Assert.Null(result.Where(x => x.BookTitle.Equals(books[10].Title)).FirstOrDefault());
                Assert.Null(result.Where(x => x.BookTitle.Equals(books[11].Title)).FirstOrDefault());
            }
        }
    }
}
