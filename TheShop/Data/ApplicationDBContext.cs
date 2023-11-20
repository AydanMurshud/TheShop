using Microsoft.EntityFrameworkCore;
using TheShop.Models;

namespace TheShop.Data
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{
		}
		public DbSet<Product> Product { get; set; }
		public DbSet<Category> Category { get; set; }	
		public DbSet<Promotion> Promotions { get; set; }
	}
}
