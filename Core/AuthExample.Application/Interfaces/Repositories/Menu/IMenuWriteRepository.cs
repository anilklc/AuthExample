﻿using AuthExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Application.Interfaces.Repositories
{
    public interface IMenuWriteRepository : IWriteRepository<Domain.Entities.Menu>
    {
    }
}