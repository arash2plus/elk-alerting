using Alerting.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alerting.Application.Interface
{
    public interface IApplicationCommand
    {
        BusinessModel<DomainModel.Models.Application> AddApplication(DomainModel.Models.Application application);
        void DeleteApplication(int id);
    }
}
