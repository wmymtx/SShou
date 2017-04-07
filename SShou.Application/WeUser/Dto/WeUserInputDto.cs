using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.WeUser.Dto
{
    [AutoMap(typeof(Entitys.WeUser))]
    public class WeUserInputDto
    {
        public int Id { get; set; }

        /// <summary>
        /// 微信Id
        /// </summary>
        public  string WeChatId { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        public  string OpenId { get; set; }

        public  DateTime? RegDate { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public  string PhoneNo { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public  string HeadImgUrl { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public  string NickName { get; set; }

        public string Address { get; set; }

        public int UserType { get; set; }

        public int IsInit { get; set; }

        /// <summary>
        /// 邀请码
        /// </summary>
        public int Invit_Code { get; set; }

        /// <summary>
        /// 推荐码
        /// </summary>
        public int Recommend_Code { get; set; }
    }
}
