using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface IRegisterWeChatRepository
    {
        Entitys.WeUser CreateUser(Entitys.WeUser user);

        Entitys.WeUser GetWeUser(string openId);

        Entitys.WeUser GetWeUserByUserId(int userId);

        Entitys.WeUser IsInit(int userId);

        Entitys.WeUser UpdateUser(Entitys.WeUser user);

        /// <summary>
        /// 邀请码是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool IsHasInvitCode(int code);

        /// <summary>
        /// 推荐码是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool IsHasRecommendCode(int code);
    }
}
