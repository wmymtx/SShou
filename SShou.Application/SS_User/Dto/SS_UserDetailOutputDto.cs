using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.SS_User.Dto
{
    [AutoMap(typeof(Entitys.SS_User))]
   public class SS_UserDetailOutputDto
    {

        public int Id { get; set; }

        public  string UserName { get; set; }


        public  string PhoneNo { get; set; }

        public  string Weixin { get; set; }

        public  string OpenId { get; set; }

        /// <summary>
        /// 省
        /// </summary>

        /// <summary>
        /// 市
        /// </summary>

        /// <summary>
        /// 县
        /// </summary>


        /// <summary>
        /// 选择地址
        /// </summary>
        public  string FirstAddress { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public  string Address { get; set; }

        /// <summary>
        /// 从业时间
        /// </summary>
        /// 
        public  string WorkingTime { get; set; }


        public  string RecyclingCategoryName { get; set; }

        public  string ID_Card { get; set; }
    }
}
