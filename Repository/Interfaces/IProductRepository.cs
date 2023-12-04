using DbLayer.Models;

namespace Repository
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		Task<IEnumerable<Product>> GetAll(string searchTerm);
		bool Add(ProductDto productDto);
		bool Update(Product product, ProductDto productDto);
	}
}
