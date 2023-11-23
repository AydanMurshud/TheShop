//using Microsoft.AspNetCore.Mvc;
//using TheShop.Data;
//using TheShop.Interfaces;
//using TheShop.Models.User;

//namespace TheShop.Controllers
//{
//	[Route("/[controller]")]
//	public class AuthController : Controller
//	{
//		private readonly IUserRepository<User> _user;
//		public  AuthController(IUserRepository<User> user)
//		{
//			_user = user;
//		}
//		[HttpPost("register")]
//		public IActionResult Register(UserDto request)
//		{
//			var user = new User
//			{
//				UserName = request.UserName,
//				UserEmail = request.UserEmail,
//				PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
//			};
//			return Ok(user);
//		}
//		[HttpPost("Login")]
//		public IActionResult Login(UserDto request)
//		{
//			if ( _user.name!= request.UserName || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
//			{
//				return BadRequest("User name or password is incorrect");
//			}

//			return Ok(user);
//		}
//	}
//}
