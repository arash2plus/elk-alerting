using Alerting.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alerting.Application.Interface
{
    public interface IUserQuery
    {
        IEnumerable<User> GetUserByapplicationId(int applicationId);
    }
}
