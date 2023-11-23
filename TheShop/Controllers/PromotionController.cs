using DbLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;

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
		public ActionResult PostPromotion([FromBody] PromotionDto promotion)
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

		[HttpPut("{Id}")]
		[ProducesResponseType(204, Type = typeof(Promotion))]
		public async Task<IActionResult> UpdatePromotion(int Id, [FromBody] PromotionDto promotion)
		{
			var promotionToUpdate = await _promotionRepository.GetById(Id);
			if (promotionToUpdate == null)
			{
				return NotFound();
			};
			promotionToUpdate.PromotionName = promotion.PromotionName;
			promotionToUpdate.PromotionRate = promotion.PromotionRate;
			_promotionRepository.Update(promotionToUpdate);
			return NoContent();
		}
		[HttpDelete("{Id}")]
		[ProducesResponseType(204, Type = typeof(Promotion))]
		public async Task<IActionResult> DeletePromotion(int Id)
		{
			var promotion = await _promotionRepository.GetById(Id);
			_promotionRepository.Delete(promotion);
			return NoContent();
		}
	}
}
