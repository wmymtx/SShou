using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Orders.Dto
{

    [AutoMap(typeof(Entitys.Orders))]
    public class OrderOuputDto
    {
        public  int UserId { get; set; }

        public  DateTime? OrderTime { get; set; }

        public  string Address { get; set; }

        public  string RecTime { get; set; }

        public  string Remark { get; set; }

        public  int Status { get; set; }

        public  string RecUserName { get; set; }

        public  string RecPhone { get; set; }

        public  string PersonName { get; set; }

        public  string PhoneNo { get; set; }

        public string Id { get; set; }

        public string ItemAll { get; set; }
    }
}
