﻿namespace ShopTARge24.Models.SpaceShips
{
    public class SpaceShipDetailsViewModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Classification { get; set; }
        public DateTime? BuildDate { get; set; }
        public int? Crew { get; set; }
        public int? EnginePower { get; set; }
        public List<ImageViewModel> Images { get; set; } = new List<ImageViewModel>();
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
