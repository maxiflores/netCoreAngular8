using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Entities;
using Wheelzy.Repository.Contract;

namespace Wheelzy.Repository.Generals
{
    public class ProductRepository : IProductRepository
    {
        private readonly EntityDbContext _dbContext;

        public ProductRepository(EntityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Product>> GetAllProducts()
        {
            return _dbContext.Set<Product>()
                .Include(x=>x.Category)
                .Include(x=>x.SubCategory)
                .ToListAsync();
        }

        public Task<List<Product>> GetProductsExpresion(Expression<Func<Product, bool>> expr)
        {
            return _dbContext.Set<Product>()
                .Include(x => x.Category)
                .Include(x => x.SubCategory)
                .Where(expr)
                .ToListAsync();
        }

        public async Task Insert(Product prod)
        {
            _dbContext.Entry(prod).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Product prod)
        {
            _dbContext.Entry(prod).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Product prod)
        {
            _dbContext.Entry(prod).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
