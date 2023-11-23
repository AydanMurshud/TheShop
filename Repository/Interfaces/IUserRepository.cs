

namespace Repository
{
	public interface IUserRepository<T>
	{
		bool Add(T entity);
		bool Update(T entity);
		bool Delete(T entity);
		bool Save();
	}
}
