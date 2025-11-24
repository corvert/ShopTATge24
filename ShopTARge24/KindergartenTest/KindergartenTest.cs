using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Xunit;

namespace KindergartenTest
{
    public class KindergartenTest : TestBase
    {
        [Fact]
        public async Task Should_CreateKindergarten_WhenCreateKindergarten()
        {
            // Arrange
            KindergartenDto dto = MockKindergartenDto();

            // Act
            var result = await Svc<IKindergartenServices>().Create(dto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Sunshine Group", result.GroupName);
            Assert.Equal(15, result.ChildrenCount);
            Assert.Equal("Happy Kids", result.KindergartenName);
            Assert.Equal("Jane Smith", result.TeacherName);
            Assert.IsType<int>(result.ChildrenCount);
        }

    

        [Fact]
        public async Task Should_UpdateKindergarten_Update()
        {
            // Arrange
            KindergartenDto dto = MockKindergartenDto();

            var created = await Svc<IKindergartenServices>().Create(dto);

            var updateDto = new KindergartenDto
            {
               
                GroupName = "Afternoon Group",
                ChildrenCount = 18,
                KindergartenName = "Bright Future",
                TeacherName = "Mary Johnson",
                UpdatedAt = DateTime.Now
            };

            // Act
            var result = await Svc<IKindergartenServices>().Update(updateDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Afternoon Group", result.GroupName);
            Assert.Equal(18, result.ChildrenCount);
            Assert.Equal("Mary Johnson", result.TeacherName);
            Assert.DoesNotMatch(created.GroupName, result.GroupName);
            Assert.DoesNotMatch(created.ChildrenCount.ToString(), result.ChildrenCount.ToString());
        }

        [Fact]
        public async Task Should_DeleteKindergarten_WhenDelete()
        {
            // Arrange
            KindergartenDto dto = MockKindergartenDto();

            // Act
            var created = await Svc<IKindergartenServices>().Create(dto);
            var deleted = await Svc<IKindergartenServices>().Delete(created.Id);
            var result = await Svc<IKindergartenServices>().DetailAsync(created.Id);

            // Assert
            Assert.NotNull(deleted);
            Assert.Null(result);
        }

        [Fact]
        public async Task Should_GetDetailsKindergarten_Successfully()
        {
            // Arrange
            KindergartenDto dto = MockKindergartenDto();

            var created = await Svc<IKindergartenServices>().Create(dto);

            // Act
            var result = await Svc<IKindergartenServices>().DetailAsync(created.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(created.Id, result.Id);
            Assert.Equal(created.GroupName, result.GroupName);
            Assert.Equal(created.ChildrenCount, result.ChildrenCount);
        }

        [Fact]
        public async Task Should_ReturnNull_WhenKindergartenNotFound()
        {
            // Arrange
            var nonExistentId = Guid.NewGuid();

            // Act
            var result = await Svc<IKindergartenServices>().DetailAsync(nonExistentId);

            // Assert
            Assert.Null(result);
        }



        [Fact]
        public async Task Should_UpdateKindergarten_WhenPartialUpdate()
        {
            // Arrange
            KindergartenDto dto = MockKindergartenDto();

            var created = await Svc<IKindergartenServices>().Create(dto);

            var updateDto = new KindergartenDto
            {
               
                GroupName = created.GroupName,
                ChildrenCount = 25,
                KindergartenName = created.KindergartenName,
                TeacherName = created.TeacherName,
                UpdatedAt = DateTime.Now
            };

            // Act
            var result = await Svc<IKindergartenServices>().Update(updateDto);

            // Assert
            Assert.Equal(25, result.ChildrenCount);
            Assert.NotEqual(created.ChildrenCount, result.ChildrenCount);
        }

        private static KindergartenDto MockKindergartenDto()
        {
            return new KindergartenDto
            {
                GroupName = "Sunshine Group",
                ChildrenCount = 15,
                KindergartenName = "Happy Kids",
                TeacherName = "Jane Smith",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }
    }
}