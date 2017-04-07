using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.WeUser
{
    public interface IWeUserAppService : IApplicationService
    {
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        Dto.WeUserOutputDto CreateWeUser(Dto.WeUserInputDto userDto);

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        Dto.WeUserOutputDto GetWeUser(string openId);

        /// <summary>
        /// 根据用户Id获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Dto.WeUserOutputDto GetWeUserByUserId(int userId);

        Dto.WeUserOutputDto IsInit(int userId);

        Dto.WeUserOutputDto UpdateUser(Dto.WeUserInputDto user);

        /// <summary>
        /// 查询邀请码是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool IsHasInvitCode(int code);

        /// <summary>
        /// 查询推荐码是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool IsHasRecommendCode(int code);
    }
}
