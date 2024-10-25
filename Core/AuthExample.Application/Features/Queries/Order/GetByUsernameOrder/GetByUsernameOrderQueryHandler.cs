using AuthExample.Application.DTOs.Order;
using AuthExample.Application.Interfaces.Repositories;
using AuthExample.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Application.Features.Queries.Order.GetByUsernameOrder
{
    public class GetByUsernameOrderQueryHandler : IRequestHandler<GetByUsernameOrderQueryRequest, GetByUsernameOrderQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly UserManager<AppUser> _userManager;

        public GetByUsernameOrderQueryHandler(IOrderReadRepository orderReadRepository, UserManager<AppUser> userManager)
        {
            _orderReadRepository = orderReadRepository;
            _userManager = userManager;
        }

        public async Task<GetByUsernameOrderQueryResponse> Handle(GetByUsernameOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var userId = _userManager.FindByNameAsync(request.Username).Result.Id;
            var orders = await _orderReadRepository.GetWhere(user=>user.AppUserId==userId).Include(p=>p.Product).ToListAsync();
            var ordersList = orders.Select(o => new OrderDto()
            {
                Id = o.Id.ToString(),
                ProductName = o.Product.ProductName,
                Status = o.Status,
                CreatedDate = o.CreatedDate,
            }).ToList();
            return new()
            {
                Orders = ordersList,
            };
        }
    }
}
