using Alerting.DomainModel.Interfaces;
using Alerting.DomainModel.Models;
using Alerting.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alerting.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AlertingContext _context;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ILogger<UserRepository> logger, AlertingContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<User> GetUsersByApplicationId(int ApplicationId)
        {
            var userList = new List<User>();
            try
            {
                userList = _context.User.Include(x => x.application).Where(x => x.application.Id == ApplicationId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetUsersByApplicationId Faild", ex.Message);
            }
            return userList;
        }
        public IEnumerable<User> GetUsersByApplicationName(string ApplicationName)
        {
            var userList = new List<User>();
            try
            {
                userList = _context.User.Include(x => x.application).Where(x => x.application.ApplicationName == ApplicationName).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetUsersByApplicationName Faild", ex.Message);
            }
            return userList;
        }

        public BusinessModel<User> AddUser(User userModel)
        {
            var response = new BusinessModel<User>();
            try
            {
                var user = _context.User.Where(x => x.Email == userModel.Email && x.application==userModel.application).FirstOrDefault();
                if (user != null)
                {
                    response.Message = "کاربر تکراری می باشد.";
                    response.StatusCode = 500;
                    return response;
                }
                _context.User.Add(userModel);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Add User Faild", ex.Message);
            }
            return response;
        }

        public void DeleteUser(int id)
        {
            try
            {
                var user = _context.User.Where(x => x.Id == id).FirstOrDefault();
                if (user != null)
                {
                    _context.User.Remove(user);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Delete User Faild", ex.Message);
            }
        }
    }
}

