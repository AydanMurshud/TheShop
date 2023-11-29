using DbLayer.Models;


namespace Repository
{
    public interface IPromotionRepository : IBaseRepository<Promotion>
	{
		Task<IEnumerable<Promotion>> GetAll(string searchTerm);
		Task<Promotion> GetById(int? promotionId);
		bool Add(PromotionDto promotion);
		bool Update(Promotion promotion, PromotionDto promotionDto);

	}
}
