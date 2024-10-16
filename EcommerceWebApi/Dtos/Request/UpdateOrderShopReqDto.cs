using EcommerceWebApi.Utils.EnumTypes;

namespace EcommerceWebApi.Dtos.Request
{
    public class UpdateOrderShopReqDto
    {
        public OrderStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
