using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Domain.Entities
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

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

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        // Navigation Properties
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; } = null!;

        [ForeignKey("PlatformId")]
        public virtual Platform Platform { get; set; } = null!;

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
