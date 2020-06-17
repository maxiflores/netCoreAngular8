using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Entities;
using Wheelzy.Repository.Contract;

namespace Wheelzy.Repository.Generals
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly EntityDbContext _dbContext;

        public OrderDetailRepository(EntityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderHistory>> GetDetailExpresion(Expression<Func<OrderDetail, bool>> expr)
        {
            //return _dbContext.Set<OrderDetail>()
            //    .Include(x=>x.Order)
            //    .Include(x=>x.Product)
            //    .Where(expr)
            //    .ToListAsync();

            _dbContext.Database.SetCommandTimeout(TimeSpan.FromMinutes(2));
            StringBuilder sb = new StringBuilder();
            var sql = "";
            sb.Append("SELECT od.IdOrder, od.ProductId, od.Price,od.Quantity,o.DateOrder,p.Code,p.Description,p.Id, c.CategoryName,sc.SubCategoryName,'' as OrderId " +
                    "FROM OrderDetails AS od LEFT JOIN Orders AS o ON od.IdOrder = o.Id " +
                    "INNER JOIN Products AS p ON od.ProductId = p.Id LEFT JOIN Categories as c ON p.CategoryId = c.Id " +
                    "LEFT JOIN SubCategories as sc ON p.SubCategoryId = sc.Id ");


            sql = sb.ToString();
            var det = await _dbContext.OrderHistories.FromSqlRaw(sql).ToListAsync();
            return det;
        }

        public async Task Insert(List<OrderDetail> order)
        {
            foreach (var det in order)
            {
                _dbContext.Entry(det).State = EntityState.Added;               
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
