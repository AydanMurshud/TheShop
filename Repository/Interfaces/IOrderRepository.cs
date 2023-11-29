using DbLayer.Models;

namespace Repository
{
	public interface IOrderRepository : IBaseRepository<Order>
	{
		Task<IEnumerable<Order>> GetAll();
		bool Add(Order order);
		bool Update(Order order);
	}
}
