using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebApi.Models
{
    [PrimaryKey(nameof(CustomerId), nameof(ProductId))]
    public class Like
    {
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
