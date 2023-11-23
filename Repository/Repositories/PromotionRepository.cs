using DbLayer;
using DbLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class PromotionRepository : IPromotionRepository
	{
		private readonly ApplicationDBContext _context;
		public PromotionRepository(ApplicationDBContext context)
		{
			_context = context;
		}
		public bool Add(Promotion entity)
		{
			_context.Add(entity);
			return Save();
		}
		public bool Delete(Promotion entity)
		{
			_context.Remove(entity);
			return Save();
		}
		public async Task<IEnumerable<Promotion>> GetAll()
		{
			return await _context.Promotions.Include(p => p.Products).ToListAsync();
		}
		public async Task<Promotion> GetById(int? Id)
		{
			return await _context.Promotions.Include(promotion => promotion.Products).FirstOrDefaultAsync(p => p.Id == Id);
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
		private void Detach(Promotion entity)
		{
			var entry = _context.Entry(entity);
			entry.State = EntityState.Detached;
		}
		private void Detach(Product entity)
		{
			var entry = _context.Entry(entity);
			entry.State = EntityState.Detached;
		}
		public bool Update(Promotion entity)
		{
			_context.Update(entity);
			return Save();
		}
	}
}
