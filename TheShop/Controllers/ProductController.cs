using DbLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace TheShop.Controllers
{
	[Authorize]
	[Route("/products")]
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;
		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
		public async Task<IActionResult> GetProducts([FromQuery(Name = "search")] string? searchTerm)
		{
			var products = await _productRepository.GetAll(searchTerm);
			if (!ModelState.IsValid) return BadRequest(ModelState);
			return Ok(new { items = products.Count(), data = products });
		}

		[HttpGet("{Id}")]
		[ProducesResponseType(200, Type = typeof(Product))]
		public async Task<IActionResult> GetProductById(int Id)
		{
			var product = await _productRepository.GetById(Id);
			if (!ModelState.IsValid) return BadRequest();
			if (product == null) return NotFound();
			return Ok(new { data = product });
		}

		[HttpPost]
		[ProducesResponseType(201, Type = typeof(Product))]
		public async Task<IActionResult> PostProduct([FromBody] ProductDto product)
		{
			if (product.Name == null || product.Name.Length < 3) return BadRequest("Name of the product can't be less than 3 chars");
			if (product.Description == null || product.Description.Length < 20) return BadRequest("Description of the product can't be less than 20 chars");
			if (product.Price < 0 || product.Price > 99999) return BadRequest("Product price can't be less than $0 or more than $99 999");
			_productRepository.Add(product);
			var createdUri = "/product";
			return Created(createdUri, product);
		}

		[HttpPut("{Id}")]
		[ProducesResponseType(204, Type = typeof(Product))]
		public async Task<IActionResult> UpdateProduct([FromBody] ProductDto update, int Id)
		{
			var productToUpdate = await _productRepository.GetById(Id);
			if (productToUpdate == null) return NotFound();
			if (update.Name == null || update.Name.Length < 3) return BadRequest("Name of the product can't be less than 3 chars");
			if (update.Description == null || update.Description.Length < 20) return BadRequest("Description of the product can't be less than 20 chars");
			if (update.Price < 0 || update.Price > 99999) return BadRequest("Product price can't be less than $0 or more than $99 999");
			_productRepository.Update(productToUpdate, update);
			return NoContent();
		}

		[HttpDelete("{Id}")]
		[ProducesResponseType(204, Type = typeof(Product))]
		public async Task<IActionResult> DeleteProduct(int Id)
		{
			var product = await _productRepository.GetById(Id);
			if (product == null) return NotFound();
			_productRepository.Delete(product);
			return NoContent();
		}
	}
}
