using Alerting.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alerting.DomainModel.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsersByApplicationId(int applicationId);
        IEnumerable<User> GetUsersByApplicationName(string applicationName);
        BusinessModel<User> AddUser(User user);
        void DeleteUser(int id);
    }
}
