using DbLayer.Models;


namespace Repository
{
    public interface IPromotionRepository : IBaseRepository<Promotion>
	{
		Task<Promotion> GetById(int? promotionId);

	}
}
