using MediatR;

namespace AuthExample.Application.Features.Commands.Brand.CreateBrand
{
    public class CreateBrandCommandRequest : IRequest<CreateBrandCommandResponse>
    {
        public string BrandName { get; set; }
    }
}