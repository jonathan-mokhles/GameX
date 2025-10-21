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
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CartId { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; } = null!;

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; } = null!;
    }
}
