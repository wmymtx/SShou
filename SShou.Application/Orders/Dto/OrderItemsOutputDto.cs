using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Orders.Dto
{
    [AutoMap(typeof(Entitys.OrderItems))]
    public class OrderItemsOutputDto
    {
        public  string ProductName { get; set; }

        public  int ProductNum { get; set; }

        public string Unit { get; set; }
    }
}
