﻿using DevFreela.Core.Entities;
using DevFreela.Core.Respositories;

using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastruture.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
