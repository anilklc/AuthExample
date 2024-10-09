using AuthExample.Domain.Common;
using AuthExample.Domain.Entities;
using AuthExample.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Persistence.Context
{
    public class AuthExampleDbContext : IdentityDbContext<AppUser,AppRole,Guid>
    {
        public AuthExampleDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Menu>  Menus { get; set; }
        public DbSet<Endpoint> Endpoint { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                var _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    _ => DateTime.Now,
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
