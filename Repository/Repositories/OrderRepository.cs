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
				UserId = order.UserId,
			};
			_context.Orders.Add(newOrder);
			return Save();
		}

		public bool Delete(Order order)
		{
			_context.Orders.Remove(order);
			return Save();
		}

		public async Task<IEnumerable<Order>> GetAll()
		{
			return await _context.Orders.Include(o => o.Products).ToListAsync();
		}
		public async Task<Order> GetByUSerId(Guid UserId)
		{
			return await _context.Orders.FirstOrDefaultAsync(o => o.UserId == UserId);
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
		public async Task<Order> AddOrderToHistory(Order order, Guid userId)
		{
			var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
			if (user == null) return null;
			user.Orders.Add(order);
			return order;
		}
		public bool Update(Order order)
		{
			_context.Update(order);
			return Save();
		}

		public Task<Order> GetById(Guid? Id)
		{
			throw new NotImplementedException();
		}
	}
}
