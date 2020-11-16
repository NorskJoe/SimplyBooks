using SimplyBooks.Api.Tests.Common.Extensions;
using SimplyBooks.Domain;
using SimplyBooks.Repository.Queries.Genres;
using System.Collections.Generic;
using Xunit;

namespace SimplyBooks.Api.Tests.RepositoryTests.Queries.Genres
{
    public class ListAllGenresQueryTests : QueryTest<ListAllGenresQuery>
    {
        [Fact]
        public async void Execute()
        {
            // Arrange
            var genres = new List<Genre>
            {
                new Genre {Name = StringExtensions.RandomString() },
                new Genre {Name = StringExtensions.RandomString() },
                new Genre {Name = StringExtensions.RandomString() },
                new Genre {Name = StringExtensions.RandomString() }
            };

            using (var context = new SimplyBooksContext(Options))
            {
                context.Genres.AddRange(genres);
                context.SaveChanges();
            }

            using (var context = new SimplyBooksContext(Options))
            {
                // Act
                var query = CreateQuery(context);
                var result = await query.Execute();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(genres.Count, result.Count);
            }
        }
    }
}
