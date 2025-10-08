namespace ShopTARge24.Models.Kindergarten
{
    public class KindergartenCreateUpdateViewModel
    {

        public Guid Id { get; set; }
        public string GroupName { get; set; }
        public int ChildrenCount { get; set; }
        public string KindergartenName { get; set; }
        public string TeacherName { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<KindergratenImageViewModel> Image { get; set; } = new List<KindergratenImageViewModel>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
