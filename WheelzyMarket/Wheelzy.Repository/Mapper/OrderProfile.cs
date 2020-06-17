using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wheelzy.Models.Dto;
using Wheelzy.Models.Entities;

namespace Wheelzy.Repository.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>()
            .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
