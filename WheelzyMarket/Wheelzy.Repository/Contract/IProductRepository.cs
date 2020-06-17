using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Entities;

namespace Wheelzy.Repository.Contract
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductsExpresion(Expression<Func<Product, bool>> expr);
        Task Insert(Product prod);
        Task Update(Product prod);
        Task Delete(Product prod);
    }
}
