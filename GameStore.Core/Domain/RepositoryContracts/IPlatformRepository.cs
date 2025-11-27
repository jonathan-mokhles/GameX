using GameStore.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Domain.RepositoryContracts
{
    public interface IPlatformRepository
    {
        Task<Platform?> GetByIdAsync(int id);
        Task<IEnumerable<Platform>> GetAllAsync();
        Task<Platform> AddAsync(Platform platform);
        Task<Platform> UpdateAsync(Platform platform);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
