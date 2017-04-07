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
    public class SsCategory : Entity<int>
    {
        [Column(TypeName = "varchar"), MaxLength(50)]
        public virtual string CategoryName { get; set; }
    }
}
