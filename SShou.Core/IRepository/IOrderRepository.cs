﻿using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SShou.IRepository
{
    public interface IOrderRepository
    {
        void CreateOrder(Entitys.Orders order);
    }
}
