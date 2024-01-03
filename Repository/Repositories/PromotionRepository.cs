using DbLayer;
using DbLayer.Models;
using Microsoft.EntityFrameworkCore;
using Repository.ViewModels;

namespace Repository
{
	public class PromotionRepository : IPromotionRepository
	{
		private readonly ApplicationDBContext _context;
		public PromotionRepository(ApplicationDBContext context)
		{
			_context = context;
		}
		public bool Add(PromotionVM entity)
		{
			var promotion = new Promotion
			{
				Id = Guid.NewGuid(),
				PromotionName = entity.PromotionName,
				PromotionRate = entity.PromotionRate,
				Products = new List<Product>()
			};
			_context.Add(promotion);
			entity.Products.ForEach(p =>
			{
				var product = _context.Product.FirstOrDefault(p => p.Id == p.Id);
				product.PromotionId = promotion.Id;
				_context.Update(product);
				_context.SaveChanges();
			});
			return Save();
		}
		public bool Delete(Promotion promotion)
		{
			_context.Remove(promotion);
			return Save();
		}
		public async Task<IEnumerable<Promotion>> GetAll(string? searchTerm)
		{
			if(searchTerm !=null)return await _context.Promotions.Where(p=>p.PromotionName.Contains(searchTerm)).ToListAsync();
			return await _context.Promotions.Include(p => p.Products).ToListAsync();
		}
		public async Task<Promotion> GetById(Guid? Id)
		{
			return await _context.Promotions.Include(promotion => promotion.Products).FirstOrDefaultAsync(p => p.Id == Id);
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
		public bool Update(Promotion promotion,PromotionVM update)
		{

			promotion.PromotionName = update.PromotionName;
			promotion.PromotionRate = update.PromotionRate;
			promotion.Products = update.Products;
			_context.Update(promotion);
			return Save();
		}
	}
}
