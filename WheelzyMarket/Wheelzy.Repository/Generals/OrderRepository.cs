using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Entities;
using Wheelzy.Repository.Contract;

namespace Wheelzy.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EntityDbContext _dbContext;

        public OrderRepository(EntityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Order>> GetOrdersExpresion(Expression<Func<Order, bool>> expr)
        {
            return _dbContext.Set<Order>()
                .Where(expr)
                .ToListAsync();
        }

        public async Task Insert(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
        }
    }
}
