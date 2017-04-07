using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.OrderComment.Dto;
using Abp.AutoMapper;
using Abp.Domain.Uow;

namespace SShou.OrderComment
{
    public class OrderCommentAppService : IOrderCommentAppService
    {
        private readonly IRepository.IOrderCommentRepository _orderCommentRepository;
        private readonly IRepository.IOrderRepository _orderRepository;
        public OrderCommentAppService(IRepository.IOrderCommentRepository orderCommentRepository, IRepository.IOrderRepository orderRepository)
        {
            this._orderCommentRepository = orderCommentRepository;
            this._orderRepository = orderRepository;
        }

        [UnitOfWork]
        void IOrderCommentAppService.AddComment(OrderCommentInput comment)
        {
            _orderCommentRepository.AddComment(comment.MapTo<Entitys.OrderComment>());
            var item = _orderRepository.QueryByOrderId(comment.F_OrderId);
            if (null != item)
            {
                item.Status = 3;
                _orderRepository.OrderAssign(item);
            }
        }

        OrderCommentOutput IOrderCommentAppService.GetComment(string orderId)
        {
            return _orderCommentRepository.GetComment(orderId).MapTo<Dto.OrderCommentOutput>();
        }

        void IOrderCommentAppService.UpdateComment(OrderCommentInput comment)
        {
            _orderCommentRepository.AddComment(comment.MapTo<Entitys.OrderComment>());
        }
    }
}
