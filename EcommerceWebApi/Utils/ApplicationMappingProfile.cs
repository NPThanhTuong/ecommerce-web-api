using AutoMapper;
using EcommerceWebApi.Dtos.Request;
using EcommerceWebApi.Dtos.Response;
using EcommerceWebApi.Models;

namespace EcommerceWebApi.Utils
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            // Product type
            CreateMap<ProductType, ProductTypeResDto>();
            CreateMap<ProductTypeReqDto, ProductType>();

            // Shop
            CreateMap<Shop, ShopResDto>();

            // Product
            CreateMap<Product, ProductResDto>()
                .ForMember(dest => dest.DiscountPercent,
                    opt => opt.MapFrom(src =>
                        src.SaleEvents
                            .Where(se => DateTime.Now >= se.StartDate && DateTime.Now <= se.EndDate)
                            .Select(se => se.Discount)
                            .FirstOrDefault()
                ))
                .ForMember(dest => dest.LikeQuantity, opt => opt.MapFrom(src => src.Likes.Count))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Ratings.Count > 0
                        ? Math.Round((decimal)src.Ratings.Sum(r => r.Score) / src.Ratings.Count, 1)
                        : 0m
                ))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ProductImages))
                .ForMember(dest => dest.SoldQuantity, opt => opt.MapFrom(src => src.DetailOrders.Sum(dt => dt.Quantity)));
            CreateMap<ProductReqDto, Product>();

            CreateMap<Product, DetailProductResDto>()
               .ForMember(dest => dest.DiscountPercent,
                   opt => opt.MapFrom(src =>
                       src.SaleEvents
                           .Where(se => DateTime.Now >= se.StartDate && DateTime.Now <= se.EndDate)
                           .Select(se => se.Discount)
                           .FirstOrDefault()
               ))
               .ForMember(dest => dest.LikeQuantity, opt => opt.MapFrom(src => src.Likes.Count))
               .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Ratings.Count > 0
                       ? Math.Round((decimal)src.Ratings.Sum(r => r.Score) / src.Ratings.Count, 1)
                       : 0m
               ))
               .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ProductImages))
               .ForMember(dest => dest.SoldQuantity, opt => opt.MapFrom(src => src.DetailOrders.Sum(dt => dt.Quantity)))
               .ForMember(dest => dest.Shop, opt => opt.MapFrom(src => src.Shop))
               .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType));

            // Product image
            CreateMap<ProductImage, ProductImageResDto>();
            CreateMap<ProductImageReqDto, ProductImage>();

            // Register user
            CreateMap<RegisterReqDto, Account>()
                .ForPath(dest => dest.Customer.Name, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.Customer.CustomerTypeId, opt => opt.MapFrom(src => ConstConfig.CommonCustomerCode))
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => ConstConfig.DefaultAvatar))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => ConstConfig.UserRoleCode))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));

            //Register shop
            CreateMap<RegisterShopReqDto, Account>()
                .ForPath(dest => dest.Shop.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => ConstConfig.DefaultAvatar))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => ConstConfig.ShopRoleCode))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));

            // Sale event
            CreateMap<SaleEvent, SaleEventResDto>();
            CreateMap<SaleEvent, SaleEventProductResDto>();


            // Customer Type
            CreateMap<CustomerType, CustomerTypeResDto>();

            // Checkout
            CreateMap<CreateDetailOrderReqDto, DetailOrder>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom((src, dest, _, context) => context.Items["OrderId"]));

            CreateMap<HandleDetailOrderReqDto, DetailOrder>();
        }
    }
}
