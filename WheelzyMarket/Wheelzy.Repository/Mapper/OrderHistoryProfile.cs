using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wheelzy.Models.Dto;
using Wheelzy.Models.Entities;

namespace Wheelzy.Repository.Mapper
{
    public class OrderHistoryProfile : Profile
    {
        public OrderHistoryProfile()
        {
            CreateMap<OrderHistory, OrderHistoryDto>();

            CreateMap<OrderHistory, OrderHistoryDto>()
            .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
