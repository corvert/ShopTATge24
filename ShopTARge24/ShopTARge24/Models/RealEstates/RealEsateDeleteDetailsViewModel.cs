namespace ShopTARge24.Models.RealEstates
{
    public class RealEstateDeleteDetailsViewModel
    {
        public Guid? Id { get; set; }
        public double? Area { get; set; }
        public string? Location { get; set; }
        public int? RoomNumber { get; set; }
        public string? BuildingType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool ShowDeleteBtn { get; set; }
    }
}
