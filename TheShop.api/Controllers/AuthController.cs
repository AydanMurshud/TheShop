using DbLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace TheShop.api.Controllers
{
	[Route("/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuth _authRepository;
		public AuthController(IAuth authRepository)
		{
			_authRepository = authRepository;
		}
		[HttpPost("register")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<User>> Register(UserRegisterModel user)
		{
			if (user == null) return BadRequest();
			var result = _authRepository.Register(user);
			if (result == null) return BadRequest();
			return StatusCode(201, result);
		}
		[HttpPost("login")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<User>> Login(UserLoginModel user)
		{
			if (user == null) return BadRequest();
			var result =  _authRepository.Login(user);
			if (result == null) return BadRequest();
			return StatusCode(200, result);
		}
	}
}
