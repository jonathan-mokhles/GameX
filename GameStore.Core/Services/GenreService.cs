using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Core.Domain.RepositoryContracts;
using GameStore.Core.DTO;
using GameStore.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _db;
        public GenreService(IGenreRepository genreRepository)
        {
            _db = genreRepository;
        }


        Task<GenreDTO> IGenreService.AddGenreAsync(GenreDTO genreDTO)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGenreService.DeleteGenreAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<GenreDTO>> IGenreService.GetAllGenresAsync()
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<SelectListItem>> IGenreService.GetAllSelectListItemAsync()
        {
            var list = await _db.GetAllAsync();
             
            return list.Select(genre => new SelectListItem
                      {
                          Text = genre.Name,
                          Value = genre.Id.ToString()
                      });
        }

        Task<GenreDTO?> IGenreService.GetGenreByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<GenreDTO> IGenreService.UpdateGenreAsync(GenreDTO genreDTO)
        {
            throw new NotImplementedException();
        }
    }
}
