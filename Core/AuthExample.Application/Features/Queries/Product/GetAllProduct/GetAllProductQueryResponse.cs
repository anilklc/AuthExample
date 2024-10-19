using AuthExample.Application.DTOs.Product;

namespace AuthExample.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public List<ProductDto> Products { get; set; }
    }
}