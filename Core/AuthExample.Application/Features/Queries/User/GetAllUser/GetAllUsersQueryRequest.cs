using MediatR;

namespace AuthExample.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUsersQueryRequest : IRequest<GetAllUsersQueryResponse>
    {
    }
}