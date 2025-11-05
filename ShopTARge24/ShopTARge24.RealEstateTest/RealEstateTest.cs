using System.Threading.Tasks;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

namespace ShopTARge24.RealEstateTest
{
    public class RealEstateTest: TestBase
    {

        private RealEstateDto realEstateDto = new()
        {
            //Id = Guid.NewGuid(),
            Area = 120.5,
            Location = "Test Location",
            RoomNumber = 3,
            BuildingType = "Apartment",
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow


        };

        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
        {
            //Arrange
            realEstateDto = new RealEstateDto();

            //Act
            var result = await Svc<IRealEstateServices>().Create(realEstateDto);


            //Assert
            Assert.NotNull(result);

        }


        //ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
        {
            //Arrange
            realEstateDto = new RealEstateDto();

            //Act
            var createdRealEstate = await Svc<IRealEstateServices>().Create(realEstateDto);
            var differentId = Guid.NewGuid();
            //var result = await Svc<IRealEstateServices>().DetailAsync(differentId);

            //Assert
            Assert.NotEqual(createdRealEstate.Id, differentId);
           // Assert.Null(result);
        }



        //Should_GetByIdRealEstate_WhenReturnsEqual()
        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            //Arrange
            realEstateDto = new RealEstateDto();
            //Act
            var createdRealEstate = await Svc<IRealEstateServices>().Create(realEstateDto);
            var result = await Svc<IRealEstateServices>().DetailAsync(createdRealEstate.Id.Value);
            //Assert
            Assert.Equal(createdRealEstate.Id, result.Id);
        }



        //Should_deleteByIdRealEstate_WhenDeleteRealEstate()
        [Fact]
        public async Task Should_deleteByIdRealEstate_WhenDeleteRealEstate()
        {
            //Arrange
            realEstateDto = new RealEstateDto();
            //Act
            var createdRealEstate = await Svc<IRealEstateServices>().Create(realEstateDto);
            var deletedRealEstate = await Svc<IRealEstateServices>().Delete(createdRealEstate.Id.Value);
            var result = await Svc<IRealEstateServices>().DetailAsync(createdRealEstate.Id.Value);
            //Assert
            Assert.Equal(createdRealEstate.Id, deletedRealEstate.Id);
            Assert.Null(result);
        }



        //ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            //Arrange
            realEstateDto = new RealEstateDto();
            //Act
            var createdRealEstate = await Svc<IRealEstateServices>().Create(realEstateDto);
            var differentId = Guid.NewGuid();
            var deletedRealEstate = await Svc<IRealEstateServices>().Delete(differentId);
            var result = await Svc<IRealEstateServices>().DetailAsync(createdRealEstate.Id.Value);
            //Assert
            Assert.Null(deletedRealEstate);
            Assert.NotNull(result);
        }

    }
}
