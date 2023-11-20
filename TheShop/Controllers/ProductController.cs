using Microsoft.AspNetCore.Mvc;
using TheShop.Interfaces;
using TheShop.Models;

namespace TheShop.Controllers
{
	[Route("/products")]
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;
		private readonly IPromotionRepository _promotionRepository;
		public ProductController(IProductRepository productRepository, IPromotionRepository promotionRepository)
		{
			_productRepository = productRepository;
			_promotionRepository = promotionRepository;
		}
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
		public async Task<IActionResult> GetProducts()
		{
			var products = await _productRepository.GetAll();
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return Ok(new { items = products.Count(), data = products });
		}
		[HttpGet("{Id}")]
		[ProducesResponseType(200, Type = typeof(Product))]
		public async Task<IActionResult> GetProductById(int Id)
		{
			var product = await _productRepository.GetById(Id);

			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}
		[HttpPost]
		[ProducesResponseType(201, Type = typeof(Product))]
		public async Task<IActionResult> PostProduct([FromBody] ProductBaseModel product)
		{
			if (product.Name == null || product.Name.Length < 3) return BadRequest("Name of the product can't be less than 3 chars");
			if (product.Description == null || product.Description.Length < 20) return BadRequest("Description of the product can't be less than 20 chars");
			if (product.Price < 0 || product.Price > 99999) return BadRequest("Product price can't be less than $0 or more than $99 999");

			var createdProduct = new Product
			{
				Name = product.Name,
				Description = product.Description,
				Image = product.Image,
				Price = product.Price,
				PromotionId = product.PromotionId != null ? product.PromotionId : null,
				CategoryId = product.CategoryId,
				CreatedAt = DateTime.UtcNow,
				UpdatedAt = DateTime.UtcNow
			};
			_productRepository.Add(createdProduct);
			if (createdProduct.PromotionId !=null)
			{
				var promotion = await _promotionRepository.GetById(product.PromotionId);
				promotion.Products.Add(createdProduct);
				_promotionRepository.Update(promotion);
			}
			var createdUri = "/product";
			return Created(createdUri, createdProduct);
		}
		[HttpPut("{Id}")]
		[ProducesResponseType(204, Type = typeof(Product))]
		public async Task<IActionResult> UpdateProduct([FromBody] ProductBaseModel product, int Id)
		{
			var productToUpdate = await _productRepository.GetById(Id);
			if (productToUpdate == null)
			{
				return NotFound();
			}
			productToUpdate.Name = product.Name;
			productToUpdate.Description = product.Description;
			productToUpdate.Image = product.Image;
			productToUpdate.Price = product.Price;
			productToUpdate.CategoryId = product.CategoryId;
			productToUpdate.UpdatedAt = DateTime.UtcNow;
			if (productToUpdate.Name == null || productToUpdate.Name.Length < 3)
			{
				return BadRequest("Name of the product can't be less than 3 chars");
			}
			if (productToUpdate.Description == null || productToUpdate.Description.Length < 20)
			{
				return BadRequest("Description of the product can't be less than 20 chars");
			}
			if (productToUpdate.Price < 0 || productToUpdate.Price > 99999)
			{
				return BadRequest("Product price can't be less than $0 or more than $99 999");
			}
			_productRepository.Update(productToUpdate);
			return NoContent();
		}
		[HttpDelete("{Id}")]
		[ProducesResponseType(204, Type = typeof(Product))]
		public async Task<IActionResult> DeleteProduct(int Id)
		{
			var product = await _productRepository.GetById(Id);
			if (product == null)
			{
				return NotFound();
			}
			_productRepository.Delete(product);
			return NoContent();
		}
	}
}
