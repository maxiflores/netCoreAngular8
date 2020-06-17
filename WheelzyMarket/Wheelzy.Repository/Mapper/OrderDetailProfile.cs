using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wheelzy.Models.Dto;
using Wheelzy.Models.Entities;

namespace Wheelzy.Repository.Mapper
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, OrderDetailDto>()
                .ForMember(dto => dto.ProductId, e => e.MapFrom(d => d.Product.Id))
                .ForMember(dto => dto.IdOrder, m => m.MapFrom(d => d.Order.Id));

            CreateMap<OrderDetailDto, OrderDetail>()
            .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
