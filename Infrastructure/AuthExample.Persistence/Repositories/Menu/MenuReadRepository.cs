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
    public class MenuReadRepository : ReadRepository<Menu>, IMenuReadRepository
    {
        public MenuReadRepository(AuthExampleDbContext context) : base(context)
        {
        }
    }
}
