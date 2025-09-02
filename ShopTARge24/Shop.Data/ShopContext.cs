using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;

namespace Shop.Data
{
    public class ShopContext : DbContext
    {
        public DbSet<SpaceShips> SpaceShips { get; set; }
    }
}
