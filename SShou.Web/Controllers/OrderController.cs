using SShou.Web.Common;
using SShou.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SShou.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly Product.IProductAppService _prodAppService;
        private readonly Orders.IOrderAppService _orderRepository;
        // GET: Order

        public OrderController(Product.IProductAppService _IProdAppService, Orders.IOrderAppService _iOrderRepositorys)
        {
            this._prodAppService = _IProdAppService;
            this._orderRepository = _iOrderRepositorys;
        }

        public ActionResult Index(string items)
        {
            string ids = items;
            var lst = this._prodAppService.GetProductById(ids);
            ViewBag.lst = lst;
            return View();
        }

        [HttpPost]
        public JsonResult CreateOrder(Orders.Dto.OrderInputDtos json)
        {
            var obj = json;
            var item = json.Order;
            string address = json.Address;
            string remark = json.Remark;
            string time = json.Time;
            List<Orders.Dto.OrderItemsInputDto> items = new List<Orders.Dto.OrderItemsInputDto>();
            string orderId = GuidToLong.GuidToOrderId();
            if (json.Order != null)
            {
                for (int index = 0; index <= json.Order.Count - 1; index++)
                {
                    items.Add(new Orders.Dto.OrderItemsInputDto() { F_OrderId = orderId, ProductId = json.Order[index].Id, ProductName = json.Order[index].Prod_Name, ProductNum = int.Parse(json.Order[index].Value) });
                }
            }
            Orders.Dto.OrderInputDto orders = new Orders.Dto.OrderInputDto();
            orders.Id = orderId;
            orders.OrderTime = DateTime.Now;
            orders.RecTime = json.Time;
            orders.UserId = "";
            orders.Address = json.Address;
            JsonResultStatus rstJson = new JsonResultStatus();
            if (_orderRepository.CreateOrder(orders, items))
            {
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
    }
}