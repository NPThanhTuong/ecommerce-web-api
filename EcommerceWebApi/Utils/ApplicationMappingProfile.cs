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
            CreateMap<UpdateShopReqDto, Shop>()
                .ForAllMembers(opts => opts
                    .Condition((src, dest, srcMember) =>
                    {
                        // Ignore null value
                        if (srcMember is null) return false;

                        // Ignore empty string value
                        if (srcMember is string str) return !string.IsNullOrWhiteSpace(str);

                        return true;
                    }));

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
            CreateMap<UpdateProductReqDto, Product>()
                .ForAllMembers(opts => opts
                    .Condition((src, dest, srcMember) =>
                    {
                        // Ignore null value
                        if (srcMember is null) return false;

                        // Ignore default decimal value
                        if (srcMember is decimal d) return d != default;

                        // Ignore default int value
                        if (srcMember is int i) return i != default;

                        // Ignore empty string value
                        if (srcMember is string str) return !string.IsNullOrWhiteSpace(str);

                        return true;
                    }));

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
            CreateMap<CreateSaleEventReqDto, SaleEvent>();
            CreateMap<UpdateSaleEventReqDto, SaleEvent>()
                .ForAllMembers(opts => opts
                    .Condition((src, dest, srcMember) =>
                    {
                        // Ignore null value
                        if (srcMember is null) return false;

                        // Ignore min date time value
                        if (srcMember is DateTime date) return date != DateTime.MinValue;

                        // Ignore default float value
                        if (srcMember is float f) return f != default;

                        // Ignore empty string value
                        if (srcMember is string str) return !string.IsNullOrWhiteSpace(str);

                        return true;
                    }));


            // Customer Type
            CreateMap<CustomerType, CustomerTypeResDto>();

            // Customer
            CreateMap<Customer, CustomerResDto>();


            // Checkout
            CreateMap<HandleDetailOrderReqDto, DetailOrder>();
            CreateMap<Order, OrderResDto>();
            CreateMap<Address, AddressResDto>();
            CreateMap<Product, CompactProductResDto>()
                .ForMember(dest => dest.DiscountPercent,
                    opt => opt.MapFrom(src =>
                        src.SaleEvents
                            .Where(se => DateTime.Now >= se.StartDate && DateTime.Now <= se.EndDate)
                            .Select(se => se.Discount)
                            .FirstOrDefault()
                ))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ProductImages));
            CreateMap<DetailOrder, DetailOrderResDto>();

            // Account
            CreateMap<Account, AccountResDto>();

            CreateMap<UpdateAccountReqDto, Account>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForAllMembers(opts => opts
                    .Condition((src, dest, srcMember) =>
                    {
                        // Ignore null value
                        if (srcMember is null) return false;

                        // Ignore empty string value
                        if (srcMember is string str) return !string.IsNullOrWhiteSpace(str);

                        return true;
                    }));



        }
    }
}
