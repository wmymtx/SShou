using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.OrderComment
{
    public interface IOrderCommentAppService : IApplicationService
    {
        void AddComment(Dto.OrderCommentInput comment);

        Dto.OrderCommentOutput GetComment(string orderId);

        void UpdateComment(Dto.OrderCommentInput comment);
    }
}
