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
        }
    }
}
