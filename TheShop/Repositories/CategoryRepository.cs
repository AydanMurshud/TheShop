using Microsoft.EntityFrameworkCore;
using TheShop.Data;
using TheShop.Interfaces;
using TheShop.Models;

namespace TheShop.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDBContext _context;
		public CategoryRepository(ApplicationDBContext context)
		{
			_context = context;
		}
		public bool Add(Category entity)
		{
			_context.Add(entity);
			return Save();
		}

		public bool Delete(Category entity)
		{
			_context.Remove(entity);
			return Save();
		}
		public async Task<IEnumerable<Category>> GetAll()
		{
			return await _context.Category.Include(cat => cat.Products).ToListAsync();
		}
		public async Task<Category> GetById(int Id)
		{
			return await _context.Category.Include(cat => cat.Products).FirstOrDefaultAsync(cat => cat.Id == Id);
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
		public bool Update(Category entity)
		{
			_context.Update(entity);
			return Save();
		}
	}
}
