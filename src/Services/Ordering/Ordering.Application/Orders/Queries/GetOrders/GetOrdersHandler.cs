
using BuildingBlocks.Context;
using BuildingBlocks.Pagination;
using Microsoft.Extensions.Logging;

namespace Ordering.Application.Orders.Queries.GetOrders;
public class GetOrdersHandler(IApplicationDbContext dbContext, IContext context, ILogger<GetOrdersHandler> logger)
	: IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
	public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
	{
		var authenticatedUserId = context.UserId;
		logger.LogInformation("successfully authenticated user {authenticatedUserId}", authenticatedUserId);
		var userRole = context.Role;
		logger.LogInformation("user with role: {userRole}", userRole);

		var pageIndex = query.PaginationRequest.PageIndex;
		var pageSize = query.PaginationRequest.PageSize;

		var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);

		var orders = await dbContext.Orders
			.Include(o => o.OrderItems)
			.AsNoTracking()
			.OrderBy(o => o.OrderName.Value)
			.Skip(pageSize * pageIndex)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		return new GetOrdersResult(
			new PaginatedResult<OrderDto>(
				pageIndex,
				pageSize,
				totalCount,
				orders.ToOrderDtoList()));
	}
}
