using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wheelzy.Models.Dto;
using Wheelzy.Models.Entities;

namespace Wheelzy.Repository.Mapper
{
    public class CategoriesProfile: Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category, CategoryDto>();

            CreateMap<CategoryDto, Category>()
            .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
