using DbLayer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.ViewModels;

namespace TheShop.api.Controllers
{
	[Route("/[controller]")]
	[ApiController]
	
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IEnumerable<Product>> GetProducts([FromQuery(Name = "category")] Guid categoryId, [FromQuery(Name = "search")] string? searchTerm)
		{
			var products = await _productRepository.GetAll(categoryId,searchTerm);
			return products;
		}
		[HttpGet("{Id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<Product>> GetProductById(Guid Id)
		{
			var product = await _productRepository.GetById(Id);
			if (product == null) return NotFound();
			return product;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public ActionResult<Product> PostProduct(ProductVM product)
		{
			if (product == null) return BadRequest("Bad request");
			_productRepository.Add(product);
			return StatusCode(201, product);
		}
		[HttpPut("{Id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> PutProduct(ProductVM update, Guid Id)
		{
			if (update == null) return BadRequest();
			_productRepository.Update(Id, update);
			return NoContent();
		}
		[HttpDelete("{Id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> DeleteProduct(Product product)
		{
			_productRepository.Delete(product);
			return NoContent();
		}
	}
}
