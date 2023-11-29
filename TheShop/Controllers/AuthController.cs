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
		public async Task<IActionResult> RegisterUser([FromBody] UserDto user)
		{
			if (user == null)
			{
				return BadRequest();
			}
			_authRepository.Register(user);
			var createdUri = "/";
			return Created(createdUri, user);
		}

		[HttpPost("/login")]
		[ProducesResponseType(200,Type = typeof(User))]
		public async Task<IActionResult> LoginUser([FromBody] UserDto user)
		{
			if (_authRepository.Login(user))
			{
				return Ok(user);
			}
			return BadRequest("User name or password incorrect");
		}
	}
}
