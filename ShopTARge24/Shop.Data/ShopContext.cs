using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Shop.Core.Domain;


namespace Shop.Data
{
 

    public class ShopContext : IdentityDbContext<ApplicationUser>
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }
        public DbSet<SpaceShips> SpaceShips { get; set; }
        public DbSet<FilesToApi> FileToApis { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
    }
}
