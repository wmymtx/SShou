using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface IUserAddressRepository
    {
        /// <summary>
        /// 添加新地址
        /// </summary>
        /// <param name="address"></param>
        void AddNewAddress(Entitys.UserAddress address);

        /// <summary>
        /// 更新地址
        /// </summary>
        /// <param name="address"></param>
        void UpdateAddress(Entitys.UserAddress address);

        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="address"></param>
        void DeleteAddres(int addrId);

        /// <summary>
        /// 获取用户所有地址
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<Entitys.UserAddress> GetAllAddress(int userId);

        /// <summary>
        /// 获取地址详情
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        Entitys.UserAddress GetAddressByAddrId(int addressId);

        void SetDefault(Entitys.UserAddress address);

        Entitys.UserAddress GetDefault(int userId);
    }
}
