using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

namespace SpaceShipTest
{
    public class SpaceShipTest: TestBase
    {
        [Fact]
        public async Task ShouldNot_CreateSpaceShip_PartialNullValues()
        {
            //arrange
            SpaceShipDto dto = new SpaceShipDto
            {
                Name = "",
                Classification = null,
                BuildDate = DateTime.UtcNow,
                Crew = null,
                EnginePower = 5000,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow

            };

            //act
            var result = await Svc<ISpaceshipServices>().Create(dto);

            //assert
            Assert.NotNull(result);
            Assert.Null(result.Crew);
            Assert.IsType<string>(result.Name);
            Assert.IsType<int>(result.EnginePower);
            Assert.Null(result.Classification);
        }

        [Fact]
        public async Task Should_CreateSpaceShip_AllValuesProvided()
        {
            //arrange
            SpaceShipDto dto = MockSpaceShipDto();
            //act
            var result = await Svc<ISpaceshipServices>().Create(dto);
            //assert
            Assert.NotNull(result);
            Assert.Equal("Enterprise", result.Name);
            Assert.Equal("Explorer", result.Classification);
            Assert.Equal(1000, result.Crew);
            Assert.Equal(9000, result.EnginePower);
        }

        [Fact]
        public async Task ShouldNot_UpdateSpaceShip_WhenDidNotUpdateData()
        {
            //Arrange
            var dto = MockSpaceShipDto();
            var nullDto = MockNullSpaceShipDto ();
            //Act
            var createSpaceShip = await Svc<ISpaceshipServices>().Create(dto);
            var result = await Svc<ISpaceshipServices>().Update(nullDto);
            //Assert
            Assert.NotEqual(createSpaceShip.Name, result.Name);
            Assert.NotEqual(createSpaceShip.Classification, result.Classification);
            Assert.DoesNotMatch(createSpaceShip.BuildDate.ToString(), result.BuildDate.ToString());
            Assert.DoesNotMatch(createSpaceShip.Crew.ToString(), result.Crew.ToString());
            Assert.DoesNotMatch(createSpaceShip.EnginePower.ToString(), result.EnginePower.ToString());
        }


        [Fact]
        public async Task Should_GetSpaceShipDetailAsync_WhenSpaceShipExists()
        {
            //Arrange
            var dto = MockSpaceShipDto();
            var createdSpaceShip = await Svc<ISpaceshipServices>().Create(dto);

            //Act
            var result = await Svc<ISpaceshipServices>().DetailAsync(createdSpaceShip.Id.Value);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(createdSpaceShip.Id, result.Id);
            Assert.Equal("Enterprise", result.Name);
        }


        [Fact]
        public async Task ShouldNot_DeleteSpaceShip_WhenSpaceShipDoesNotExist()
        {
            //Arrange
            var nonExistentId = Guid.NewGuid();

            //Act
            var result = await Svc<ISpaceshipServices>().Delete(nonExistentId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Should_UpdateSpaceShip_WhenAllDataIsUpdated()
        {
            //Arrange
            var createDto = MockSpaceShipDto();
            var createdSpaceShip = await Svc<ISpaceshipServices>().Create(createDto);

            var updateDto = new SpaceShipDto
            {
               
                Name = "Voyager",
                Classification = "Science Vessel",
                BuildDate = DateTime.UtcNow.AddYears(-5),
                Crew = 150,
                EnginePower = 7500,
                CreatedAt = createdSpaceShip.CreatedAt,
                ModifiedAt = DateTime.UtcNow
            };

            //Act
            var result = await Svc<ISpaceshipServices>().Update(updateDto);

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Voyager", result.Name);
            Assert.Equal("Science Vessel", result.Classification);
            Assert.Equal(150, result.Crew);
            Assert.Equal(7500, result.EnginePower);
            Assert.NotEqual(createdSpaceShip.ModifiedAt, result.ModifiedAt);
            Assert.NotEqual(createdSpaceShip.Crew.ToString(), result.Crew.ToString());
        }

        [Fact]
        public async Task Should_DeleteSpaceShip_WhenSpaceShipExists()
        {
            //Arrange
            var dto = MockSpaceShipDto();
            var createdSpaceShip = await Svc<ISpaceshipServices>().Create(dto);

            //Act
            var result = await Svc<ISpaceshipServices>().Delete(createdSpaceShip.Id.Value);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(createdSpaceShip.Id, result.Id);
            Assert.Equal("Enterprise", result.Name);
        }

        private static SpaceShipDto MockSpaceShipDto()
        {
            return new SpaceShipDto
            {
                Name = "Enterprise",
                Classification = "Explorer",
                BuildDate = DateTime.UtcNow,
                Crew = 1000,
                EnginePower = 9000,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };
        }
        private static SpaceShipDto MockNullSpaceShipDto()
        {
            return new SpaceShipDto
            {
                Name = "",
                Classification = "",
                BuildDate = null,
                Crew = null,
                EnginePower = null,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };
        }


    }
}
