using Microsoft.EntityFrameworkCore;
using TheShop.Data;
using TheShop.Interfaces;
using TheShop.Models;

namespace TheShop.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDBContext _context;
		public ProductRepository(ApplicationDBContext context)
		{
			_context = context;
		}
		public bool Add(Product entity)
		{
			_context.Add(entity);
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

		public async Task<Product> GetById(int Id)
		{
			return await _context.Product.FirstOrDefaultAsync(p=>p.Id ==  Id);
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
