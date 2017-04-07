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
    public class OrderComment : Entity<int>
    {
        public string F_OrderId { get; set; }

        [ForeignKey("F_OrderId")]
        public virtual Orders Orders { get; set; }

        [Column(TypeName = "varchar"), MaxLength(100)]
        public virtual string Comment { get; set; }

        public virtual decimal Score { get; set; }

        [Column(TypeName = "varchar"), MaxLength(100)]
        public virtual string ReMark { get; set; }
    }
}
