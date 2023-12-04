using DbLayer.Models;

namespace Repository
{
	public interface ICategoryRepository:IBaseRepository<Category>
	{
		Task<IEnumerable<CategoryDto>> GetAll(string searchTerm);
		bool Add(CategoryDto category);
		bool Update(Category category,CategoryDto update);
	}
}
