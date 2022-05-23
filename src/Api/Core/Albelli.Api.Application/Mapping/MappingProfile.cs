using Albelli.Api.Domain.Models;
using Albelli.Common.Models.RequestModels;
using Albelli.Common.Models.ResponseModels;
using AutoMapper;

namespace Albelli.Api.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.CreatedDate.ToLongDateString()))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.OrderDetails.Sum(x => x.Quantity * x.Price)))
                .ReverseMap();


            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();

            CreateMap<OrderRequestDto, Order>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId)).ReverseMap();
            
            CreateMap<OrderDetailRequestDto, OrderDetail>().ReverseMap();
        }
    }
}
