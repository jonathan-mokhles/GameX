using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Core.Domain.Entities
{
    public class OrderItem
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int GameId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceAtPurchase { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; } = null!;

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; } = null!;
    }
}
