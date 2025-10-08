using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;
using Shop.Core.ServiceInterface;

namespace Shop.Data
{
    public class ShopContext : DbContext


    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) {  }
        public DbSet<SpaceShips> SpaceShips { get; set; }
        public DbSet<FilesToApi> FileToApis { get; set; }
        public DbSet<Kindergarten> Kindergartens { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
    }
}
