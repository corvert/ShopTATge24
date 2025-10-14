
using Microsoft.AspNetCore.Http;

namespace Shop.Core.Dto
{
    public class KindergartenDto
    {
        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public int ChildrenCount { get; set; }
        public string KindergartenName { get; set; }
        public string TeacherName { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<KGFileToDatabaseDto> Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
