using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface IOrderItemsRepository : IRepository<Entitys.OrderItems>
    {
        void CreateOrderItems(IList<Entitys.OrderItems> orderItems);
    }
}
