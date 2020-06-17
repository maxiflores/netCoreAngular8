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
    public class SubCategoriesService : ISubCategoriesService
    {
        private readonly IMapper _mapper;
        private readonly ISubCategoriesRepository _subCategoriesRepository;

        public SubCategoriesService(IMapper mapper,
            ISubCategoriesRepository subCategoriesRepository)
        {
            _mapper = mapper;
            _subCategoriesRepository = subCategoriesRepository;
        }

        public async Task<List<SubCategoryDto>> GetSubCategories()
        {
            try
            {
                var data = await _subCategoriesRepository.GetAll();

                return _mapper.Map<List<SubCategoryDto>>(data);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
