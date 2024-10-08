using AuthExample.Application.Interfaces.Repositories;
using AuthExample.Domain.Entities;
using AuthExample.Persistence.Context;

namespace AuthExample.Persistence.Repositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(AuthExampleDbContext context) : base(context)
        {
        }
    }
}
