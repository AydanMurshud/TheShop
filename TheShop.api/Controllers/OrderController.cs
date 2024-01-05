using DbLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace TheShop.api.Controllers
{
	[Route("/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderRepository _orderRepository;
		public OrderController(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IEnumerable<Order>> GetOrders()
		{
			var orders = await _orderRepository.GetAll();
			return orders;
		}
		[HttpGet("{UserId}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<Order>> GetOrderByUserId(Guid UserId)
		{
			var order = await _orderRepository.GetByUSerId(UserId);
			if (order == null) return NotFound();
			return order;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<Order> CreateOrder(Order order)
		{
			if(order == null) return BadRequest();
			_orderRepository.Add(order);
			return StatusCode(201, order);
		}
	}
}
