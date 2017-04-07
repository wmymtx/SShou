using SShou.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.Entitys;
using Abp.EntityFramework;
using Abp.Domain.Entities;

namespace SShou.EntityFramework.Repositories
{
    public class OrderRepository : SShouRepositoryBase<Entitys.Orders, string>, IOrderRepository
    {
        public OrderRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }
        public void CreateOrder(Orders order)
        {
            Insert(order);
        }

        public List<Entitys.Orders> QueryOrder(string uid, int pageIndex, int pageSize)
        {
            var query = GetAll();
            int userId = int.Parse(uid);
            var orderLst = query.Where(o => o.UserId == userId).OrderByDescending(o => o.OrderTime).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
            return orderLst;
        }

        public List<Entitys.Orders> QueryOrderByStatus(int status, int pageIndex, int pageSize,string orderDate,int OrderType, string endTime)
        {
            var query = GetAll();
            DateTime start = DateTime.Parse(orderDate + " 00:00:00");
            DateTime end = DateTime.Parse(endTime + " 23:59:59");
            var orderLst = query.Where(o => o.Status == status&&o.OrderType==OrderType&&o.OrderTime>= start&&o.OrderTime<=end).OrderBy(o => o.OrderTime).Skip(pageSize * pageIndex).Take(pageSize).ToList();
            return orderLst;
        }

        public int QueryOrderCoutByStatus(int status,string orderDate,int OrderType, string endTime)
        {
            DateTime start = DateTime.Parse(orderDate + " 00:00:00");
            DateTime end = DateTime.Parse(endTime + " 23:59:59");
            return Count(o => o.Status == status&&o.OrderType==OrderType && o.OrderTime >= start && o.OrderTime <= end);
        }

        public Entitys.Orders QueryByOrderId(string orderId)
        {
            var query = GetAll();
            var order = query.Where(o => o.Id == orderId).FirstOrDefault();
            return order;
        }

        public List<Entitys.Orders> QueryOrders(int status)
        {
            var query = GetAll();
            var lst = query.Where(o => o.Status == status).OrderByDescending(o=>o.OrderTime).ToList();
            return lst;
        }

        public Entitys.Orders CancelOrder(string id)
        {
            var order = Get(id);
            if (order != null)
            {
                order.Status = -1;
                return Update(order);
            }
            return null;
        }

        public Entitys.Orders OrderAssign(Entitys.Orders order)
        {
            return Update(order);
        }
    }
}
