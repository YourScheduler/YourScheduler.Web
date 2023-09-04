﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YourScheduler.Infrastructure.Repositories
{
    public class TeamRoleRepository
    {
        private readonly YourSchedulerDbContext _dbContext;
        private readonly ILogger _logger;

        public TeamRoleRepository(YourSchedulerDbContext dbContext, ILogger<TeamsRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}