using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Dto;
using Wheelzy.Repository.Contract;
using Wheelzy.Services.Contracts;

namespace Wheelzy.Services.Generals
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(IMapper mapper,
            ICategoriesRepository  categoriesRepository)
        {
            _mapper = mapper;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            try
            {
                var data = await _categoriesRepository.GetAll();

                return _mapper.Map<List<CategoryDto>>(data);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
