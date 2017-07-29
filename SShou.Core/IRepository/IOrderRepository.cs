using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface IOrderRepository
    {
        void CreateOrder(Entitys.Orders order);

        List<Entitys.Orders> QueryOrder(string uid, int pageIndex, int pageSize);

        Entitys.Orders QueryByOrderId(string orderId);

        List<Entitys.Orders> QueryOrders(int status);

        int QueryOrderCoutByStatus(int status, string orderDate,int OrderType,string endTime);

        Entitys.Orders CancelOrder(string id);

        Entitys.Orders CanOrder(string id);

        Entitys.Orders OrderAssign(Entitys.Orders order);

        List<Entitys.Orders> QueryOrderByStatus(int status, int pageIndex, int pageSize, string orderDate,int OrderType, string endTime);

    }


}
