using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Entities;

namespace Wheelzy.Repository.Contract
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderHistory>> GetDetailExpresion(Expression<Func<OrderDetail, bool>> expr);
        Task Insert(List<OrderDetail> order);
    }
}
