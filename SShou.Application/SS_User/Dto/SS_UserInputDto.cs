using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.SS_User.Dto
{
    [AutoMap(typeof(Entitys.SS_User))]
    public class SS_UserInputDto
    {
        public virtual string LoginName { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Weixin { get; set; }

        public virtual string PassWord { get; set; }

        public virtual string PhoneNo { get; set; }


        public virtual string OpenId { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public virtual string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public virtual string City { get; set; }

        /// <summary>
        /// 县
        /// </summary>
        public virtual string County { get; set; }


        /// <summary>
        /// 选择地址
        /// </summary>
        public virtual string FirstAddress { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Address { get; set; }

        /// <summary>
        /// 从业时间
        /// </summary>
        /// 
        public virtual string WorkingTime { get; set; }

        public virtual string RecyclingCategoryId { get; set; }

        public virtual string RecyclingCategoryName { get; set; }

        public virtual string ID_Card { get; set; }
    }
}
