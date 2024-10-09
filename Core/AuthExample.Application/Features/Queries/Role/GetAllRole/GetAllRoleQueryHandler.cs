using AuthExample.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Application.Features.Queries.Role.GetAllRole
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQueryRequest, GetAllRoleQueryResponse>
    {
        private readonly IRoleService _roleService;

        public GetAllRoleQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<GetAllRoleQueryResponse> Handle(GetAllRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = _roleService.GetAllRole();
            return new()
            {
                Roles = roles,
            };
        }
    }
}
