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
    public class AbpUser : Entity<int>
    {
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string UserName { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public string PassWord { get; set; }

        public int IsActive { get; set; }
    }
}
