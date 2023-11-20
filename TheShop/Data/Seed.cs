using TheShop.Models;

namespace TheShop.Data
{
	public class Seed
	{
		public static void SeedData(IApplicationBuilder applicationBuilder)
		{
			using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();

				context.Database.EnsureCreated();

				if (!context.Category.Any())
				{
					var categories = new List<Category>()
				{
					new Category() {
						Title = "Electronics",
						Image = "Some Image",
						Products= new List<Product>()
						{
							new Product()
							{
								Name = "Laptop",
								Description="Some Description",
								Image = "Some Image",
								Price = 1999
							},
							new Product()
							{
								Name = "SmartPhone",
								Description="Some Description",
								Image = "Some Image",
								Price = 300
							}
						}
					}
				};
					context.SaveChanges();
				}
			}
		}
	}
}
