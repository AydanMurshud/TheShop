namespace Repository
{
	public interface IBaseRepository<T>
	{
		//Task<IEnumerable<T>> GetAll();
		Task<T> GetById(int? Id);
		//bool Add(T entity);
		//bool Update(T entity);
		bool Delete(T entity);
		bool Save();
	}
}
