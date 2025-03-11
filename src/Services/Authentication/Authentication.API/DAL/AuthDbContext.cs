using Authentication.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication.API.DAL;

public class AuthDbContext : DbContext
{
	public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

	public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>()
			.HasIndex(u => u.Username)
			.IsUnique();
	}
}
