using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wheelzy.Models.Dto;
using Wheelzy.Models.Entities;
using Wheelzy.Repository.Contract;
using Wheelzy.Repository.Helper;
using Wheelzy.Services.Contracts;

namespace Wheelzy.Services.Generals
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService(IMapper mapper,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrderHistoryDto>> GetOrdersHistory()
        {
            try
            {
                var filter = PredicateBuilder.True<OrderDetail>();

                var data = await _orderDetailRepository.GetDetailExpresion(filter);

                return _mapper.Map<List<OrderHistoryDto>>(data);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderDto> SaveOrders(List<OrderDto> req)
        {
            try
            {
                var response = new OrderDto();

                var order = new Order
                {
                    DateOrder=DateTime.Now
                };

                await _orderRepository.Insert(order);

                response.Id = order.Id;

                List<OrderDetail> list = new List<OrderDetail>();

                foreach (var item in req)
                {
                    var detail = new OrderDetail
                    {
                        IdOrder = order.Id,
                        Price = item.Price,
                        ProductId =item.Id,
                        Quantity=item.Quantity
                    };
                    list.Add(detail);
                }
                await _orderDetailRepository.Insert(list);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
