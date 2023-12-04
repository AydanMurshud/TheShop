using DbLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace TheShop.Controllers
{

	[Route("/categories")]

	public class CategoryController : Controller
	{
		private readonly ICategoryRepository _categoryRepository;
		public CategoryController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
		public async Task<IActionResult> GetCategories(
			[FromQuery(Name = "search")] string? searchTerm
			)
		{
			var categories = await _categoryRepository.GetAll(searchTerm);
			if (!ModelState.IsValid) return BadRequest(ModelState);
			return Ok(new { items = categories.Count(), data = categories });
		}

		[HttpGet("{Id}")]
		[ProducesResponseType(200, Type = typeof(Category))]
		public async Task<IActionResult> GetCategoryById(int Id)
		{
			var category = await _categoryRepository.GetById(Id);
			if (category == null) return NotFound();
			return Ok(category);
		}

		[HttpPost]
		[ProducesResponseType(201, Type = typeof(Category))]
		public ActionResult AddCategory([FromBody] CategoryDto category)
		{
			if (category == null) return BadRequest();
			_categoryRepository.Add(category);
			var createdUri = "/category";
			return Created(createdUri, category);
		}

		[HttpPut("{Id}")]
		[ProducesResponseType(204, Type = typeof(Product))]
		public async Task<IActionResult> UpdateProduct([FromBody] CategoryDto update, int Id)
		{
			var category = await _categoryRepository.GetById(Id);
			if (category == null) return NotFound();
			if (update.Title == null || update.Title.Length < 3) return BadRequest("Name of the category can't be less than 3 chars");
			_categoryRepository.Update(category,update);
			return NoContent();
		}

		[HttpDelete("{Id}")]
		[ProducesResponseType(204, Type = typeof(Category))]
		public async Task<IActionResult> DeleteCategory(int Id)
		{
			var category = await _categoryRepository.GetById(Id);
			if (category == null)return NotFound();
			_categoryRepository.Delete(category);
			return NoContent();
		}
	}
}
