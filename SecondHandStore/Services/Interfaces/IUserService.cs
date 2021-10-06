using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(UserModel user);
        UserModel GetDetailsByUserName(string userName);
        void UpdateDetailsUser(UserModel newUser);
        bool IsUserNameExist(string userName);
        bool IsUserLogin(string userName, string password);
    }
}
