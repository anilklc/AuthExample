using MediatR;

namespace AuthExample.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoint
{
    public class GetRolesToEndpointQueryRequest : IRequest<GetRolesToEndpointQueryResponse>
    {
        public string Menu {  get; set; }
        public string Code { get; set; }
    }
}