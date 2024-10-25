using AuthExample.Application.DTOs.Order;
using AuthExample.Domain.Entities.Identity;
using MediatR;

namespace AuthExample.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
       public Guid ProductId { get; set; }
       public string Username { get; set; }
    }
}