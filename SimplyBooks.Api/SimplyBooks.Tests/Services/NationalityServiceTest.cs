using Moq;
using SimplyBooks.Models;
using SimplyBooks.Repository.Commands.Nationalities;
using SimplyBooks.Repository.Queries.Nationalities;
using SimplyBooks.Services.Nationalities;
using System.Collections.Generic;
using System.Linq;
using SimplyBooks.Models.QueryModels;
using Xunit;

namespace SimplyBooks.Tests.Services
{
    public class NationalityServiceTest
    {
        protected Mock<IAddNationalityCommand> AddNationalityCommandMock { get; }
        protected Mock<IUpdateNationalityCommand> UpdateNationalityCommandMock { get; }
        protected Mock<IListAllNationalitiesQuery> ListAllNationalitiesQueryMock { get; }
        protected NationalityService ServiceUnderTest { get; }

        public NationalityServiceTest()
        {
            AddNationalityCommandMock = new Mock<IAddNationalityCommand>();
            UpdateNationalityCommandMock = new Mock<IUpdateNationalityCommand>();
            ListAllNationalitiesQueryMock = new Mock<IListAllNationalitiesQuery>();
            ServiceUnderTest = new NationalityService(AddNationalityCommandMock.Object,
                UpdateNationalityCommandMock.Object,
                ListAllNationalitiesQueryMock.Object);
        }

        public class ListAllNationalityAsync : NationalityServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_Nationality()
            {
                // Arrange
                var Nationality = new List<Nationality>
                {
                    new Nationality { Name = "Katherine Man" },
                    new Nationality { Name = "Matherine Kan" }
                };
                var result = new Result<IList<Nationality>>(Nationality);
                ListAllNationalitiesQueryMock
                    .Setup(x => x.Execute())
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListAllNationalitiesAsync();

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotNull(serviceResult.Value);
                Assert.Same(Nationality.FirstOrDefault(), serviceResult.Value.FirstOrDefault());
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var Nationality = new List<Nationality>
                {
                    new Nationality { Name = "Katherine Man" },
                    new Nationality { Name = "Matherine Kan" }
                };
                var result = new Result<IList<Nationality>>();
                result.AddError("fuck off");
                ListAllNationalitiesQueryMock
                    .Setup(x => x.Execute())
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.ListAllNationalitiesAsync();

                // Assert
                Assert.Same(result, serviceResult);
                Assert.Null(serviceResult.Value);
                Assert.Same(result.Errors.FirstOrDefault(), serviceResult.Errors.FirstOrDefault());
            }
        }

        public class AddNationalityAsync : NationalityServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_success()
            {
                // Arrange
                var Nationality = new Nationality
                {
                    Name = "Peter Piper"
                };
                var result = new Result();
                AddNationalityCommandMock
                    .Setup(x => x.Execute(Nationality))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.AddNationalityAsync(Nationality);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.True(serviceResult.IsSuccess);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var Nationality = new Nationality
                {
                    Name = "Peter Piper"
                };
                var result = new Result();
                result.AddError("no thank you");
                AddNationalityCommandMock
                    .Setup(x => x.Execute(Nationality))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.AddNationalityAsync(Nationality);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotEmpty(serviceResult.Errors);
                Assert.False(serviceResult.IsSuccess);
            }
        }

        public class UpdateNationalityAsync : NationalityServiceTest
        {
            [Fact]
            public async void Should_return_ok_with_success()
            {
                // Arrange
                var Nationality = new Nationality
                {
                    Name = "Marshmellow Man"
                };
                var result = new Result();
                UpdateNationalityCommandMock
                    .Setup(x => x.Execute(Nationality))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.UpdateNationalityAsync(Nationality);

                Assert.Same(result, serviceResult);
                Assert.True(serviceResult.IsSuccess);
            }

            [Fact]
            public async void Should_return_error_with_message()
            {
                // Arrange
                var Nationality = new Nationality
                {
                    Name = "Peter Piper"
                };
                var result = new Result();
                result.AddError("no thank you");
                UpdateNationalityCommandMock
                    .Setup(x => x.Execute(Nationality))
                    .ReturnsAsync(result);

                // Act
                var serviceResult = await ServiceUnderTest.UpdateNationalityAsync(Nationality);

                // Assert
                Assert.Same(result, serviceResult);
                Assert.NotEmpty(serviceResult.Errors);
                Assert.False(serviceResult.IsSuccess);
            }
        }

    }
}
