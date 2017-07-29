using Senparc.Weixin.Exceptions;
using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Helpers;
using SShou.Web.Common;
using SShou.Web.Helper;
using SShou.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SShou.Web.Controllers
{
    [Common.Authorization]
    public class OrderController : SShouControllerBase
    {
        private readonly Product.IProductAppService _prodAppService;
        private readonly Orders.IOrderAppService _orderRepository;
        private readonly UserAddress.IUserAddressAppService _userAddressService;
        private readonly OrderComment.IOrderCommentAppService _commentAppService;

        public string timestamp = string.Empty;
        public string nonceStr = string.Empty;
        public string signature = string.Empty;

        private readonly PointIntersect pointIntersect = new PointIntersect();

        // GET: Order

        public OrderController(Product.IProductAppService _IProdAppService, Orders.IOrderAppService _iOrderRepositorys, UserAddress.IUserAddressAppService userAddressService, OrderComment.IOrderCommentAppService commentAppService)
        {
            this._prodAppService = _IProdAppService;
            this._orderRepository = _iOrderRepositorys;
            this._userAddressService = userAddressService;
            this._commentAppService = commentAppService;
        }



        public ActionResult Index(string items, int orderType)
        {
            string ids = items;
            var lst = this._prodAppService.GetProductById(ids);
            ViewBag.OrderType = orderType;
            ViewBag.lst = lst;
            var address = _userAddressService.GetDefault(Common.UserHelper.Instance.getUserId());
            if (address != null)
            {
                ViewBag.Address = address.Address;
                ViewBag.Phone = address.PhoneNo;
                ViewBag.Name = address.ContactName;

                string ticket = string.Empty;
                timestamp = JSSDKHelper.GetTimestamp();
                nonceStr = JSSDKHelper.GetNoncestr();
                JSSDKHelper jssdkhelper = new JSSDKHelper();

                try
                {
                    ticket = JsApiTicketContainer.GetJsApiTicket(Common.CommonConst.AppID);
                    signature = JSSDKHelper.GetSignature(ticket, nonceStr, timestamp, Request.Url.AbsoluteUri.ToString());
                    ViewBag.timestamp = timestamp;
                    ViewBag.nonceStr = nonceStr;
                    ViewBag.AppId = Common.CommonConst.AppID;
                    ViewBag.signature = signature;
                }
                catch (ErrorJsonResultException ex)
                {
                    Logger.Error("errorcode:" + ex.JsonResult.errcode.ToString() + "   errmsg:" + ex.JsonResult.errmsg);
                }
            }


            return View();
        }

        [HttpPost]
        public JsonResult CreateOrder(Orders.Dto.OrderInputDtos json)
        {
            Logger.Debug("当前json" + json.ToString());
            var obj = json;
            var item = json.Order;
            string address = json.Address;
            string remark = json.Remark;
            string time = json.Time;

            JsonResultStatus rstJson = new JsonResultStatus();
            var lng_lat = _orderRepository.getMapRange();
            if (lng_lat.Lat!=null&& lng_lat.Lat.Count>=1&& !pointIntersect.IsPointInPolygon(json.Lat, json.Lng, lng_lat.Lat, lng_lat.Lng))
            {
                rstJson.Code = 401;
                rstJson.Msg = "该区域未开通";

                return Json(rstJson);
            }

            //Logger.Debug("当前用户Cookie" + Common.UserHelper.Instance.getCookie());
            Logger.Debug("当前用户Id" + Common.UserHelper.Instance.getUserId().ToString());
            List<Orders.Dto.OrderItemsInputDto> items = new List<Orders.Dto.OrderItemsInputDto>();
            string orderId = GuidToLong.OrderId();
            if (json.Order != null)
            {
                for (int index = 0; index <= json.Order.Count - 1; index++)
                {
                    items.Add(new Orders.Dto.OrderItemsInputDto() { F_OrderId = orderId, ProductId = json.Order[index].Id, ProductName = json.Order[index].Prod_Name, ProductNum = int.Parse(json.Order[index].Value), Unit = json.Order[index].Unit });
                }
            }
            Orders.Dto.OrderInputDto orders = new Orders.Dto.OrderInputDto();
            orders.Id = orderId;
            orders.OrderTime = DateTime.Now;
            orders.RecTime = json.Time;
            Logger.Debug("当前用户Id" + Common.UserHelper.Instance.getUserId().ToString());
            orders.UserId = Common.UserHelper.Instance.getUserId().ToString();

            orders.Address = json.Address;
            orders.OrderType = json.OrderType;
            orders.RecPhone = json.RecPhone;
            orders.RecUserName = json.RecUserName;
          
            if (_orderRepository.CreateOrder(orders, items))
            {
                var addressItem = _userAddressService.GetDefault(Common.UserHelper.Instance.getUserId());
                if (addressItem == null)
                {
                    UserAddress.Dto.UserAddressInputDto input = new UserAddress.Dto.UserAddressInputDto();
                    input.Address = orders.Address;
                    input.ContactName = orders.RecUserName;
                    input.PhoneNo = orders.RecPhone;
                    input.IsDefault = 1;
                    input.UserId = Common.UserHelper.Instance.getUserId();
                    input.Status = 1;
                    _userAddressService.AddNewAddress(input);
                }
                string[] weixin = Common.UserHelper.Instance.getAccessToken();
                try
                {
                    if (weixin == null)
                    {
                        Logger.Debug("订单下发成功后无法微信推送");
                    }
                    else
                    {
                        OrderTemplateData orderData = new OrderTemplateData();
                        orderData.first = new TemplateDataItem("亲，你的订单已提交成功");
                        orderData.keyword1 = new TemplateDataItem(DateTime.Now.ToString("yyyy-MM-dd"));
                        orderData.keyword2 = new TemplateDataItem(string.Join("、", items.Select(o => o.ProductName)));
                        orderData.keyword3 = new TemplateDataItem(orders.Id);
                        orderData.remark = new TemplateDataItem("感谢你的支持，派单成功后，工作人员半小时内与你取得联系。");
                        Common.WeiXinHelper.SendMsgToWeUser(Common.CommonConst.AppID, weixin[4], orders.Id, orderData);
                        //Senparc.Weixin.MP.AdvancedAPIs.CustomApi.SendText(Common.CommonConst.AppID, weixin[4], string.Format("下单成功！您的订单号为{0}", orders.Id));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Debug("订单下发成功后微信推送" + ex.Message + ex.StackTrace);
                }
                rstJson.Code = 200;
                rstJson.Msg = "下单成功！";
            }
            else
            {
                rstJson.Code = 401;
                rstJson.Msg = "下单失败！";

            }
            return Json(rstJson);
        }

        public ViewResult OrderList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetOrderList(RequestPrams param)
        {

            var outResult = this._orderRepository.QueryOrders(Common.UserHelper.Instance.getUserId().ToString(), param.PageIndex, param.PageSize);
            //return Json(outResult, JsonRequestBehavior.AllowGet);
            return new ToJsonResult
            {
                Data = outResult,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                FormateStr = "yyyy-MM-dd HH:mm:ss"
            };
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetOrderDetail(string id)
        {
            var outResult = this._orderRepository.QueryOrderItems(id);
            //return Json(outResult, JsonRequestBehavior.AllowGet);
            var order = this._orderRepository.QueryByOrderId(id);
            var orderInfo = new { Order = order, OrderItems = outResult };
            var rst = new Common.JsonResultStatus() { Code = 200, Msg = "获取成功", Result = orderInfo };
            return Json(rst, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult CancelOrder(string id)
        {
            var outResult = this._orderRepository.CancelOrder(id);
            //return Json(outResult, JsonRequestBehavior.AllowGet);

            var rst = new Common.JsonResultStatus() { Code = 200, Msg = "获取成功", Result = outResult };
            return Json(rst, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CanOrder(string id)
        {
            var outResult = this._orderRepository.CanOrder(id);
            //return Json(outResult, JsonRequestBehavior.AllowGet);

            var rst = new Common.JsonResultStatus() { Code = 200, Msg = "获取成功", Result = outResult };
            return Json(rst, JsonRequestBehavior.AllowGet);
        }

        public ActionResult History()
        {
            return View();
        }

        public JsonResult GetHistory(RequestPrams param)
        {
            var outResult = this._orderRepository.QueryOrders(Common.UserHelper.Instance.getUserId().ToString(), param.PageIndex, param.PageSize);
            if (outResult != null)
            {
                for (int index = 0; index <= outResult.Count - 1; index++)
                {
                    var item = _orderRepository.QueryOrderItems(outResult[index].Id);
                    var itemAll = item.Select(o => { return o.ProductNum + " x " + o.ProductName; });
                    outResult[index].ItemAll = string.Join("、", itemAll.ToArray());
                }
            }
            //return Json(outResult, JsonRequestBehavior.AllowGet);
            return new ToJsonResult
            {
                Data = outResult,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                FormateStr = "yyyy-MM-dd HH:mm:ss"
            };
        }

        public ActionResult Detail(string orderId)
        {
            //var outResult = this._orderRepository.QueryOrderItems(orderId);
            ////return Json(outResult, JsonRequestBehavior.AllowGet);
            //var order = this._orderRepository.QueryByOrderId(orderId);
            //var orderInfo = new { Order = order, OrderItems = outResult };

            //ViewBag.OrderInfo = orderInfo;
            ViewBag.orderId = orderId;
            return View();
        }

        public JsonResult OrderComment(OrderComment.Dto.OrderCommentInput input)
        {
            this._commentAppService.AddComment(input);
            return Json("");
        }
    }
}