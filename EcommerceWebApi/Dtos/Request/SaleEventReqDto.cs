using EcommerceWebApi.Models;

namespace EcommerceWebApi.Dtos.Request
{
    public class SaleEventReqDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<CustomerType> CustomerTypes { get; set; } = [];
        public List<Product> Products { get; set; } = [];
    }
}
