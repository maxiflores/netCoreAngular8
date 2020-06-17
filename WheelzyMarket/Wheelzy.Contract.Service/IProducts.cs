using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wheelzy.Models.Dto;

namespace Wheelzy.Contract.Service
{
    public interface IProducts
    {
        Task<List<ProductDto>> GetProduct(int category, int subcategory, string description);
    }
}
