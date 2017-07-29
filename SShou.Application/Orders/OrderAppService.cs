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
        private readonly IRepository.IMapRangeRepository _mapRangeRspository;

        public OrderAppService(IRepository.IOrderRepository iOrderRepository, IRepository.IOrderItemsRepository iOrderItemRepository,
            IRepository.IMapRangeRepository mapRangeRepository)
        {
            this._orderItemsRepository = iOrderItemRepository;
            this._orderRepository = iOrderRepository;
            this._mapRangeRspository = mapRangeRepository;
        }

        [UnitOfWork]
        public bool CreateOrder(OrderInputDto order, IList<Dto.OrderItemsInputDto> orderItems)
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

        public List<Dto.OrderOuputDto> QueryOrders(string uid, int pageIndex, int pageSize)
        {
            return _orderRepository.QueryOrder(uid, pageIndex, pageSize).MapTo<List<Dto.OrderOuputDto>>();
        }

        public List<Dto.OrderOuputDto> QueryOrderByStatus(int status, int pageIndex, int pageSize, string orderDate, int OrderType, string endTime)
        {
            return _orderRepository.QueryOrderByStatus(status, pageIndex, pageSize, orderDate, OrderType, endTime).MapTo<List<Dto.OrderOuputDto>>();
        }

        public List<Dto.OrderItemsOutputDto> QueryOrderItems(string orderId)
        {
            return _orderItemsRepository.QueryOrderItems(orderId).MapTo<List<Dto.OrderItemsOutputDto>>();
        }

        public int QueryOrderCoutByStatus(int status, string orderDate, int OrderType, string endTime)
        {
            return _orderRepository.QueryOrderCoutByStatus(status, orderDate, OrderType, endTime);
        }

        public Dto.OrderOuputDto QueryByOrderId(string orderId)
        {
            return _orderRepository.QueryByOrderId(orderId).MapTo<Dto.OrderOuputDto>();
        }

        public List<Dto.OrderOuputDto> QueryOrders(int status)
        {
            return _orderRepository.QueryOrders(status).MapTo<List<Dto.OrderOuputDto>>();
        }

        public Dto.OrderOuputDto CancelOrder(string id)
        {
            return _orderRepository.CancelOrder(id).MapTo<Dto.OrderOuputDto>();
        }

        public Dto.OrderOuputDto CanOrder(string id)
        {
            return _orderRepository.CanOrder(id).MapTo<Dto.OrderOuputDto>();
        }

        public Dto.OrderOuputDto OrderAssign(Dto.UserAssignInputDto input)
        {
            var orderInfo = _orderRepository.QueryByOrderId(input.Id);
            orderInfo.ProsonId = input.ProsonId;
            orderInfo.PersonName = input.PersonName;
            orderInfo.PhoneNo = input.PhoneNo;
            orderInfo.Status = 1;
            return _orderRepository.OrderAssign(orderInfo).MapTo<Dto.OrderOuputDto>();
        }

        public Dto.MapRangeOutput getMapRange()
        {
            var rst = _mapRangeRspository.getAllRange();
            MapRangeOutput output = new MapRangeOutput();
            if (rst != null)
            {
                
                List<double> lng = new List<double>();
                List<double> lat = new List<double>();
                foreach (var item in rst)
                {
                    var subRst = item.Lat_Lng.Split('|');
                    foreach (var subItem in subRst)
                    {
                        var lng_lat = subItem.Split(',');
                        lng.Add(double.Parse(lng_lat[0]));
                        lat.Add(double.Parse(lng_lat[1]));
                    }
                }

                output.Lat = lat;
                output.Lng = lng;
            }
            return output;
        }
    }
}
