using Game_Store.CustomAttributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Core.DTO
{
    public class GameUpdateRequestDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountPrice { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int PlatformId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        public string? ExistingImageUrl { get; set; }

        [AllowedExtensionAttributes(".jpg,.jpeg,.png")]
        public IFormFile? ImageFile { get; set; } = default!;
    }
}