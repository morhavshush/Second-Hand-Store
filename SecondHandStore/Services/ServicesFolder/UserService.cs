using Entities;
using LibraryData;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.ServicesFolder
{
    public class UserService : IUserService
    {
        private readonly LibraryContext _context;
        public UserService(LibraryContext context)
        {
            _context = context;
        }
        public void AddUser(UserModel user)
        {
            if (!IsUserNameExist(user.UserName))
                _context.Add(user);
            _context.SaveChanges();
        }

        public UserModel GetDetailsByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(user => user.UserName == userName);
        }

        public bool IsUserNameExist(string userName)
        {
            var item = _context.Users.FirstOrDefault(user => user.UserName == userName);
            return item != default;
        }

        public bool IsUserLogin(string userName, string password)
        {
            var item = _context.Users.FirstOrDefault(user => user.UserName == userName && user.Password==password);
            return item != default;
        }

        public void UpdateDetailsUser(UserModel newUser)
        {
            var oldUser = _context.Users.Find(newUser.Id);
            _context.Entry(oldUser).CurrentValues.SetValues(newUser);
            _context.SaveChanges();
        }
    }
}
