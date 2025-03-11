using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BuildingBlocks.Context;
public class MicroservicesContext : IContext
{
	private readonly IHttpContextAccessor _httpContextAccessor;

	public MicroservicesContext(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
	}

	public Guid? UserId =>
		Guid.TryParse(_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var id) ? id : null;

	public string? Role =>
		_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Role)?.Value;

	public bool IsAuthenticated =>
		_httpContextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false;
}
