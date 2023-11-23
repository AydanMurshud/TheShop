using DbLayer;
using DbLayer.Models;


namespace Repository
{
	public class UserRepository : IUserRepository<User>
	{
		private readonly ApplicationDBContext _context;
		public UserRepository(ApplicationDBContext context)
		{
			_context = context;
		}

		public bool Add(User entity)
		{
			_context.Users.Add(entity);
			return Save();
		}

		public bool Delete(User entity)
		{
			_context.Users.Remove(entity);
			return Save();
		}

		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(User entity)
		{
			_context.Users.Update(entity);
			return Save();
		}
	}
}
