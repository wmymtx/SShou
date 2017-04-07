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
    public class PCOrderController : Controller
    {

        private readonly Orders.IOrderAppService orderAppService;
        private readonly SS_User.ISs_UserAppService userAppService;
        private readonly WeUser.IWeUserAppService _iUserAppService;
        public PCOrderController(Orders.IOrderAppService _orderAppService, SS_User.ISs_UserAppService _userAppService, WeUser.IWeUserAppService iUserAppService)
        {
            orderAppService = _orderAppService;
            userAppService = _userAppService;
            _iUserAppService = iUserAppService;
        }

        // GET: PCOrder
        public ActionResult Index()
        {
            
            //ViewBag.Orders = orderAppService.QueryOrders(0);
            return View();
        }

        public JsonResult GetOrderList(int limit, int offset, string departmentname, int status,string orderTime,int OrderType,string endTime)
        {
            
            var rst = new { rows = orderAppService.QueryOrderByStatus(status, offset, limit,orderTime,OrderType, endTime), total = orderAppService.QueryOrderCoutByStatus(status, orderTime,OrderType,endTime) };
           return Json(rst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllSSUser()
        {
            var allUser = userAppService.GetAllUser();
            return Json(allUser, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OrderAssign(Orders.Dto.UserAssignInputDto input)
        {
            var output = orderAppService.OrderAssign(input);
            if (output != null)
            {
                var userInfo = _iUserAppService.GetWeUserByUserId(output.UserId);
                OrderTemplateData orderData = new OrderTemplateData();
                orderData.first = new TemplateDataItem("亲，你的订单已指派人员");
                //orderData.keyword1 = new TemplateDataItem(string.Format("您的订单号为{0}的订单已指派", output.Id));
                orderData.keyword1 = new TemplateDataItem(string.Format("您的订单号为{0}的订单已指派", output.Id));
                orderData.keyword2 = new TemplateDataItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                orderData.remark = new TemplateDataItem("派单成功后，工作人员半小时内与你取得联系。");
                Common.WeiXinHelper.SendTemplateToWeUser(Common.CommonConst.AppID, userInfo.OpenId, output.Id, orderData);

                OrderTemplateData orderData1 = new OrderTemplateData();
                orderData1.first = new TemplateDataItem("亲，你收到新的订单啦！");
                orderData1.keyword1 = new TemplateDataItem(string.Format("订单号为{0}", output.Id));
                orderData1.keyword2 = new TemplateDataItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                orderData1.remark = new TemplateDataItem("请及时与下单用户取得联系");
                Common.WeiXinHelper.SendTemplateToWeUser(Common.CommonConst.AppID, input.OpenId, output.Id, orderData1);
            }
            //Senparc.Weixin.MP.AdvancedAPIs.CustomApi.SendText(Common.CommonConst.AppID, userInfo.OpenId, string.Format("您的订单号为{0}的订单已经指派收货人员请耐心等待", output.Id));
            return Json(output, JsonRequestBehavior.AllowGet);
        }
    }
}