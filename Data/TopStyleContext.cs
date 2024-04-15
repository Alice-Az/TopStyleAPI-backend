using Microsoft.EntityFrameworkCore;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data;

public partial class TopStyleContext : DbContext
{
    public TopStyleContext()
    {
    }

    public TopStyleContext(DbContextOptions<TopStyleContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<OrderProduct> OrderProducts { get; set; }


}
