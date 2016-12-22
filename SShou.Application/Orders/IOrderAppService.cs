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
    }
}
