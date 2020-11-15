using Xunit;
using SimplyBooks.Domain;
using SimplyBooks.Repository.Queries.Authors;
using SimplyBooks.Api.Tests.Common.Extensions;
using System.Collections.Generic;

namespace SimplyBooks.Api.Tests.RepositoryTests.Authors.AuthorSelectListQueryTests
{
    public class AuthorSelectListQueryTests : QueryTest<AuthorSelectListQuery>
    {
        [Fact]
        public async void Execute()
        {
            // Arrange
            var authors = new List<Author>
                {
                    new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    },
                    new Author
                    {
                        Name = StringExtensions.GenerateRandomString(),
                        Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                    }
                };

            using (var context = new SimplyBooksContext(Options))
            {
                context.Authors.AddRange(authors);
                context.SaveChanges();
            }


            using (var context = new SimplyBooksContext(Options))
            {
                // Act
                var query = CreateQuery(context);
                var result = await query.Execute();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(authors.Count, result.Count);
            }
        }
    }
}
