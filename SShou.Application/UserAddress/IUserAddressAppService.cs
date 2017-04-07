using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.UserAddress
{
    public interface IUserAddressAppService : IApplicationService
    {
        void AddNewAddress(Dto.UserAddressInputDto inputDto);

        void UpdateAddress(Dto.UserAddressInputDto inputDto);

        void RemoveAddress(int addrId);

        void SetDefault(Dto.UserAddressInputDto inputDto);

        List<Dto.UserAddressOutputDto> GetAllAddress(int userId);

        Dto.UserAddressOutputDto GetAddress(int addrId);

        Dto.UserAddressOutputDto GetDefault(int userId);
    }
}
