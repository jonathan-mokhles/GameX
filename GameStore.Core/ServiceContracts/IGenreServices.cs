using GameStore.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.ServiceContracts
{
    public interface IGenreService
    {
        Task<GenreDTO?> GetGenreByIdAsync(int id);
        Task<IEnumerable<GenreDTO>> GetAllGenresAsync();
        Task<GenreDTO> AddGenreAsync(GenreDTO genreDTO);
        Task<GenreDTO> UpdateGenreAsync(GenreDTO genreDTO);
        Task<bool> DeleteGenreAsync(int id);
    }
}
