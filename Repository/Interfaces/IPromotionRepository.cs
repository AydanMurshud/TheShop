using DbLayer.Models;
using Repository.ViewModels;


namespace Repository
{
    public interface IPromotionRepository : IBaseRepository<Promotion>
	{
		Task<IEnumerable<Promotion>> GetAll(string searchTerm);
		Task<Promotion> GetById(Guid? promotionId);
		bool Add(PromotionVM promotion);
		bool Update(Promotion promotion, PromotionVM update);

	}
}
