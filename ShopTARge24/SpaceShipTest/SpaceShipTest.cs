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


    }
}
