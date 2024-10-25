using MediatR;

namespace AuthExample.Application.Features.Queries.Product.GetProductCount
{
    public class GetProductCountQueryRequest : IRequest<GetProductCountQueryResponse>
    {
    }
}