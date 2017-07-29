using Abp.Domain.Entities;
using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Entitys
{
    public class PointsLog : Entity<int>
    {
        public virtual int UserId { get; set; }

        [Column(TypeName = "varchar"), MaxLength(10)]
        public virtual string AddTime { get; set; }

        /// <summary>
        /// 增加的积分
        /// </summary>
        public virtual int Score { get; set; }

        /// <summary>
        /// 积分来源类型
        /// </summary>
        public virtual int SourceType { get; set; }

        [Column(TypeName = "varchar"), MaxLength(30)]
        public virtual string FK_ID { get; set; }

    }
}
