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
    public class GenreRepositry : IGenreRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GenreRepositry(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task IGenreRepository.AddAsync(Genre genre)
        {
            await _dbContext.Genres.AddAsync(genre);
            _dbContext.SaveChanges();
        }

        async Task<bool> IGenreRepository.DeleteAsync(int id)
        {
            Genre genre = await _dbContext.Genres.FindAsync(id);

            if (genre == null)
            {
                return  false;
            }
             _dbContext.Genres.Remove(genre);
            await  _dbContext.SaveChangesAsync();

            return true;
        }

        Task<bool> IGenreRepository.ExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<Genre>> IGenreRepository.GetAllAsync()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        async Task<Genre> IGenreRepository.GetByIdAsync(int id)
        {
            return await _dbContext.Genres.FirstAsync(g => g.Id == id);
        }

        Task IGenreRepository.UpdateAsync(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
