using DbLayer;
using DbLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDBContext _context;
		public OrderRepository(ApplicationDBContext context)
		{
			_context = context;
		}

		public bool Add(Order order)
		{
			var newOrder = new Order
			{
				Orders = order.Orders,
				UserId = order.UserId,
			};
			_context.Orders.Add(newOrder);
			return Save();
		}

		public bool Delete(Order entity)
		{
			_context.Orders.Remove(entity);
			return Save();
		}

		public async Task<IEnumerable<Order>> GetAll()
		{
			return await _context.Orders.Include(o => o.Orders).ToListAsync();
		}

		public async Task<Order> GetById(int? Id)
		{
			return await _context.Orders.FirstOrDefaultAsync(o => o.Id == Id);
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(Order order)
		{
			_context.Update(order);
			return Save();
		}
	}
}
