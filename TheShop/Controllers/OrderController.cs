using DbLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace TheShop.Controllers
{
	[Route("/order")]
	public class OrderController : Controller
	{
		private readonly IOrderRepository _orderRepository;
		public OrderController(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]

		public async Task<IActionResult> GetOrders()
		{
			var orders = await _orderRepository.GetAll();
			if(!ModelState.IsValid) return BadRequest(ModelState);
			return Ok(new {items = orders.Count(), data = orders});
		}

		[HttpGet("{Id}")]
		[ProducesResponseType(200,Type = typeof(Order))]
		public async Task<IActionResult> GetOrderById(int Id)
		{
			var order = await _orderRepository.GetById(Id);
			if (!ModelState.IsValid) return BadRequest(ModelState);
			return Ok(order);
		}

		[HttpPost]
		[ProducesResponseType(201,Type = typeof(Order))]
		public async Task<IActionResult> PostOrder([FromBody] Order order)
		{
			var createdOrder = new Order
			{
				UserId = order.UserId,
				Orders = order.Orders
			};
			_orderRepository.Add(createdOrder);
			var createdUri = "/order";
			return Created(createdUri, createdOrder);
		}

		[HttpDelete("{Id}")]
		[ProducesResponseType(204, Type = typeof(Order))]
		public async Task<IActionResult> DeleteOrder(int Id)
		{
			var order = await _orderRepository.GetById(Id);
			if (order == null) return NotFound();
			_orderRepository.Delete(order);
			return NoContent();
		}
	}
}
