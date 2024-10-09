using AuthExample.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Persistence.Services
{
    public class AuthorizationEndpointService : IAuthorizationEndpointService
    {
        public Task AssignRoleEndpointAsync(string[] roles, string menu, string code, Type type)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetRolesToEndpointAsync(string code, string menu)
        {
            throw new NotImplementedException();
        }
    }
}
