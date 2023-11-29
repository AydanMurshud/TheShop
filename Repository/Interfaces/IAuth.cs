using DbLayer.Models;
namespace Repository
{
	public interface IAuth
	{
		bool Register(UserDto user);
		bool Login(UserDto user);
		//bool Add(UserDto user);
		bool Update(User user);
		bool Delete(User user);
		bool Save();
	}
}
