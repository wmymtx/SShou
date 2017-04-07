using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.UserAddress.Dto
{
    [AutoMap(typeof(Entitys.UserAddress))]
    public class UserAddressOutputDto
    {
        public int Id { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public string ContactName { get; set; }

        public int IsDefault { get; set; }

        public int Status { get; set; }

        public virtual DateTime? AddTime { get; set; }
    }
}
