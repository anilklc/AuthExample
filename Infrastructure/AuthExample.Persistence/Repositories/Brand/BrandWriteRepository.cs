using AuthExample.Application.Interfaces.Repositories;
using AuthExample.Domain.Entities;
using AuthExample.Persistence.Context;

namespace AuthExample.Persistence.Repositories
{
    public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
    {
        public BrandWriteRepository(AuthExampleDbContext context) : base(context)
        {
        }
    }
}
