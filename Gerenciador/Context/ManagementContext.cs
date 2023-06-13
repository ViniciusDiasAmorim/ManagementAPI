using Gerenciador.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerenciador.Context
{
    public class ManagementContext :DbContext
    {
        public ManagementContext(DbContextOptions <ManagementContext> options) : base(options)
        {
        }

        DbSet<Order> orders { get; set; }
        DbSet<User> users { get; set; }
        DbSet<Product> products { get; set; }
    }
}
