using Alerting.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alerting.Application.Interface
{
    public interface IApplicationQuery
    {
        IEnumerable<DomainModel.Models.Application> GetApplications();
    }
}
