using AuthExample.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Application.Features.Queries.Product.GetProductCount
{
    public class GetProductCountQueryHandler : IRequestHandler<GetProductCountQueryRequest, GetProductCountQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        public GetProductCountQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetProductCountQueryResponse> Handle(GetProductCountQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _productReadRepository.GetAll(false).Count();
            return new() 
            { 
                ProductCount = totalCount 
            };
        }
    }
}
