using GameStore.Core.Domain.Entities;
using GameStore.Core.Domain.RepositoryContracts;
using GameStore.Core.DTO;
using GameStore.Core.ServiceContracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string _imageFolderPath ;

        public GameService(IGameRepository gameRepository, IHostingEnvironment hostingEnvironment)
        {
            _gameRepository = gameRepository;
            _hostingEnvironment = hostingEnvironment;
            _imageFolderPath = $"{_hostingEnvironment.WebRootPath}/images/games";
        }



        async Task IGameService.AddGameAsync(GameAddRequestDTO gameAddRequest)
        {
            string imageName = $"{gameAddRequest.Title}{gameAddRequest.ReleaseDate}{Path.GetExtension(gameAddRequest.ImageFile?.FileName)}";
            var imagePath= Path.Combine(_imageFolderPath,imageName);
            using(var fileStream=new FileStream(imagePath,FileMode.Create))
            {
                await gameAddRequest.ImageFile.CopyToAsync(fileStream);
            }

            Game game = new Game()
            {
                Title = gameAddRequest.Title,
                Description = gameAddRequest.Description,
                Price = gameAddRequest.Price,
                OldPrice = gameAddRequest.DiscountPrice,
                GenreId = gameAddRequest.GenreId,
                PlatformId = gameAddRequest.PlatformId,
                ReleaseDate = gameAddRequest.ReleaseDate,
                StockQuantity = gameAddRequest.StockQuantity,
                ImageUrl= imageName
            };
            await _gameRepository.AddAsync(game);

        }

        async Task IGameService.DeleteGameAsync(int id)
        {
             await _gameRepository.DeleteAsync(id);
        }

        async Task<IEnumerable<GameResponseDTO>> IGameService.GetAllGamesAsync()
        {
            var games =  await _gameRepository.GetAllGamesAsync();
            var gameResponseDTOs = games.Select(game => new GameResponseDTO
            {
                Id = game.GameId,
                Title = game.Title,
                Description = game.Description,
                Price = game.Price,
                OldPrice = game.OldPrice,
                Genre = game.Genre.Name,
                Platform = game.Platform.Name,
                ReleaseDate = game.ReleaseDate,
                StockQuantity = game.StockQuantity,
                ImageUrl = game.ImageUrl
            });
            return gameResponseDTOs;
        }

        async Task<IEnumerable<GameResponseDTO>> IGameService.GetDiscountedGamesAsync()
        {
            throw new NotImplementedException();
        }

        async Task<GameResponseDTO?> IGameService.GetGameByIdAsync(int id)
        {
            Game game = await _gameRepository.GetByIdAsync(id);
            
            return new GameResponseDTO
            {
                Id = game.GameId,
                Title = game.Title,
                Description = game.Description,
                Price = game.Price,
                OldPrice = game.OldPrice,
                Genre = game.Genre.Name,
                Platform = game.Platform.Name,
                ReleaseDate = game.ReleaseDate,
                StockQuantity = game.StockQuantity,
                ImageUrl = game.ImageUrl
            };
        }

        async Task<IEnumerable<GameResponseDTO>> IGameService.GetGamesByGenreAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<GameResponseDTO>> IGameService.GetGamesByPlatformAsync(int platformId)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<GameResponseDTO>> IGameService.GetInStockGamesAsync()
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<GameResponseDTO>> IGameService.SearchGamesByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        async Task<GameResponseDTO> IGameService.UpdateGameAsync(GameUpdateRequestDTO gameUpdateRequest)
        {
            throw new NotImplementedException();
        }

        async Task IGameService.UpdateStockAsync(int id, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
