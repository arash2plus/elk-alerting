using Alerting.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alerting.Application.Interface
{
    public interface IUserCommand
    {
        BusinessModel<User> AddUser(User user);
        void DeletUser(int id);
    }
}
