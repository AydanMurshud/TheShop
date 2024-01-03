using DbLayer;
using DbLayer.Models;
using Microsoft.EntityFrameworkCore;
using Repository.ViewModels;

namespace Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDBContext _context;
		public ProductRepository(ApplicationDBContext context)
		{
			_context = context;
		}
		public bool Add(ProductVM product)
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
		public bool Delete(Product product)
		{
			_context.Remove(product);
			return Save();
		}
		public async Task<IEnumerable<Product>> GetAll(string? searchTerm)
		{
			if (searchTerm != null) return await _context.Product.Where(p => p.Name.Contains(searchTerm)).ToListAsync();
			return await _context.Product.ToListAsync();
		}
		public async Task<Product> GetById(Guid? Id)
		{
			return await _context.Product.FirstOrDefaultAsync(p => p.Id == Id);
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
		public bool Update(Guid Id, ProductVM update)
		{
			var productToUpdate = _context.Product.FirstOrDefault(p => p.Id == Id);
			productToUpdate.Name = update.Name;
			productToUpdate.Description = update.Description;
			productToUpdate.Image = update.Image;
			productToUpdate.Price = update.Price;
			productToUpdate.PromotionId = update.PromotionId != null ? update.PromotionId : null;
			productToUpdate.CategoryId = update.CategoryId;
			productToUpdate.UpdatedAt = DateTime.UtcNow;
			_context.Update(productToUpdate);
			return Save();
		}
	}
}
