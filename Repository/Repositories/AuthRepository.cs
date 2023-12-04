using DbLayer;
using DbLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Repository
{
	public class AuthRepository : IAuth
	{
		private readonly ApplicationDBContext _context;
		private readonly IConfiguration _config;
		public AuthRepository(ApplicationDBContext context, IConfiguration config)
		{
			_config = config;
			_context = context;
		}

		public async Task<IEnumerable<User>> GetUsers()
		{
			var users = await _context.Users.Include(u=>u.Orders).ToListAsync();
			return users;
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
		public string GenerateJwt(UserLoginModel user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				_config["Jwt:Issuer"],
				 _config["Jwt:Issuer"],
				 claims: new List<Claim>() {
					 new Claim("email", user.UserEmail),
				 },
				 expires: DateTime.Now.AddMinutes(120),
				 signingCredentials: credentials
			 );
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
		public string? Register(UserRegisterModel user)
		{
			var createUser = new User
			{
				UserName = user.UserName,
				UserEmail = user.UserEmail,
				PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password)
			};
			_context.Add(createUser);
			var token = GenerateJwt(user);
			Save();
			return token;
		}

		public string? Login(UserLoginModel user)
		{
			var userToLogin = _context.Users.Where(u => u.UserEmail == user.UserEmail).FirstOrDefault();
			if (userToLogin != null && BCrypt.Net.BCrypt.Verify(user.Password, userToLogin.PasswordHash, false, BCrypt.Net.HashType.SHA256))
			{
				var token = GenerateJwt(user);
				return token;
			}
			return null;

		}
	}
}
