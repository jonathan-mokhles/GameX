using GameStore.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.Core.DTO
{
    public class GameResponseDTO
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
        public decimal? OldPrice { get; set; }

        [Required]
        public Genre? Genre { get; set; }

        [Required]
        public Platform? Platform { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [StringLength(500)]
        public string? ImageUrl { get; set; }
    }
}