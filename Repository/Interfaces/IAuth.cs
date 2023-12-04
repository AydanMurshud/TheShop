using DbLayer.Models;
namespace Repository
{
	public interface IAuth
	{
		string Register(UserRegisterModel user);
		string Login(UserLoginModel user);
		Task<IEnumerable<User>> GetUsers();
		string GenerateJwt(UserLoginModel user);
		//bool Add(UserDto user);
		bool Update(User user);
		bool Delete(User user);
		bool Save();
	}
}
