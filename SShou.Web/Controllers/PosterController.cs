using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP;
using System.IO;
using System.Threading.Tasks;
using SShou.Web.Helper;

namespace SShou.Web.Controllers
{

    public class PosterController : SShouControllerBase
    {
        // GET: Poster
        [Common.Authorization]
        public ActionResult Index()
        {
            CreateQrCode();
            string userMsg = Common.UserHelper.Instance.getCookie();
            string[] userArray = userMsg.Split('|');
            string userStr = userArray[0] + "P|" + userArray[4];
            ViewBag.openId = string.Format("\\images\\full\\full-{0}.jpg", userArray[4]);
            ViewBag.img_path = userArray[4];
            return Redirect("Share?path=" + userArray[4]);
        }

        public ActionResult Share(string path)
        {
            ViewBag.openId = string.Format("\\images\\full\\full-{0}.jpg", path);
            return View();
        }

        public ActionResult CreateQrCode(int isRefresh = 0)
        {
            try
            {
                string userMsg = Common.UserHelper.Instance.getCookie();
                string[] userArray = userMsg.Split('|');
                string userStr = userArray[0] + "P|" + userArray[4];
                //string userStr = "5P|oCbECv1pwMNyAodYQtRJVvJf_Zsg";
                string fullPath = Server.MapPath("\\images\\full\\") + string.Format("full-{0}.jpg", userArray[4]);
                FileInfo fileInfo = new FileInfo(fullPath);
                if ((!fileInfo.Exists) || (isRefresh == 1))
                {

                    //var result = QrCodeApi.Create(Common.CommonConst.AppID, 100, 999999, QrCode_ActionName.QR_SCENE, "邀请");
                    var result = QrCodeApi.Create(Common.CommonConst.AppID, 100, 1000, QrCode_ActionName.QR_LIMIT_STR_SCENE, userStr);
                    var headFileName = Server.MapPath("\\images\\header\\") + string.Format("head-{0}.jpg", DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));
                    using (FileStream fsHeader = new FileStream(headFileName, FileMode.OpenOrCreate))
                    {
                        var user = Senparc.Weixin.MP.AdvancedAPIs.UserApi.Info(Common.CommonConst.AppID, userArray[4]);
                        Senparc.Weixin.HttpUtility.Get.Download(user.headimgurl, fsHeader);
                    }

                    var dirPath = Server.MapPath("\\images");
                    var fileName = Server.MapPath("\\images\\qrcode\\") + string.Format("qrcode-{0}.jpg", DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));
                    using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        QrCodeApi.ShowQrCode(result.ticket, fs);//下载二维码
                    }

                    // 模板路径
                    string sourcePath = dirPath + "\\template\\haibao.jpg";
                    // 二维码路径
                    string twoDimensionCode = fileName;
                    string headPath = headFileName;
                    fileInfo.Delete();

                    int seq = 0;
                    int.TryParse(userArray[0], out seq);

                    string reqNum = (seq + 2000).ToString();
                    Logger.Warn("seq:" + reqNum);
                    // 生成个人海报
                    //ImageHelper.GeneratePoster(sourcePath, twoDimensionCode, fullPath, headPath);
                    ImageHelper.GeneratePoster(sourcePath, twoDimensionCode, fullPath, headPath, reqNum);
                }
                return Content(fullPath);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
    }
}