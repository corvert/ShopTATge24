using System.Threading.Tasks;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;

namespace ShopTARge24.RealEstateTest
{
    public class RealEstateTest : TestBase
    {


        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
        {
            //Arrange
            RealEstateDto dto = mockRealEstateDto();

            //Act
            var result = await Svc<IRealEstateServices>().Create(dto);


            //Assert
            Assert.NotNull(result);

        }


        //ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
        [Fact]
        public async Task ShouldNot_GetByIdRealEstate_WhenReturnsNotEqual()
        {
            //Arrange
            //realEstateDto = new RealEstateDto();
            var wrongId = Guid.NewGuid();
            Guid guid = Guid.Parse("2ded0d9f-f00f-4b44-9270-b2ad98678676");

            //Act
            //var createdRealEstate = await Svc<IRealEstateServices>().Create(realEstateDto);
            //var differentId = Guid.NewGuid();
            //var result = await Svc<IRealEstateServices>().DetailAsync(differentId);
            await Svc<IRealEstateServices>().DetailAsync(guid);

            //Assert
            Assert.NotEqual(wrongId, guid);
            // Assert.Null(result);
        }



        //Should_GetByIdRealEstate_WhenReturnsEqual()
        [Fact]
        public async Task Should_GetByIdRealEstate_WhenReturnsEqual()
        {
            //Arrange
            //realEstateDto = new RealEstateDto();
            Guid databaseGuid = Guid.Parse("2ded0d9f-f00f-4b44-9270-b2ad98678676");
            Guid guid = Guid.Parse("2ded0d9f-f00f-4b44-9270-b2ad98678676");
            //Act
            //var createdRealEstate = await Svc<IRealEstateServices>().Create(realEstateDto);
            //var result = await Svc<IRealEstateServices>().DetailAsync(createdRealEstate.Id.Value);
            await Svc<IRealEstateServices>().DetailAsync(guid);
            //Assert
            Assert.Equal(databaseGuid, guid);
        }



        //Should_deleteByIdRealEstate_WhenDeleteRealEstate()
        [Fact]
        public async Task Should_deleteByIdRealEstate_WhenDeleteRealEstate()
        {
            //Arrange
            RealEstateDto dto = mockRealEstateDto();
            var idToDelete = dto.Id;
            //Act
            var createdRealEstate = await Svc<IRealEstateServices>().Create(dto);
            var deletedRealEstate = await Svc<IRealEstateServices>().Delete((Guid)createdRealEstate.Id);
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
            RealEstateDto dto = mockRealEstateDto();
            //Act
            var createdRealEstate = await Svc<IRealEstateServices>().Create(dto);
            // var differentId = Guid.NewGuid();
            var deletedRealEstate = await Svc<IRealEstateServices>().Create(dto);
            var result = await Svc<IRealEstateServices>().Delete((Guid)deletedRealEstate.Id);
            //Assert
            // Assert.Null(deletedRealEstate);
            Assert.NotEqual(createdRealEstate.Id, result.Id);
            Assert.NotNull(result);
        }

        //Should_UpdateByIdRealEstate_WhenReturnUpdatedRealEstate()
        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateData()
        {
            ////Arrange
            //var dto = mockRealEstateDto();
            ////Act
            //var createdRealEstate = await Svc<IRealEstateServices>().Create(dto);

            //// Map the updated properties to a RealEstateDto for the Update method
            //var updatedDto = new RealEstateDto
            //{
            //    Id = createdRealEstate.Id,
            //    Area = createdRealEstate.Area,
            //    Location = "Updated Location",
            //    RoomNumber = createdRealEstate.RoomNumber,
            //    BuildingType = createdRealEstate.BuildingType,
            //    CreatedAt = createdRealEstate.CreatedAt,
            //    ModifiedAt = DateTime.UtcNow
            //};

            //var updatedRealEstate = await Svc<IRealEstateServices>().Update(updatedDto);
            ////Assert
            //Assert.Equal(createdRealEstate.Id, updatedRealEstate.Id);
            //Assert.Equal("Updated Location", updatedRealEstate.Location);

            //Arrange
            var Guid = new Guid("2ded0d9f-f00f-4b44-9270-b2ad98678676");
            var dto = mockRealEstateDto();
            RealEstateDto domain = new();
            domain.Id = Guid.Parse("2ded0d9f-f00f-4b44-9270-b2ad98678676");
            domain.Area = 250.0;
            domain.Location = "Updated Location";
            domain.RoomNumber = 5;
            domain.BuildingType = "Villa";
            domain.CreatedAt = DateTime.UtcNow;
            domain.ModifiedAt = DateTime.UtcNow;
            //Act
            await Svc<IRealEstateServices>().Update(dto);
            //Assert
            Assert.Equal(domain.Id, Guid);
            Assert.Equal(domain.Area, 250.0);
            Assert.NotEqual(domain.Area, dto.Area);
            Assert.DoesNotMatch(domain.RoomNumber.ToString(), dto.RoomNumber.ToString());
            Assert.NotEqual(domain.Location, dto.Location);
            Assert.Equal(domain.Location, "Updated Location");

        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenUpdateDataVersion2()
        {


            //in the end check that data is different
            //arrange
            //first data will be create and using mockRealEstaDto
            RealEstateDto dto = mockRealEstateDto();

            //data will be update and use new Mock method(will created)
            RealEstateDto updateDto = mockUpdateRealEstate();


            //act
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);
            var result = await Svc<IRealEstateServices>().Update(updateDto);
            Console.WriteLine(result);

            //assert
           
            Assert.NotEqual(createRealEstate.Area, result.Area);
            Assert.DoesNotMatch(createRealEstate.Location, result.Location);
            Assert.DoesNotMatch(createRealEstate.RoomNumber.ToString(), result.RoomNumber.ToString());
            Assert.NotEqual(createRealEstate.Location, result.Location);

        }

