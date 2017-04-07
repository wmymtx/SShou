using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Web.Helper
{
    public class GuidToLong
    {
        /// <summary>
        /// 根据GUID获取19位的唯一数字序列
        /// </summary>
        public static long GuidToLongID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        public static string GuidToOrderId()
        {
            string orderId = "O" + GuidToLongID().ToString() + DateTime.Now.ToString("HHmmsss");
            return orderId;
        }

        public static string OrderId()
        {
            string orderId = "028" + DateTime.Now.ToString("yyyyMMddHHmmsss") + GuidToLongID().ToString().Substring(6, 2);
            return orderId;
        }
    }
}
