using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wheelzy.Models.Dto;
using Wheelzy.Models.Entities;
using Wheelzy.Repository;
using Wheelzy.Repository.Contract;
using Wheelzy.Repository.Helper;
using Wheelzy.Services.Contracts;

namespace Wheelzy.Services.Generals
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetProduct()
        {
            try
            {
                var filter = PredicateBuilder.True<Product>();

                //if (req.CategoryId != 0)
                //    filter = filter.And(x => x.CategoryId == req.CategoryId);

                //if (req.SubCategoryId != 0)
                //    filter = filter.And(x => x.SubCategoryId == req.SubCategoryId);

                //if (!string.IsNullOrEmpty(req.Description))
                //    filter = filter.And(x => x.Description == req.Description);

                var data = await _productRepository.GetProductsExpresion(filter);

                return _mapper.Map<List<ProductDto>>(data);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductDto>> GetProductAvailable()
        {
            try
            {
                var filter = PredicateBuilder.True<Product>();

                filter = filter.And(x => x.Status == true);

                var data = await _productRepository.GetProductsExpresion(filter);

                return _mapper.Map<List<ProductDto>>(data);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            try
            {
                var filter = PredicateBuilder.True<Product>();

                filter = filter.And(x => x.Id == id);

                var data = await _productRepository.GetProductsExpresion(filter);

                return _mapper.Map<ProductDto>(data.FirstOrDefault());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductDto> SaveProduct(ProductDto req)
        {
            try
            {
                var response = new ProductDto();
                var product = _mapper.Map<Product>(req);
                await _productRepository.Insert(product);

                response.Id = product.Id;

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductDto> UpdateProduct(ProductDto req)
        {
            try
            {
                var response = new ProductDto();
                var product = _mapper.Map<Product>(req);
                await _productRepository.Update(product);

                response.Id = product.Id;

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductDto> DeleteProduct(ProductDto req)
        {
            try
            {
                var response = new ProductDto();
                var filter = PredicateBuilder.True<Product>();

                filter = filter.And(x => x.Id == req.Id);

                var data = await _productRepository.GetProductsExpresion(filter);

                var product = _mapper.Map<Product>(data.FirstOrDefault());
                if (product.Status)
                    product.Status = false;
                else
                    product.Status = true;

                await _productRepository.Update(product);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
