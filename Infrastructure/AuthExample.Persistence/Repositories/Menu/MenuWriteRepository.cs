using AuthExample.Application.Interfaces.Repositories;
using AuthExample.Domain.Entities;
using AuthExample.Persistence.Context;

namespace AuthExample.Persistence.Repositories
{
    public class MenuWriteRepository : WriteRepository<Menu>, IMenuWriteRepository
    {
        public MenuWriteRepository(AuthExampleDbContext context) : base(context)
        {
        }
    }
}
