using Moq;
using SimplyBooks.Domain;
using SimplyBooks.Repository.Commands.Authors;
using SimplyBooks.Repository.Queries.Authors;
using SimplyBooks.Services.Authors;
using System.Collections.Generic;
using System.Linq;
using SimplyBooks.Domain.QueryModels;
using Xunit;

namespace SimplyBooks.Tests.Services
{
    public class AuthorsServiceTest
    {
        protected Mock<IAddAuthorCommand> AddAuthorCommandMock { get; }
        protected Mock<IUpdateAuthorCommand> UpdateAuthorCommandMock { get; }
        protected Mock<IListAuthorsQuery> ListAuthorsQueryMock { get; }
        protected AuthorsService ServiceUnderTest { get; }

        public AuthorsServiceTest()
        {
            AddAuthorCommandMock = new Mock<IAddAuthorCommand>();
            UpdateAuthorCommandMock = new Mock<IUpdateAuthorCommand>();
            ListAuthorsQueryMock = new Mock<IListAuthorsQuery>();
            ServiceUnderTest = new AuthorsService(AddAuthorCommandMock.Object,
                UpdateAuthorCommandMock.Object,
                ListAuthorsQueryMock.Object);
        }

        public class ListAllAuthorsAsync : AuthorsServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_authors()
            {
                // Arrange
                var authors = new List<AuthorListItem>
                {
                    new AuthorListItem
                    {
                        Name = "Peter Piper",
                        Nationality =  "Austrian" 
                    },
                    new AuthorListItem
                    {
                        Name = "Spiderman",
                        Nationality = "American" 
                    }
                };
                var result = new Result<IList<AuthorListItem>>(authors);
                ListAllAuthorsQueryMock
                    .Setup(x => x.Execute())
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListAllAuthorsAsync();

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult.Value);
                Assert.Same(authors.FirstOrDefault(), serviceResult.Value.FirstOrDefault());
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var authors = new List<AuthorListItem>
                {
                    new AuthorListItem
                    {
                        Name = "Peter Piper",
                        Nationality =  "Austrian" 
                    },
                    new AuthorListItem
                    {
                        Name = "Spiderman",
                        Nationality = "American" 
                    }
                };
                var result = new Result<IList<AuthorListItem>>();
                result.AddError("fuck off");
                ListAllAuthorsQueryMock
                    .Setup(x => x.Execute())
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListAllAuthorsAsync();

                // Assert
                Assert.Same(result, serviceResult);
                Assert.Null(serviceResult.Value);
                Assert.Same(result.Errors.FirstOrDefault(), serviceResult.Errors.FirstOrDefault());
            }
        }

        public class AddAuthorAsync : AuthorsServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_success()
            {
                // Arrange
                var author = new Author
                {
                    Name = "Peter Piper"
                };
                var result = new Result();
                AddAuthorCommandMock
                    .Setup(x => x.Execute(author))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.AddAuthorAsync(author);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.True(serviceResult.IsSuccess);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var author = new Author
                {
                    Name = "Peter Piper"
                };
                var result = new Result();
                result.AddError("no thank you");
                AddAuthorCommandMock
                    .Setup(x => x.Execute(author))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.AddAuthorAsync(author);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotEmpty(serviceResult.Errors);
                Assert.False(serviceResult.IsSuccess);
            }
        }

        public class UpdateAuthorAsync : AuthorsServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_success()
            {
                // Arrange
                var author = new Author
                {
                    Name = "Marshmellow Man"
                };
                var result = new Result();
                UpdateAuthorCommandMock
                    .Setup(x => x.Execute(author))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.UpdateAuthorAsync(author);

                Assert.Same(result, serviceResult);
                Assert.True(serviceResult.IsSuccess);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var author = new Author
                {
                    Name = "Peter Piper"
                };
                var result = new Result();
                result.AddError("no thank you");
                UpdateAuthorCommandMock
                    .Setup(x => x.Execute(author))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.UpdateAuthorAsync(author);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotEmpty(serviceResult.Errors);
                Assert.False(serviceResult.IsSuccess);
            }
        }

    }
}
