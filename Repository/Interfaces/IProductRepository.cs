using DbLayer.Models;
using Repository.ViewModels;

namespace Repository
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		Task<IEnumerable<Product>> GetAll(Guid categoryId,string searchTerm);
		bool Add(ProductVM productDto);
		bool Update(Guid Id, ProductVM update);
	}
}
