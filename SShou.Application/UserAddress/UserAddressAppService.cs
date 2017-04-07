using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SShou.UserAddress.Dto;
using Abp.AutoMapper;

namespace SShou.UserAddress
{
    public class UserAddressAppService : IUserAddressAppService
    {
        private readonly IRepository.IUserAddressRepository _userAddressRepository;
        public UserAddressAppService(IRepository.IUserAddressRepository userAddressRepository)
        {
            this._userAddressRepository = userAddressRepository;
        }

        public void AddNewAddress(UserAddressInputDto inputDto)
        {
            _userAddressRepository.AddNewAddress(inputDto.MapTo<Entitys.UserAddress>());
        }

        public UserAddressOutputDto GetAddress(int addrId)
        {
            return _userAddressRepository.GetAddressByAddrId(addrId).MapTo<Dto.UserAddressOutputDto>();
        }

        public List<UserAddressOutputDto> GetAllAddress(int userId)
        {
            return _userAddressRepository.GetAllAddress(userId).MapTo<List<Dto.UserAddressOutputDto>>();
        }

        public void RemoveAddress(int addrId)
        {
            _userAddressRepository.DeleteAddres(addrId);
        }

        public void SetDefault(UserAddressInputDto inputDto)
        {
            _userAddressRepository.SetDefault(inputDto.MapTo<Entitys.UserAddress>());
        }

        public void UpdateAddress(UserAddressInputDto inputDto)
        {
            var source = _userAddressRepository.GetAddressByAddrId(inputDto.Id);
            source.Address = inputDto.Address;
            source.ContactName = inputDto.ContactName;
            source.PhoneNo = inputDto.PhoneNo;
            _userAddressRepository.UpdateAddress(source);
        }

        public Dto.UserAddressOutputDto GetDefault(int userId)
        {
            return _userAddressRepository.GetDefault(userId).MapTo<Dto.UserAddressOutputDto>();
        }
    }
}
