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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IMapper _mapper;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IMapper mapper,
            IOrderDetailRepository orderDetailRepository)
        {
            _mapper = mapper;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrderDetailDto>> GetOrders()
        {
            try
            {
                var filter = PredicateBuilder.True<OrderDetail>();

                var data = await _orderDetailRepository.GetDetailExpresion(filter);

                return _mapper.Map<List<OrderDetailDto>>(data);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
