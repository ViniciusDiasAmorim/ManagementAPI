using Gerenciador.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Context
{
    public class ManagementContext :DbContext
    {
        public ManagementContext(DbContextOptions <ManagementContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
    }
}
