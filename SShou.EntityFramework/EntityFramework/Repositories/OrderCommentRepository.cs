using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.Entitys;
using SShou.IRepository;
using Abp.EntityFramework;

namespace SShou.EntityFramework.Repositories
{
    public class OrderCommentRepository : SShouRepositoryBase<Entitys.OrderComment>, IRepository.IOrderCommentRepository
    {
        public OrderCommentRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }
        void IOrderCommentRepository.AddComment(OrderComment comment)
        {
            Insert(comment);
        }

        OrderComment IOrderCommentRepository.GetComment(string orderId)
        {
            var query = GetAll();
            var comment = query.Where(o => o.F_OrderId == orderId).FirstOrDefault();
            return comment;
        }

        void IOrderCommentRepository.UpdateComment(OrderComment comment)
        {
            var query = GetAll();
            var Lcomment = query.Where(o => o.Id == comment.Id).FirstOrDefault();
            Lcomment.ReMark = comment.ReMark;
            Lcomment.Score = comment.Score;
            Lcomment.Comment = comment.Comment;
            Update(Lcomment);
        }
    }
}
