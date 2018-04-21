﻿using System.Collections.Generic;
using DataManagement.Entities;

namespace DataManagement.Repository.Interfaces
{
    public interface IUserRepository
    {
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int userId);
        IList<User> GetAllUser();
        User GetUserById(int userId);
    }
}