using BuildingBlocks.Context;
using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddApplicationServices(builder.Configuration)
	.AddInfrastructureServices(builder.Configuration)
	.AddApiServices(builder.Configuration)
	.AddSharedAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();
app.UseApiServices();

if (app.Environment.IsDevelopment())
{
	await app.InitialiseDatabaseAsync();
}

app.Run();
