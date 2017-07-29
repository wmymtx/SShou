using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using SShou.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Web.Common
{
    public class WeiXinHelper
    {
        public static void SendMsgToWeUser(string access_token, string openId, string orderId, OrderTemplateData templateData)
        {
            var linkUrl = string.Format("http://weixin.shoushouto.com/Order/Detail?orderId={0}", orderId);
            SendTemplateMessageResult sendResult = TemplateApi.SendTemplateMessage(access_token, openId, CommonConst.TemplateId, linkUrl, templateData);
        }

        public static void SendTemplateToWeUser(string access_token, string openId, string orderId, OrderTemplateData templateData)
        {
            var linkUrl = string.Format("http://weixin.shoushouto.com/Order/Detail?orderId={0}", orderId);
            SendTemplateMessageResult sendResult = TemplateApi.SendTemplateMessage(access_token, openId, "cogrr5tjx2GK_FGqFj1ty5A0Q1I80iIjyTOpkQlU-Qk", linkUrl, templateData);
        }

        public static void SendSimpleMsg(string access_token, string openId, string msg)
        {
            Senparc.Weixin.MP.AdvancedAPIs.CustomApi.SendText(access_token, openId, msg);
        }
    }
}
