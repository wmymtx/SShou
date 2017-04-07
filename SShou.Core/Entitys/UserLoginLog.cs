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
    public class UserLoginLog : Entity<int>
    {
        public virtual int UserId { get; set; }

        public virtual DateTime? LoginTime { get; set; }

        [Column(TypeName = "varchar"), MaxLength(20)]
        public virtual string LoginAddr { get; set; }
    }
}
