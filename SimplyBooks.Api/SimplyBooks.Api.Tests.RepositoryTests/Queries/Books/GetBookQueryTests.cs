using SimplyBooks.Api.Tests.Common.Extensions;
using SimplyBooks.Domain;
using SimplyBooks.Repository.Queries.Books;
using Xunit;

namespace SimplyBooks.Api.Tests.RepositoryTests.Queries.Books
{
    public class GetBookQueryTests : QueryTest<GetBookQuery>
    {
        [Fact]
        public async void Execute_should_return_book()
        {
            // Arrange
            var book = new Book
            {
                Title = StringExtensions.GenerateRandomString(),
                Author = new Author
                {
                    Name = StringExtensions.GenerateRandomString(),
                    Nationality = new Nationality { Name = StringExtensions.GenerateRandomString() }
                }
            };

            using (var context = new SimplyBooksContext(Options))
            {
                context.Books.Add(book);
                context.SaveChanges();
            }

            using (var context = new SimplyBooksContext(Options))
            {
                // Act
                var query = CreateQuery(context);
                var result = await query.Execute(new BookItemCriteria { BookId = book.BookId });

                // Assert
                Assert.NotNull(result);
                Assert.Equal(book.Title, result.Title);
            }
        }

        [Fact]
        public async void Execute_should_return_null_result()
        {
            using (var context = new SimplyBooksContext(Options))
            {
                // Act
                var query = CreateQuery(context);
                var result = await query.Execute(new BookItemCriteria { BookId = 1 });

                // Assert
                Assert.Null(result);
            }
        }
    }
}
