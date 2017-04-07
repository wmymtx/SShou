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
    public class WeUser : Entity<int>
    {

        /// <summary>
        /// 微信OpenId
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(30)]
        public virtual string OpenId { get; set; }

        [Column(TypeName = "DateTime")]
        public virtual DateTime RegDate { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(11)]
        public virtual string PhoneNo { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(300)]
        public virtual string HeadImgUrl { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(20)]
        public virtual string NickName { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(200)]
        public virtual string Address { get; set; }

        public virtual int UserType { get; set; }

        /// <summary>
        /// 是否初始化
        /// </summary>
        public virtual int IsInit { get; set; }

        /// <summary>
        /// 邀请码
        /// </summary>
        public virtual int Invit_Code { get; set; }

        /// <summary>
        /// 推荐码
        /// </summary>
        public virtual int Recommend_Code { get; set; }
    }
}
