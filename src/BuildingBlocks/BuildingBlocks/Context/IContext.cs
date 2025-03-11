namespace BuildingBlocks.Context;
public interface IContext
{
	Guid? UserId { get; }
	string? Role { get; }
	bool IsAuthenticated { get; }
}
