using DbLayer;
using DbLayer.Models;

namespace Repository
{
	public class AuthRepository : IAuth
	{
		private readonly ApplicationDBContext _context;
		public AuthRepository(ApplicationDBContext context)
		{
			_context = context;
		}

		public bool Delete(User user)
		{
			throw new NotImplementedException();
		}

		public bool Save()
		{
			var save = _context.SaveChanges();
			return save > 0 ? true : false;
		}

		public bool Update(User user)
		{
			throw new NotImplementedException();
		}

		public bool Register(UserDto user)
		{
			var createUser = new User
			{
				UserName = user.UserName,
				UserEmail = user.UserEmail,
				PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password)
			};
			_context.Add(createUser);
			return Save();
		}

		public bool Login(UserDto user)
		{
			var userToLogin = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
			var pass = BCrypt.Net.BCrypt.Verify(user.Password, userToLogin.PasswordHash, false, BCrypt.Net.HashType.SHA256);
			if(userToLogin !=null && pass)
			{
				return true;
			}
			return false;
		}
	}
}
