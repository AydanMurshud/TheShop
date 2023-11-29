using DbLayer.Models;

namespace Repository
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		Task<IEnumerable<Product>> GetAll(string searchTerm);
		Task<IEnumerable<Product>> SearchByName(string searchTerm); 
		bool Add(ProductDto productDto);
		bool Update(Product product, ProductDto productDto);
	}
}
