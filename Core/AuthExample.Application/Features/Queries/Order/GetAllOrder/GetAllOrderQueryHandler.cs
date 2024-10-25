using AuthExample.Application.DTOs.Order;
using AuthExample.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public GetAllOrderQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var orders = await _orderReadRepository.GetAll(false).Include(p=>p.Product).ToListAsync();
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
