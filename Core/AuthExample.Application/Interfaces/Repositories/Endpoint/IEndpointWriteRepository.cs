﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Application.Interfaces.Repositories
{
    public interface IEndpointWriteRepository : IWriteRepository<Domain.Entities.Endpoint>
    {
    }
}