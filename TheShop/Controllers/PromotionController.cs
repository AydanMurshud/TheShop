using Microsoft.AspNetCore.Mvc;
using TheShop.Interfaces;
using TheShop.Models;

namespace TheShop.Controllers
{
	[Route("/promotions")]
	public class PromotionController : Controller
	{
		private readonly IPromotionRepository _promotionRepository;
		public PromotionController(IPromotionRepository promotionRepository)
		{
			_promotionRepository = promotionRepository;
		}
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Promotion>))]
		public async Task<IActionResult> GetPromotions()
		{
			var promotions = await _promotionRepository.GetAll();
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(promotions);
		}
		[HttpPost]
		[ProducesResponseType(201, Type = typeof(Promotion))]
		public IActionResult PostPromotion([FromBody] Promotion promotion)
		{
			var createdPromotion = new Promotion
			{
				PromotionName = promotion.PromotionName,
				PromotionRate = promotion.PromotionRate,
			};
			var createdUri = "/promotions";
			_promotionRepository.Add(createdPromotion);
			return Created(createdUri, createdPromotion);
		}
	}
}
