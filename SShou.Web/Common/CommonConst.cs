using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Web.Common
{
   public class CommonConst
    {
        /// <summary>
        /// /认证地址
        /// </summary>
        public static readonly string AuthUrl = System.Configuration.ConfigurationManager.AppSettings["AuthUrl"];

        /// <summary>
        /// 保存键名
        /// </summary>
        public static readonly string AuthSaveKey = System.Configuration.ConfigurationManager.AppSettings["AuthSaveKey"];

        /// <summary>
        /// 保存类型
        /// </summary>
        public static readonly string AuthSaveType = System.Configuration.ConfigurationManager.AppSettings["AuthSaveType"];

        public static readonly string PointsScore = System.Configuration.ConfigurationManager.AppSettings["PointsScore"];

        public static readonly string AppID = System.Configuration.ConfigurationManager.AppSettings["AppID"] ?? "wx457188085d48d1ca";

        public static readonly string AppSecret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"] ?? "29cad2671f79f1899517569acce74210";

        public static readonly string RedirectUrl = System.Configuration.ConfigurationManager.AppSettings["RedirectUrl"] ?? "http://wmymtx.eicp.net/WeLogin/Index";

        public static readonly string TemplateId = "waueKR4lYpI1lZqDhQCH4cnnure8Qv2pE9FT3tl2nTg";
    }
}
