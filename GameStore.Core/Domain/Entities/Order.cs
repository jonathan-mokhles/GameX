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
    public  class Order
    {
            [Key]
            public int Id { get; set; }

            [Required]
            public string UserId { get; set; } = string.Empty;

            [Required]
            public DateTime OrderDate { get; set; } = DateTime.Now;

            [Required]
            [Column(TypeName = "decimal(18,2)")]
            public decimal TotalAmount { get; set; }

            [Required]
            [StringLength(50)]
            public string Status { get; set; } = "Pending"; // Pending, Completed, Cancelled

            [Required]
            [StringLength(500)]
            public string ShippingAddress { get; set; } = string.Empty;

            [Required]
            [StringLength(50)]
            public string PaymentMethod { get; set; } = string.Empty;

            [ForeignKey("UserId")]
            public virtual ApplicationUser User { get; set; } = null!;

            public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        }
    }
