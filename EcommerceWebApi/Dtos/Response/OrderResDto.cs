﻿using EcommerceWebApi.Utils.EnumTypes;

namespace EcommerceWebApi.Dtos.Response
{
    public class OrderResDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public AddressResDto Address { get; set; } = null!;
        public List<DetailOrderResDto> DetailOrders { get; set; } = [];
    }
}
