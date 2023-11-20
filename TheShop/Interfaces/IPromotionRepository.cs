using TheShop.Models;

namespace TheShop.Interfaces
{
	public interface IPromotionRepository : IBaseRepository<Promotion>
	{
		Task<Promotion> GetById(int? promotionId);
	}
}
