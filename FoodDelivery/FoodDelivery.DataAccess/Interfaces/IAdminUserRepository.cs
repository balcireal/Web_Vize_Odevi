﻿using FoodDelivery.Model.Entities;
using Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.DataAccess.Interfaces
{
    public interface IAdminUserRepository : IBaseRepository<AdminUser>
    {
        Task<AdminUser> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList);
    }
}
