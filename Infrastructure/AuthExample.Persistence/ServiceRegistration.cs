using AuthExample.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthExample.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using AuthExample.Application.Interfaces.Repositories;
using AuthExample.Persistence.Repositories;
using AuthExample.Application.Interfaces.Services;
using AuthExample.Persistence.Services;

namespace AuthExample.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AuthExampleDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 3;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
            }).AddRoles<AppRole>().AddEntityFrameworkStores<AuthExampleDbContext>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthorizationEndpointService, AuthorizationEndpointService>();
            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository,ProductWriteRepository>();
            services.AddScoped<IBrandReadRepository,BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository,BrandWriteRepository>();
            services.AddScoped<IMenuReadRepository,MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository,MenuWriteRepository>();
            services.AddScoped<IEndpointReadRepository,EndpointReadRepository>();
            services.AddScoped<IEndpointWriteRepository,EndpointWriteRepository>();
            services.AddScoped<IAuthorizationEndpointService,AuthorizationEndpointService>();
        }
    }
}
