using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Context;
public static class Extensions
{
	public static IServiceCollection AddSharedContext(this IServiceCollection services)
	{
		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		services.AddScoped<IContext, MicroservicesContext>();

		return services;
	}
}
