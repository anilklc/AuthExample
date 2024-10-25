using AuthExample.Application.Interfaces.Repositories;
using AuthExample.Domain.Entities;
using AuthExample.Domain.Entities.Identity;
using EllipticCurve;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly UserManager<AppUser> _userManager;
        public CreateOrderCommandHandler(IOrderWriteRepository orderWriteRepository, UserManager<AppUser> userManager)
        {
            _orderWriteRepository = orderWriteRepository;
            _userManager = userManager;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var userId =  _userManager.FindByNameAsync(request.Username).Result.Id;
            await _orderWriteRepository.AddAsync(new()
            {
                ProductId = request.ProductId,
                AppUserId = userId,
                
                Status = "Placed",
            });
            await _orderWriteRepository.SaveAsync();
            return new();
        }
    }
}
