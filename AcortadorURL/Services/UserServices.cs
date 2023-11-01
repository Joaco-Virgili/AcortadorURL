﻿using AcortadorURL.Data;
using AcortadorURL.Entities;
using AcortadorURL.Models;
using Microsoft.EntityFrameworkCore;

namespace AcortadorURL.Services
{
    public interface IUserService
    {
        User? ValidateUser(AuthRequestBody authRequestBody);
        void Create(UserForCreation user);
    }

    public class UserServices : IUserService
    {
        private readonly UrlContext _urlContext;
        public UserServices(UrlContext urlContext)
        {
            _urlContext = urlContext;
        }
        public void Create(UserForCreation user)
        {
            User newUser = new User()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
            };
            _urlContext.Add(newUser);
            _urlContext.SaveChanges();
        }

        public User? ValidateUser(AuthRequestBody authRequestBody)
        {
            return _urlContext.Users.FirstOrDefault(p => p.Email == authRequestBody.Email && p.Password == authRequestBody.Password);
        }

    }
}
