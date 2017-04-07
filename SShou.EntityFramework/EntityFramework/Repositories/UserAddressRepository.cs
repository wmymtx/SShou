using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.EntityFramework.Repositories
{
    public class UserAddressRepository : SShouRepositoryBase<Entitys.UserAddress>, IRepository.IUserAddressRepository
    {
        public UserAddressRepository(IDbContextProvider<SShouDbContext> dbContextProvider) : base(dbContextProvider) { }
        /// <summary>
        /// 添加新地址
        /// </summary>
        /// <param name="address"></param>
        public void AddNewAddress(Entitys.UserAddress address)
        {
            Insert(address);
        }


        /// <summary>
        /// 更新地址
        /// </summary>
        /// <param name="address"></param>
        public void UpdateAddress(Entitys.UserAddress address)
        {
            Update(address);
        }

        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="address"></param>
        public void DeleteAddres(int addrId)
        {
            Delete(addrId);
        }

        /// <summary>
        /// 获取用户所有地址
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Entitys.UserAddress> GetAllAddress(int userId)
        {
            var query = GetAll();
            return query.Where(o => o.UserId == userId).ToList();
        }

        /// <summary>
        /// 获取地址详情
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public Entitys.UserAddress GetAddressByAddrId(int addressId)
        {
            return Get(addressId);
        }

        public void SetDefault(Entitys.UserAddress address)
        {
            var query = GetAll();
            var sourceDefault = query.Where(o => o.UserId == address.UserId && o.IsDefault == 1).FirstOrDefault();
            if (sourceDefault != null)
            {
                sourceDefault.IsDefault = 0;
                Update(sourceDefault);
            }
            var setDefault = Get(address.Id);
            setDefault.IsDefault = 1;
            Update(setDefault);
        }

        public Entitys.UserAddress GetDefault(int userId)
        {
            var query = GetAll();
            var addressDefault = query.Where(o => o.UserId == userId && o.IsDefault == 1).FirstOrDefault();
            return addressDefault;
        }


    }
}
