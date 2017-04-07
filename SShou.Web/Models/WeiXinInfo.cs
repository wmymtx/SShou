using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Web.Models
{
    public class WeiXinInfo
    {
        public string AccessToken { get; set; }

        public string OpenId { get; set; }

        public string HeadImgUrl { get; set; }

        public string NickName { get; set; }

        public string RetUrl { get; set; }
    }
}
