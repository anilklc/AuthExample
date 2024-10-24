﻿using MediatR;

namespace AuthExample.Application.Features.Queries.Order.GetByIdOrder
{
    public class GetByIdOrderQueryRequest : IRequest<GetByIdOrderQueryResponse>
    {
        public string Id { get; set; }
    }
}