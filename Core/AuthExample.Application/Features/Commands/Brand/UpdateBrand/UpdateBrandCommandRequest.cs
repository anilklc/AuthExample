﻿using MediatR;

namespace AuthExample.Application.Features.Commands.Brand.UpdateBrand
{
    public class UpdateBrandCommandRequest : IRequest<UpdateBrandCommandResponse>
    {
        public string Id { get; set; }
        public string BrandName { get; set; }
    }
}