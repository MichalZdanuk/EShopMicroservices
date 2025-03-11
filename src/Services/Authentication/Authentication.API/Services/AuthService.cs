using Authentication.API.DAL;
using Authentication.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.API.Services;

public class AuthService
{
	private readonly AuthDbContext _context;
	private readonly IConfiguration _config;

	public AuthService(AuthDbContext context, IConfiguration config)
	{
		_context = context;
		_config = config;
	}

	public async Task<bool> Register(string username, string password)
	{
		if (await _context.Users.AnyAsync(u => u.Username == username))
			return false; // User already exists

		var user = new User
		{
			Username = username,
			PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
		};

		_context.Users.Add(user);
		await _context.SaveChangesAsync();
		return true;
	}

	public async Task<string?> Login(string username, string password)
	{
		var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
		if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
			return null; // Invalid login

		return GenerateJwtToken(user);
	}

	private string GenerateJwtToken(User user)
	{
		var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);
		var claims = new List<Claim>
		{
			new(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new(ClaimTypes.Name, user.Username),
			new(ClaimTypes.Role, user.Role)
		};

		var token = new JwtSecurityToken(
			_config["Jwt:Issuer"],
			_config["Jwt:Audience"],
			claims,
			expires: DateTime.UtcNow.AddHours(2),
			signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
