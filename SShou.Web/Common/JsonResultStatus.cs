using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.Web.Common
{
    public class JsonResultStatus
    {
        public int Code { get; set; }

        public string Msg { get; set; }

        public dynamic Result { get; set; }

        public string RedirectUrl { get; set; }
    }
}
