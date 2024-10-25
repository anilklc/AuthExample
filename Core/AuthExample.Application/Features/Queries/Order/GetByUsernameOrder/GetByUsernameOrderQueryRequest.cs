using MediatR;

namespace AuthExample.Application.Features.Queries.Order.GetByUsernameOrder
{
    public class GetByUsernameOrderQueryRequest : IRequest<GetByUsernameOrderQueryResponse>
    {
        public string Username { get; set; }
    }
}