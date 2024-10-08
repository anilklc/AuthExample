using AuthExample.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace AuthExample.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }

}
