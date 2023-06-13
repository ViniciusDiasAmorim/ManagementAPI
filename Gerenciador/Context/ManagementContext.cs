using Gerenciador.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Context
{
    public class ManagementContext :DbContext
    {
        public ManagementContext(DbContextOptions <ManagementContext> options) : base(options)
        {
        }

        DbSet<Order> Orders { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<OrderItems> OrderItems { get; set; }
    }
}
