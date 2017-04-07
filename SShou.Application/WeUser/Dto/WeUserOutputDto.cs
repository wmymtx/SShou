using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.WeUser.Dto
{
    [AutoMapFrom(typeof(Entitys.WeUser))]
    public class WeUserOutputDto
    {
        public int Id { get; set; }

        public DateTime? RegDate { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string PhoneNo { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string HeadImgUrl { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        public int IsInit { get; set; }

        public string OpenId { get; set; }

        public string Address { get; set; }

        public int UserType { get; set; }

        /// <summary>
        /// 邀请码
        /// </summary>
        public  int Invit_Code { get; set; }

        /// <summary>
        /// 推荐码
        /// </summary>
        public  int Recommend_Code { get; set; }
    }
}
