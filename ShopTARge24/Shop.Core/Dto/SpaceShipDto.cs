

using Microsoft.AspNetCore.Http;

namespace Shop.Core.Dto
{
    public class SpaceShipDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Classification { get; set; }
        public DateTime? BuildDate { get; set; }
        public int? Crew { get; set; }
        public int? EnginePower { get; set; }
        public List<IFormFile>? Files { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
