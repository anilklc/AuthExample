using AuthExample.Application.Interfaces.Repositories;
using AuthExample.Domain.Entities;
using AuthExample.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Persistence.Repositories
{
    public class EndpointReadRepository : ReadRepository<Endpoint>, IEndpointReadRepository
    {
        public EndpointReadRepository(AuthExampleDbContext context) : base(context)
        {
        }
    }
}
