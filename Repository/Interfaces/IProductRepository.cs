using DbLayer.Models;

namespace Repository
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		bool Add(ProductDto productDto);
		bool Update(Product product, ProductDto productDto);
	}
}
