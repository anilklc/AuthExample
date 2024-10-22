using AuthExample.Application.Interfaces.Repositories;
using AuthExample.Domain.Entities;
using AuthExample.Persistence.Context;

namespace AuthExample.Persistence.Repositories
{
    public class EndpointWriteRepository : WriteRepository<Endpoint>, IEndpointWriteRepository
    {
        public EndpointWriteRepository(AuthExampleDbContext context) : base(context)
        {
        }
    }
}
