using CardInventoryServiceDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace CardInventoryServiceInfrastructure
{
    public class InventoryDbContext:DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }
        public DbSet<Stock> Stocks { get; set; }
    }
}