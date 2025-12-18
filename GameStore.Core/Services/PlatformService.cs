using GameStore.Core.Domain.RepositoryContracts;
using GameStore.Core.DTO;
using GameStore.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;

        public PlatformService(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }


        Task<PlatformDTO> IPlatformService.AddPlatformAsync(PlatformDTO platformDTO)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPlatformService.DeletePlatformAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<PlatformDTO>> IPlatformService.GetAllPlatformsAsync()
        {
            throw new NotImplementedException();
        }

        Task<PlatformDTO?> IPlatformService.GetPlatformByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<SelectListItem>> IPlatformService.GetPlatformSelectListItemsAsync()
        {
            var list = await _platformRepository.GetAllAsync();

            return list.Select(platform => new SelectListItem
                {
                    Text = platform.Name,
                    Value = platform.Id.ToString()
                });
            
        }

        Task<PlatformDTO> IPlatformService.UpdatePlatformAsync(PlatformDTO platformDTO)
        {
            throw new NotImplementedException();
        }
    }
}
