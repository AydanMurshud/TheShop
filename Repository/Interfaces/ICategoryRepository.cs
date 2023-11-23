using DbLayer.Models;

namespace Repository
{
	public interface ICategoryRepository:IBaseRepository<Category>
	{
		bool Add(CategoryDto category);
		bool Update(Category category,CategoryDto update);
	}
}
