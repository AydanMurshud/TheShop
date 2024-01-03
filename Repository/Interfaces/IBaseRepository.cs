namespace Repository
{
	public interface IBaseRepository<T>
	{
		Task<T> GetById(Guid? Id);
		bool Delete(T entity);
		bool Save();
	}
}
