using DbLayer.Models;

namespace Repository
{
	public interface IOrderRepository : IBaseRepository<Order>
	{
		Task<IEnumerable<Order>> GetAll();
		Task<Order> GetByUSerId(Guid USerid);
		bool Add(Order order);
		bool Update(Order order);
	}
}
