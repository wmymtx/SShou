using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.UserPoints.Dto
{
    public class UserPointsInputDto
    {
        public int UserId;

        public int Score;

        public string Ip { get; set; }
    }
}
