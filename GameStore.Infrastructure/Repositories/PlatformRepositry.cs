using GameStore.Core.Domain.Entities;
using GameStore.Core.Domain.RepositoryContracts;
using GameStore.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Infrastructure.Repositories
{
    public class PlatformRepositry : IPlatformRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public PlatformRepositry(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        Task<Platform> IPlatformRepository.AddAsync(Platform platform)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPlatformRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPlatformRepository.ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Platform>> IPlatformRepository.GetAllAsync()
        {
            return await _dbContext.Platforms.ToListAsync();
        }

        async Task<Platform> IPlatformRepository.GetByIdAsync(int id)
        {
            return await _dbContext.Platforms.FirstAsync(p => p.Id == id);
        }

        Task<Platform> IPlatformRepository.UpdateAsync(Platform platform)
        {
            throw new NotImplementedException();
        }
    }
}
