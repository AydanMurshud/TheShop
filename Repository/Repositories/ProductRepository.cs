using DbLayer;
using DbLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDBContext _context;
		public ProductRepository(ApplicationDBContext context)
		{
			_context = context;
		}
		public bool Add(ProductDto product)
		{
			var newProduct = new Product
			{
				Name = product.Name,
				Description = product.Description,
				Image = product.Image,
				Price = product.Price,
				PromotionId = product.PromotionId != null ? product.PromotionId : null,
				CategoryId = product.CategoryId,
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow
			};
			_context.Add(newProduct);
			return Save();
		}

		public bool Delete(Product entity)
		{
			_context.Remove(entity);
			return Save();
		}

		public async Task<IEnumerable<Product>> GetAll()
		{
			return await _context.Product.ToListAsync();
		}

		public async Task<Product> GetById(int? Id)
		{
			return await _context.Product.FirstOrDefaultAsync(p => p.Id == Id);
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(Product entity)
		{
			_context.Update(entity);
			return Save();
		}
	}
}
