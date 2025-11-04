using System.Threading.Tasks;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

namespace ShopTARge24.RealEstateTest
{
    public class RealEstateTest: TestBase
    {
        [Fact]
        public async Task Test1()
        {
            //Arrange
            RealEstateDto dto = new()
            {
                //Id = Guid.NewGuid(),
                Area = 120.5,
                Location = "Test Location",
                RoomNumber = 3,
                BuildingType = "Apartment",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow


            };

            //Act
            var result = await Svc<IRealEstateServices>().Create(dto);


            //Assert
            Assert.NotNull(result);

        }
    }
}