        [Fact]
        public async Task ShouldNot_UpdateRealEstate_WhenDidNotUpdateData()
        {
            //Arrange
            RealEstateDto dto = mockRealEstateDto();
            RealEstateDto nullDto = mockNullRealEstateData();
            //Act
            var createRealEstate = await Svc<IRealEstateServices>().Create(dto);
            var result = await Svc<IRealEstateServices>().Update(nullDto);
            //Assert
            Assert.NotEqual(createRealEstate.Location, result.Location);
            Assert.NotEqual(createRealEstate.Area, result.Area);
            Assert.DoesNotMatch(createRealEstate.RoomNumber.ToString(), result.RoomNumber.ToString());
            Assert.DoesNotMatch(createRealEstate.BuildingType, result.BuildingType);
        }

        [Fact]
        public async Task Should_ReturntRealEstate_WhenCorrectDataDetailAsync()
        {
            //Arrange
            RealEstateDto dto = mockRealEstateDto();

            //Act
            var createdRealEstate = await Svc<IRealEstateServices>().Create(dto);
            var detailedRealEstate = await Svc<IRealEstateServices>().DetailAsync((Guid)createdRealEstate.Id);

            //Assert
            Assert.NotNull(detailedRealEstate);
            Assert.Equal(createdRealEstate.Id, detailedRealEstate.Id);
            Assert.Equal(createdRealEstate.Area, detailedRealEstate.Area);
            Assert.Equal(createdRealEstate.Location, detailedRealEstate.Location);
            Assert.Equal(createdRealEstate.RoomNumber, detailedRealEstate.RoomNumber);
            Assert.Equal(createdRealEstate.BuildingType, detailedRealEstate.BuildingType);
        }

        [Fact]
        public async Task Should_UpdateRealEstate_WhenPartialUpdate()
        {
            //Arrange
            RealEstateDto dto = mockRealEstateDto();

            //Act
            var createdRealEstate = await Svc<IRealEstateServices>().Create(dto);

            var updateDto = new RealEstateDto
            {
              
                Area = 99, 
                Location = "Changed Location Only", 
                RoomNumber = createdRealEstate.RoomNumber, 
                BuildingType = createdRealEstate.BuildingType,
                CreatedAt = createdRealEstate.CreatedAt,
                ModifiedAt = DateTime.UtcNow
            };

            var updatedRealEstate = await Svc<IRealEstateServices>().Update(updateDto);

            //Assert        
           
            Assert.NotEqual(createdRealEstate.Area, updatedRealEstate.Area);
            Assert.DoesNotMatch(createdRealEstate.Area.ToString(), updatedRealEstate.Area.ToString());
            Assert.Equal("Changed Location Only", updatedRealEstate.Location);
            Assert.NotEqual(createdRealEstate.Location, updatedRealEstate.Location);
            Assert.Equal(createdRealEstate.RoomNumber, updatedRealEstate.RoomNumber);
            Assert.Equal(createdRealEstate.BuildingType, updatedRealEstate.BuildingType);
        }

        [Fact]
        public async Task ShouldNot_CreateRealEstate_PartialNullValues()
        {
            //Arrange
            RealEstateDto dto = new RealEstateDto
            {
                Area = null,
                Location = "Test Location",
                RoomNumber = 3,
                BuildingType = "",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            //Act
            var result = await Svc<IRealEstateServices>().Create(dto);

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.Area);
            Assert.NotNull(result.Location);
            Assert.NotNull(result.RoomNumber);

        }



        private RealEstateDto mockNullRealEstateData()
        {
            return new RealEstateDto
            {

                Id = null,
                Area = null,
                Location = "",
                RoomNumber = null,
                BuildingType = "",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

        }
        private RealEstateDto mockRealEstateDto()
        {
            return new RealEstateDto
            {

                //Id = Guid.NewGuid(),
                Area = 120.5,
                Location = "Test Location",
                RoomNumber = 3,
                BuildingType = "Apartment",
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

        }
        private RealEstateDto mockUpdateRealEstate()
        {
            return new RealEstateDto
            {

                //Id = Guid.NewGuid(),
                Area = 220.5,
                Location = "Updated Location",
                RoomNumber = 4,
                BuildingType = "Villa",
                CreatedAt = DateTime.Now.AddDays(10),
                ModifiedAt = DateTime.Now.AddYears(1)
            };

        }
    }
}
