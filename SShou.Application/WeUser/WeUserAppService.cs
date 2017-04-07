using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.WeUser.Dto;
using Abp.AutoMapper;

namespace SShou.WeUser
{
    public class WeUserAppService : IWeUserAppService
    {
        private readonly IRepository.IRegisterWeChatRepository regWeChatRepository;
        public WeUserAppService(IRepository.IRegisterWeChatRepository _regRepository)
        {
            this.regWeChatRepository = _regRepository;
        }

        public WeUserOutputDto CreateWeUser(WeUserInputDto userDto)
        {
            Entitys.WeUser user = new Entitys.WeUser();
            user.HeadImgUrl = userDto.HeadImgUrl;
            user.NickName = userDto.NickName;
            user.OpenId = userDto.OpenId;
            user.PhoneNo = userDto.PhoneNo;
            user.RegDate = DateTime.Now;
            user.Address = userDto.Address;
            var userRst = regWeChatRepository.CreateUser(user);
            return userRst.MapTo<Dto.WeUserOutputDto>() ?? null;
        }

        public WeUserOutputDto GetWeUser(string openId)
        {
            var user = regWeChatRepository.GetWeUser(openId);
            return user.MapTo<Dto.WeUserOutputDto>() ?? null;
        }

        public Dto.WeUserOutputDto GetWeUserByUserId(int userId)
        {
            var user = regWeChatRepository.GetWeUserByUserId(userId);
            return user.MapTo<Dto.WeUserOutputDto>() ?? null;
        }

        public Dto.WeUserOutputDto IsInit(int userId)
        {
            var user = regWeChatRepository.IsInit(userId);
            return user.MapTo<Dto.WeUserOutputDto>() ?? null;
        }

        public Dto.WeUserOutputDto UpdateUser(Dto.WeUserInputDto user)
        {
            var sourceUser = regWeChatRepository.GetWeUserByUserId(user.Id);
            sourceUser.IsInit = 0;
            sourceUser.NickName = user.NickName;
            sourceUser.Address = user.Address;
            sourceUser.PhoneNo = user.PhoneNo;
            sourceUser.Invit_Code = user.Invit_Code;
            sourceUser.Recommend_Code = user.Recommend_Code;
            var userInfo = regWeChatRepository.UpdateUser(sourceUser);
            return userInfo.MapTo<Dto.WeUserOutputDto>() ?? null;
        }

        public bool IsHasInvitCode(int code)
        {
            return regWeChatRepository.IsHasInvitCode(code);
        }

        public bool IsHasRecommendCode(int code)
        {
            return regWeChatRepository.IsHasRecommendCode(code);
        }

    }
}
