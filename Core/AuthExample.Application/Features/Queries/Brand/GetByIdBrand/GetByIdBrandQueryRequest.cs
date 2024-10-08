﻿using MediatR;

namespace AuthExample.Application.Features.Queries.Brand.GetByIdBrand
{
    public class GetByIdBrandQueryRequest : IRequest<GetByIdBrandQueryResponse>
    {
        public string Id { get; set; }
    }
}