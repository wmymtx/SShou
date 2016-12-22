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
    public class OrderItems : Entity
    {
        public string F_OrderId { get; set; }

        [ForeignKey("F_OrderId")]
        public virtual Orders Orders { get; set; }

        [Column(TypeName = "varchar"), MaxLength(30)]
        public virtual string ProductName { get; set; }

        [Column(TypeName = "int")]
        public virtual int ProductNum { get; set; }

        [Column(TypeName = "varchar"), MaxLength(3)]
        public virtual string ProductId { get; set; }
    }
}
