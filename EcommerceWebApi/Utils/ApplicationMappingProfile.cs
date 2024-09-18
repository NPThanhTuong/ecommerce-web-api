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
            CreateMap<ProductType, ProductTypeResDto>();
            CreateMap<ProductTypeReqDto, ProductType>();
            CreateMap<Shop, ShopResDto>();

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

            CreateMap<ProductImage, ProductImageResDto>();
            CreateMap<ProductImageReqDto, ProductImage>();

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


        }
    }
}
