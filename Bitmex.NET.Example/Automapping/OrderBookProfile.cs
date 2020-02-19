using AutoMapper;
using Bitmex.NET.Dtos;
using Bitmex.NET.Example.Models;

namespace Bitmex.NET.Example.Automapping
{
    internal class OrderBookProfile : Profile
    {
        public OrderBookProfile()
        {
            CreateMap<OrderBookDto, OrderBookModel>()
                .ForMember(dest => dest.Price, a =>
                {
                    a.Condition(dto => dto.Price.HasValue);
                    a.MapFrom(b => b.Price);
                })
                .ForMember(a => a.Size, a => a.MapFrom(b => b.Size))
                .ForMember(a => a.Direction, a => a.MapFrom(b => b.Side))
                .ForMember(a => a.Id, a => a.MapFrom(b => b.Id));
        }
    }
}