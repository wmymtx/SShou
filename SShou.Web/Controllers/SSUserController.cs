using Abp.Web.Mvc.Controllers;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using SShou.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SShou.Web.Controllers
{
    [Authorize]
    public class SSUserController : Controller
    {

        private readonly SS_User.ISs_UserAppService userAppService;
        public SSUserController(Orders.IOrderAppService _orderAppService, SS_User.ISs_UserAppService _userAppService)
        {
            userAppService = _userAppService;
        }
        // GET: SSUser
        public ActionResult Index()
        {
            //ViewBag.User = userAppService.GetAllUser();
            return View();
        }

        public JsonResult GetOrderList(int limit, int offset, string departmentname, int status, string orderTime)
        {

            var rst = new { rows = userAppService.GetUserByPage(offset, limit, status), total = userAppService.GetTotal(status) };
            return Json(rst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetail(int userId)
        {
            var item = userAppService.GetUserDetail(userId);
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditStatus(int userId, int status)
        {
            Common.JsonResultStatus json = new Common.JsonResultStatus();
            json.Code = 200;
            if (userAppService.UpdateStatus(userId, status) > 0)
            {
                var item = userAppService.GetUserDetail(userId);
                if (item != null)
                {
                    OrderTemplateData orderData1 = new OrderTemplateData();
                    orderData1.first = new TemplateDataItem("尊敬的回收用户，你好！你提交的申请已受理");
                    orderData1.keyword1 = new TemplateDataItem(item.JoinTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    orderData1.keyword2 = new TemplateDataItem("加入收收");
                   

                    if (status == 1)
                    {
                        orderData1.keyword3 = new TemplateDataItem("审核已通过");
                    }

                    else
                    {
                        orderData1.keyword3 = new TemplateDataItem("审核未通过");
                        //Common.WeiXinHelper.SendSimpleMsg(Common.CommonConst.AppID, item.OpenId, "您登记加入收收的信息未通过审核，请到重新登记加盟信息");
                    }
                    orderData1.remark = new TemplateDataItem("感谢你对收收的支持！");
                    Common.WeiXinHelper.SendTemplateToSSWeUser(Common.CommonConst.AppID, item.OpenId, orderData1);
                }
                json.Msg = "操作成功";
            }
            else
            {
                json.Msg = "操作失败";
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}