using MediatR;

namespace AuthExample.Application.Features.Commands.Order.UpdateOrder
{
    public class UpdateOrderCommandRequest :IRequest<UpdateOrderCommandResponse>
    {
        public string Id { get; set; }
        public string Status { get; set; }
    }
}