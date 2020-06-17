using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Entities;

namespace Wheelzy.Repository.Contract
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersExpresion(Expression<Func<Order, bool>> expr);
        Task Insert(Order order);
    }
}
