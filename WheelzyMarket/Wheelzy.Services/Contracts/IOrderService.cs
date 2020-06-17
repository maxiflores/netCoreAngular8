using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Dto;

namespace Wheelzy.Services.Contracts
{
    public interface IOrderService
    {
        Task<List<OrderHistoryDto>> GetOrdersHistory();
        Task<OrderDto> SaveOrders(List<OrderDto> req);
    }
}
