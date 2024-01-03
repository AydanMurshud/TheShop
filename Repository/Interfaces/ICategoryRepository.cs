using DbLayer.Models;
using TheShop.api.ViewModels;

namespace Repository
{
	public interface ICategoryRepository:IBaseRepository<Category>
	{
		Task<IEnumerable<Category>> GetAll(string searchTerm);
		bool Add(CategoryVM category);
		bool Update(Guid Id,CategoryVM update);
	}
}
