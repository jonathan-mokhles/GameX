using GameStore.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Domain.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [StringLength(1000)]
        public string? Comment { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; } = DateTime.Now;

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; } = null!;

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; } = null!;

    }
}
