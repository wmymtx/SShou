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
    public class SS_User : Entity<int>
    {
        [Column(TypeName = "varchar"), MaxLength(20)]
        public virtual string LoginName { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(20)]
        public virtual string UserName { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public virtual string PassWord { get; set; }

        [Column(TypeName = "varchar"), MaxLength(11)]
        public virtual string PhoneNo { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public virtual string Weixin { get; set; }

        [Column(TypeName = "varchar"), MaxLength(50)]
        public virtual string OpenId { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(10)]
        public virtual string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(10)]
        public virtual string City { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(10)]
        public virtual string County { get; set; }


        /// <summary>
        /// 选择地址
        /// </summary>
        public virtual string FirstAddress { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Column(TypeName = "nvarchar"), MaxLength(200)]
        public virtual string Address { get; set; }

        /// <summary>
        /// 从业时间
        /// </summary>
        /// 
        [Column(TypeName = "varchar"), MaxLength(20)]
        public virtual string WorkingTime { get; set; }

        [Column(TypeName = "varchar"), MaxLength(200)]
        public virtual string RecyclingCategoryId { get; set; }

        [Column(TypeName = "varchar"), MaxLength(200)]
        public virtual string RecyclingCategoryName { get; set; }

        public virtual int Status { get; set; }

        public virtual DateTime JoinTime { get; set; }

        [Column(TypeName = "varchar"), MaxLength(20)]
        public virtual string ID_Card { get; set; }

    }
}
