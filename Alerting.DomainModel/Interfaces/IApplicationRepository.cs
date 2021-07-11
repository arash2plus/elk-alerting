using Alerting.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alerting.DomainModel.Interfaces
{
    public interface IApplicationRepository
    {
        IEnumerable<Application> GetApplications();
        BusinessModel<Application> AddApplication(Application application);
        void DeleteApplication(int id);
    }
}
