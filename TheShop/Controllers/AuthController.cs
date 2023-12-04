using DbLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace TheShop.Controllers
{
	[Route("/auth")]
	public class AuthController : Controller
	{
		private readonly IAuth _authRepository;
		public AuthController(IAuth authRepository)
		{
			_authRepository = authRepository;
		}

		[HttpPost("/register")]
		[ProducesResponseType(201, Type = typeof(User))]
		public async Task<IActionResult> RegisterUser([FromBody] UserRegisterModel user)
		{
			if (user == null)
			{
				return BadRequest();
			}

			var token = _authRepository.Register(user);
			var createdUri = "/";
			return Created(createdUri, token);
		}

		[HttpPost("/login")]
		[ProducesResponseType(200, Type = typeof(User))]
		public async Task<IActionResult> LoginUser([FromBody] UserLoginModel user)
		{
			if (_authRepository.Login(user) != null)
			{
				return Ok(new { token = _authRepository.GenerateJwt(user) });
			}
			return BadRequest("User name or password incorrect");
		}

		[HttpGet("/users")]
		[ProducesResponseType(200,Type =  typeof(IEnumerable<User>))]
		 public async Task<IActionResult> GetUsers()
		{
			var users = await _authRepository.GetUsers();
			return Ok(users);
		}

	}
}
