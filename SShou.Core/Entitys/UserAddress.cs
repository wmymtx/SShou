using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Entitys
{
    public class UserAddress : Entity<int>
    {
        public virtual int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual WeUser WeUser { get; set; }

        [Column(TypeName = "varchar"), MaxLength(11)]
        public virtual string PhoneNo { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(200)]
        public virtual string Address { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(10)]
        public virtual string ContactName { get; set; }

        public virtual int IsDefault { get; set; }

        public virtual int Status { get; set; }

        public virtual DateTime? AddTime { get; set; }
    }
}
