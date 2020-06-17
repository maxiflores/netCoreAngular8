using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Wheelzy.Models.Dto;
using Wheelzy.Models.Entities;

namespace Wheelzy.Repository.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dto => dto.Category, e => e.MapFrom(d => d.Category.CategoryName))
                .ForMember(dto => dto.SubCategory, m => m.MapFrom(d => d.SubCategory.SubCategoryName));


            CreateMap<ProductDto, Product>()
            .ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
