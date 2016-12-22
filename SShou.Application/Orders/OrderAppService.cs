using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.Orders.Dto;
using Abp.Domain.Uow;
using Abp.AutoMapper;

namespace SShou.Orders
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IRepository.IOrderRepository _orderRepository;
        private readonly IRepository.IOrderItemsRepository _orderItemsRepository;

        public OrderAppService(IRepository.IOrderRepository iOrderRepository, IRepository.IOrderItemsRepository iOrderItemRepository)
        {
            this._orderItemsRepository = iOrderItemRepository;
            this._orderRepository = iOrderRepository;
        }

        [UnitOfWork]
        public bool CreateOrder(OrderInputDto order,IList<Dto.OrderItemsInputDto> orderItems)
        {
            try
            {
                _orderRepository.CreateOrder(order.MapTo<Entitys.Orders>());
                _orderItemsRepository.CreateOrderItems(orderItems.MapTo<IList<Entitys.OrderItems>>());
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
