using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.UserPoints.Dto
{
    public class UserPointsOutputDto
    {
        public  DateTime? AddTime { get; set; }

        /// <summary>
        /// 增加的积分
        /// </summary>
        public  int Score { get; set; }
    }
}
