using Authentication.API.Commands;
using Authentication.API.Queries;
using Authentication.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(AuthService _authService) : ControllerBase
{
	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegisterRequest request)
	{
		var success = await _authService.Register(request.Username, request.Password);
		if (!success) return BadRequest("User already exists");
		return Ok("User registered successfully");
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginRequest request)
	{
		var token = await _authService.Login(request.Username, request.Password);
		if (token == null) return Unauthorized("Invalid credentials");
		return Ok(new { Token = token });
	}
}
