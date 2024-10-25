using MediatR;

namespace AuthExample.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryRequest : IRequest<GetAllOrderQueryResponse>
    {
    }
}