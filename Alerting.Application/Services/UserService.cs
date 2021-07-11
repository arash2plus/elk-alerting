using Alerting.Application.Interface;
using Alerting.DomainModel.Interfaces;
using Alerting.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alerting.Application.Services
{
    public class UserService : IUserQuery, IUserCommand
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BusinessModel<User> AddUser(User user)
        {
           return _userRepository.AddUser(user);
        }

        public void DeletUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public IEnumerable<User> GetUserByapplicationId(int applicationId)
        {
            return _userRepository.GetUsersByApplicationId(applicationId);
        }
         
    }
}
