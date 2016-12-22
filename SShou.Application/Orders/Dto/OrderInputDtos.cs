using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Orders.Dto
{
    public class OrderInputDtos
    {
        public string Address { get; set; }

        public string Remark { get; set; }

        public string Time { get; set; }

        public List<Items> Order { get; set; }
    }

    public class Items
    {
        public string Id { get; set; }

        public string Value { get; set; }

        public string Prod_Name { get; set; }
    }
}
