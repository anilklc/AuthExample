using AuthExample.Application.DTOs.Product;
using AuthExample.Application.Interfaces.Repositories;
using AuthExample.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productReadRepository.GetAll(false).Include(b=>b.Brand).ToListAsync();
            var productList = products.Select(p => new ProductDto()
            { 
                Id = p.Id.ToString(),
                ProductName = p.ProductName,
                ProductDescription = p.ProductDescription,
                ProductPrice = p.ProductPrice,
                BrandId = p.BrandId,
                BrandName = p.Brand.BrandName,   
            }).ToList();
            return new()
            {
                Products = productList
            };
        }
    }
}
