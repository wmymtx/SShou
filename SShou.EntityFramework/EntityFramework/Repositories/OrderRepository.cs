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
    }
}
