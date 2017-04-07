using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.SS_User.Dto
{
    [AutoMap(typeof(Entitys.SS_User))]
    public class SS_UserOutput
    {
        public int Id { get; set; }

        public string UserName { get; set; }


        public string PhoneNo { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        public string OpenId { get; set; }

        public int Status { get; set; }

        public string ID_Card { get; set; }

        public string WorkingTime { set; get; }


    }
}
