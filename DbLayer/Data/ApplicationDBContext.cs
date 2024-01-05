using DbLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DbLayer
{
    public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{
		}
		public DbSet<Product> Product { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Promotion> Promotions { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<User> Users { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>()
				.HasMany(o => o.Products)
				.WithOne(p => p.Order)
				.HasForeignKey(p => p.OrderId);
		}
	}

}
