using SimplyBooks.Api.Tests.Common.Extensions;
using SimplyBooks.Domain;
using SimplyBooks.Repository.Queries.Genres;
using SimplyBooks.Repository.Queries.Nationalities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SimplyBooks.Api.Tests.RepositoryTests.Queries.Nationalities
{
    public class ListAllNationalitiesQueryTests : QueryTest<ListAllNationalitiesQuery>
    {
        [Fact]
        public async void Execute()
        {
            // Arrange
            var nationalities = new List<Nationality>
            {
                new Nationality {Name = StringExtensions.RandomString() },
                new Nationality {Name = StringExtensions.RandomString() },
                new Nationality {Name = StringExtensions.RandomString() },
                new Nationality {Name = StringExtensions.RandomString() }
            };

            using (var context = new SimplyBooksContext(Options))
            {
                context.Nationalilties.AddRange(nationalities);
                context.SaveChanges();
            }

            using (var context = new SimplyBooksContext(Options))
            {
                // Act
                var query = CreateQuery(context);
                var result = await query.Execute();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(nationalities.Count, result.Count);
            }
        }
    }
}
