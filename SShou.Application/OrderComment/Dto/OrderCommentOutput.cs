using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.OrderComment.Dto
{
    [AutoMap(typeof(Entitys.OrderComment))]
    public class OrderCommentOutput
    {
        public int Id { get; set; }

        public string F_OrderId { get; set; }

        public string Comment { get; set; }

        public decimal Score { get; set; }

        public string ReMark { get; set; }
    }
}
