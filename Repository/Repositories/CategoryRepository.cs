using DbLayer;
using DbLayer.Models;
using Microsoft.EntityFrameworkCore;
using TheShop.api.ViewModels;

namespace Repository
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDBContext _context;
		public CategoryRepository(ApplicationDBContext context)
		{
			_context = context;
		}
		public bool Add(CategoryVM entity)
		{
			var category = new Category
			{
				Id = Guid.NewGuid(),
				Title = entity.Title,
				Image = entity.Image,
				Products = new List<Product>()
			};
			_context.Category.Add(category);
			return Save();
		}
		public bool Delete(Category category)
		{
			_context.Remove(category);
			return Save();
		}
		public async Task<IEnumerable<Category>> GetAll(string? searchTerm)
		{
			if (searchTerm == null) return await _context.Category.Include(cat => cat.Products).ToListAsync();
			return await _context.Category.Where(c => c.Title.ToLower().Contains(searchTerm.ToLower())).Include(cat => cat.Products).ToListAsync();
		}

		public Task<Category> GetById(Guid? Id)
		{
			return _context.Category.Include(cat => cat.Products).FirstOrDefaultAsync(cat => cat.Id == Id);
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
		public bool Update(Guid Id, CategoryVM update)
		{
			var categoryToUpdate = _context.Category.FirstOrDefault(cat => cat.Id == Id);
			if (categoryToUpdate == null) return false;
			categoryToUpdate.Title = update.Title;
			categoryToUpdate.Image = update.Image;
			_context.Update(categoryToUpdate);
			return Save();
		}
	}
}
