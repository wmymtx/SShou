using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Orders.Dto
{
    [AutoMap(typeof(Entitys.Orders))]
    public class OrderInputDto
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public DateTime? OrderTime { get; set; }

        public string Address { get; set; }

        public string RecTime { get; set; }

        public virtual int Status { get; set; }

        //[Column(TypeName = "varchar"), MaxLength(20)]
        //public virtual string ProsonId { get; set; }

        //[Column(TypeName = "varchar"), MaxLength(20)]
        //public virtual string PersonName { get; set; }

        //[Column(TypeName = "varchar"), MaxLength(20)]
        //public virtual string PhoneNo { get; set; }

        //public List<OrderItemsInputDto> OrderItems { get; set; }
    }
}
