using SShou.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.Entitys;
using Abp.EntityFramework;

namespace SShou.EntityFramework.Repositories
{
    public class OrderItemsRepository : SShouRepositoryBase<Entitys.OrderItems>, IOrderItemsRepository
    {
        public OrderItemsRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }
        public void CreateOrderItems(IList<OrderItems> orderItems)
        {
            if (orderItems != null)
            {
                for (int index = 0; index <= orderItems.Count - 1; index++)
                {
                    Insert(orderItems[index]);
                }
            }
        }

        public List<Entitys.OrderItems> QueryOrderItems(string orderId)
        {
            var query = GetAll();
            return query.Where(d => d.F_OrderId == orderId).ToList();

            
        }
    }
}
