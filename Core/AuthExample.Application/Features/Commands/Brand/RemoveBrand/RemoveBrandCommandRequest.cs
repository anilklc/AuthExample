﻿using MediatR;

namespace AuthExample.Application.Features.Commands.Brand.RemoveBrand
{
    public class RemoveBrandCommandRequest : IRequest<RemoveBrandCommandResponse>
    {
        public string Id { get; set; }
    }
}