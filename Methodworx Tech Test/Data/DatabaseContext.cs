using Methodworx_Tech_Test.Models.Generated;
using Microsoft.EntityFrameworkCore;

namespace Methodworx_Tech_Test.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }

        public DbSet<BasketStatus> BasketStatuses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }
    }
}
