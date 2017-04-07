using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace SShou.Web.Common
{
    public class UserHelper
    {
        public static ILogger Logger { get; set; }

        private static readonly UserHelper _userHelper = new UserHelper();

        public static UserHelper Instance
        {
            get { return _userHelper; }
        }

        public UserHelper()
        {
            Logger = NullLogger.Instance;
        }

        public string getCookie()
        {
            var cookie = HttpContext.Current.Request.Cookies[Common.CommonConst.AuthSaveKey];
            string token = cookie.Value;
            var strTicket = Common.DESEncryptEx.Decrypt(token);
            return strTicket;
        }

        public int getUserId()
        {
            Logger.Debug("当前token" + Common.CommonConst.AuthSaveKey);
            var cookie = HttpContext.Current.Request.Cookies[Common.CommonConst.AuthSaveKey];
            //解密Ticket
            if (cookie != null)
            {
                string token = cookie.Value;
                Logger.Debug("当前token" + token);
                //var strTicket = FormsAuthentication.Decrypt(token).UserData;
                //Logger.Debug("当前strTicket" + strTicket);
                //if (!string.IsNullOrEmpty(strTicket))
                //{
                //    int userId = int.Parse(strTicket.Split('|')[0]);
                //    return userId;
                //}
                var strTicket = Common.DESEncryptEx.Decrypt(token);
                if (!string.IsNullOrEmpty(strTicket))
                {
                    int userId = int.Parse(strTicket.Split('|')[0]);
                    return userId;
                }
            }
            else
            {
                Logger.Debug("未获取到cookie" + Common.CommonConst.AuthSaveKey);
            }
            return 5;
        }

        public string[] getAccessToken()
        {
            var cookie = HttpContext.Current.Request.Cookies[Common.CommonConst.AuthSaveKey];
            //解密Ticket
            string token = cookie.Value;
            //var strTicket = FormsAuthentication.Decrypt(token).UserData;
            //if (!string.IsNullOrEmpty(strTicket))
            //{
            //    return strTicket.Split('|');

            //}
            var strTicket = Common.DESEncryptEx.Decrypt(token);
            if (!string.IsNullOrEmpty(strTicket))
            {
                return strTicket.Split('|');
            }
            return null;
        }
    }
}
