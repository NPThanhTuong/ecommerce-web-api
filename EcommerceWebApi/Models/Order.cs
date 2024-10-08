﻿
using EcommerceWebApi.Utils.EnumTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(9, 1)")]
        public decimal Total { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Processing;
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        public int AddressId { get; set; }
        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; } = null!;

        public List<DetailOrder> DetailOrders { get; set; } = [];

        public List<Rating> Ratings { get; set; } = [];
    }
}
