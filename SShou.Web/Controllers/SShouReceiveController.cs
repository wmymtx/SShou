using SShou.UserRecommend;
using SShou.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SShou.Web.Controllers
{
    public class SShouReceiveController : Controller
    {
        public static readonly string Token = Common.CommonConst.Token;

        readonly IUserRecommendApplicationService _appService;
        public SShouReceiveController(IUserRecommendApplicationService appService)
        {
            this._appService = appService;
        }
        // GET: SShouReceive
        public ActionResult Index()
        {

            return View();
        }

        public void JoinToken()
        {
            WriteContent("OK");
        }

        public ActionResult Receive()
        {
            string signature = Request.QueryString["signature"];
            string timestamp = Request.QueryString["timestamp"];
            string nonce = Request.QueryString["nonce"];
            string echostr = Request.QueryString["echostr"];
            string token = Token;
            if (CheckSignature(signature, timestamp, nonce, Token))
            {
                //return Content(echostr);
                var maxRecordCount = 10;
                ////自定义MessageHandler，对微信请求的详细判断操作都在这里面。
                var messageHandler = new CustomMessageHandler(Request.InputStream, maxRecordCount);
                messageHandler.AppService = this._appService;
                messageHandler.OmitRepeatedMessage = true;
                messageHandler.Execute();
                //WriteContent(messageHandler.ResponseDocument.ToString());
                return Content(messageHandler.ResponseDocument.ToString()); //返回随机字符串则表示验证通过
            }
            else
            {
                return Content("failed:" + signature + "," + Senparc.Weixin.MP.CheckSignature.GetSignature(timestamp, nonce, Token) + "。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
            }
            //设置每个人上下文消息储存的最大数量，防止内存占用过多，如果该参数小于等于0，则不限制

            //WriteContent(token);
        }

        private void WriteContent(string str)
        {
            Response.Output.Write(str);
        }

        public static bool CheckSignature(string signature, string timestamp, string nonce, string token)
        {
            return signature == GetSignature(timestamp, nonce, token);
        }

        public static string GetSignature(string timestamp, string nonce, string token)
        {
            string[] arr = new[] { token, timestamp, nonce }.OrderBy(z => z).ToArray();
            string arrString = string.Join("", arr);
            System.Security.Cryptography.SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
            byte[] sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(arrString));
            StringBuilder enText = new StringBuilder();
            foreach (var b in sha1Arr)
            {
                enText.AppendFormat("{0:x2}", b);
            }
            return enText.ToString();
        }

        /// <summary>
        /// 验证企业号签名
        /// </summary>
        /// <param name="token">企业号配置的Token</param>
        /// <param name="signature">签名内容</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="nonce">nonce参数</param>
        /// <param name="corpId">企业号ID标识</param>
        /// <param name="encodingAESKey">加密键</param>
        /// <param name="echostr">内容字符串</param>
        /// <param name="retEchostr">返回的字符串</param>
        /// <returns></returns>
        public bool CheckSignature(string token, string signature, string timestamp, string nonce, string corpId, string encodingAESKey, string echostr, ref string retEchostr)
        {
            WXBizMsgCrypt wxcpt = new WXBizMsgCrypt(token, encodingAESKey, corpId);
            int result = wxcpt.VerifyURL(signature, timestamp, nonce, echostr, ref retEchostr);
            if (result != 0)
            {
                //LogTextHelper.Error("ERR: VerifyURL fail, ret: " + result);
                return false;
            }

            return true;

            //ret==0表示验证成功，retEchostr参数表示明文，用户需要将retEchostr作为get请求的返回参数，返回给企业号。
            // HttpUtils.SetResponse(retEchostr);
        }
    }
}