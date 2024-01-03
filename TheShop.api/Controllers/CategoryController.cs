using DbLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using TheShop.api.ViewModels;
namespace TheShop.api.Controllers
{
	[Route("/[controller]")]
	[ApiController]
	//[Authorize]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryRepository _categoryRepository;
		public CategoryController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IEnumerable<Category>> GetCategories([FromQuery(Name ="search")] string? searchTerm)
		{
			var categories = await _categoryRepository.GetAll(searchTerm);
			return categories;
		}
		[HttpGet("{Id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<Category>> GetCategory(Guid? Id)
		{
			var category = await _categoryRepository.GetById(Id);
			if (category == null) return NotFound();
			return category;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<Category> CreateCategory(CategoryVM category)
		{
			if (category == null) return BadRequest();
			_categoryRepository.Add(category);
			return StatusCode(201, category);
		}
		[HttpPut("{Id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> UpdateCategory(CategoryVM category, Guid Id)
		{
			if (category == null) return BadRequest();
			_categoryRepository.Update(Id, category);
			return NoContent();
		}
		[HttpDelete("{Id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteCategory(Guid Id)
		{
			var category = await _categoryRepository.GetById(Id);
			_categoryRepository.Delete(category);
			return NoContent();
		}
	}
}
