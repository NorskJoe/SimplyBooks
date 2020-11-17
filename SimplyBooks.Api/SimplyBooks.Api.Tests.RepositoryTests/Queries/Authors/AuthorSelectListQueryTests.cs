﻿using Xunit;
using SimplyBooks.Domain;
using SimplyBooks.Repository.Queries.Authors;
using SimplyBooks.Api.Tests.Common.Extensions;
using System.Collections.Generic;
using SimplyBooks.Api.Tests.Common;

namespace SimplyBooks.Api.Tests.RepositoryTests.Queries.Authors
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
                    Name = StringExtensions.RandomString(),
                    Nationality = new Nationality { Name = StringExtensions.RandomString() }
                },
                new Author
                {
                    Name = StringExtensions.RandomString(),
                    Nationality = new Nationality { Name = StringExtensions.RandomString() }
                },
                new Author
                {
                    Name = StringExtensions.RandomString(),
                    Nationality = new Nationality { Name = StringExtensions.RandomString() }
                },
                new Author
                {
                    Name = StringExtensions.RandomString(),
                    Nationality = new Nationality { Name = StringExtensions.RandomString() }
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
