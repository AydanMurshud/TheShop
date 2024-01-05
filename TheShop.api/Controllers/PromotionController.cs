using DbLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.ViewModels;

namespace TheShop.api.Controllers
{
	[Route("/[controller]")]
	[ApiController]
	public class PromotionController : ControllerBase
	{
		private readonly IPromotionRepository _promotionRepository;
		public PromotionController(IPromotionRepository promotionRepository)
		{
			_promotionRepository = promotionRepository;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IEnumerable<Promotion>> GetPromotions(string? searchTerm)
		{
			var promotions = await _promotionRepository.GetAll(searchTerm);
			return promotions;
		}
		[HttpGet("{Id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<Promotion>> GetPromotionById(Guid? Id)
		{
			var promotion = await _promotionRepository.GetById(Id);
			if (promotion == null) return NotFound();
			return promotion;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<Promotion> PostPromotion(PromotionVM promotion)
		{
			
			_promotionRepository.Add(promotion);

			return StatusCode(201, promotion);
		}
		[HttpPut("{Id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> PutPromotion(PromotionVM update, Guid Id)
		{
			var promotion = await _promotionRepository.GetById(Id);
			if (promotion == null) return NotFound();
			if (update == null ) return BadRequest();
			_promotionRepository.Update(promotion, update);
			return NoContent();
		}
		[HttpDelete("{Id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeletePromotion(Guid Id)
		{
			var promotion = await _promotionRepository.GetById(Id);
			if (promotion == null) return NotFound();
			_promotionRepository.Delete(promotion);
			return NoContent();
		}

	}
}
