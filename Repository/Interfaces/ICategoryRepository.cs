using DbLayer.Models;

namespace Repository
{
	public interface ICategoryRepository:IBaseRepository<Category>
	{
		Task<IEnumerable<Category>> GetAll(string searchTerm,string deep);
		bool Add(CategoryDto category);
		bool Update(Category category,CategoryDto update);
	}
}
