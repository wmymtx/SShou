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
    public class Orders : Entity<string>
    {

       
        public virtual int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual WeUser WeUser { get; set; }

        [Column(TypeName = "DateTime")]
        public virtual DateTime? OrderTime { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(80)]
        public virtual string RecUserName { get; set; }

        [Column(TypeName = "varchar"), MaxLength(11)]
        public virtual string RecPhone { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(80)]
        public virtual string Address { get; set; }

        [Column(TypeName = "varchar"), MaxLength(30)]
        public virtual string RecTime { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(200)]
        public virtual string Remark { get; set; }

        public virtual int Status { get; set; }

        [Column(TypeName = "varchar"), MaxLength(20)]
        public virtual string ProsonId { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(20)]
        public virtual string PersonName { get; set; }

        [Column(TypeName = "varchar"), MaxLength(20)]
        public virtual string PhoneNo { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public virtual int OrderType{get;set;}
    }
}
