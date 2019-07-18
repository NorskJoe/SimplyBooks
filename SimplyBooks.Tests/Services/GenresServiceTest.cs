using Moq;
using SimplyBooks.Models;
using SimplyBooks.Models.ResultModels;
using SimplyBooks.Repository.Commands.Genres;
using SimplyBooks.Repository.Queries.Genres;
using SimplyBooks.Services.Genres;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SimplyBooks.Tests.Services
{
    public class GenresServiceTest
    {
        protected Mock<IAddGenreCommand> AddGenreCommandMock { get; }
        protected Mock<IUpdateGenreCommand> UpdateGenreCommandMock { get; }
        protected Mock<IListAllGenresQuery> ListAllGenresQueryMock { get; }
        protected GenresService ServiceUnderTest { get; }

        public GenresServiceTest()
        {
            AddGenreCommandMock = new Mock<IAddGenreCommand>();
            UpdateGenreCommandMock = new Mock<IUpdateGenreCommand>();
            ListAllGenresQueryMock = new Mock<IListAllGenresQuery>();
            ServiceUnderTest = new GenresService(AddGenreCommandMock.Object,
                UpdateGenreCommandMock.Object,
                ListAllGenresQueryMock.Object);
        }

        public class ListAllGnresAsync : GenresServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_genres()
            {
                // Arrange
                var genres = new List<Genre>
                {
                    new Genre { Name = "Katherine Man" },
                    new Genre { Name = "Matherine Kan" }
                };
                var result = new Result<IList<Genre>>(genres);
                ListAllGenresQueryMock
                    .Setup(x => x.Execute())
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListAllGenresAsync();

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult.Value);
                Assert.Same(genres.FirstOrDefault(), serviceResult.Value.FirstOrDefault());
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var genres = new List<Genre>
                {
                    new Genre { Name = "Katherine Man" },
                    new Genre { Name = "Matherine Kan" }
                };
                var result = new Result<IList<Genre>>();
                result.AddError("fuck off");
                ListAllGenresQueryMock
                    .Setup(x => x.Execute())
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListAllGenresAsync();

                // Assert
                Assert.Same(result, serviceResult);
                Assert.Null(serviceResult.Value);
                Assert.Same(result.Errors.FirstOrDefault(), serviceResult.Errors.FirstOrDefault());
            }
        }

        public class AddGenreAsync : GenresServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_success()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Peter Piper"
                };
                var result = new Result();
                AddGenreCommandMock
                    .Setup(x => x.Execute(genre))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.AddGenreAsync(genre);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.True(serviceResult.IsSuccess);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Peter Piper"
                };
                var result = new Result();
                result.AddError("no thank you");
                AddGenreCommandMock
                    .Setup(x => x.Execute(genre))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.AddGenreAsync(genre);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotEmpty(serviceResult.Errors);
                Assert.False(serviceResult.IsSuccess);
            }
        }

        public class UpdateGenreAsync : GenresServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_success()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Marshmellow Man"
                };
                var result = new Result();
                UpdateGenreCommandMock
                    .Setup(x => x.Execute(genre))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.UpdateGenreAsync(genre);

                Assert.Same(result, serviceResult);
                Assert.True(serviceResult.IsSuccess);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var genre = new Genre
                {
                    Name = "Peter Piper"
                };
                var result = new Result();
                result.AddError("no thank you");
                UpdateGenreCommandMock
                    .Setup(x => x.Execute(genre))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.UpdateGenreAsync(genre);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotEmpty(serviceResult.Errors);
                Assert.False(serviceResult.IsSuccess);
            }
        }

    }
}
