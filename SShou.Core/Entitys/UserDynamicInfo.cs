using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Entitys
{
    public class UserDynamicInfo : Entity<int>
    {
        public virtual int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual WeUser WeUser { get; set; }

        public virtual decimal TotalScore { get; set; }
    }
}
