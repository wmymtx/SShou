using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Orders
{
    public interface IOrderAppService : IApplicationService
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        bool CreateOrder(Dto.OrderInputDto order, IList<Dto.OrderItemsInputDto> orderItems);

        List<Dto.OrderOuputDto> QueryOrders(string uid, int pageIndex, int pageSize);

        List<Dto.OrderOuputDto> QueryOrderByStatus(int status, int pageIndex, int pageSize, string orderDate,int OrderType,string endTime);

        List<Dto.OrderItemsOutputDto> QueryOrderItems(string orderId);

        Dto.OrderOuputDto QueryByOrderId(string orderId);

        List<Dto.OrderOuputDto> QueryOrders(int status);

        int QueryOrderCoutByStatus(int status, string orderDate,int OrderType, string endTime);

        Dto.OrderOuputDto CancelOrder(string id);

        Dto.OrderOuputDto CanOrder(string id);

        Dto.OrderOuputDto OrderAssign(Dto.UserAssignInputDto input);

        Dto.MapRangeOutput getMapRange();
    }
}
