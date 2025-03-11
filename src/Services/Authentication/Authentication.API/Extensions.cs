﻿using Authentication.API.DAL;
using Microsoft.EntityFrameworkCore;

namespace Authentication.API;

public static class Extensions
{
	public static async Task InitialiseDatabaseAsync(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();

		var context = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

		context.Database.MigrateAsync().GetAwaiter().GetResult();
	}
}
