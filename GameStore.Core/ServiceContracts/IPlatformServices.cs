using GameStore.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ServiceContracts
{
    public interface IPlatformService
    {
        Task<PlatformDTO?> GetPlatformByIdAsync(int id);
        Task<IEnumerable<PlatformDTO>> GetAllPlatformsAsync();
        Task<PlatformDTO> AddPlatformAsync(PlatformDTO platformDTO);
        Task<PlatformDTO> UpdatePlatformAsync(PlatformDTO platformDTO);
        Task<bool> DeletePlatformAsync(int id);
    }
}
