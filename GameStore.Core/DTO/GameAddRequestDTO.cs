using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Game_Store.CustomAttributes;

namespace GameStore.Core.DTO
{
    public class GameAddRequestDTO
    {
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

        [Required(ErrorMessage = "Please upload an image")]
        [AllowedExtensionAttributes(".jpg,.jpeg,.png")]
        public IFormFile ImageFile { get; set; } = default!;
    }
}