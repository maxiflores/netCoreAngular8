using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Dto;

namespace Wheelzy.Services.Contracts
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProduct();
        Task<ProductDto> SaveProduct(ProductDto req);
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> UpdateProduct(ProductDto req);
        Task<ProductDto> DeleteProduct(ProductDto req);
        Task<List<ProductDto>> GetProductAvailable();
    }
}
