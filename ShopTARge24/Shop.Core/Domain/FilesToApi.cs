
namespace Shop.Core.Domain
{
    public class FilesToApi
    {
        public Guid Id { get; set; }
        public string? ExistingFilePath { get; set; }
        public Guid? SpaceShipId { get; set; }

    }

    public class KGFileToApis
    {
        public Guid Id { get; set; }
        public string? ExistingFilePath { get; set; }
   
        public Guid? KindergartenId { get; set; }
    }
}
