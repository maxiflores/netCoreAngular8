using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wheelzy.Models.Dto;
using Wheelzy.Models.Entities;

namespace Wheelzy.Repository.Mapper
{
    public class SubCategoriesProfile : Profile
    {
        public SubCategoriesProfile()
        {
            CreateMap<SubCategory, SubCategoryDto>();

            CreateMap<SubCategoryDto, SubCategory>()
            .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
