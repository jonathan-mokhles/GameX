using GameStore.Core.Domain.Entities;
using GameStore.Core.Domain.RepositoryContracts;
using GameStore.Core.DTO;
using GameStore.Core.ServiceContracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            string imageName = await AddCoverImage(gameAddRequest.Title + gameAddRequest.ReleaseDate.ToString("MMM yyyy"), gameAddRequest.ImageFile);

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
                Genre = game.Genre,
                Platform = game.Platform,
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
                Genre = game.Genre,
                Platform = game.Platform,
                ReleaseDate = game.ReleaseDate,
                StockQuantity = game.StockQuantity,
                ImageUrl = game.ImageUrl
            };
        }
        async Task IGameService.UpdateGameAsync(GameUpdateRequestDTO gameUpdateRequest)
        {
            Game existingGame = await _gameRepository.GetByIdAsync(gameUpdateRequest.Id);
            if (existingGame == null)
            {
                throw new Exception($"Game with ID {gameUpdateRequest.Id} not found.");
            }
            existingGame.Title = gameUpdateRequest.Title;
            existingGame.Description = gameUpdateRequest.Description;
            existingGame.Price = gameUpdateRequest.Price;
            existingGame.OldPrice = gameUpdateRequest.DiscountPrice;
            existingGame.GenreId = gameUpdateRequest.GenreId;
            existingGame.PlatformId = gameUpdateRequest.PlatformId;
            existingGame.ReleaseDate = gameUpdateRequest.ReleaseDate;
            existingGame.StockQuantity = gameUpdateRequest.StockQuantity;
            if (gameUpdateRequest.ImageFile != null)
            {
                if(!string.IsNullOrEmpty(gameUpdateRequest.ExistingImageUrl))
                {
                    string imagePath = Path.Combine(_imageFolderPath, gameUpdateRequest.ExistingImageUrl);
                    File.Delete(imagePath);
                }

                existingGame.ImageUrl = await AddCoverImage(gameUpdateRequest.Title + gameUpdateRequest.ReleaseDate.ToString("MMM.yyyy"), gameUpdateRequest.ImageFile);
            }
            await _gameRepository.UpdateAsync(existingGame);

        }

        async Task IGameService.UpdateStockAsync(int id, int quantity)
        {
            throw new NotImplementedException();
        }

        async Task<string> AddCoverImage(string Name, IFormFile file)
        {
            string imageName = $"{SanitizeFileName(Name)}{Path.GetExtension(file.FileName)?.ToLowerInvariant()}";
            var imagePath = Path.Combine(_imageFolderPath, imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                 await file.CopyToAsync(fileStream);
            }
           return imageName;
        }
        private string SanitizeFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            // Remove invalid characters
            var invalidChars = Path.GetInvalidFileNameChars();
            var sanitized = new string(fileName
                .Where(ch => !invalidChars.Contains(ch))
                .ToArray());

            return sanitized.Trim();
        }

    }
}
