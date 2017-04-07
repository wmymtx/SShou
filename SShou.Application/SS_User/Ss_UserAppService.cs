using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.SS_User.Dto;
using Abp.AutoMapper;

namespace SShou.SS_User
{
    public class Ss_UserAppService : ISs_UserAppService
    {
        private readonly IRepository.ISsUserRepository _ssuserRespository;

        public Ss_UserAppService(IRepository.ISsUserRepository ssuserRespository)
        {
            _ssuserRespository = ssuserRespository;
        }

        public List<SS_UserOutput> GetAllUser()
        {
            return _ssuserRespository.GetAllUser().MapTo<List<Dto.SS_UserOutput>>();
        }

        public List<SS_UserOutput> GetUserByPage(int pageIdex, int pageSize, int status)
        {
            return _ssuserRespository.GetUserByPage(pageIdex, pageSize,status).MapTo<List<Dto.SS_UserOutput>>();
        }

        public int CreateUser(Dto.SS_UserInputDto input)
        {
           return _ssuserRespository.CreateSsUser(input.MapTo<Entitys.SS_User>());
        }
        

        public int GetTotal(int status)
        {
            return _ssuserRespository.GetTotal(status);
        }

        public SS_UserDetailOutputDto GetUserDetail(int userId)
        {
            return _ssuserRespository.GetUserDetail(userId).MapTo<Dto.SS_UserDetailOutputDto>();
        }

        public int UpdateStatus(int userId, int status)
        {
            return _ssuserRespository.UpdateStatus(userId, status);
        }
    }
}
